using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmVentasDetalleModificar : Form
    {

        string _connectionString = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        private Dictionary<string, object> valoresOriginales;
        private VentaDetalleBLL _ventaDetalleBLL;
        private VentaBLL _ventaBLL;

        public VentaDetalle ventaDetalle { get; set; }
        private short CantidadOld { get; set; }
        private decimal DescuentoOld { get; set; }
        private short UInventarioOld { get; set; }


        public FrmVentasDetalleModificar()
        {
            InitializeComponent();
            _ventaDetalleBLL = new VentaDetalleBLL(_connectionString);
            _ventaBLL = new VentaBLL(_connectionString);
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
            
            txtId.Text = ventaDetalle.Venta.OrderID.ToString();
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
            ValidarInventario();
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
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidarControles()
        {
            try
            {
                btnModificar.Enabled = false;
                errorProvider1.Clear();
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

                // Validación informativa (inventario)
                ValidarInventario(); // no afecta el retorno, solo muestra íconos

                // Valida reglas de negocio con StatusIconHelper
                // Validación restrictiva (cantidad)
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
        // en si ValidarCantidad y ValidarInventario no son precisas en el caso en que otro usuario haya modificado el inventario (por la concurrencia optimista) entre el momento en que se cargó el formulario. Solo funcionarian bien en un entorno monousuario. Por lo que es más seguro que las validaciones se hagan en los stored procedures, como ya estan programados con esas validaciones.
        private bool ValidarCantidad()
        {
            decimal cantidadNueva = nudCantidad.Value;
            decimal cantidadVieja = CantidadOld;
            decimal inventarioViejo = UInventarioOld;

            // Stock disponible total para este pedido
            decimal disponible = inventarioViejo + cantidadVieja;
            // Inventario inicial real (solo lo que había en almacén)
            decimal inventarioInicial = disponible - cantidadVieja;
            // Inventario remanente REAL en DB después de reservar la nueva cantidad
            decimal inventarioNuevoDb = disponible - cantidadNueva;
            decimal inventarioActual = nudUInventario.Value;
            const decimal SmallintMax = 32767M;

            // Condiciones de error
            bool condErrorCantidadCero = cantidadNueva <= 0;
            bool condErrorExcedeInvent = cantidadNueva > disponible;
            bool condErrorInventarioCero = (inventarioActual == 0 && cantidadNueva > disponible);
            bool condErrorOverflowSmall = inventarioNuevoDb > SmallintMax;

            bool showError = condErrorCantidadCero || condErrorExcedeInvent || condErrorInventarioCero || condErrorOverflowSmall;

            // Construir mensaje acumulado
            string errorMsg = "";
            if (condErrorCantidadCero)
                errorMsg += "La cantidad debe ser mayor que cero.\n";
            if (condErrorExcedeInvent)
                errorMsg += $"La cantidad excede el inventario inicial disponible ({inventarioInicial}).\n";
            if (condErrorInventarioCero)
                errorMsg += "El inventario es 0.\n";
            if (condErrorOverflowSmall)
                errorMsg += "La cantidad de producto devuelto más las unidades en inventario\nexcede el límite maximo que se puede almacenar en la base de datos (32,767 unidades).\n No se puede realizar la operación.";

            // Información y advertencia
            bool showInfo = cantidadNueva >= 0;
            // Warnings
            bool condWarningInventarioCero = inventarioActual == 0;
            bool condWarningInventarioBajo = inventarioActual > 0 && inventarioActual <= 50;

            bool showWarning = condWarningInventarioCero || condWarningInventarioBajo;

            string warningMsg = "";
            if (condWarningInventarioCero)
                warningMsg += "El inventario es 0.\n";
            if (condWarningInventarioBajo)
                warningMsg += "La existencia en inventario es baja.\n";

            // Mostrar íconos con StatusIconHelper
            StatusIconHelper.ShowIcons(
                nudCantidad,
                toolTip1,
                (pbError, (Image)errorProvider1.Icon.ToBitmap(), errorMsg, showError),
                (pbInfo, (Image)SystemIcons.Information.ToBitmap(),
                    "La cantidad de producto devuelto se añade al inventario.\nLa cantidad de producto añadido se descuenta del inventario.",
                    showInfo),
                (pbWarning, (Image)SystemIcons.Warning.ToBitmap(),
                    warningMsg,
                    showWarning)
            );

            return !showError;
        }

        private void ValidarInventario()
        {
            decimal cantidadNueva = nudCantidad.Value;
            decimal cantidadVieja = CantidadOld;
            decimal inventarioViejo = UInventarioOld;

            // Stock total disponible para este pedido
            decimal disponible = inventarioViejo + cantidadVieja;
            // Inventario remanente REAL en DB después de reservar la nueva cantidad
            decimal inventarioNuevoDb = disponible - cantidadNueva;
            decimal inventarioActual = nudUInventario.Value;

            const decimal SmallintMax = 32767M;
            
            // Condiciones de error (solo visuales)
            bool condErrorExcedeInvent = cantidadNueva > disponible;
            bool condErrorInventarioCero = (inventarioActual == 0 && cantidadNueva > disponible);
            bool condErrorOverflowSmall = inventarioNuevoDb > SmallintMax;

            bool showError = condErrorExcedeInvent || condErrorInventarioCero || condErrorOverflowSmall;

            string errorMsg = "";
            if (condErrorExcedeInvent)
                errorMsg += $"La cantidad excede el inventario inicial disponible ({disponible - cantidadVieja}).\n";
            if (condErrorInventarioCero)
                errorMsg += "El inventario es 0.\n";
            if (condErrorOverflowSmall)
                errorMsg += "La cantidad de producto devuelto más las unidades en inventario\n" +
                            "excede el límite máximo que se puede almacenar en la base de datos (32,767 unidades).\n" +
                            "No se puede realizar la operación.\n";
            // Información (siempre mostrar)
            bool showInfo = true;

            // Warnings
            bool condWarningInventarioCero = inventarioActual == 0;
            bool condWarningInventarioBajo = inventarioActual > 0 && inventarioActual <= 50;

            bool showWarning = condWarningInventarioCero || condWarningInventarioBajo;

            string warningMsg = "";
            if (condWarningInventarioCero)
                warningMsg += "El inventario es 0.\n";
            if (condWarningInventarioBajo)
                warningMsg += "La existencia en inventario es baja.\n";

            // Mostrar íconos con StatusIconHelper en nudUInventario
            StatusIconHelper.ShowIcons(
                nudUInventario,
                toolTip1,
                (pbError1, (Image)errorProvider1.Icon.ToBitmap(), errorMsg, showError),
                (pbInfo1, (Image)SystemIcons.Information.ToBitmap(),
                    "La cantidad de producto devuelto se añade al inventario.\n" +
                    "La cantidad de producto añadido se descuenta del inventario.",
                    showInfo),
                (pbWarning1, (Image)SystemIcons.Warning.ToBitmap(), warningMsg, showWarning)
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
            int numRegs = 0;
            // No se realiza la validación porque ya se han realizado previamente en el evento leave y valuechanged de 
            // txtdescuento y txtcantidad
            try
            {
                btnModificar.Enabled = false;
                MDIPrincipal.ActualizarBarraDeEstado(Utils.modificandoRegistro);
                VentaDetalle ventaDetalleModificacion = new VentaDetalle
                {
                    Venta = new Venta() 
                    { 
                        OrderID = ventaDetalle.Venta.OrderID,
                        RowVersion = ventaDetalle.Venta.RowVersion
                    },
                    Producto = new Producto() { ProductID = ventaDetalle.Producto.ProductID },
                    Quantity = short.Parse(nudCantidad.Value.ToString()),
                    Discount = decimal.Parse((nudDescuento.Value / 100).ToString()),
                    RowVersion = ventaDetalle.RowVersion
                };
                numRegs = _ventaDetalleBLL.Actualizar(ventaDetalleModificacion);
                string strProductoVenta = $"El producto: {ventaDetalle.ProductName} - Venta: {ventaDetalle.Venta.OrderID}:";
                string strVenta = $"La venta con Id: {ventaDetalle.Venta.OrderID}:";
                if (numRegs > 0)
                {
                    // deja que continue el proceso para cerrar el formulario
                }
                else if (numRegs == -1)
                    U.NotificacionError(strProductoVenta + Utils.nfmfe);
                else if (numRegs == -2)
                    U.NotificacionError(strProductoVenta + Utils.nfmfm);
                else if (numRegs == -3)
                    U.NotificacionError(strVenta + Utils.fepou);
                else if (numRegs == -4)
                    U.NotificacionError(strProductoVenta + "\n[red]No fue actualizado en la base de datos.\n" + strVenta + Utils.fmpou);
                else if (numRegs == -5)
                    U.NotificacionError(strProductoVenta + Utils.nfmcqn); // El campo Quantity del detalle de la venta es nulo
                else if (numRegs == -6)
                    U.NotificacionError(strProductoVenta + Utils.nfmii); // Stock insuficiente
                else if (numRegs == -7)
                    U.NotificacionError(strProductoVenta + Utils.nfmie); // Stock excedió el máximo permitido
                else if (numRegs == -8)
                    U.NotificacionError(strProductoVenta + Utils.nfmin); // stock negativo
                else
                    U.NotificacionError(strProductoVenta + Utils.nfmmd);
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
                DialogResult = DialogResult.Cancel;
                CargarValoresOriginales();
                this.Close();
                return;
            }
            // La siguientes linea es necesaria para que se permita cerrar la ventana. 
            // ya que se validan las variables en FrmPedidosDetalleModificar_FormClosing
            CargarValoresOriginales();
            if (numRegs == -3)
                DialogResult = DialogResult.Cancel;
            else
                DialogResult = DialogResult.OK;
            this.Close();
        }

        private void nudCantidad_Leave(object sender, EventArgs e) => ValidarControles();

        private void nudDescuento_Leave(object sender, EventArgs e) => ValidarControles();

        private void nudCantidad_ValueChanged(object sender, EventArgs e) => ValidarControles();

        private void nudDescuento_ValueChanged(object sender, EventArgs e) => ValidarControles();

        private void Nud_Enter(object sender, EventArgs e)
        {
            if (sender is NumericUpDown nud && nud.Controls[1] is TextBox tb)
            {
                // Diferir la selección para que ocurra después de que el TextBox reciba el foco
                tb.BeginInvoke((Action)(() => tb.SelectAll()));
            }
        }
    }
}
