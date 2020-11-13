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
	public partial class frmGestionarQuejas : Form
	{
		private QuejaWS.QuejaWSClient daoQueja;
		public frmGestionarQuejas()
		{
			daoQueja = new QuejaWS.QuejaWSClient();
			InitializeComponent();
			dgvQuejas.AutoGenerateColumns = false;
			QuejaWS.queja[] misQuejas = daoQueja.listarQuejas(0);
			if (misQuejas != null)
			{
				dgvQuejas.DataSource = new BindingList<QuejaWS.queja>(misQuejas.ToArray());
			}
			else
			{
				dgvQuejas.DataSource = new BindingList<QuejaWS.queja>();

			}

			#region colores de seleccion
			dgvQuejas.ColumnHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
			dgvQuejas.ColumnHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);

			dgvQuejas.RowHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
			dgvQuejas.RowHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);

			dgvQuejas.RowsDefaultCellStyle.SelectionBackColor = Program.colorR;
			dgvQuejas.RowsDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);
			#endregion
		}
	}
}
