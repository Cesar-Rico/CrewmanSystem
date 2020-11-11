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
	public partial class frmGestionarZonas : Form
	{
		ZonaWS.ZonaWSClient daoZona;
		public frmGestionarZonas()
		{
			daoZona = new ZonaWS.ZonaWSClient();
			InitializeComponent();
			dataGridView1.AutoGenerateColumns = false;
			ZonaWS.zona[] misZonas = daoZona.listarZonas();
			if (misZonas != null)
			{
				dataGridView1.DataSource = new BindingList<ZonaWS.zona>(misZonas.ToArray());
			}
			else
			{
				dataGridView1.DataSource = new BindingList<ZonaWS.zona>();

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
	}
}