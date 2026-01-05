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
            ValidarCantidad();
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

                // Recalcula importes (si depende de cantidad/descuento)
                CalcularImportes();

                decimal cantidadNueva = nudCantidad.Value;
                decimal cantidadVieja = CantidadOld;
                decimal inventarioViejo = UInventarioOld;

                // Stock total disponible para este pedido (reservado + inventario)
                decimal disponible = inventarioViejo + cantidadVieja;

                // Inventario remanente REAL en DB después de reservar la nueva cantidad
                decimal inventarioNuevoDb = disponible - cantidadNueva;

                // Aplica límites del NumericUpDown solo para mostrar en UI
                decimal inventarioNuevoUi = inventarioNuevoDb;
                inventarioNuevoUi = Math.Min(inventarioNuevoUi, nudUInventario.Maximum);
                inventarioNuevoUi = Math.Max(inventarioNuevoUi, nudUInventario.Minimum);
                nudUInventario.Value = inventarioNuevoUi;

                // Valida reglas de negocio con StatusIconHelper
                bool ok = ValidarCantidad();
                if (!ok) return false;

                // Habilitar el botón Modificar si hubo cambios y las validaciones pasaron
                bool hayCambios = (nudCantidad.Value != CantidadOld) || (nudDescuento.Value != DescuentoOld);
                if (hayCambios)
                {
                    btnModificar.Enabled = true;
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
                return false;
            }
        }

        //private bool ValidarControles()
        //{
        //    try
        //    {
        //        btnModificar.Enabled = false;
        //        errorProvider1.Clear();
        //        CalcularImportes();

        //        // Usa decimal de extremo a extremo
        //        decimal cantidadNueva = nudCantidad.Value;
        //        decimal cantidadVieja = CantidadOld;      // asegúrate de que sea decimal
        //        decimal inventarioViejo = UInventarioOld;   // asegúrate de que sea decimal

        //        // Stock total disponible para este pedido (reservado + inventario)
        //        decimal disponible = inventarioViejo + cantidadVieja;

        //        // Inventario remanente después de reservar la nueva cantidad
        //        decimal inventarioNuevo = disponible - cantidadNueva;

        //        // Aplica límites del NumericUpDown
        //        inventarioNuevo = Math.Min(inventarioNuevo, nudUInventario.Maximum);
        //        inventarioNuevo = Math.Max(inventarioNuevo, nudUInventario.Minimum);

        //        // Refleja en UI
        //        nudUInventario.Value = inventarioNuevo;

        //        // Valida reglas de negocio con iconos y devuelve estado
        //        bool ok = ValidarCantidad(); // debe usar la misma regla de “excede inventario”
        //        if (!ok) return false;

        //        // Habilita Modificar si hubo cambios
        //        bool hayCambios = (nudCantidad.Value != CantidadOld) || (nudDescuento.Value != DescuentoOld);
        //        if (hayCambios)
        //        {
        //            btnModificar.Enabled = true;
        //            return true;
        //        }

        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        U.MsgCatchOue(ex);
        //        return false;
        //    }
        //}
        //private bool ValidarControles()
        //{
        //    try
        //    {
        //        btnModificar.Enabled = false;
        //        errorProvider1.Clear();

        //        // Recalcula importes (si depende de cantidad/descuento)
        //        CalcularImportes();

        //        // Usa decimal, no short (NumericUpDown.Value es decimal)
        //        decimal cantidadNueva = nudCantidad.Value;
        //        decimal cantidadVieja = CantidadOld;         // Asegúrate de que este sea decimal
        //        decimal inventarioViejo = UInventarioOld;    // También en decimal

        //        decimal diferencia = cantidadNueva - cantidadVieja;

        //        // Caso: devolver productos al inventario (diferencia < 0)
        //        if (diferencia < 0)
        //        {
        //            decimal devueltos = -diferencia; // cantidad devuelta
        //            decimal inventarioNuevo = inventarioViejo + devueltos;

        //            // Aplica límites del NumericUpDown para evitar fuera de rango
        //            inventarioNuevo = Math.Min(inventarioNuevo, nudUInventario.Maximum);
        //            inventarioNuevo = Math.Max(inventarioNuevo, nudUInventario.Minimum);

        //            nudUInventario.Value = inventarioNuevo;

        //            if (!ValidarCantidad())
        //                return false;
        //        }
        //        // Caso: retirar productos del inventario (diferencia > 0)
        //        else if (diferencia > 0)
        //        {
        //            decimal retirados = diferencia;
        //            // Validación clave: no puedes retirar más de lo disponible
        //            if (retirados > inventarioViejo)
        //            {
        //                // Actualiza UI para reflejar error y no permitir inventario negativo
        //                nudUInventario.Value = inventarioViejo; // permanece igual
        //                                                        // Puedes setear el error provider aquí si quieres un mensaje inmediato:
        //                                                        // errorProvider1.SetError(nudCantidad, "La cantidad excede el inventario disponible.");

        //                if (!ValidarCantidad())
        //                    return false;
        //            }
        //            else
        //            {
        //                decimal inventarioNuevo = inventarioViejo - retirados;

        //                // Aplica límites del NumericUpDown
        //                inventarioNuevo = Math.Min(inventarioNuevo, nudUInventario.Maximum);
        //                inventarioNuevo = Math.Max(inventarioNuevo, nudUInventario.Minimum);

        //                nudUInventario.Value = inventarioNuevo;

        //                if (!ValidarCantidad())
        //                    return false;
        //            }
        //        }
        //        else
        //        {
        //            // Sin cambios de cantidad: el inventario se queda igual que el viejo
        //            nudUInventario.Value = inventarioViejo;
        //            if (!ValidarCantidad())
        //                return false;
        //        }

        //        // Habilitar el botón Modificar sólo si hay cambios y las validaciones pasaron
        //        bool hayCambios = (nudCantidad.Value != CantidadOld) || (nudDescuento.Value != DescuentoOld);
        //        if (hayCambios)
        //        {
        //            btnModificar.Enabled = true;
        //            return true;
        //        }

        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        U.MsgCatchOue(ex);
        //        return false;
        //    }
        //}

        //private bool ValidarControles()
        //{
        //    try
        //    {
        //        btnModificar.Enabled = false;
        //        errorProvider1.Clear();
        //        CalcularImportes();

        //        short diferencia = 0;
        //        // Calcula la diferencia de cantidad
        //        diferencia = (short)(nudCantidad.Value - CantidadOld);

        //        // Verificar disponibilidad en el inventario
        //        // Aquí manejamos el caso de devolver productos al inventario
        //        if (diferencia <= 0)
        //        {
        //            nudUInventario.Value = Math.Abs(nudCantidad.Value - CantidadOld - UInventarioOld);
        //            if (!ValidarCantidad())
        //                return false;

        //        }
        //        // Aquí manejamos el caso de retirar productos del inventario
        //        else if (diferencia > 0)
        //        {
        //            nudUInventario.Value = UInventarioOld - diferencia;
        //            if (!ValidarCantidad())
        //                return false;
        //        }
        //        // Habilitar el botón Modificar si las cantidades y descuentos son válidos y han cambiado
        //        if (nudCantidad.Value != CantidadOld || nudDescuento.Value != DescuentoOld)
        //        {
        //            btnModificar.Enabled = true;
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        U.MsgCatchOue(ex);
        //        return false;
        //    }
        //}

        private bool ValidarCantidad()
        {
            decimal cantidadNueva = nudCantidad.Value;
            decimal cantidadVieja = CantidadOld;
            decimal inventarioViejo = UInventarioOld;

            // Stock disponible total para este pedido
            decimal disponible = inventarioViejo + cantidadVieja;

            // Inventario remanente REAL en DB después de reservar la nueva cantidad
            decimal inventarioNuevoDb = disponible - cantidadNueva;

            const decimal SmallintMax = 32767M;

            // Condiciones de error
            bool condErrorCantidadCero = cantidadNueva <= 0;
            bool condErrorExcedeInvent = cantidadNueva > disponible;
            bool condErrorOverflowSmall = inventarioNuevoDb > SmallintMax;

            bool showError = condErrorCantidadCero || condErrorExcedeInvent || condErrorOverflowSmall;

            // Construir mensaje acumulado
            string errorMsg = "";
            if (condErrorCantidadCero)
                errorMsg += "La cantidad debe ser mayor que cero.\n";
            if (condErrorExcedeInvent)
                errorMsg += $"La cantidad excede el inventario disponible ({disponible}).\n";
            if (condErrorOverflowSmall)
                errorMsg += "La cantidad de producto devuelto más las unidades en inventario exceden las 32,767 unidades.\n";

            // Información y advertencia
            bool showInfo = cantidadNueva >= 0;
            bool showWarning = nudUInventario.Value >= 0 && nudUInventario.Value <= 50;

            // Mostrar íconos con StatusIconHelper
            StatusIconHelper.ShowIcons(
                nudCantidad,
                toolTip1,
                (pbError, (Image)errorProvider1.Icon.ToBitmap(), errorMsg, showError),
                (pbInfo, (Image)SystemIcons.Information.ToBitmap(),
                    "La cantidad de producto devuelto se añadirá al inventario.\nLa cantidad de producto añadido se descontará del inventario.",
                    showInfo),
                (pbWarning, (Image)SystemIcons.Warning.ToBitmap(),
                    "La existencia en inventario es baja.",
                    showWarning)
            );

            return !showError;
        }

        //private bool ValidarCantidad()
        //{
        //    decimal cantidadNueva = nudCantidad.Value;
        //    decimal cantidadVieja = CantidadOld;
        //    decimal inventarioViejo = UInventarioOld;

        //    // Stock disponible total para este pedido
        //    decimal disponible = inventarioViejo + cantidadVieja;

        //    bool condErrorCantidadCero = cantidadNueva <= 0;
        //    bool condErrorExcedeInvent = cantidadNueva > disponible;

        //    bool showError = condErrorCantidadCero || condErrorExcedeInvent;

        //    string errorMsg = "";
        //    if (condErrorCantidadCero) errorMsg += "La cantidad debe ser mayor que cero.\n";
        //    if (condErrorExcedeInvent) errorMsg += $"La cantidad excede el inventario disponible ({disponible}).\n";

        //    bool showInfo = cantidadNueva >= 0; // ajusta tu regla de info
        //    bool showWarning = nudUInventario.Value >= 0 && nudUInventario.Value <= 50; // ejemplo

        //    StatusIconHelper.ShowIcons(
        //        nudCantidad,
        //        toolTip1,
        //        (pbError, (Image)errorProvider1.Icon.ToBitmap(), errorMsg, showError),
        //        (pbInfo, (Image)SystemIcons.Information.ToBitmap(),
        //            "La cantidad de producto devuelto se añadirá al inventario.\nLa cantidad de producto añadido se descontará del inventario.",
        //            showInfo),
        //        (pbWarning, (Image)SystemIcons.Warning.ToBitmap(),
        //            "La existencia en inventario es baja.",
        //            showWarning)
        //    );

        //    return !showError;
        //}

        //private bool ValidarCantidad()
        //{
        //    bool condError1 = nudCantidad.Value <= 0;
        //    bool condError2 = (nudCantidad.Value - CantidadOld) > nudUInventario.Value;
        //    bool condError3 = nudUInventario.Value > 32767;
        //    bool showError = condError1 || condError2 || condError3;

        //    bool showInfo = nudCantidad.Value >= 0; // tu regla
        //    bool showWarning = nudUInventario.Value >= 0 && nudUInventario.Value <= 50;

        //    string errorMsg = "";
        //    if (condError1) errorMsg += "La cantidad debe ser mayor que cero.\n";
        //    if (condError2) errorMsg += "La cantidad excede el inventario disponible.\n";
        //    if (condError3) errorMsg += "La cantidad de producto devuelto más las unidades en inventario exceden las 32,767 unidades.\n";

        //    StatusIconHelper.ShowIcons(
        //        nudCantidad,
        //        toolTip1,
        //        // Error: usa el ícono del ErrorProvider para que coincida visualmente
        //        (pbError, (Image)errorProvider1.Icon.ToBitmap(), errorMsg, showError),
        //        // Information
        //        (pbInfo, (Image)SystemIcons.Information.ToBitmap(),
        //            "La cantidad de producto devuelto se añadirá al inventario.\nLa cantidad de producto añadido se descontará del inventario.",
        //            showInfo),
        //        // Warning
        //        (pbWarning, (Image)SystemIcons.Warning.ToBitmap(),
        //            "La existencia en inventario es baja.",
        //            showWarning)
        //    );
        //    return !showError;
        //}

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
