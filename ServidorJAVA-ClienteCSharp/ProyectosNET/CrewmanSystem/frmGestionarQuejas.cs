﻿using System;
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
	public partial class frmGestionarQuejas : Form
	{
		public static QuejaWS.QuejaWSClient daoQueja;
		private ReporteWS.ReporteWSClient daoReporte;
		public static DataGridView dgv;
		public static QuejaWS.queja quejaSeleccionada;
		public QuejaWS.queja[] misQuejas;

		public frmGestionarQuejas()
		{
			daoQueja = new QuejaWS.QuejaWSClient();
			daoReporte = new ReporteWS.ReporteWSClient();
			InitializeComponent();
			dgv = dgvQuejas;

			if (Program.empleado.cargo.idCargo == 1)
			{
				panel1.Visible = false;
			}
			
			dgvQuejas.AutoGenerateColumns = false;

			if (Program.empleado.cargo.nombre == "VENDEDOR")
			{
				dgvQuejas.Columns["NOMBRE"].Visible = false;
				dgvQuejas.Columns["APELLIDO_PATERNO"].Visible = false;
				dgvQuejas.Columns["APELLIDO_MATERNO"].Visible = false;
			}

			recargarDGV();

			#region colores de seleccion
			dgvQuejas.ColumnHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
			dgvQuejas.ColumnHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);

			dgvQuejas.RowHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
			dgvQuejas.RowHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);

			dgvQuejas.RowsDefaultCellStyle.SelectionBackColor = Program.colorR;
			dgvQuejas.RowsDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);
			#endregion
		}

		private void btnGenerar_Click(object sender, EventArgs e)
		{
			if (sfdReporte.ShowDialog() == DialogResult.OK)
			{
				try
				{
					string nombre = Program.empleado.apellidoPaterno + " " + Program.empleado.apellidoMaterno + ", " + Program.empleado.nombre;
					byte[] arreglo = daoReporte.generarReporteQuejas(Program.empleado.idEmpleado, nombre);
					File.WriteAllBytes(sfdReporte.FileName, arreglo);
					MessageBox.Show("El reporte fue generado con exito", "Mensaje de confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception)
				{
					MessageBox.Show("No se pudo generar el reporte", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
        private void dgvQuejas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			try
			{
				QuejaWS.queja queja = dgvQuejas.Rows[e.RowIndex].DataBoundItem
				as QuejaWS.queja;

				dgvQuejas.Rows[e.RowIndex].Cells["ID_PEDIDO"].Value = queja.pedido.idPedido;
				dgvQuejas.Rows[e.RowIndex].Cells["RUC"].Value = queja.pedido.cliente.ruc;
				dgvQuejas.Rows[e.RowIndex].Cells["RAZON_SOCIAL"].Value = queja.pedido.cliente.razonSocial;
				dgvQuejas.Rows[e.RowIndex].Cells["GRUPO"].Value = queja.pedido.cliente.grupo;
				dgvQuejas.Rows[e.RowIndex].Cells["TIPO_CLIENTE"].Value = queja.pedido.cliente.tipoEmpresa;
				dgvQuejas.Rows[e.RowIndex].Cells["NOMBRE"].Value = queja.pedido.empleado.nombre;
				dgvQuejas.Rows[e.RowIndex].Cells["APELLIDO_PATERNO"].Value = queja.pedido.empleado.apellidoPaterno;
				dgvQuejas.Rows[e.RowIndex].Cells["APELLIDO_MATERNO"].Value = queja.pedido.empleado.apellidoMaterno;
			}
			catch (Exception) { }
		}
		public static void eliminar()
		{
			quejaSeleccionada = (QuejaWS.queja)dgv.CurrentRow.DataBoundItem;
			daoQueja.eliminarQueja(quejaSeleccionada.idQueja);
		}
		private void dgvQuejas_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvQuejas.SelectedCells.Count != 1 && dgvQuejas.SelectedCells.Count != 0)
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
			misQuejas = daoQueja.listarQuejas(Program.empleado.idEmpleado);
			if (misQuejas != null)
			{
				dgvQuejas.DataSource = new BindingList<QuejaWS.queja>(misQuejas.ToArray());
				lblNotFound.Visible = false;
			}
			else
			{
				dgvQuejas.DataSource = new BindingList<QuejaWS.queja>();
				lblNotFound.Visible = true;
			}
		}
	}
}
