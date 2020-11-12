﻿using CrewmanSystem.ZonaWS;
using System;
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
	public partial class frmBuscarZona : Form
	{
		ZonaWS.ZonaWSClient daoZona = new ZonaWS.ZonaWSClient();
		public frmBuscarZona()
		{
			InitializeComponent();

			#region colores de seleccion
			dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
			dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);

			dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
			dataGridView1.RowHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);

			dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Program.colorR;
			dataGridView1.RowsDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);
			#endregion
		}

        private void btnBuscar_Click(object sender, EventArgs e)
        {
			//daoZona = new ZonaWS.ZonaWSClient();
			////ZonaWS.zona[] misZonas = daoZona(txtNombre.Text);
			//if (misZonas != null)
			//{
			//	dataGridView1.DataSource = new BindingList<ZonaWS.zona>(misZonas.ToArray());
			//}
			//else
			//{
			//	dataGridView1.DataSource = new BindingList<ZonaWS.zona>();

			//}
		}
    }
}
