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
	public partial class frmBuscarCliente : Form
	{
		ClienteWS.ClienteWSClient daoCliente;
		public frmBuscarCliente()
		{
			daoCliente = new ClienteWS.ClienteWSClient();
			InitializeComponent();
			dataGridView1.AutoGenerateColumns = false;
			ClienteWS.cliente[] misClientes = daoCliente.listarClientes("", "");
			if (misClientes != null)
			{
				dataGridView1.DataSource = new BindingList<ClienteWS.cliente>(misClientes.ToArray());
			}
			else
			{
				dataGridView1.DataSource = new BindingList<ClienteWS.cliente>();

			}

			#region colores de seleccion
			dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
			dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);

			dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
			dataGridView1.RowHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);

			dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Program.colorR;
			dataGridView1.RowsDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);
			#endregion
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			frmMostrarCliente formBusquedaClientes = new frmMostrarCliente();
			if (formBusquedaClientes.ShowDialog() == DialogResult.OK) 
			{ 
			}
		}

        private void btnBuscar_Click(object sender, EventArgs e)
        {
			daoCliente = new ClienteWS.ClienteWSClient();
			ClienteWS.cliente[] misClientes = daoCliente.listarClientes(txtRazonSocial.Text, txtGrupo.Text);
			if (misClientes != null)
			{
				dataGridView1.DataSource = new BindingList<ClienteWS.cliente>(misClientes.ToArray());
			}
			else
			{
				dataGridView1.DataSource = new BindingList<ClienteWS.cliente>();

			}
		}

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
			//castear objetos y mostrar valor determinado
			ClienteWS.cliente cliente = dataGridView1.Rows[e.RowIndex].DataBoundItem
										as ClienteWS.cliente;

			dataGridView1.Rows[e.RowIndex].Cells["ID_LINEA_CREDITO"].Value = cliente.lineaCredito.idLineaCredito;
			dataGridView1.Rows[e.RowIndex].Cells["ID_PERSONA_CONTACTO"].Value = cliente.personaContacto.idPersonaContacto;
			dataGridView1.Rows[e.RowIndex].Cells["ID_CARTERA"].Value = cliente.cartera.idCartera;
		}
    }
}
