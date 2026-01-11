using BLL;
using BLL.Services;
using Entities;
using Entities.DTOs;
using NorthwindTradersV5EnCapas.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmVentasDetalleCrud : Form
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        int numDetalle = 1;
        private Dictionary<string, object> valoresOriginales;
        private VentaBLL _ventaBLL;
        private VentaDetalleBLL _ventaDetalleBLL;
        private readonly CategoriaService _categoriaService;
        private ProductoService _productoService;

        public FrmVentasDetalleCrud()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _ventaBLL = new VentaBLL(_connectionString);
            _ventaDetalleBLL = new VentaDetalleBLL(_connectionString);
            _categoriaService = new CategoriaService(_connectionString);
            _productoService = new ProductoService(_connectionString);
        }

        private void GrbPaint(object sender, PaintEventArgs e) => Utils.GrbPaint(this, sender, e);

        private void FrmVentasDetalleCrud_FormClosed(object sender, FormClosedEventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void FrmVentasDetalleCrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Utils.HayCambios(this, valoresOriginales, errorProvider1))
                if (U.NotificacionQuestion(Utils.preguntaCerrar) == DialogResult.No)
                    e.Cancel = true;
        }

        private void FrmVentasDetalleCrud_Load(object sender, EventArgs e)
        {
            DeshabilitarControles();
            // Obtener el símbolo de moneda según la configuración regional del equipo
            string simboloMoneda = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
            // Mostrarlo en el Label
            LblPrecio.Text = "Precio " + simboloMoneda + ":";
            LblSubtotalDelImporte.Text = "Subtotal del importe " + simboloMoneda + ":";
            LblSubtotalDelImporteDelDescuento.Text = "Subtotal del importe del descuento " + simboloMoneda + ":";
            LblSubtotalDelImporteConDescuento.Text = "Subtotal del importe con descuento " + simboloMoneda + ":";
            LblSubtotalDelImporteDelIVA.Text = "Subtotal del importe del IVA " + simboloMoneda + ":";
            LblTotal.Text = "Total " + simboloMoneda + ":";
            LlenarCboCategoria();
            LlenarDgvVentas(false);
            Utils.ConfDgv(DgvVentas);
            Utils.ConfDgv(DgvDetalle);
            ConfDgvVentas();
            ConfDgvDetalle();
            DeshabilitarNudsNoSeleccionables();
            InicializarCboProducto();
            CargarValoresOriginales();
            DgvDetalle.Columns["Modificar"].Visible = false;
            DgvDetalle.Columns["Eliminar"].Visible = false;
        }

        private void CargarValoresOriginales()
        {
            valoresOriginales = Utils.CapturarValoresOriginales(this);
        }

        private void DeshabilitarNudsNoSeleccionables()
        {
            Utilities.NudHelper.SetEnabled(nudPrecio, false);
            Utilities.NudHelper.SetEnabled(nudUInventario, false);
            Utilities.NudHelper.SetEnabled(nudNumProd, false);
            Utilities.NudHelper.SetEnabled(nudTotalDeUnidades, false);
            Utilities.NudHelper.SetEnabled(nudSubtotalDelImporte, false);
            Utilities.NudHelper.SetEnabled(nudSubtotalDelImporteDelDescuento, false);
            Utilities.NudHelper.SetEnabled(nudSubtotalDelImporteConDescuento, false);
            Utilities.NudHelper.SetEnabled(nudSubtotalDelImporteDelIVA, false);
            Utilities.NudHelper.SetEnabled(nudTotal, false);
        }

        private void DeshabilitarCantidadDescuento()
        {
            Utilities.NudHelper.SetEnabled(nudCantidad, false);
            Utilities.NudHelper.SetEnabled(nudDescuento, false);
        }

        private void HabilitarCantidadDescuento()
        {
            Utilities.NudHelper.SetEnabled(nudCantidad, true);
            Utilities.NudHelper.SetEnabled(nudDescuento, true);
        }

        private void InicializarCboProducto()
        {
            DataTable dtCboProductos = new DataTable();
            dtCboProductos.Columns.Add("ProductID", typeof(int));
            dtCboProductos.Columns.Add("ProductName", typeof(string));
            DataRow dr = dtCboProductos.NewRow();
            dr["ProductID"] = 0;
            dr["ProductName"] = "«--- Seleccione ---»";
            dtCboProductos.Rows.Add(dr);
            cboProducto.DataSource = dtCboProductos;
            cboProducto.DisplayMember = "ProductName";
            cboProducto.ValueMember = "ProductID";
            cboProducto.Enabled = false;
        }

        private void InicializarNuds() 
        { 
            nudNumProd.Value = nudTotalDeUnidades.Value = nudSubtotalDelImporte.Value = nudSubtotalDelImporteDelDescuento.Value = nudSubtotalDelImporteConDescuento.Value = nudSubtotalDelImporteDelIVA.Value = nudTotal.Value = 0;
        }

        private void DeshabilitarControles()
        {
            cboCategoria.Enabled = cboProducto.Enabled = false;
            btnAgregar.Enabled = false;
        }

        private void HabilitarControles()
        {
            cboCategoria.Enabled = cboProducto.Enabled = true;
            btnAgregar.Enabled = true;
        }

        private void DeshabilitarControlesProducto() => DeshabilitarCantidadDescuento();

        private void HabilitarControlesProducto() => HabilitarCantidadDescuento();

        private void LlenarCboCategoria()
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var dtCboCategoria = _categoriaService.ObtenerCategoriasCbo();
                ComboBoxHelper.LlenarCbo(cboCategoria, dtCboCategoria, "CategoryName", "CategoryID");
                MDIPrincipal.ActualizarBarraDeEstado();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

        private void LlenarDgvVentas(bool selectorRealizaBusqueda)
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                DtoVentasBuscar criterios;
                if (selectorRealizaBusqueda == true)
                {
                    criterios = new DtoVentasBuscar
                    {
                        IdIni = Convert.ToInt32(nudBIdIni.Value),
                        IdFin = Convert.ToInt32(nudBIdFin.Value),
                        Cliente = txtBCliente.Text.Trim(),

                        FVenta = dtpBFVentaIni.Checked && dtpBFVentaFin.Checked,
                        FVentaIni = (dtpBFVentaIni.Checked && dtpBFVentaFin.Checked) ? dtpBFVentaIni.Value.Date : (DateTime?)null,
                        FVentaFin = (dtpBFVentaIni.Checked && dtpBFVentaFin.Checked) ? dtpBFVentaFin.Value.Date.AddDays(1) : (DateTime?)null,
                        FVentaNull = chkbBFVentaNull.Checked,

                        FRequerido = dtpBFRequeridoIni.Checked && dtpBFRequeridoFin.Checked,
                        FRequeridoIni = (dtpBFRequeridoIni.Checked && dtpBFRequeridoFin.Checked) ? dtpBFRequeridoIni.Value.Date : (DateTime?)null,
                        FRequeridoFin = (dtpBFRequeridoIni.Checked && dtpBFRequeridoFin.Checked) ? dtpBFRequeridoFin.Value.Date.AddDays(1) : (DateTime?)null,
                        FRequeridoNull = chkbBFRequeridoNull.Checked,

                        FEnvio = dtpBFEnvioIni.Checked && dtpBFEnvioFin.Checked,
                        FEnvioIni = (dtpBFEnvioIni.Checked && dtpBFEnvioFin.Checked) ? dtpBFEnvioIni.Value.Date : (DateTime?)null,
                        FEnvioFin = (dtpBFEnvioIni.Checked && dtpBFEnvioFin.Checked) ? dtpBFEnvioFin.Value.Date.AddDays(1) : (DateTime?)null,
                        FEnvioNull = chkbBFEnvioNull.Checked,

                        Empleado = txtBEmpleado.Text.Trim(),
                        CompañiaT = txtBCompañiaT.Text.Trim(),
                        DirigidoA = txtBDirigidoa.Text.Trim()
                    };
                }
                else
                    criterios = null;
                var ventas = _ventaBLL.ObtenerVentas(selectorRealizaBusqueda, criterios, false);
                DgvVentas.DataSource = ventas;
                if (!selectorRealizaBusqueda)
                    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran las últimas {DgvVentas.RowCount} venta(s) registrada(s)");
                else
                    MDIPrincipal.ActualizarBarraDeEstado($"Se encontraron {DgvVentas.RowCount} registro(s)");
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

        private void ConfDgvVentas()
        {
            DgvVentas.Columns["RowVersionStr"].Visible = false;
            DgvVentas.Columns["OrderID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DgvVentas.Columns["OrderDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvVentas.Columns["RequiredDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvVentas.Columns["ShippedDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvVentas.Columns["ShipperCompanyName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvVentas.Columns["EmployeeName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DgvVentas.Columns["OrderDate"].DefaultCellStyle.Format = "ddd dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";
            DgvVentas.Columns["RequiredDate"].DefaultCellStyle.Format = "ddd dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";
            DgvVentas.Columns["ShippedDate"].DefaultCellStyle.Format = "ddd dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";

            DgvVentas.Columns["OrderID"].HeaderText = "Id";
            DgvVentas.Columns["CustomerCompanyName"].HeaderText = "Cliente";
            DgvVentas.Columns["CustomerContactName"].HeaderText = "Nombre de contacto";
            DgvVentas.Columns["OrderDate"].HeaderText = "Fecha de venta";
            DgvVentas.Columns["RequiredDate"].HeaderText = "Fecha de entrega";
            DgvVentas.Columns["ShippedDate"].HeaderText = "Fecha de envío";
            DgvVentas.Columns["EmployeeName"].HeaderText = "Vendedor";
            DgvVentas.Columns["ShipperCompanyName"].HeaderText = "Compañía transportista";
            DgvVentas.Columns["ShipName"].HeaderText = "Enviar a";
        }

        private void ConfDgvDetalle()
        {
            DgvDetalle.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvDetalle.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvDetalle.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvDetalle.Columns["Descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvDetalle.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvDetalle.Columns["ImporteDelDescuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvDetalle.Columns["ImporteConDescuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvDetalle.Columns["TasaIVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvDetalle.Columns["ImporteDelIVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvDetalle.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DgvDetalle.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["Precio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["Importe"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["Descuento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["ImporteDelDescuento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["ImporteConDescuento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["TasaIVA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["ImporteDelIVA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["Subtotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["Eliminar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DgvDetalle.Columns["ImporteDelDescuento"].HeaderText = "Importe\ndel\ndescuento";
            DgvDetalle.Columns["ImporteConDescuento"].HeaderText = "Importe\ncon\ndescuento";

            DgvDetalle.Columns["Modificar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            DgvDetalle.Columns["Eliminar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            DgvDetalle.Columns["Precio"].DefaultCellStyle.Format = "c2";
            DgvDetalle.Columns["Cantidad"].DefaultCellStyle.Format = "n0";
            DgvDetalle.Columns["Descuento"].DefaultCellStyle.Format = "p2";
            DgvDetalle.Columns["Importe"].DefaultCellStyle.Format = "c2";
            DgvDetalle.Columns["ImporteDelDescuento"].DefaultCellStyle.Format = "c2";
            DgvDetalle.Columns["ImporteConDescuento"].DefaultCellStyle.Format = "c2";
            DgvDetalle.Columns["TasaIVA"].DefaultCellStyle.Format = "p2";
            DgvDetalle.Columns["ImporteDelIVA"].DefaultCellStyle.Format = "c2";
            DgvDetalle.Columns["Subtotal"].DefaultCellStyle.Format = "c2";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            BorrarDatosVenta();
            BorrarDatosDetalleVenta();
            BorrarMensajesError();
            BorrarDatosBusqueda();
            DeshabilitarControles();
            BtnNota.Enabled = false;
            LlenarDgvVentas(false);
            DgvVentas.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BorrarDatosVenta();
            BorrarDatosDetalleVenta();
            BorrarMensajesError();
            DeshabilitarControles();
            BtnNota.Enabled = false;
            LlenarDgvVentas(true);
            DgvVentas.Focus();
        }

        private void BorrarDatosVenta()
        {
            errorProvider1.Clear();
            txtId.Text = txtCliente.Text = "";
            txtId.Tag = null;
            InicializarValoresAgregarProducto();
            InicializarCboProducto();
            cboCategoria.SelectedIndex = 0;
            DgvDetalle.Rows.Clear();
        }

        private void BorrarMensajesError() => errorProvider1.Clear();

        private bool ValidarControles()
        {
            bool valida = true;
            if (cboCategoria.SelectedIndex <= 0)
            {
                valida = false;
                errorProvider1.SetError(cboCategoria, "Seleccione la categoría");
            }
            if (cboProducto.SelectedIndex <= 0)
            {
                valida = false;
                errorProvider1.SetError(cboProducto, "Seleccione el producto");
            }
            if (nudCantidad.Value <= 0)
            {
                valida = false;
                errorProvider1.SetError(nudCantidad, "La cantidad debe ser mayor que cero");
            }
            if (nudCantidad.Value > nudUInventario.Value)
            {
                valida = false;
                errorProvider1.SetError(nudCantidad, "La cantidad de productos en la venta excede el inventario disponible");
            }
            if (cboProducto.SelectedIndex > 0)
            {
                int numProd = int.Parse(cboProducto.SelectedValue.ToString());
                bool productoDuplicado = false;
                foreach (DataGridViewRow dgvr in DgvDetalle.Rows)
                {
                    if (int.Parse(dgvr.Cells["ProductoId"].Value.ToString()) == numProd)
                    {
                        productoDuplicado = true;
                        break;
                    }
                }
                if (productoDuplicado)
                {
                    valida = false;
                    errorProvider1.SetError(cboProducto, "No se puede tener un producto duplicado en el detalle del pedido");
                }
            }
            // necesario crear un objeto temporal para calcular el subtotal con la formulas ya definidas en la clase VentaDetalle
            VentaDetalle ventaDetalle = new VentaDetalle();
            ventaDetalle.UnitPrice = nudPrecio.Value;
            ventaDetalle.Quantity = (short)nudCantidad.Value;
            ventaDetalle.Discount = nudDescuento.Value / 100m;
            if (ventaDetalle.Subtotal == 0 && nudTotal.Value == 0)
            { 
                valida = false;
                if (nudCantidad.Value == 0)
                    errorProvider1.SetError(btnAgregar, "Ingrese el detalle del pedido");
                else if (ventaDetalle.Subtotal == 0)
                    errorProvider1.SetError(btnAgregar, "El valor del subtotal del detalle no puede ser cero");
                errorProvider1.SetError(nudTotal, "El total de la venta no puede ser cero");
            }
            return valida;
        }

        private void BorrarDatosBusqueda()
        {
            nudBIdIni.Value = nudBIdFin.Value = 0;
            txtBCliente.Text = txtBEmpleado.Text = txtBCompañiaT.Text = txtBDirigidoa.Text = "";
            dtpBFVentaIni.Checked = dtpBFVentaFin.Checked = dtpBFRequeridoIni.Checked = dtpBFRequeridoFin.Checked = dtpBFEnvioIni.Checked = dtpBFEnvioFin.Checked = false;
            chkbBFVentaNull.Checked = chkbBFRequeridoNull.Checked = chkbBFEnvioNull.Checked = false;
        }

        #region eventosDeControles

        private void Nud_Enter(object sender, EventArgs e)
        {
            if (sender is NumericUpDown nud && nud.Controls[1] is TextBox tb)
            {
                // Diferir la selección para que ocurra después de que el TextBox reciba el foco
                tb.BeginInvoke((Action)(() => tb.SelectAll()));
            }
        }

        private void nudBIdIni_Leave(object sender, EventArgs e) => Utils.ValidarRango(sender, nudBIdIni, nudBIdFin);

        private void nudBIdFin_Leave(object sender, EventArgs e) => Utils.ValidarRango(sender, nudBIdIni, nudBIdFin);

        private void nudBIdIni_ValueChanged(object sender, EventArgs e) => Utils.ValidarRango(sender, nudBIdIni, nudBIdFin);

        private void nudBIdFin_ValueChanged(object sender, EventArgs e) => Utils.ValidarRango(sender, nudBIdIni, nudBIdFin);

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (nudCantidad.Value > nudUInventario.Value)
            {
                U.NotificacionWarning("La cantidad de unidades vendidas no puede ser mayor a la existencia en inventario");
                nudCantidad.Value = nudUInventario.Value;
            }
        }
        
        private void dtpBFPedidoIni_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBFVentaIni.Checked)
            {
                dtpBFVentaFin.Checked = true;
                chkbBFVentaNull.Checked = false;
            }
            else
                dtpBFVentaFin.Checked = false;
        }

        private void dtpBFPedidoFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBFVentaFin.Checked)
            {
                dtpBFVentaIni.Checked = true;
                chkbBFVentaNull.Checked = false;
            }
            else
                dtpBFVentaIni.Checked = false;
        }

        private void dtpBFRequeridoIni_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBFRequeridoIni.Checked)
            {
                dtpBFRequeridoFin.Checked = true;
                chkbBFRequeridoNull.Checked = false;
            }
            else
                dtpBFRequeridoFin.Checked = false;
        }

        private void dtpBFRequeridoFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBFRequeridoFin.Checked)
            {
                dtpBFRequeridoIni.Checked = true;
                chkbBFRequeridoNull.Checked = false;
            }
            else
                dtpBFRequeridoIni.Checked = false;
        }

        private void dtpBFEnvioIni_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBFEnvioIni.Checked)
            {
                dtpBFEnvioFin.Checked = true;
                chkbBFEnvioNull.Checked = false;
            }
            else
                dtpBFEnvioFin.Checked = false;
        }

        private void dtpBFEnvioFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBFEnvioFin.Checked)
            {
                dtpBFEnvioIni.Checked = true;
                chkbBFEnvioNull.Checked = false;
            }
            else
                dtpBFEnvioIni.Checked = false;
        }

        private void chkbBFVentaNull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbBFVentaNull.Checked)
            {
                dtpBFVentaIni.Checked = false;
                dtpBFVentaFin.Checked = false;
            }
        }

        private void chkbBFRequeridoNull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbBFRequeridoNull.Checked)
            {
                dtpBFRequeridoIni.Checked = false;
                dtpBFRequeridoFin.Checked = false;
            }
        }

        private void chkbBFEnvioNull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbBFEnvioNull.Checked)
            {
                dtpBFEnvioIni.Checked = false;
                dtpBFEnvioFin.Checked = false;
            }
        }

        private void dtpBFVentaIni_Leave(object sender, EventArgs e)
        {
            if (dtpBFVentaIni.Checked && dtpBFVentaFin.Checked)
                if (dtpBFVentaFin.Value < dtpBFVentaIni.Value)
                    dtpBFVentaFin.Value = dtpBFVentaIni.Value;
        }

        private void dtpBFVentaFin_Leave(object sender, EventArgs e)
        {
            if (dtpBFVentaIni.Checked && dtpBFVentaFin.Checked)
                if (dtpBFVentaFin.Value < dtpBFVentaIni.Value)
                    dtpBFVentaIni.Value = dtpBFVentaFin.Value;
        }

        private void dtpBFRequeridoIni_Leave(object sender, EventArgs e)
        {
            if (dtpBFRequeridoIni.Checked && dtpBFRequeridoFin.Checked)
                if (dtpBFRequeridoFin.Value < dtpBFRequeridoIni.Value)
                    dtpBFRequeridoFin.Value = dtpBFRequeridoIni.Value;
        }

        private void dtpBFRequeridoFin_Leave(object sender, EventArgs e)
        {
            if (dtpBFRequeridoIni.Checked && dtpBFRequeridoFin.Checked)
                if (dtpBFRequeridoFin.Value < dtpBFRequeridoIni.Value)
                    dtpBFRequeridoIni.Value = dtpBFRequeridoFin.Value;
        }

        private void dtpBFEnvioIni_Leave(object sender, EventArgs e)
        {
            if (dtpBFEnvioIni.Checked && dtpBFEnvioFin.Checked)
                if (dtpBFEnvioFin.Value < dtpBFEnvioIni.Value)
                    dtpBFEnvioFin.Value = dtpBFEnvioIni.Value;
        }

        private void dtpBFEnvioFin_Leave(object sender, EventArgs e)
        {
            if (dtpBFEnvioIni.Checked && dtpBFEnvioFin.Checked)
                if (dtpBFEnvioFin.Value < dtpBFEnvioIni.Value)
                    dtpBFEnvioIni.Value = dtpBFEnvioFin.Value;
        }

        #endregion

        private void InicializarValoresAgregarProducto() => nudPrecio.Value = nudCantidad.Value = nudUInventario.Value = nudDescuento.Value = 0;

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            InicializarValoresAgregarProducto();
            BorrarMensajesError();
            if (cboCategoria.SelectedIndex > 0)
            {
                try
                {
                    MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                    var dtCboProductos = _productoService.ObtenerProductosPorCategoriaCbo(int.Parse(cboCategoria.SelectedValue.ToString()));
                    cboProducto.DataSource = dtCboProductos;
                    cboProducto.DisplayMember = "ProductName";
                    cboProducto.ValueMember = "ProductID";
                    cboProducto.Enabled = true;
                    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {DgvVentas.RowCount} registro(s) en ventas");
                }
                catch (Exception ex)
                {
                    U.MsgCatchOue(ex);
                }
            }
            else
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                InicializarCboProducto();
                MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {DgvVentas.RowCount} registro(s) en ventas");
            }
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            BorrarMensajesError();
            if (cboProducto.SelectedIndex > 0)
            {
                try
                {
                    MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                    var productId = cboProducto.SelectedValue?.ToString();
                    InicializarValoresAgregarProducto();
                    var dtoProductoCostoInventario = _productoService.ObtenerProductoCostoEInventario(int.Parse(productId));
                    if (dtoProductoCostoInventario != null)
                    {
                        nudPrecio.Value = dtoProductoCostoInventario.UnitPrice;
                        nudUInventario.Value = dtoProductoCostoInventario.UnitsInStock;
                        if (dtoProductoCostoInventario.UnitsInStock == 0)
                        {
                            DeshabilitarControlesProducto();
                            U.NotificacionWarning("No hay este producto en existencia");
                            cboProducto.SelectedIndex = 0;
                            InicializarValoresAgregarProducto();
                        }
                        else
                            HabilitarControlesProducto();
                    }
                    else
                    {
                        DeshabilitarControlesProducto();
                        InicializarValoresAgregarProducto();
                        InicializarCboProducto();
                    }
                    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {DgvVentas.RowCount} registro(s) en ventas");
                }
                catch (Exception ex)
                {
                    U.MsgCatchOue(ex);
                }
            }
            else
            {
                DeshabilitarControlesProducto();
                InicializarValoresAgregarProducto();
            }
        }

        private void DgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            BtnNota.Enabled = false;
            BorrarDatosVenta();
            BorrarDatosDetalleVenta();
            BorrarMensajesError();
            DataGridViewRow dgvr = DgvVentas.CurrentRow;
            txtId.Text = dgvr.Cells["OrderId"].Value.ToString();
            txtCliente.Text = dgvr.Cells["CustomerCompanyName"].Value.ToString();
            txtId.Tag = dgvr.Cells["RowVersionStr"].Value;
            int orderId = string.IsNullOrEmpty(txtId.Text) ? 0 : Convert.ToInt32(txtId.Text);
            LlenarDatosVenta(ref orderId);
            LlenarDatosDetalleVenta(orderId);
            if (orderId != 0)
                HabilitarControles();
            else
            {
                DeshabilitarControles();
                BorrarDatosVenta();
            }
            CargarValoresOriginales();
        }

        private void LlenarDatosVenta(ref int orderId)
        {
            if (orderId == 0) return;
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var venta = _ventaBLL.ObtenerVentaPorId(orderId);
                if (venta != null)
                {
                    txtId.Text = venta.OrderID.ToString();
                    txtCliente.Text = venta.Cliente.CompanyName;
                    txtId.Tag = venta.RowVersionStr;
                    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {DgvVentas.RowCount} registro(s) en ventas");
                }
                else
                {
                    txtId.Text = string.Empty;
                    txtId.Tag = null;
                    orderId = 0;
                    U.NotificacionWarning("[orange]No se encontró la venta especificada." + Utils.erfep);
                }
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

        private void LlenarDatosDetalleVenta(int orderId)
        {
            if (orderId == 0) return;
            try
            {
                numDetalle = 1;
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var detalles = _ventaDetalleBLL.ObtenerVentaDetallePorVentaId(orderId);
                if (detalles.Count == 0)
                {
                    DgvDetalle.Columns["Modificar"].Visible = false;
                    DgvDetalle.Columns["Eliminar"].Visible = false;
                    U.NotificacionWarning("No se encontraron detalles para la venta especificada");
                }
                else
                {
                    DgvDetalle.Columns["Modificar"].Visible = true;
                    DgvDetalle.Columns["Eliminar"].Visible = true;
                    foreach (var ventaDetalle in detalles)
                    {
                        DgvDetalle.Rows.Add(new object[]
                        {
                            numDetalle,
                            ventaDetalle.Producto.ProductName,
                            ventaDetalle.UnitPrice,
                            ventaDetalle.Quantity,
                            ventaDetalle.Importe,
                            ventaDetalle.Discount,
                            ventaDetalle.ImporteDelDescuento,
                            ventaDetalle.ImporteConDescuento,
                            ventaDetalle.TasaIVA,
                            ventaDetalle.ImporteDelIVA,
                            ventaDetalle.Subtotal,
                            "  Modificar  ",
                            "  Eliminar  ",
                            ventaDetalle.Producto.ProductID,
                            ventaDetalle.RowVersion
                        });
                        ++numDetalle;
                    }
                }
                CalcularTotales();
                MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {DgvVentas.RowCount} registro(s) en ventas");
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

        private void CalcularTotales()
        {
            decimal importe, total, totalDeUnidades, subtotalDelImporte, subtotalDelImporteDelDescuento, subtotalDelImporteConDescuento, subtotalDelImporteDelIVA;
            importe = total = totalDeUnidades = subtotalDelImporte = subtotalDelImporteDelDescuento = subtotalDelImporteConDescuento = subtotalDelImporteDelIVA = 0;
            numDetalle = 0;
            foreach (DataGridViewRow dgvr in DgvDetalle.Rows)
            {
                totalDeUnidades += decimal.Parse(dgvr.Cells["Cantidad"].Value.ToString());
                subtotalDelImporte += Math.Round(decimal.Parse(dgvr.Cells["Importe"].Value.ToString()), 2, MidpointRounding.AwayFromZero);
                subtotalDelImporteDelDescuento += Math.Round(decimal.Parse(dgvr.Cells["ImporteDelDescuento"].Value.ToString()), 2, MidpointRounding.AwayFromZero);
                subtotalDelImporteConDescuento += Math.Round(decimal.Parse(dgvr.Cells["ImporteConDescuento"].Value.ToString()), 2, MidpointRounding.AwayFromZero);
                subtotalDelImporteDelIVA += Math.Round(decimal.Parse(dgvr.Cells["ImporteDelIVA"].Value.ToString()), 2, MidpointRounding.AwayFromZero);
                total += Math.Round(decimal.Parse(dgvr.Cells["Subtotal"].Value.ToString()), 2, MidpointRounding.AwayFromZero);
                dgvr.Cells["Id"].Value = ++numDetalle;
            }
            nudNumProd.Value = numDetalle;
            nudTotalDeUnidades.Value = totalDeUnidades;
            nudSubtotalDelImporte.Value = subtotalDelImporte;
            nudSubtotalDelImporteDelDescuento.Value = subtotalDelImporteDelDescuento;
            nudSubtotalDelImporteConDescuento.Value = subtotalDelImporteConDescuento;
            nudSubtotalDelImporteDelIVA.Value = subtotalDelImporteDelIVA;
            nudTotal.Value = total;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int numRegs = 0;
            BorrarMensajesError();
            if (ValidarControles())
            {
                try
                {
                    MDIPrincipal.ActualizarBarraDeEstado(Utils.insertandoRegistro);
                    DeshabilitarControles();
                    DeshabilitarControlesProducto();
                    VentaDetalle ventaDetalle = new VentaDetalle();
                    ventaDetalle.Venta.OrderID = int.Parse(txtId.Text);
                    ventaDetalle.Producto.ProductID = int.Parse(cboProducto.SelectedValue.ToString());
                    ventaDetalle.UnitPrice = nudPrecio.Value;
                    ventaDetalle.Quantity = Convert.ToInt16(nudCantidad.Value);
                    ventaDetalle.Discount = nudDescuento.Value / 100m;
                    ventaDetalle.Producto.ProductName = cboProducto.Text;
                    numRegs = _ventaDetalleBLL.Insertar(ventaDetalle);
                    string strProductoVenta = $"El producto: {ventaDetalle.ProductName} - Venta: {ventaDetalle.Venta.OrderID}:";
                    string strVenta = $"La venta con Id: {ventaDetalle.Venta.OrderID}:";
                    if (numRegs > 0)
                    {
                        int orderId = string.IsNullOrEmpty(txtId.Text) ? 0 : Convert.ToInt32(txtId.Text);
                        BorrarDatosVenta();
                        BorrarDatosDetalleVenta();
                        LlenarDatosVenta(ref orderId); // necesario para actualizar el RowVersion de la venta
                        LlenarDatosDetalleVenta(orderId);
                        MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {DgvVentas.RowCount} registro(s) en ventas");
                        BtnNota.Enabled = true;
                        DgvDetalle.Focus();
                    }
                    else if (numRegs == -1)
                        U.NotificacionError(strProductoVenta + Utils.nfrfa);
                    else if (numRegs == -3)
                        U.NotificacionError(strVenta + Utils.fepou);
                    else if (numRegs == -4)
                        U.NotificacionError(strProductoVenta + "\n[red]No fue registrado en la base de datos.\n" + strVenta + Utils.fmpou);
                    else if (numRegs == -6)
                        U.NotificacionError(strProductoVenta + Utils.nfrii); // Stock insuficiente
                    else if (numRegs == -7)
                        U.NotificacionError(strProductoVenta + Utils.nfrie); // Stock excedió el máximo permitido
                    else if (numRegs == -8)
                        U.NotificacionError(strProductoVenta + Utils.nfrin); // stock negativo
                    else
                        U.NotificacionError(strProductoVenta + Utils.nfrs); // motivo desconocido
                    HabilitarControles();
                    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {DgvVentas.RowCount} registro(s) en ventas");
                }
                catch (Exception ex)
                {
                    U.MsgCatchOue(ex);
                }
            }
        }

        private void BorrarDatosAgregarProducto()
        {
            cboCategoria.SelectedIndex = 0;
            InicializarCboProducto();
            InicializarValoresAgregarProducto();
        }

        private void BorrarDatosDetalleVenta()
        {
            cboCategoria.SelectedIndex = 0;
            cboProducto.DataSource = null;
            InicializarValoresAgregarProducto();
            InicializarCboProducto();
            InicializarNuds();
            DgvDetalle.Rows.Clear();
        }

        private void DgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                if (e.ColumnIndex == DgvDetalle.Columns["Eliminar"].Index)
                {
                    DataGridViewRow dgvr = DgvDetalle.CurrentRow;
                    VentaDetalle ventaDetalle = new VentaDetalle();
                    ventaDetalle.Venta.OrderID = int.Parse(txtId.Text);
                    ventaDetalle.Producto.ProductID = (int)dgvr.Cells["ProductoId"].Value;
                    ventaDetalle.Producto.ProductName = dgvr.Cells["Producto"].Value.ToString();
                    object cellValue = dgvr.Cells["RowVersion"].Value;
                    if (cellValue == null || cellValue == DBNull.Value) // para evitar excepcion devuelve null si el valor es dbnull
                        ventaDetalle.RowVersion = null;
                    else
                        ventaDetalle.RowVersion = (byte[])cellValue;
                    if (txtId.Tag != null && long.TryParse(txtId.Tag.ToString(), out long valor)) // para evitar excepcion devuelve null si el valor no es convertible a long
                    {
                        ventaDetalle.Venta.RowVersion = BitConverter.GetBytes(valor);
                    }
                    else
                    {
                        ventaDetalle.Venta.RowVersion = null; // o manejar el error según tu lógica
                    }
                    EliminarProducto(ventaDetalle);
                    BtnNota.Enabled = true;
                }
                if (e.ColumnIndex == DgvDetalle.Columns["Modificar"].Index)
                {
                    DataGridViewRow dgvr = DgvDetalle.CurrentRow;
                    using (FrmVentasDetalleModificar frmVentasDetalleModificar = new FrmVentasDetalleModificar())
                    {
                        VentaDetalle ventaDetalle = new VentaDetalle()
                        {
                            Venta = new Venta()
                            {
                                OrderID = int.Parse(txtId.Text),
                                RowVersion = (txtId.Tag != null && long.TryParse(txtId.Tag.ToString(), out long tagVal))
                                                ? BitConverter.GetBytes(tagVal)
                                                : null // para evitar excepcion devuelve null si el valor no es convertible a long
                            },
                            Producto = new Producto()
                            {
                                ProductID = (int)dgvr.Cells["ProductoId"].Value,
                                ProductName = dgvr.Cells["Producto"].Value.ToString()
                            },
                            UnitPrice = decimal.Parse(dgvr.Cells["Precio"].Value.ToString()),
                            Quantity = short.Parse(dgvr.Cells["Cantidad"].Value.ToString()),
                            Discount = decimal.Parse(dgvr.Cells["Descuento"].Value.ToString()),
                            RowVersion = dgvr.Cells["RowVersion"].Value as byte[] // devuelve null si es DBNull o no es byte[]
                        };
                        frmVentasDetalleModificar.ventaDetalle = ventaDetalle;
                        DialogResult dialogResult = frmVentasDetalleModificar.ShowDialog();
                        int orderId = string.IsNullOrEmpty(txtId.Text) ? 0 : Convert.ToInt32(txtId.Text);
                        BorrarDatosVenta();
                        BorrarDatosDetalleVenta();
                        if (dialogResult == DialogResult.OK)
                        {
                            BtnNota.Enabled = true;
                            LlenarDatosVenta(ref orderId); // necesario para actualizar el RowVersion de la venta
                            LlenarDatosDetalleVenta(orderId);
                            CargarValoresOriginales();
                        }
                        else
                        {
                            BtnNota.Enabled = false;
                            DeshabilitarControles();
                            LlenarDgvVentas(false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
            MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {DgvVentas.RowCount} registro(s) en ventas");
            //?CargarValoresOriginales();
            DgvDetalle.Focus();
        }

        private void EliminarProducto(VentaDetalle ventaDetalle)
        {
            int numRegs = 0;
            BorrarMensajesError();
            BorrarDatosAgregarProducto();
            try
            {
                if (U.NotificacionQuestion($"[orange]¿Esta seguro de eliminar el producto: {ventaDetalle.ProductName} de la venta: {ventaDetalle.Venta.OrderID}?") == DialogResult.Yes)
                {
                    MDIPrincipal.ActualizarBarraDeEstado(Utils.eliminandoRegistro);
                    DeshabilitarControles();
                    DeshabilitarControlesProducto();
                    numRegs = _ventaDetalleBLL.Eliminar(ventaDetalle);
                    string strProductoVenta = $"El producto: {ventaDetalle.ProductName} - Venta: {ventaDetalle.Venta.OrderID}:";
                    string strVenta = $"La venta con Id: {ventaDetalle.Venta.OrderID}:";
                    if (numRegs > 0)
                    {
                        int orderId = string.IsNullOrEmpty(txtId.Text) ? 0 : Convert.ToInt32(txtId.Text);
                        BorrarDatosVenta();
                        BorrarDatosDetalleVenta();
                        LlenarDatosVenta(ref orderId);
                        LlenarDatosDetalleVenta(orderId);
                        MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {DgvVentas.RowCount} registro(s) en ventas");
                    }
                    else if (numRegs == -1)
                        U.NotificacionError(strProductoVenta + Utils.nfefe);
                    else if (numRegs == -2)
                        U.NotificacionError(strProductoVenta + Utils.nfefm);
                    else if (numRegs == -3)
                        U.NotificacionError(strVenta + Utils.fepou);
                    else if (numRegs == -4)
                        U.NotificacionError(strProductoVenta + "\n[red]No fue eliminado en la base de datos.\n" + strVenta + Utils.fmpou);
                    else if (numRegs == -5)
                        U.NotificacionError(strProductoVenta + Utils.nfecqn); // El campo Quantity del detalle de la venta es nulo
                    // el caso -6 no existe en el stored procedure 
                    else if (numRegs == -7)
                        U.NotificacionError(strProductoVenta + Utils.nfeie); // Stock excedió el máximo permitido
                    else if (numRegs == -8)
                        U.NotificacionError(strProductoVenta + Utils.nfein); // stock negativo
                    else
                        U.NotificacionError(strProductoVenta + Utils.nfemd);
                }
                HabilitarControles();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

        private void BtnNota_Click(object sender, EventArgs e)
        {
            int result = chkRowVersion();
            string strVenta = $"La venta con Id: {txtId.Text}:";
            if (result == -1)
                U.NotificacionError(strVenta + Utils.oevvd);
            else if (result == -2)
                U.NotificacionError(strVenta + Utils.fepou);
            else if (result == -3)
                U.NotificacionError(strVenta + Utils.fmpousmn);
            else if (result == -4)
                U.NotificacionError(strVenta + Utils.oed);
            if (result == 1 || result == -3)
            {
                FrmRptNotaRemision8 frmRptNotaRemision8 = new FrmRptNotaRemision8();
                frmRptNotaRemision8.Id = int.Parse(txtId.Text);
                frmRptNotaRemision8.ShowDialog();
            }
            return;
        }

        private int chkRowVersion()
        {
            if (txtId.Tag == null)
                return -1;
            byte[] rowVersion = txtId.Tag as byte[];
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                Venta venta = _ventaBLL.ObtenerVentaPorId(int.Parse(txtId.Text));
                if (venta == null)
                    return -2;
                if (!venta.RowVersion.SequenceEqual(rowVersion))
                    return -3;
                MDIPrincipal.ActualizarBarraDeEstado();
                return 1;
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
                return -4;
            }
        }
    }
}
