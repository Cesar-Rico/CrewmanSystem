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
    public partial class frmNuevaGuiaRemision : Form
    {
        PedidoWS.pedido pedidoSeleccionado;
        PedidoWS.PedidoWSClient daoPedido;
        GuiaRemisionWS.GuiaRemisionWSClient daoGuiaRemision;
       
        public frmNuevaGuiaRemision()
        {
            pedidoSeleccionado = new PedidoWS.pedido();
            daoGuiaRemision = new GuiaRemisionWS.GuiaRemisionWSClient();
            daoPedido = new PedidoWS.PedidoWSClient();
            InitializeComponent();
            dtpRangoIniRegistro.Value = DateTime.Now;
            dtpRangoIniRegistro.Enabled = false;

            if (frmVentanaPrincipal.nBtn == 1)
            {   //OBTNER DATOS DE FILA SELECCIONADA
                GuiaRemisionWS.guiaRemision miGuiaRemision = new GuiaRemisionWS.guiaRemision();

                if (Program.pantallas[Program.pantallas.Count - 1].Formulario.Name == "frmGestionarGuiasRemision")
                {
                    frmGestionarGuiasRemision.guiaRemisionSeleccionado = (GuiaRemisionWS.guiaRemision)frmGestionarGuiasRemision.dgv.CurrentRow.DataBoundItem;
                    miGuiaRemision = frmGestionarGuiasRemision.guiaRemisionSeleccionado;
                }
                else
                {
                    miGuiaRemision = (GuiaRemisionWS.guiaRemision)frmBuscarGuiaRemision.dgv.CurrentRow.DataBoundItem;
                }
                txtIdGuiaRemision.Text = miGuiaRemision.idGuiaRemision.ToString();
                txtIdPedido.Text = miGuiaRemision.pedido.idPedido.ToString();
                txtMotivoTraslado.Text = miGuiaRemision.motivoTraslado;
                dtpRangoIniRegistro.Value = miGuiaRemision.fechaRegistro;
                dtpRangoIniTraslado.Value = miGuiaRemision.fechaTraslado;
            }
        }

        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            frmBuscarBorrador formBusquedaPedidoAGuiaRemision = new frmBuscarBorrador(2);
            if (formBusquedaPedidoAGuiaRemision.ShowDialog() == DialogResult.OK)
            {
                pedidoSeleccionado = frmBuscarBorrador.pedidoSeleccionado;
                txtIdPedido.Text = pedidoSeleccionado.idPedido.ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtMotivoTraslado.Text == "")
            {
                MessageBox.Show("Debe ingresar el motivo de traslado", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpRangoIniTraslado.Value < dtpRangoIniRegistro.Value)
            {
                MessageBox.Show("Fecha de traslado inválida", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GuiaRemisionWS.guiaRemision guiaRemision = new GuiaRemisionWS.guiaRemision();
            int resultado;
            guiaRemision.motivoTraslado = txtMotivoTraslado.Text;
            guiaRemision.pedido = new GuiaRemisionWS.pedido();
            guiaRemision.pedido.idPedido = pedidoSeleccionado.idPedido;
            guiaRemision.fechaRegistroSpecified = true;
            guiaRemision.fechaTrasladoSpecified = true;
            guiaRemision.fechaRegistro = dtpRangoIniRegistro.Value;
            guiaRemision.fechaTraslado = dtpRangoIniTraslado.Value;

            if (frmVentanaPrincipal.nBtn == 0)
            {
                resultado = daoPedido.entregarPedido(pedidoSeleccionado.idPedido);
                if (resultado == 0)
                {
                    MessageBox.Show("No se entrego el pedido", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                resultado = daoGuiaRemision.insertarGuiaRemision(guiaRemision);
                if (resultado == 0)
                {
                    MessageBox.Show("No se insertó correctamente", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ((frmGestionarGuiasRemision)Program.pantallas[Program.pantallas.Count - 2].Formulario).recargarDGV();
                    MessageBox.Show("Se insertó correctamente", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIdGuiaRemision.Text = resultado.ToString();
                }
            }
            else if (frmVentanaPrincipal.nBtn == 1) 
            {
                guiaRemision.idGuiaRemision= Convert.ToInt32(txtIdGuiaRemision.Text);
                resultado = daoGuiaRemision.actualizarGuiaRemision(guiaRemision);
                if (resultado == 0)
                {
                    MessageBox.Show("No se actualizó correctamente", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ((frmGestionarGuiasRemision)Program.pantallas[Program.pantallas.Count - 2].Formulario).recargarDGV();
                    MessageBox.Show("Se actualizó correctamente", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIdGuiaRemision.Text = resultado.ToString();
                }
            }
            
        }
    }
}
