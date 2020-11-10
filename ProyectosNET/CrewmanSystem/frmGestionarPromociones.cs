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
	public partial class frmGestionarPromociones : Form
	{
		PromocionWS.PromocionWSClient daoPromocion;
		public frmGestionarPromociones()
		{
			daoPromocion = new PromocionWS.PromocionWSClient();
			InitializeComponent();
			dataGridView1.AutoGenerateColumns = false;
			PromocionWS.promocion[] misPromocions = daoPromocion.listarPromocions("", DateTime.MinValue, DateTime.Today);
			if (misPromocions != null)
			{
				dataGridView1.DataSource = new BindingList<PromocionWS.promocion>(misPromocions.ToArray());
			}
			else
			{
				dataGridView1.DataSource = new BindingList<PromocionWS.promocion>();

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
