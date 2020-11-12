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
	public partial class frmNuevoProducto : Form
	{
        ProductoWS.ProductoWSClient daoProducto;
        FamiliaWS.FamiliaWSClient daoFamilia;
        SubFamiliaWS.SubFamiliaWSClient daoSubfamilia;
        MarcaWS.MarcaWSClient daoMarca;
        string[] unidades = {"gr","ml"};
        public frmNuevoProducto()
		{
			InitializeComponent();

            daoFamilia = new FamiliaWS.FamiliaWSClient();
            daoSubfamilia = new SubFamiliaWS.SubFamiliaWSClient();
            daoProducto = new ProductoWS.ProductoWSClient();
            daoMarca = new MarcaWS.MarcaWSClient();
            cboMarca.DataSource = new BindingList<MarcaWS.marca>(daoMarca.listarMarcas().ToArray());
            cboMarca.ValueMember = "idMarca";
            cboMarca.DisplayMember = "nombre";
            FamiliaWS.familia[] misFamilias = daoFamilia.listarFamilias();
            cboUnidades.DataSource = unidades;
            if (misFamilias != null)
            {
                cboFamilia.DataSource = new BindingList<FamiliaWS.familia>(misFamilias.ToArray());
                cboFamilia.ValueMember = "idFamilia";
                cboFamilia.DisplayMember = "descripcion";
            }
        }

		private void btnGuardar_Click(object sender, EventArgs e)
		{
            foreach (Control c in panel2.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Text == string.Empty && textBox.Name != "txtId")
                    {
                        MessageBox.Show("Falta llenar los datos de " + 
                            textBox.Name.Substring(3));
                        return;
                    }
                    else
                    {
                        if (textBox == txtNombre)
                        {
                            String txtNombreAux = string.Join("", textBox.Text.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
                            if (!txtNombreAux.All(Char.IsLetter))
                            {
                                MessageBox.Show("Los datos de " +
                                    textBox.Name.Substring(3) + " solo pueden contener letras");
                                return;
                            }
                        }
                        if (textBox == txtPrecioSugerido)
                        {
                            try{
                                double precio = Convert.ToDouble(textBox.Text);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Los datos de " +
                                    textBox.Name.Substring(3) + " solo pueden contener dígitos");
                                return;
                            }
                        }
                        if(textBox == txtStock)
                        {
                            if (!textBox.Text.All(Char.IsDigit))
                            {
                                MessageBox.Show("Los datos de " +
                                    textBox.Name.Substring(3) + " solo pueden contener dígitos");
                                return;
                            }
                        }
                    }
                }
                if (c is ComboBox)
                {
                    ComboBox cmbBox = c as ComboBox;
                    if (cmbBox.SelectedIndex == -1)
                    {
                        MessageBox.Show("Falta llenar los datos de " +
                            cmbBox.Name.Substring(3));
                        return;
                    }
                }
            }
            //AQUI VA EL INSERTAR
            frmConfirmarInsertar formInsertar = new frmConfirmarInsertar();
            if (formInsertar.ShowDialog() == DialogResult.OK)
            {
                ProductoWS.producto producto = new ProductoWS.producto();
                producto.nombre = txtNombre.Text;
                producto.precioSugerido = float.Parse(txtPrecioSugerido.Text);
                producto.subFamilia = new ProductoWS.subFamilia();
                producto.subFamilia.idSubFamilia = ((SubFamiliaWS.subFamilia)cboSubfamilia.SelectedItem).idSubFamilia;
                producto.marca = new ProductoWS.marca();
                producto.marca.idMarca = ((MarcaWS.marca)cboMarca.SelectedItem).idMarca;
                producto.unidades = cboUnidades.SelectedItem.ToString();
                producto.cantUnidad = Convert.ToDouble(txtCantidad.Text);
                producto.stock = Convert.ToInt32(txtStock.Text);
                int resultado = daoProducto.insertarProducto(producto);
                txtId.Text = resultado.ToString();
                //Usar resultado para ver si se inserto correctamente
            }
        }

		private void cboFamilia_SelectedIndexChanged(object sender, EventArgs e)
		{
            SubFamiliaWS.subFamilia[] misSubfamilias = daoSubfamilia.listarSubFamilias(((FamiliaWS.familia)cboFamilia.SelectedItem).descripcion);
            if (misSubfamilias != null)
            {
                cboSubfamilia.DataSource = new BindingList<SubFamiliaWS.subFamilia>(misSubfamilias.ToArray());
                cboSubfamilia.ValueMember = "idSubFamilia";
                cboSubfamilia.DisplayMember = "descripcionSubFamilia";
            }
        }
	}
}
