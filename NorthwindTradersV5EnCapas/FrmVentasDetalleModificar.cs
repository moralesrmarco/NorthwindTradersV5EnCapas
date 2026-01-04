using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmVentasDetalleModificar : Form
    {

        string _connectionString = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        private Dictionary<string, object> valoresOriginales;
        private VentaDetalleBLL _ventaDetalleBLL;

        public VentaDetalle ventaDetalle { get; set; }
        //public int PedidoId { get; set; }
        //public int ProductoId { get; set; }
        //public string Producto { get; set; }
        //public decimal Precio { get; set; }
        //public short Cantidad { get; set; }
        //public decimal Descuento { get; set; }
        //public decimal Importe { get; set; }
        //public short? UInventario { get; set; }
        //public int RowVersion { get; set; }
        //public short CantidadOld { get; set; }
        //public decimal DescuentoOld { get; set; }

        public FrmVentasDetalleModificar()
        {
            InitializeComponent();
            _ventaDetalleBLL = new VentaDetalleBLL(_connectionString);
        }

        private void FrmVentasDetalleModificar_FormClosed(object sender, FormClosedEventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void FrmVentasDetalleModificar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Utils.HayCambios(this, valoresOriginales, errorProvider1))
                if (U.NotificacionQuestion(Utils.preguntaCerrar) == DialogResult.No)
                    e.Cancel = true;
        }

        private void FrmVentasDetalleModificar_Load(object sender, EventArgs e)
        {
            // Obtener el símbolo de moneda según la configuración regional del equipo
            string simboloMoneda = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
            // Mostrarlo en el Label
            LblPrecio.Text = "Precio " + simboloMoneda + ":";
            LblImporte.Text = "Importe " + simboloMoneda + ":";
            LblImporteDelDecuento.Text = "Importe del descuento " + simboloMoneda + ":";
            LblImporteConDescunto.Text = "Importe con descuento " + simboloMoneda + ":";
            LblImporteDelIVA.Text = "Importe del IVA " + simboloMoneda + ":";
            LblSubtotal.Text = "Subtotal " + simboloMoneda + ":";
            
            txtPedido.Text = ventaDetalle.Venta.OrderID.ToString();
            txtProducto.Text = ventaDetalle.Producto.ProductName;
            nudPrecio.Value = ventaDetalle.UnitPrice;
            nudUInventario.Value = ObtenerUInventario();
            nudCantidad.Value = ventaDetalle.Quantity;
            nudDescuento.Value = ventaDetalle.TasaDescuentoPorcentaje;
            nudImporte.Value = ventaDetalle.Importe;
            nudImporteDelDescuento.Value = ventaDetalle.ImporteDelDescuento;
            nudImporteConDescuento.Value = ventaDetalle.ImporteConDescuento;
            nudTasaIVA.Value = ventaDetalle.TasaIVAPorcentaje;
            nudImporteDelIVA.Value = ventaDetalle.ImporteDelIVA;
            nudSubtotal.Value = ventaDetalle.Subtotal;
            DeshabilitarNudsNoSeleccionables();
            CargarValoresOriginales();
        }

        private Decimal ObtenerUInventario()
        {
            Decimal uInventario = 0;
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                uInventario = Convert.ToDecimal(_ventaDetalleBLL.ObtenerUInventario(ventaDetalle.Producto.ProductID));
                MDIPrincipal.ActualizarBarraDeEstado();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
            return uInventario;
        }

        private void DeshabilitarNudsNoSeleccionables()
        {
            Utilities.NudHelper.SetEnabled(nudPrecio, false);
            Utilities.NudHelper.SetEnabled(nudUInventario, false);
            Utilities.NudHelper.SetEnabled(nudImporte, false);
            Utilities.NudHelper.SetEnabled(nudImporteDelDescuento, false);
            Utilities.NudHelper.SetEnabled(nudImporteConDescuento, false);
            Utilities.NudHelper.SetEnabled(nudTasaIVA, false);
            Utilities.NudHelper.SetEnabled(nudImporteDelIVA, false);
            Utilities.NudHelper.SetEnabled(nudSubtotal, false);
        }

        private void CargarValoresOriginales()
        {
            valoresOriginales = Utils.CapturarValoresOriginales(this);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void FrmPedidosDetalleModificar_Load(object sender, EventArgs e)
        //{
        //    ObtenerUInventario();
        //    txtPedido.Text = PedidoId.ToString();
        //    txtProducto.Text = Producto;
        //    txtPrecio.Text = Precio.ToString("c");
        //    txtUinventario.Text = string.Format("{0:n0}", UInventario);
        //    txtCantidad.Text = Cantidad.ToString("n0");
        //    txtDescuento.Text = Descuento.ToString("n2");
        //    txtImporte.Text = Importe.ToString("c");
        //    CantidadOld = Cantidad;
        //    DescuentoOld = Descuento;
        //}

        private bool ValidarControles()
        {
            //txtCantidad.Text = txtCantidad.Text.Replace(",", "");
            bool valida = true;
            //btnModificar.Enabled = false;
            //errorProvider1.Clear();

            //int cantidadInt = 0, unidadesInventario = 0;
            //short cantidad = 0, diferencia = 0;
            //decimal descuento = 0;

            ////Validar txtCantidad 
            //if (!short.TryParse(txtCantidad.Text.Replace(",", ""), out cantidad))
            //{
            //    valida = false;
            //    errorProvider1.SetError(txtCantidad, "Ingrese una cantidad valida, la cantidad debe ser mayor que 1 y menor que 32,767");
            //}
            //if (valida && cantidad == 0)
            //{
            //    valida = false;
            //    errorProvider1.SetError(txtCantidad, "Ingrese la cantidad");
            //}
            //// Validar descuento
            //if (string.IsNullOrWhiteSpace(txtDescuento.Text) || !decimal.TryParse(txtDescuento.Text, out descuento))
            //{
            //    valida = false;
            //    errorProvider1.SetError(txtDescuento, "Ingrese el descuento");
            //}
            //else if (descuento > 1 || descuento < 0)
            //{
            //    valida = false;
            //    errorProvider1.SetError(txtDescuento, "El descuento no puede ser mayor que 1 o menor que 0");
            //}
            //if (valida)
            //{
            //    // Calcula la diferencia de cantidad
            //    diferencia = (short)(cantidad - CantidadOld);

            //    // Validar cantidad y unidades en inventario sean números válidos
            //    if (!int.TryParse(txtCantidad.Text.Replace(",", ""), out cantidadInt) || !int.TryParse(txtUinventario.Text.Replace(",", ""), out unidadesInventario))
            //    {
            //        valida = false;
            //        errorProvider1.SetError(txtCantidad, "Ingrese una cantidad válida");
            //    }
            //    // Verificar disponibilidad en el inventario
            //    if (valida && UInventario != null)
            //    {
            //        // Aquí manejamos el caso de devolver productos al inventario
            //        if (diferencia < 0)
            //        {
            //            // La validación es correcta al devolver productos
            //            if (unidadesInventario + Math.Abs(diferencia) > 32767)
            //            {
            //                valida = false;
            //                errorProvider1.SetError(txtCantidad, "La cantidad de producto devuelto mas las unidades en inventario exceden los 32,767 unidades");
            //            }
            //        }
            //        // Aquí manejamos el caso de retirar productos del inventario
            //        else if (diferencia > 0)
            //        {
            //            if (diferencia > unidadesInventario)
            //            {
            //                valida = false;
            //                errorProvider1.SetError(txtCantidad, "La cantidad de productos en el pedido excede el inventario disponible");
            //            }
            //        }
            //    }
            //    else if (UInventario == null)
            //    {
            //        valida = false;
            //        errorProvider1.SetError(txtCantidad, "Es posible que el producto haya sido eliminado por otro usuario en la red");
            //    }
        //}

        //    // Habilitar el botón Modificar si las cantidades y descuentos son válidos y han cambiado
        //    if (valida && (cantidad != CantidadOld || descuento != DescuentoOld))
        //        btnModificar.Enabled = true;
            return valida;
        }

        private void CalcularImporte()
        {
            //Cantidad = short.Parse(txtCantidad.Text.Replace(",", ""));
            //Descuento = decimal.Parse(txtDescuento.Text);
            //Importe = (Precio * Cantidad) * (1 - Descuento);
            //txtImporte.Text = Importe.ToString("c");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //int numRegs = 0;
            //// No se realiza la validación porque ya se han realizado previamente en el evento leave de 
            //// txtdescuento y txtcantidad
            //try
            //{
            //    btnModificar.Enabled = false;
            //    MDIPrincipal.ActualizarBarraDeEstado(Utils.modificandoRegistro);
            //    PedidoDetalle pedidoDetalle = new PedidoDetalle
            //    {
            //        OrderID = PedidoId,
            //        ProductID = ProductoId,
            //        Quantity = short.Parse(txtCantidad.Text.Replace(",", "")),
            //        Discount = decimal.Parse(txtDescuento.Text),
            //        RowVersion = RowVersion
            //    };
            //    numRegs = new PedidoRepository(cnStr).Actualizar(pedidoDetalle, CantidadOld, DescuentoOld);
            //    if (numRegs == 0)
            //        Utils.MensajeExclamation("No se pudo realizar la modificación, es posible que el registro se haya eliminado previamente por otro usuario de la red");
            //}
            //catch (Exception ex)
            //{
            //    Utils.MsgCatchOue(ex);
            //}
            //if (numRegs > 0)
            //{
            //    // Las siguientes dos lineas son necesarias para que se permita cerrar la ventana. 
            //    // ya que se validan las variables en FrmPedidosDetalleModificar_FormClosing
            //    CantidadOld = short.Parse(txtCantidad.Text);
            //    DescuentoOld = decimal.Parse(txtDescuento.Text);
            //    DialogResult = DialogResult.OK;
            //    this.Close();
            //}
        }

    }
}
