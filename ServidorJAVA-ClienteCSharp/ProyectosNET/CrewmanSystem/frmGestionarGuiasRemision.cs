using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace CrewmanSystem
{
	public partial class frmGestionarGuiasRemision : Form
	{
		private GuiaRemisionWS.GuiaRemisionWSClient daoGuiaRemision;
		public static GuiaRemisionWS.guiaRemision guiaRemisionSeleccionado;
		public static DataGridView dgv;
		private GuiaRemisionWS.guiaRemision[] misGuias;
		public frmGestionarGuiasRemision()
		{
			daoGuiaRemision = new GuiaRemisionWS.GuiaRemisionWSClient();
			InitializeComponent();
			dgv = dgvGuiasDeRemision;
			dgvGuiasDeRemision.AutoGenerateColumns = false;
			recargarDGV();

			#region colores de seleccion
			dgvGuiasDeRemision.ColumnHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
			dgvGuiasDeRemision.ColumnHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);

			dgvGuiasDeRemision.RowHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
			dgvGuiasDeRemision.RowHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);

			dgvGuiasDeRemision.RowsDefaultCellStyle.SelectionBackColor = Program.colorR;
			dgvGuiasDeRemision.RowsDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);
			#endregion
		}

        private void dgvGuiasDeRemision_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
				GuiaRemisionWS.guiaRemision guiaRemision = dgvGuiasDeRemision.Rows[e.RowIndex].DataBoundItem
								as GuiaRemisionWS.guiaRemision;

				dgvGuiasDeRemision.Rows[e.RowIndex].Cells["ID_PEDIDO"].Value = guiaRemision.pedido.idPedido;
				dgvGuiasDeRemision.Rows[e.RowIndex].Cells["RUC"].Value = guiaRemision.pedido.cliente.ruc;
				dgvGuiasDeRemision.Rows[e.RowIndex].Cells["RAZON_SOCIAL"].Value = guiaRemision.pedido.cliente.razonSocial;
				dgvGuiasDeRemision.Rows[e.RowIndex].Cells["GRUPO"].Value = guiaRemision.pedido.cliente.grupo;
				dgvGuiasDeRemision.Rows[e.RowIndex].Cells["TIPO_CLIENTE"].Value = guiaRemision.pedido.cliente.tipoEmpresa;
				dgvGuiasDeRemision.Rows[e.RowIndex].Cells["NOMBRE"].Value = guiaRemision.pedido.empleado.nombre;
				dgvGuiasDeRemision.Rows[e.RowIndex].Cells["APELLIDO_PATERNO"].Value = guiaRemision.pedido.empleado.apellidoPaterno;
				dgvGuiasDeRemision.Rows[e.RowIndex].Cells["APELLIDO_MATERNO"].Value = guiaRemision.pedido.empleado.apellidoMaterno;
			}
            catch (Exception){ }
		}
		private void dgvGuiasDeRemision_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvGuiasDeRemision.SelectedCells.Count != 1 && dgvGuiasDeRemision.SelectedCells.Count != 0)
			{
				frmVentanaPrincipal.act.Enabled = true;
				frmVentanaPrincipal.elim.Enabled = true;
				return;
			}
			else
			{
				frmVentanaPrincipal.act.Enabled = false;
				frmVentanaPrincipal.elim.Enabled = false;
			}
		}
        public void recargarDGV()
		{
			misGuias =
				daoGuiaRemision.listarGuiaRemisions(Program.empleado.idEmpleado, "", "", DateTime.Today.AddMonths(-3),
				DateTime.Today.AddMonths(3), DateTime.Today.AddMonths(-3), DateTime.Today.AddMonths(3));
			if (misGuias == null)
			{
				dgvGuiasDeRemision.DataSource = new BindingList<GuiaRemisionWS.guiaRemision>();
				lblNotFound.Visible = true;
			}
			else
			{
				dgvGuiasDeRemision.DataSource = new BindingList<GuiaRemisionWS.guiaRemision>(misGuias.ToList());
				lblNotFound.Visible = false;
			}

			if (Program.empleado.cargo.nombre == "VENDEDOR")
			{
				dgvGuiasDeRemision.Columns["NOMBRE"].Visible = false;
				dgvGuiasDeRemision.Columns["APELLIDO_PATERNO"].Visible = false;
				dgvGuiasDeRemision.Columns["APELLIDO_MATERNO"].Visible = false;
			}
		}

        private void dgvGuiasDeRemision_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
			if (e.ColumnIndex == 0)
			{
				if (sfdGuia.ShowDialog() == DialogResult.OK)
				{
					try
					{
						ReporteWS.ReporteWSClient daoReporte = new ReporteWS.ReporteWSClient();
						string nombre = Program.empleado.apellidoPaterno + " " + Program.empleado.apellidoMaterno + ", " + Program.empleado.nombre;
						byte[] arreglo = daoReporte.generarReportePedidoFinal(nombre, ((GuiaRemisionWS.guiaRemision)dgvGuiasDeRemision.CurrentRow.DataBoundItem).pedido.idPedido);
						File.WriteAllBytes(sfdGuia.FileName, arreglo);
						MessageBox.Show("El reporte fue generado con exito", "Mensaje de confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch (Exception)
					{
						MessageBox.Show("No se pudo generar el reporte", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}

			}
		}
    }
}
