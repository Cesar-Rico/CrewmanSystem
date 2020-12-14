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
	public partial class frmNuevoBorrador : Form
	{
        public static ClienteWS.cliente clienteSeleccionado;
        public static ZonaWS.ZonaWSClient daoZona;
        public static ClienteWS.ClienteWSClient daoCliente;
        public static PedidoWS.PedidoWSClient daoPedido;
        public static LineaPedidoWS.LineaPedidoWSClient daoLinea;
        public static ProductoXZonaWS.productoXZona productoXZonaSeleccionado;
        public static BindingList<LineaPedidoWS.lineaPedido> lineas;
        public static double montoTotal;
        string[] estadoBorrador = { "ESPERANDO", "EN_PROCESO" };
        string[] estadoPedido = { "EN_PROCESO", "FINALIZADO" };
        public static PedidoWS.pedido pedidoSeleccionado;
        public frmNuevoBorrador()
        {
            montoTotal = 0;
            daoZona = new ZonaWS.ZonaWSClient();
            daoPedido = new PedidoWS.PedidoWSClient();
            InitializeComponent();
            cboEstado.DataSource = estadoBorrador;
            lineas = new BindingList<LineaPedidoWS.lineaPedido>();
            completarTabla();
            if (frmVentanaPrincipal.nBtn == 1)
            {
                daoCliente = new ClienteWS.ClienteWSClient();
                daoLinea = new LineaPedidoWS.LineaPedidoWSClient();
                btnBuscarCliente.Enabled = false;
                if (Program.empleado.cargo.idCargo == 2)
                {
                    gboPedido.Enabled = true;
                    gboLineaPedido.Enabled = false;
                    txtDireccion.BackColor = SystemColors.InactiveCaption;
                    txtCantidad.BackColor = SystemColors.InactiveCaption;
                    gboCliente.Enabled = false;
                }
                //OBTENER DATOS DE FILA SELECCIONADA
                if (Program.pantallas[Program.pantallas.Count - 1].Formulario.Name == "frmGestionarBorradores")
                {
                    pedidoSeleccionado = (PedidoWS.pedido)frmGestionarBorradores.dgv.CurrentRow.DataBoundItem;
                    
                }
                else
                {
                    pedidoSeleccionado = (PedidoWS.pedido)frmBuscarBorrador.dgv.CurrentRow.DataBoundItem;
                }
                txtIDOrdenVenta.Text = pedidoSeleccionado.idPedido.ToString();
                txtDireccion.Text = pedidoSeleccionado.direccionEntrega;
                clienteSeleccionado = daoCliente.obtenerCliente(pedidoSeleccionado.cliente.idCliente);
                clienteSeleccionado.idCliente = pedidoSeleccionado.cliente.idCliente;
                pedidoSeleccionado.cliente = new PedidoWS.cliente();
                pedidoSeleccionado.cliente.idCliente = clienteSeleccionado.idCliente;
                pedidoSeleccionado.cliente.ruc = clienteSeleccionado.ruc;
                pedidoSeleccionado.cliente.razonSocial = clienteSeleccionado.razonSocial;
                pedidoSeleccionado.cliente.grupo = clienteSeleccionado.grupo;
                pedidoSeleccionado.cliente.tipoEmpresa = clienteSeleccionado.tipoEmpresa;
                ZonaWS.zona zona = daoZona.mostrarZonaCliente(clienteSeleccionado.idCliente);
                clienteSeleccionado.zona = new ClienteWS.zona();
                clienteSeleccionado.zona.idZona = zona.idZona;
                txtRucCliente.Text = clienteSeleccionado.ruc.ToString();
                txtRazonSocial.Text = clienteSeleccionado.razonSocial;
                LineaPedidoWS.lineaPedido[] auxLineas = daoLinea.listarLineaPedidos(pedidoSeleccionado.idPedido);
                montoTotal = pedidoSeleccionado.montoTotal;
                foreach (LineaPedidoWS.lineaPedido lp in auxLineas)
                {
                    lineas.Add(lp);
                }
                completarTabla();
            }

            #region colores de seleccion
            dgvLineas.ColumnHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
            dgvLineas.ColumnHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);

            dgvLineas.RowHeadersDefaultCellStyle.SelectionBackColor = Program.colorR;
            dgvLineas.RowHeadersDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);

            dgvLineas.RowsDefaultCellStyle.SelectionBackColor = Program.colorR;
            dgvLineas.RowsDefaultCellStyle.SelectionForeColor = ThemeColor.ChangeColorBrightness(Program.colorR, -0.7);
            #endregion
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarCliente formBusquedaCliente = new frmBuscarCliente(1,Program.empleado.cartera.idCartera);
            if (formBusquedaCliente.ShowDialog() == DialogResult.OK)
            {
                clienteSeleccionado = frmBuscarCliente.clienteSeleccionado;
                ZonaWS.zona zona = daoZona.mostrarZonaCliente(clienteSeleccionado.idCliente);
                clienteSeleccionado.zona = new ClienteWS.zona();
                clienteSeleccionado.zona.idZona = zona.idZona;
                txtRucCliente.Text = clienteSeleccionado.ruc.ToString();
                txtRazonSocial.Text = clienteSeleccionado.razonSocial;
                txtIdProducto.Text = "";
                txtNombreProducto.Text = "";
                txtPrecioUnitario.Text = "";
                productoXZonaSeleccionado = null;
                completarTabla();
            }
        }

        public void completarTabla()
        {
            dgvLineas.DataSource = null;
            dgvLineas.AutoGenerateColumns = false;
            dgvLineas.DataSource = lineas;
            txtMontoTotal.Text = montoTotal.ToString("n2");
        }

        private void btnBuscarProductoXZona_Click(object sender, EventArgs e)
        {
            if (txtRazonSocial.Text == "")
            {
                MessageBox.Show("Debe escoger un cliente","Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmBuscarProductoPorZona formBusquedaProductoPorZona = new frmBuscarProductoPorZona(0,clienteSeleccionado.zona.idZona);
            if (formBusquedaProductoPorZona.ShowDialog() == DialogResult.OK)
            {
                productoXZonaSeleccionado = frmBuscarProductoPorZona.productoXZonaSeleccionado;
                txtIdProducto.Text = productoXZonaSeleccionado.idProductoXZona.ToString();
                txtNombreProducto.Text = productoXZonaSeleccionado.producto.nombre;
                txtPrecioUnitario.Text = productoXZonaSeleccionado.precioReal.ToString("n2");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse(txtCantidad.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("La cantidad de productos deben ser números", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToInt32(txtCantidad.Text)<=0)
            {
                MessageBox.Show("La cantidad de productos deben ser mayores a 0", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (LineaPedidoWS.lineaPedido lp in lineas)
            {
                if (lp.productoXZona.idProductoXZona == productoXZonaSeleccionado.idProductoXZona) return;
            }
            LineaPedidoWS.lineaPedido linea = new LineaPedidoWS.lineaPedido();
            linea.cantidad = Convert.ToInt32(txtCantidad.Text);
            linea.productoXZona = new LineaPedidoWS.productoXZona();
            linea.productoXZona.idProductoXZona = productoXZonaSeleccionado.idProductoXZona;
            linea.productoXZona.precioReal = productoXZonaSeleccionado.precioReal;
            linea.productoXZona.producto = new LineaPedidoWS.producto();
            linea.productoXZona.producto.nombre = productoXZonaSeleccionado.producto.nombre;
            linea.montoSubTotal = linea.productoXZona.precioReal * linea.cantidad;
            montoTotal += linea.montoSubTotal;
            lineas.Add(linea);
            completarTabla();
        }

        private void dgvLineas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //castear objetos y mostrar valor determinado
            LineaPedidoWS.lineaPedido linea = dgvLineas.Rows[e.RowIndex].DataBoundItem
            as LineaPedidoWS.lineaPedido;

            dgvLineas.Rows[e.RowIndex].Cells["IDPRODUCTOXZONA"].Value = linea.productoXZona.idProductoXZona;
            dgvLineas.Rows[e.RowIndex].Cells["NOMBRE"].Value = linea.productoXZona.producto.nombre;
            dgvLineas.Rows[e.RowIndex].Cells["PRECIO"].Value = linea.productoXZona.precioReal;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(dgvLineas.CurrentRow==null || dgvLineas.CurrentRow.Index < 0)
            {
                return;
            }
            int index = dgvLineas.CurrentRow.Index;
            montoTotal -= lineas.ElementAt(index).montoSubTotal;
            dgvLineas.DataSource = new BindingList<LineaPedidoWS.lineaPedido>();
            lineas.RemoveAt(index);
            completarTabla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Necesita seleccionar un cliente", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDireccion.Text == "")
            {
                MessageBox.Show("Necesita especificar la dirección de entrega", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lineas.Count == 0)
            {
                MessageBox.Show("Debe añadir al menos un producto", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmConfirmarInsertar formInsertar = new frmConfirmarInsertar();
            if (formInsertar.ShowDialog() == DialogResult.OK)
            {
                PedidoWS.pedido pedido = new PedidoWS.pedido();
                pedido.cliente = new PedidoWS.cliente();
                pedido.cliente.idCliente = clienteSeleccionado.idCliente;
                pedido.empleado = new PedidoWS.empleado();
                pedido.empleado.idEmpleado = Program.empleado.idEmpleado;
                pedido.direccionEntrega = txtDireccion.Text;
                pedido.montoTotal = montoTotal;
                //agregar lineas
                int numLineas = lineas.Count;
                pedido.lineasPedidos = new PedidoWS.lineaPedido[numLineas];
                int cont = 0;
                foreach (LineaPedidoWS.lineaPedido lp in lineas)
                {
                    pedido.lineasPedidos[cont] = new PedidoWS.lineaPedido();
                    pedido.lineasPedidos[cont].idLineaPedido = lp.idLineaPedido;
                    pedido.lineasPedidos[cont].montoSubTotal = lp.montoSubTotal;
                    pedido.lineasPedidos[cont].cantidad = lp.cantidad;
                    pedido.lineasPedidos[cont].productoXZona = new PedidoWS.productoXZona();
                    pedido.lineasPedidos[cont].productoXZona.idProductoXZona = lp.productoXZona.idProductoXZona;
                    pedido.lineasPedidos[cont].productoXZona.precioReal = lp.productoXZona.precioReal;
                    cont++;
                }
                if (frmVentanaPrincipal.nBtn == 1)
                {
                    pedido.tipoPedido = pedidoSeleccionado.tipoPedido;
                    pedido.idPedido = pedidoSeleccionado.idPedido;
                    if (Program.empleado.cargo.idCargo == 2)
                    {
                        switch (cboEstado.Text)
                        {
                            case "ESPERANDO":
                                break;
                            case "EN_PROCESO":
                                pedido.fechaEstim = dtpFechaEstimada.Value;
                                pedido.fechaEstimSpecified = true;
                                int resultado= 0;
                                resultado = daoPedido.aprobarBorrador(pedido);
                                if(resultado != 0)MessageBox.Show("Aprobado con exito", "Mensaje de resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else MessageBox.Show("Error en la aprobación del pedido", "Mensaje de resultado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                        return;
                    }
                    daoPedido.actualizarPedido(pedido);
                }
                else
                {
                    int resultado = daoPedido.insertarPedido(pedido);
                    if (resultado == 0)
                    {
                        MessageBox.Show("No se insertó correctamente", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        ((frmGestionarBorradores)Program.pantallas[Program.pantallas.Count - 2].Formulario).recargarDGV();
                        MessageBox.Show("Se insertó correctamente", "Mensaje de confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pedido.idPedido = resultado;
                        txtIDOrdenVenta.Text = resultado.ToString();
                    }
                }
            }
        }
    }
}
