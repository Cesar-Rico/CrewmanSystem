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
	public partial class frmHomeJefe : Form
	{
		private EmpleadoWS.EmpleadoWSClient daoEmpleado;
		public frmHomeJefe()
		{
			InitializeComponent();
			chartVentas.ChartAreas[0].BackColor = SystemColors.ControlLight;
			chartVentas.PaletteCustomColors = new System.Drawing.Color[] {Program.colorR};
			daoEmpleado = new EmpleadoWS.EmpleadoWSClient();
			string saludo = "";
			if (Program.empleado.genero == 'M') saludo = "Bienvenido, ";
			else saludo = "Bienvenida, ";
			lblNombre.Text = saludo + Program.empleado.nombre + " " +
				Program.empleado.apellidoPaterno + " " +
				Program.empleado.apellidoMaterno;

			lblZona.Text = Program.empleado.zona.nombre;
			actualizarMapa();
		}

		public void actualizarMapa()
        {
			MessageBox.Show("actualizar mapa");
			chartVentas.Series.Clear();
			BindingList<EmpleadoWS.empleado> misEmpleados;
			EmpleadoWS.empleado[] empleados = daoEmpleado.listarPorJefeVentas(Program.empleado.idEmpleado, "", "", "");
			if (empleados == null || empleados.Length < 1) misEmpleados = new BindingList<EmpleadoWS.empleado>();
			else misEmpleados = new BindingList<EmpleadoWS.empleado>(empleados.ToList());
			chartVentas.Series.Add("Suma Ventas");
			chartVentas.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
			chartVentas.ChartAreas[0].AxisX.Interval = 1;
			foreach (EmpleadoWS.empleado emp in empleados)
			{
				chartVentas.Series["Suma Ventas"].Points.AddXY(emp.apellidoPaterno + " " + emp.apellidoMaterno + ", " + emp.nombre, emp.sumVentas);
			}
		}
	}
}
