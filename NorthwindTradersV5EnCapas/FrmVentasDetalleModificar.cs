using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
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
        private short CantidadOld { get; set; }
        private decimal DescuentoOld { get; set; }
        private short UInventarioOld { get; set; }


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
            //informationProvider1.Icon = SystemIcons.Information;
            //informationProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            //// Extraer el bitmap en 16x16 y volver a crear un Icon
            //using (Bitmap bmp = new Bitmap(SystemIcons.Information.ToBitmap(), new Size(16, 16)))
            //{
            //    informationProvider1.Icon = Icon.FromHandle(bmp.GetHicon());
            //}

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
            nudCantidad.ValueChanged -= nudCantidad_ValueChanged;
            nudCantidad.Leave -= nudCantidad_Leave;
            nudCantidad.Value = ventaDetalle.Quantity;
            nudCantidad.ValueChanged += nudCantidad_ValueChanged;
            nudCantidad.Leave += nudCantidad_Leave;
            nudDescuento.ValueChanged -= nudDescuento_ValueChanged;
            nudDescuento.Leave -= nudDescuento_Leave;
            nudDescuento.Value = ventaDetalle.TasaDescuentoPorcentaje;
            nudDescuento.ValueChanged += nudDescuento_ValueChanged;
            nudDescuento.Leave += nudDescuento_Leave;
            nudImporte.Value = ventaDetalle.Importe;
            nudImporteDelDescuento.Value = ventaDetalle.ImporteDelDescuento;
            nudImporteConDescuento.Value = ventaDetalle.ImporteConDescuento;
            nudTasaIVA.Value = ventaDetalle.TasaIVAPorcentaje;
            nudImporteDelIVA.Value = ventaDetalle.ImporteDelIVA;
            nudSubtotal.Value = ventaDetalle.Subtotal;
            CantidadOld = ventaDetalle.Quantity;
            DescuentoOld = ventaDetalle.TasaDescuentoPorcentaje;
            UInventarioOld = Convert.ToInt16(nudUInventario.Value);
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

        private bool ValidarControles()
        {
            try
            {
                btnModificar.Enabled = false;
                errorProvider1.Clear();
                CalcularImportes();

                short cantidad = 0, diferencia = 0;
                // Calcula la diferencia de cantidad
                diferencia = (short)(nudCantidad.Value - CantidadOld);
                // Validar cantidad y unidades en inventario sean números válidos
                //if (!short.TryParse(nudCantidad.Value.ToString(), out cantidad))
                //{
                //    errorProvider1.SetError(nudCantidad, "Ingrese una cantidad válida");
                //    return false;
                //}
                // Verificar disponibilidad en el inventario
                // Aquí manejamos el caso de devolver productos al inventario
                if (diferencia <= 0)
                {
                    nudUInventario.Value = Math.Abs(nudCantidad.Value - CantidadOld - UInventarioOld);
                    ValidarCantidad();

                    //informationProvider1.SetError(nudCantidad, "La cantidad de producto devuelto se añadirá al inventario");
                    // La validación es correcta al devolver productos
                    //if (nudUInventario.Value > 32767)
                    //{
                    //    errorProvider1.SetError(nudCantidad, "La cantidad de producto devuelto mas las unidades en inventario exceden las 32,767 unidades");
                    //    return false;
                    //}
                    //if (cantidad == 0)
                    //{
                    //    errorProvider1.SetError(nudCantidad, "Ingrese la cantidad");
                    //    return false;
                    //}
                }
                // Aquí manejamos el caso de retirar productos del inventario
                else if (diferencia > 0)
                {
                    nudUInventario.Value = nudUInventario.Value + diferencia - CantidadOld - UInventarioOld;
                    if (diferencia > nudUInventario.Value)
                    {
                        errorProvider1.SetError(nudCantidad, "La cantidad de productos en el pedido excede el inventario disponible");
                        return false;
                    }
                }
                // Habilitar el botón Modificar si las cantidades y descuentos son válidos y han cambiado
                if (nudCantidad.Value != CantidadOld || nudDescuento.Value != DescuentoOld)
                {
                    btnModificar.Enabled = true;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
                return false;
            }
        }

        private void ValidarCantidad()
        {
            StatusIconHelper.ShowIcons(
                nudCantidad,
                toolTip1,
                // Error
                (pbError, errorProvider1.Icon.ToBitmap(), "La cantidad debe ser mayor que cero.", nudCantidad.Value <= 0),
                // Information
                (pbInfo, SystemIcons.Information.ToBitmap(), "La cantidad de producto devuelto se añadirá al inventario.", nudCantidad.Value > 0 && nudCantidad.Value >= 0),
                // Warning
                (pbWarning, SystemIcons.Warning.ToBitmap(), "La existencia en inventario es baja.", nudUInventario.Value > 0 && nudUInventario.Value < 10)
            );
        }


        private void CalcularImportes()
        {
            try
            {
                VentaDetalle ventaDetalle = new VentaDetalle()
                {
                    UnitPrice = nudPrecio.Value,
                    Quantity = Convert.ToInt16(nudCantidad.Value),
                    Discount = nudDescuento.Value / 100
                };
                nudImporte.Value = ventaDetalle.Importe;
                nudImporteDelDescuento.Value = ventaDetalle.ImporteDelDescuento;
                nudImporteConDescuento.Value = ventaDetalle.ImporteConDescuento;
                nudImporteDelIVA.Value = ventaDetalle.ImporteDelIVA;
                nudSubtotal.Value = ventaDetalle.Subtotal;
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
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

        private void nudCantidad_Leave(object sender, EventArgs e)
        {
            if (!ValidarControles())
                return;
        }

        private void nudDescuento_Leave(object sender, EventArgs e)
        {
            if (!ValidarControles())
                return;
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (!ValidarControles())
                return;
        }

        private void nudDescuento_ValueChanged(object sender, EventArgs e)
        {
            if (!ValidarControles())
                return;
        }
    }
}
