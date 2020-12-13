﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace CrewmanSystem
{
	public partial class frmGestionarProductosXZona : Form
	{
		private static ProductoXZonaWS.ProductoXZonaWSClient daoProductoXZona;
		public ProductoXZonaWS.productoXZona[] misProductoXZonas;
		public frmGestionarProductosXZona()
		{
			daoProductoXZona = new ProductoXZonaWS.ProductoXZonaWSClient();
			InitializeComponent();
			dgvProductosXZona.AutoGenerateColumns = false;
			recargarDGV();

			#region colores de seleccion
			dgvProductosXZona.ColumnHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
			dgvProductosXZona.ColumnHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);

			dgvProductosXZona.RowHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
			dgvProductosXZona.RowHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);

			dgvProductosXZona.RowsDefaultCellStyle.SelectionBackColor = Program.colorR;
			dgvProductosXZona.RowsDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);
			#endregion
		}

		private void dgvProductosXZona_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			//castear objetos y mostrar valor determinado
			ProductoXZonaWS.productoXZona productoXZona = dgvProductosXZona.Rows[e.RowIndex].DataBoundItem
			as ProductoXZonaWS.productoXZona;

			dgvProductosXZona.Rows[e.RowIndex].Cells["PRODUCTO"].Value = productoXZona.producto.nombre;
			dgvProductosXZona.Rows[e.RowIndex].Cells["CANT_UNIDADES"].Value = productoXZona.producto.cantUnidad;
			dgvProductosXZona.Rows[e.RowIndex].Cells["UNIDADES"].Value = productoXZona.producto.unidades;
			dgvProductosXZona.Rows[e.RowIndex].Cells["ZONA"].Value = productoXZona.zona.nombre;
			dgvProductosXZona.Rows[e.RowIndex].Cells["SUBFAMILIA"].Value = productoXZona.producto.subFamilia.descripcionSubFamilia;
			dgvProductosXZona.Rows[e.RowIndex].Cells["FAMILIA"].Value = productoXZona.producto.subFamilia.familia.descripcion;
			dgvProductosXZona.Rows[e.RowIndex].Cells["MARCA"].Value = productoXZona.producto.marca.nombre;
		}

		public void recargarDGV()
		{
			misProductoXZonas = null;
			if (Program.empleado.cargo.nombre == "VENDEDOR")
				misProductoXZonas = daoProductoXZona.listarProductosXZonas("", "", "", "", Program.empleado.zona.idZona);
			else
				misProductoXZonas = daoProductoXZona.listarProductosXZonas("", "", "", "", 0);

			if (misProductoXZonas != null)
			{
				dgvProductosXZona.DataSource = new BindingList<ProductoXZonaWS.productoXZona>(misProductoXZonas.ToArray());
			}
			else
			{
				dgvProductosXZona.DataSource = new BindingList<ProductoXZonaWS.productoXZona>();
			}
		}

		public void revisarDGV(object source, ElapsedEventArgs e)
		{

			if (dgvProductosXZona.InvokeRequired)
			{
				dgvProductosXZona.Invoke(new Action(() =>
				{
					if (dgvProductosXZona.Rows.Count > 0)
					{
						int i = ((ProductoXZonaWS.productoXZona)dgvProductosXZona.CurrentRow.DataBoundItem).idProductoXZona;
						int j = dgvProductosXZona.CurrentCell.ColumnIndex;

						recargarDGV();

						int k = 0;
						foreach (ProductoXZonaWS.productoXZona p in misProductoXZonas)
						{
							if (p.idProductoXZona == i)
							{
								i = k;
								break;
							}
							k++;
						}

						if (k != misProductoXZonas.Length)
							dgvProductosXZona.CurrentCell = dgvProductosXZona[j, i];
					}
				}));
			}
		}
	}
}
