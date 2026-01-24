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
        private VentaBLL _ventaBLL;

        public VentaDetalle ventaDetalle;
        private short CantidadOld;
        private decimal DescuentoOld;
        private short UInventarioOld;


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
            LblPrecio.Text = "Precio con IVA incluido " + simboloMoneda + ":";
            LblImporte.Text = "Importe " + simboloMoneda + ":";
            LblImporteDelDecuento.Text = "Importe del descuento " + simboloMoneda + ":";
            LblImporteConDescunto.Text = "Importe con descuento " + simboloMoneda + ":";
            LblImporteSinIVA.Text = "Importe sin IVA " + simboloMoneda + ":";
            LblImporteDelIVA.Text = "Importe del IVA (Incluido) " + simboloMoneda + ":";
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
            nudImporteSinIVA.Value = ventaDetalle.ImporteSinIVA;
            nudImporteDelIVA.Value = ventaDetalle.ImporteDelIVA;
            nudSubtotal.Value = ventaDetalle.Subtotal;
            CantidadOld = ventaDetalle.Quantity;
            DescuentoOld = ventaDetalle.TasaDescuentoPorcentaje;
            UInventarioOld = Convert.ToInt16(nudUInventario.Value);
            DeshabilitarNudsNoSeleccionables();
            CargarValoresOriginales();
            ValidarCantidadEInventarioHelper.ValidarInventario
            (
                nudCantidad.Value,
                CantidadOld,
                UInventarioOld,
                nudUInventario.Value,
                nudUInventario,
                toolTip1,
                pbError1,
                pbInfo1,
                pbWarning1,
                errorProvider1
            );
            ValidarCantidadEInventarioHelper.ValidarCantidad
            (
                nudCantidad.Value,
                CantidadOld,
                UInventarioOld,
                nudUInventario.Value,
                nudCantidad,
                toolTip1,
                pbError,
                pbInfo,
                pbWarning,
                errorProvider1
            );
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
            Utilities.NudHelper.SetEnabled(nudImporteSinIVA, false);
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
                // Recalcula importes
                CalcularImportes();
                InventarioHelper.ActualizarInventarioUi
                (
                    nudCantidad.Value,
                    CantidadOld,
                    UInventarioOld,
                    nudUInventario
                );
                // Validación informativa (inventario)
                // no afecta el retorno, solo muestra íconos
                ValidarCantidadEInventarioHelper.ValidarInventario
                (
                    nudCantidad.Value,
                    CantidadOld,
                    UInventarioOld,
                    nudUInventario.Value,
                    nudUInventario,
                    toolTip1,
                    pbError1,
                    pbInfo1,
                    pbWarning1,
                    errorProvider1
                );
                // Valida reglas de negocio con StatusIconHelper
                // Validación restrictiva (cantidad)
                if (!ValidarCantidadEInventarioHelper.ValidarCantidad
                    (
                        nudCantidad.Value,
                        CantidadOld,
                        UInventarioOld,
                        nudUInventario.Value,
                        nudCantidad,
                        toolTip1,
                        pbError,
                        pbInfo,
                        pbWarning,
                        errorProvider1
                    )
                )
                {
                    return false;
                }
                if (nudSubtotal.Value <= 0)
                {
                    errorProvider1.SetError(nudSubtotal, "El valor del subtotal del producto no puede ser cero.");
                    return false;
                }
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
                nudImporteSinIVA.Value = ventaDetalle.ImporteSinIVA;
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
                    U.NotificacionError(strProductoVenta + Utils.nfmcqn); // El campo Quantity del detalle de la venta es nulo, este caso no ocurre nunca
                else if (numRegs == -6)
                    U.NotificacionError(strProductoVenta + Utils.nfmii); // Stock insuficiente
                else if (numRegs == -7)
                    U.NotificacionError(strProductoVenta + Utils.nfmie); // Stock excedió el máximo permitido
                else if (numRegs == -8)
                    U.NotificacionError(strProductoVenta + Utils.nfmin); // stock negativo, este caso nunca ocurre porque la base de datos no lo permite con un check constraint
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
