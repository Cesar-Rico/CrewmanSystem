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
	public partial class frmBuscarProducto : Form
	{
		ProductoWS.ProductoWSClient daoProducto;
		public frmBuscarProducto()
		{
			daoProducto = new ProductoWS.ProductoWSClient();
			InitializeComponent();
			dataGridView1.AutoGenerateColumns = false;
			//dataGridView1.DataSource = new BindingList<ProductoWS.producto>(daoProducto.listarProductos(txtNombre.Text, txtFamilia, txtSubfamilia, txtMarca).ToArray());
			
			#region colores de seleccion
			dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
			dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);

			dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
			dataGridView1.RowHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);
			#endregion
		}
	}
}
