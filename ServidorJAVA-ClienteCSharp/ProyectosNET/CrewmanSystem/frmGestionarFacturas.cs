﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrewmanSystem
{
	public partial class frmGestionarFacturas : Form
	{
		public static FacturaWS.FacturaWSClient daoFactura;
		public static FacturaWS.factura facturaSeleccionada;
		public static DataGridView dgv;

		public frmGestionarFacturas()
		{
			daoFactura = new FacturaWS.FacturaWSClient();
			InitializeComponent();
			dgv = dgvFacturas;
			dgvFacturas.AutoGenerateColumns = false;
			FacturaWS.factura[] misFacturas = daoFactura.listarFacturas(Program.empleado.idEmpleado,"","",
																		DateTime.MinValue,DateTime.MaxValue,
																		DateTime.MinValue,DateTime.MaxValue,2,2);
			if (misFacturas != null)
				dgvFacturas.DataSource = new BindingList<FacturaWS.factura>(misFacturas.ToArray());
			else
				dgvFacturas.DataSource = new BindingList<FacturaWS.factura>();
			
			if(Program.empleado.cargo.nombre == "VENDEDOR")
            {
				dgvFacturas.Columns["NOMBRE"].Visible = false;
				dgvFacturas.Columns["APELLIDO_PATERNO"].Visible = false;
				dgvFacturas.Columns["APELLIDO_MATERNO"].Visible = false;
            }

			#region colores de seleccion
			dgvFacturas.ColumnHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
			dgvFacturas.ColumnHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);

			dgvFacturas.RowHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
			dgvFacturas.RowHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);

			dgvFacturas.RowsDefaultCellStyle.SelectionBackColor = Program.colorR;
			dgvFacturas.RowsDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);
			#endregion
		}

		private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			frmVentanaPrincipal.act.Enabled = false;
			frmVentanaPrincipal.elim.Enabled = false;
		}

		private void dgvFacturas_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
		{
			//Preguntar al profe
			if (e.StateChanged != DataGridViewElementStates.Selected)
			{
				//frmVentanaPrincipal.act.Enabled = false;
				//frmVentanaPrincipal.elim.Enabled = false;
				return;
			}
			else
			{
				frmVentanaPrincipal.act.Enabled = true;
				frmVentanaPrincipal.elim.Enabled = true;
			}
		}

		public static void eliminar()
		{
			facturaSeleccionada = (FacturaWS.factura)dgv.CurrentRow.DataBoundItem;
			daoFactura.eliminarFactura(facturaSeleccionada);
		}

        private void dgvFacturas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
				FacturaWS.factura factura = dgvFacturas.Rows[e.RowIndex].DataBoundItem
				as FacturaWS.factura;

				dgvFacturas.Rows[e.RowIndex].Cells["ID_PEDIDO"].Value = factura.pedido.idPedido;
				dgvFacturas.Rows[e.RowIndex].Cells["RUC"].Value = factura.pedido.cliente.ruc;
				dgvFacturas.Rows[e.RowIndex].Cells["RAZON_SOCIAL"].Value = factura.pedido.cliente.razonSocial;
				dgvFacturas.Rows[e.RowIndex].Cells["GRUPO"].Value = factura.pedido.cliente.grupo;
				dgvFacturas.Rows[e.RowIndex].Cells["TIPO_CLIENTE"].Value = factura.pedido.cliente.tipoEmpresa;
				dgvFacturas.Rows[e.RowIndex].Cells["NOMBRE"].Value = factura.pedido.empleado.nombre;
				dgvFacturas.Rows[e.RowIndex].Cells["APELLIDO_PATERNO"].Value = factura.pedido.empleado.apellidoPaterno;
				dgvFacturas.Rows[e.RowIndex].Cells["APELLIDO_MATERNO"].Value = factura.pedido.empleado.apellidoMaterno;

				String anulado = "";
				if (factura.anulado) anulado = "SI";
				else anulado = "NO";

				String estadoPagar = "";
				if (factura.estadoPagar) estadoPagar = "SI";
				else estadoPagar = "NO";

				dgvFacturas.Rows[e.RowIndex].Cells["ANULADO"].Value = anulado;
				dgvFacturas.Rows[e.RowIndex].Cells["ESTADO_PAGAR"].Value = estadoPagar;
				
			}
            catch (Exception){}
		}
    }
}
