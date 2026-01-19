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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmVentasCrud : Form
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        private VentaBLL _ventaBLL;
        private VentaDetalleBLL _ventaDetalleBLL;
        private readonly ClienteService _clienteService;
        private readonly EmpleadoService _empleadoService;
        private readonly TransportistaService _transportistaService;
        private readonly CategoriaService _categoriaService;
        private readonly ProductoService _productoService;
        private readonly VentaService _ventaService;
        private Dictionary<string, object> valoresOriginales;
        bool EventoCargado = true; // esta variable es necesaria para controlar el manejador de eventos de la celda del dgv ojo no quitar
        int numDetalle = 1;
        bool VentaGenerada = false;
        private short CantidadOld = 0;
        private short UInventarioOld = 0;

        public FrmVentasCrud()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _ventaBLL = new VentaBLL(_connectionString);
            _ventaDetalleBLL = new VentaDetalleBLL(_connectionString);
            _clienteService = new ClienteService(_connectionString);
            _empleadoService = new EmpleadoService(_connectionString);
            _transportistaService = new TransportistaService(_connectionString);
            _categoriaService = new CategoriaService(_connectionString);
            _productoService = new ProductoService(_connectionString);
            _ventaService = new VentaService(_connectionString);
        }

        private void GrbPaint(object sender, PaintEventArgs e) => Utils.GrbPaint(this, sender, e);

        private void GrbPaint2(object sender, PaintEventArgs e) => Utils.GrbPaint2(this, sender, e);

        private void FrmVentasCrud_FormClosed(object sender, FormClosedEventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void FrmVentasCrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Utils.HayCambios(this, valoresOriginales, errorProvider1))
                if (U.NotificacionQuestion(Utils.preguntaCerrar) == DialogResult.No)
                    e.Cancel = true;
        }

        private void tabcOperacion_DrawItem(object sender, DrawItemEventArgs e) => Utils.DibujarPestañas(sender as TabControl, e);

        private void FrmVentasCrud_Load(object sender, EventArgs e)
        {
            tabcOperacion.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabcOperacion.DrawItem += tabcOperacion_DrawItem;
            nudCantidad.ValueChanged += nudCantidad_ValueChanged;
            // Obtener el símbolo de moneda según la configuración regional del equipo
            string simboloMoneda = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
            // Mostrarlo en el Label
            LblPrecio.Text = "Precio " + simboloMoneda + ":";
            LblSubtotalDelImporte.Text = LblSubtotalDelImporte2.Text = "Subtotal del importe " + simboloMoneda + ":";
            LblSubtotalDelImporteDelDescuento.Text = LblSubtotalDelImporteDelDescuento2.Text = "Subtotal del importe del descuento " + simboloMoneda + ":";
            LblSubtotalDelImporteConDescuento.Text = LblSubtotalDelImporteConDescuento2.Text = "Subtotal del importe con descuento " + simboloMoneda + ":";
            LblSubtotalDelImporteSinIVA.Text = LblSubtotalDelImporteSinIVA2.Text = "Subtotal del importe sin IVA " + simboloMoneda + ":";
            LblSubtotalDelImporteDelIVA.Text = LblSubtotalDelImporteDelIVA2.Text = "Subtotal del importe del IVA (Incluido) " + simboloMoneda + ":";
            LblTotal.Text = "Total " + simboloMoneda + ":";
            LblTotal2.Text = "Total del producto " + simboloMoneda + ":";
            dtpHoraRequerido.Value = DateTime.Today; 
            dtpHoraEnvio.Value = DateTime.Today; 
            DeshabilitarControles();
            LlenarCboCliente();
            LlenarCboEmpleado();
            LlenarCboTransportista();
            LlenarCboCategoria();
            Utils.ConfDgv(dgvVentas);
            Utils.ConfDgv(dgvDetalle);
            LlenarDgvVentas(false);
            ConfDgvVentas();
            ConfDgvDetalle();
            dgvDetalle.Columns["Eliminar"].Visible = false;
            DeshabilitarNudsNoSeleccionables();
            InicializarCboProducto();
            CargarValoresOriginales();
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
            Utilities.NudHelper.SetEnabled(nudSubtotalDelImporteSinIVA, false);
            Utilities.NudHelper.SetEnabled(nudSubtotalDelImporteDelIVA, false);
            Utilities.NudHelper.SetEnabled(nudTotal, false);
            Utilities.NudHelper.SetEnabled(nudSubtotalDelImporte2, false);
            Utilities.NudHelper.SetEnabled(nudSubtotalDelImporteDelDescuento2, false);
            Utilities.NudHelper.SetEnabled(nudSubtotalDelImporteConDescuento2, false);
            Utilities.NudHelper.SetEnabled(nudSubtotalDelImporteSinIVA2, false);
            Utilities.NudHelper.SetEnabled(nudSubtotalDelImporteDelIVA2, false);
            Utilities.NudHelper.SetEnabled(nudTotal2, false);
        }

        private void DeshabilitarCantidadDescuento()
        {
            Utilities.NudHelper.SetEnabled(nudCantidad, false);
            Utilities.NudHelper.SetEnabled(nudDescuento, false);
        }

        private void DeshabilitarFlete()
        {
            Utilities.NudHelper.SetEnabled(nudFlete, false);
        }

        private void HabilitarFlete()
        {
            Utilities.NudHelper.SetEnabled(nudFlete, true);
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

        private void DeshabilitarControles()
        {
            cboCliente.Enabled = cboEmpleado.Enabled = cboTransportista.Enabled = cboCategoria.Enabled = cboProducto.Enabled = false;
            dtpVenta.Enabled = dtpHoraVenta.Enabled = dtpRequerido.Enabled = dtpHoraRequerido.Enabled = dtpEnvio.Enabled = dtpHoraEnvio.Enabled = false;
            txtDirigidoa.ReadOnly = txtDomicilio.ReadOnly = txtCiudad.ReadOnly = txtRegion.ReadOnly = txtCP.ReadOnly = txtPais.ReadOnly = true;
            btnAgregar.Enabled = btnGenerar.Enabled = false;
            DeshabilitarCantidadDescuento();
            DeshabilitarFlete();
        }

        private void HabilitarControles()
        {
            cboCliente.Enabled = cboEmpleado.Enabled = cboTransportista.Enabled = cboCategoria.Enabled = true;
            cboProducto.Enabled = false;
            dtpVenta.Enabled = dtpRequerido.Enabled = dtpEnvio.Enabled = true;
            txtDirigidoa.ReadOnly = txtDomicilio.ReadOnly = txtCiudad.ReadOnly = txtRegion.ReadOnly = txtCP.ReadOnly = txtPais.ReadOnly = false;
            HabilitarFlete();
            btnAgregar.Enabled = btnGenerar.Enabled = true;
        }

        private void DeshabilitarControlesProducto()
        {
            DeshabilitarCantidadDescuento();
            OcultarIconosValidacion();
            btnAgregar.Enabled = false;
            cboProducto.Enabled = false;
        }

        private void OcultarIconosValidacion()
        {
            StatusIconHelper.HideIcons(pbError, pbInfo, pbWarning);
            StatusIconHelper.HideIcons(pbError1, pbInfo1, pbWarning1);
        }

        private void HabilitarControlesProducto() => HabilitarCantidadDescuento();

        private void LlenarCboCliente()
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var dtCboCliente = _clienteService.ObtenerClientesCbo();
                ComboBoxHelper.LlenarCbo(cboCliente, dtCboCliente, "CompanyName", "CustomerID");
                MDIPrincipal.ActualizarBarraDeEstado();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

        private void LlenarCboEmpleado()
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var dtCboEmpleado = _empleadoService.ObtenerEmpleadosCbo();
                ComboBoxHelper.LlenarCbo(cboEmpleado, dtCboEmpleado, "EmployeeName", "EmployeeID");
                MDIPrincipal.ActualizarBarraDeEstado();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

        private void LlenarCboTransportista()
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var dtCboTransportista = _transportistaService.ObtenerTransportistasCbo();
                ComboBoxHelper.LlenarCbo(cboTransportista, dtCboTransportista, "CompanyName", "ShipperID");
                MDIPrincipal.ActualizarBarraDeEstado();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

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
                dgvVentas.DataSource = ventas;
                if (!selectorRealizaBusqueda)
                    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran las últimas {dgvVentas.RowCount} venta(s) registrada(s)");
                else
                    MDIPrincipal.ActualizarBarraDeEstado($"Se encontraron {dgvVentas.RowCount} registro(s)");
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

        private void ConfDgvVentas()
        {
            dgvVentas.Columns["RowVersionStr"].Visible = false;
            dgvVentas.Columns["OrderID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvVentas.Columns["OrderDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVentas.Columns["RequiredDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVentas.Columns["ShippedDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVentas.Columns["ShipperCompanyName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVentas.Columns["EmployeeName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvVentas.Columns["OrderDate"].DefaultCellStyle.Format = "ddd dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";
            dgvVentas.Columns["RequiredDate"].DefaultCellStyle.Format = "ddd dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";
            dgvVentas.Columns["ShippedDate"].DefaultCellStyle.Format = "ddd dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";

            dgvVentas.Columns["OrderID"].HeaderText = "Id";
            dgvVentas.Columns["CustomerCompanyName"].HeaderText = "Cliente";
            dgvVentas.Columns["CustomerContactName"].HeaderText = "Nombre de contacto";
            dgvVentas.Columns["OrderDate"].HeaderText = "Fecha de venta";
            dgvVentas.Columns["RequiredDate"].HeaderText = "Fecha de entrega";
            dgvVentas.Columns["ShippedDate"].HeaderText = "Fecha de envío";
            dgvVentas.Columns["EmployeeName"].HeaderText = "Vendedor";
            dgvVentas.Columns["ShipperCompanyName"].HeaderText = "Compañía transportista";
            dgvVentas.Columns["ShipName"].HeaderText = "Enviar a";
        }

        private void ConfDgvDetalle()
        {
            dgvDetalle.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns["ImporteDelDescuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns["ImporteConDescuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns["TasaIVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["ImporteSinIVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns["ImporteDelIVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalle.Columns["Precio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalle.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalle.Columns["Importe"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalle.Columns["Descuento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalle.Columns["ImporteDelDescuento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalle.Columns["ImporteConDescuento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalle.Columns["TasaIVA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalle.Columns["ImporteSinIVA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalle.Columns["ImporteDelIVA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalle.Columns["Subtotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalle.Columns["Eliminar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            dgvDetalle.Columns["ImporteDelDescuento"].HeaderText = "Importe\ndel\ndescuento";
            dgvDetalle.Columns["ImporteConDescuento"].HeaderText = "Importe\ncon\ndescuento";

            dgvDetalle.Columns["Precio"].DefaultCellStyle.Format = "c2";
            dgvDetalle.Columns["Cantidad"].DefaultCellStyle.Format = "n0";
            dgvDetalle.Columns["Descuento"].DefaultCellStyle.Format = "p2";
            dgvDetalle.Columns["Importe"].DefaultCellStyle.Format = "c2";
            dgvDetalle.Columns["ImporteDelDescuento"].DefaultCellStyle.Format = "c2";
            dgvDetalle.Columns["ImporteConDescuento"].DefaultCellStyle.Format = "c2";
            dgvDetalle.Columns["TasaIVA"].DefaultCellStyle.Format = "p2";
            dgvDetalle.Columns["ImporteSinIVA"].DefaultCellStyle.Format = "c2";
            dgvDetalle.Columns["ImporteDelIVA"].DefaultCellStyle.Format = "c2";
            dgvDetalle.Columns["Subtotal"].DefaultCellStyle.Format = "c2";
        }

        private void dgvVentas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // debe estar vinculado a la clase List<> a la cual esta vinculado el DataGridView.DataSource
            Utils.OrdenarPorColumna<DtoVentaDgv>(dgvVentas, e);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            BorrarDatosVenta();
            BorrarDatosDetalleVenta();
            BorrarMensajesError();
            BorrarDatosBusqueda();
            if (tabcOperacion.SelectedTab != tabpRegistrar)
                DeshabilitarControles();
            LlenarDgvVentas(false);
            dgvVentas.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BorrarDatosVenta();
            BorrarDatosDetalleVenta();
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab != tabpRegistrar)
                DeshabilitarControles();
            LlenarDgvVentas(true);
            dgvVentas.Focus();
        }

        private void BorrarDatosVenta()
        {
            errorProvider1.Clear();
            txtId.Text = "";
            txtId.Tag = null;
            cboCliente.SelectedIndex = cboEmpleado.SelectedIndex = cboTransportista.SelectedIndex = 0;
            dtpVenta.Value = dtpRequerido.Value = dtpEnvio.Value = DateTime.Now;
            dtpHoraVenta.Value = DateTime.Now;
            dtpHoraRequerido.Value = dtpHoraEnvio.Value = DateTime.Today;
            dtpRequerido.Checked = dtpEnvio.Checked = false;
            txtDirigidoa.Text = txtDomicilio.Text = txtCiudad.Text = txtRegion.Text = txtCP.Text = txtPais.Text = "";
            btnNota.Enabled = false;
        }

        private void BorrarDatosDetalleVenta()
        {
            cboCategoria.SelectedIndex = 0;
            InicializarValoresAgregarProducto();
            InicializarCboProducto();
            InicializarNuds();
            dgvDetalle.Rows.Clear();
        }

        private void InicializarValoresAgregarProducto() => nudPrecio.Value = nudCantidad.Value = nudUInventario.Value = nudDescuento.Value = 0;

        private void InicializarValoresEnvio() => txtDirigidoa.Text = txtDomicilio.Text = txtCiudad.Text = txtRegion.Text = txtCP.Text = txtPais.Text = "";
        
        private void InicializarNuds()
        {
            nudNumProd.Value = nudTotalDeUnidades.Value = nudSubtotalDelImporte.Value = nudSubtotalDelImporteDelDescuento.Value = nudSubtotalDelImporteConDescuento.Value = nudSubtotalDelImporteSinIVA.Value = nudSubtotalDelImporteDelIVA.Value = nudTotal.Value = 0;
            InicializarNudsProducto();
        }

        private void InicializarNudsProducto()
        {
            nudSubtotalDelImporte2.Value = nudSubtotalDelImporteDelDescuento2.Value = nudSubtotalDelImporteConDescuento2.Value = nudSubtotalDelImporteSinIVA2.Value = nudSubtotalDelImporteDelIVA2.Value = nudTotal2.Value = 0;
        }

        private void BorrarMensajesError() => errorProvider1.Clear();

        private void BorrarDatosBusqueda()
        {
            nudBIdIni.Value = nudBIdFin.Value = 0;
            txtBCliente.Text = txtBEmpleado.Text = txtBCompañiaT.Text = txtBDirigidoa.Text = "";
            dtpBFVentaIni.Value = dtpBFVentaFin.Value = dtpBFRequeridoIni.Value = dtpBFRequeridoFin.Value = dtpBFEnvioIni.Value = dtpBFEnvioFin.Value = DateTime.Today;
            dtpBFVentaIni.Checked = dtpBFVentaFin.Checked = dtpBFRequeridoIni.Checked = dtpBFRequeridoFin.Checked = dtpBFEnvioIni.Checked = dtpBFEnvioFin.Checked = false;
            chkbBFVentaNull.Checked = chkbBFRequeridoNull.Checked = chkbBFEnvioNull.Checked = false;
        }

        private bool ValidarControlesVenta()
        {
            errorProvider1.Clear();
            bool valida = true;
            if (cboCliente.SelectedIndex == 0)
            {
                valida = false;
                errorProvider1.SetError(cboCliente, "Ingrese el cliente");
            }
            if (cboEmpleado.SelectedIndex == 0)
            {
                valida = false;
                errorProvider1.SetError(cboEmpleado, "Ingrese el empleado");
            }
            if (dtpVenta.Checked == false)
            {
                valida = false;
                errorProvider1.SetError(dtpVenta, "Ingrese la fecha de la venta");
            }
            if (cboTransportista.SelectedIndex == 0)
            {
                valida = false;
                errorProvider1.SetError(cboTransportista, "Ingrese la compañía transportista");
            }
            if (nudTotal.Value == 0)
            {
                valida = false;
                errorProvider1.SetError(btnAgregar, "Ingrese el detalle de la venta");
                errorProvider1.SetError(nudTotal, "El total de la venta no puede ser cero");
            }
            if (cboProducto.SelectedIndex > 0)
            {
                valida = false;
                errorProvider1.SetError(cboProducto, "Se ha seleccionado un producto y no lo ha agregado a la venta");
            }
            return valida;
        }

        private bool ValidarControlesProducto()
        {
            errorProvider1.Clear();
            bool valida = false;
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
            if (cboProducto.SelectedIndex > 0)
            {
                int numProd = int.Parse(cboProducto.SelectedValue.ToString());
                bool productoDuplicado = false;
                foreach (DataGridViewRow dgvr in dgvDetalle.Rows)
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
            CalcularTotalProducto(ventaDetalle);
            if (ventaDetalle.Subtotal == 0)
            {
                valida = false;
                if (nudCantidad.Value == 0)
                    errorProvider1.SetError(btnAgregar, "Ingrese el detalle del pedido");
                else if (ventaDetalle.Subtotal == 0)
                {
                    errorProvider1.SetError(btnAgregar, "El valor del subtotal del producto no puede ser cero");
                    errorProvider1.SetError(nudTotal2, "El valor del subtotal del producto no puede ser cero");
                }
            }
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
                valida = false;
                btnAgregar.Enabled = false;
            }
            else
                btnAgregar.Enabled = true;

            return valida;
        }

        private void CalcularTotalProducto(VentaDetalle ventaDetalle)
        {
            nudSubtotalDelImporte2.Value = ventaDetalle.Importe;
            nudSubtotalDelImporteDelDescuento2.Value = ventaDetalle.ImporteDelDescuento;
            nudSubtotalDelImporteConDescuento2.Value = ventaDetalle.ImporteConDescuento;
            nudSubtotalDelImporteSinIVA2.Value = ventaDetalle.ImporteSinIVA;
            nudSubtotalDelImporteDelIVA2.Value = ventaDetalle.ImporteDelIVA;
            nudTotal2.Value = ventaDetalle.Subtotal;
        }

        private void CalcularTotales()
        {
            decimal importe, total, totalDeUnidades, subtotalDelImporte, subtotalDelImporteDelDescuento, subtotalDelImporteConDescuento, subtotalDelImporteSinIVA, subtotalDelImporteDelIVA;
            importe = total = totalDeUnidades = subtotalDelImporte = subtotalDelImporteDelDescuento = subtotalDelImporteConDescuento = subtotalDelImporteSinIVA = subtotalDelImporteDelIVA = 0;
            numDetalle = 0;
            foreach (DataGridViewRow dgvr in dgvDetalle.Rows)
            {
                totalDeUnidades += decimal.Parse(dgvr.Cells["Cantidad"].Value.ToString());
                subtotalDelImporte += decimal.Parse(dgvr.Cells["Importe"].Value.ToString());
                subtotalDelImporteDelDescuento += decimal.Parse(dgvr.Cells["ImporteDelDescuento"].Value.ToString());
                subtotalDelImporteConDescuento += decimal.Parse(dgvr.Cells["ImporteConDescuento"].Value.ToString());
                subtotalDelImporteSinIVA += decimal.Parse(dgvr.Cells["ImporteSinIVA"].Value.ToString());
                subtotalDelImporteDelIVA += decimal.Parse(dgvr.Cells["ImporteDelIVA"].Value.ToString());
                total += decimal.Parse(dgvr.Cells["Subtotal"].Value.ToString());
                dgvr.Cells["Id"].Value = ++numDetalle;
            }
            nudNumProd.Value = numDetalle;
            nudTotalDeUnidades.Value = totalDeUnidades;
            nudSubtotalDelImporte.Value = subtotalDelImporte;
            nudSubtotalDelImporteDelDescuento.Value = subtotalDelImporteDelDescuento;
            nudSubtotalDelImporteConDescuento.Value = subtotalDelImporteConDescuento;
            nudSubtotalDelImporteSinIVA.Value = subtotalDelImporteSinIVA;
            nudSubtotalDelImporteDelIVA.Value = subtotalDelImporteDelIVA;
            nudTotal.Value = total;
        }

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

        private void nudCantidad_Leave(object sender, EventArgs e) => ValidarControlesProducto();

        private void nudDescuento_Leave(object sender, EventArgs e) => ValidarControlesProducto();

        private void nudCantidad_ValueChanged(object sender, EventArgs e) => ValidarControlesProducto();

        private void nudDescuento_ValueChanged(object sender, EventArgs e) => ValidarControlesProducto();

        private void dtpBFVentaIni_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBFVentaIni.Checked)
            {
                dtpBFVentaFin.Checked = true;
                chkbBFVentaNull.Checked = false;
            }
            else
                dtpBFVentaFin.Checked = false;
        }

        private void dtpBFVentaFin_ValueChanged(object sender, EventArgs e)
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

        private void chkBFVentaNull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbBFVentaNull.Checked)
            {
                dtpBFVentaIni.Checked = false;
                dtpBFVentaFin.Checked = false;
            }
        }

        private void chkBFRequeridoNull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbBFRequeridoNull.Checked)
            {
                dtpBFRequeridoIni.Checked = false;
                dtpBFRequeridoFin.Checked = false;
            }
        }

        private void chkBFEnvioNull_CheckedChanged(object sender, EventArgs e)
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

        private void dtpVenta_ValueChanged(object sender, EventArgs e)
        {
            if (dtpVenta.Checked)
            {
                dtpHoraVenta.Value = DateTime.Now; // este es para que me ponga el componente del time
                dtpHoraVenta.Enabled = true;
            }
            else
            {
                dtpHoraVenta.Value = DateTime.Today; // este es para que no me ponga el componente del time
                dtpHoraVenta.Enabled = false;
            }
        }

        private void dtpRequerido_ValueChanged(object sender, EventArgs e)
        {
            if (dtpRequerido.Checked)
            {
                dtpHoraRequerido.Value = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 12:00:00.000");
                dtpHoraRequerido.Enabled = true;
            }
            else
            {
                dtpHoraRequerido.Value = DateTime.Today;
                dtpHoraRequerido.Enabled = false;
            }
        }

        private void dtpEnvio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEnvio.Checked)
            {
                dtpHoraEnvio.Value = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 12:00:00.000");
                dtpHoraEnvio.Enabled = true;
            }
            else
            {
                dtpHoraEnvio.Value = DateTime.Today;
                dtpHoraEnvio.Enabled = false;
            }
        }

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
                    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registro(s) en ventas");
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
                MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registro(s) en ventas");
            }
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex > 0)
            {
                try
                {
                    MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                    var dtoEnvioInformacion = _ventaService.ObtenerUltimaInformacionDeEnvio(cboCliente.SelectedValue?.ToString());
                    if (dtoEnvioInformacion != null)
                    {
                        txtDirigidoa.Text = dtoEnvioInformacion.ShipName ?? "";
                        txtDomicilio.Text = dtoEnvioInformacion.ShipAddress ?? "";
                        txtCiudad.Text = dtoEnvioInformacion.ShipCity ?? "";
                        txtRegion.Text = dtoEnvioInformacion.ShipRegion ?? "";
                        txtCP.Text = dtoEnvioInformacion.ShipPostalCode ?? "";
                        txtPais.Text = dtoEnvioInformacion.ShipCountry ?? "";
                    }
                    else
                        InicializarValoresEnvio();
                    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registro(s) en ventas");
                }
                catch (Exception ex)
                {
                    U.MsgCatchOue(ex);
                }
            }
            else
                InicializarValoresEnvio();
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
                    var dtoProductoCostoEInventario = _productoService.ObtenerProductoCostoEInventario(int.Parse(productId));
                    if (dtoProductoCostoEInventario != null)
                    {
                        nudPrecio.Value = dtoProductoCostoEInventario.UnitPrice;
                        nudUInventario.Value = dtoProductoCostoEInventario.UnitsInStock;
                        UInventarioOld = short.Parse(dtoProductoCostoEInventario.UnitsInStock.ToString());

                        if (dtoProductoCostoEInventario.UnitsInStock == 0)
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
                    }
                    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registro(s) en ventas");
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





        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarControlesProducto())
                return;
            //bool hayError = false;
            //BorrarMensajesError();
            //if (cboCategoria.SelectedIndex <= 0)
            //{
            //    errorProvider1.SetError(cboCategoria, "Seleccione la categoría");
            //    hayError = true;
            //}
            //if (cboProducto.SelectedIndex <= 0)
            //{
            //    errorProvider1.SetError(cboProducto, "Seleccione el producto");
            //    hayError = true;
            //}
            //if (nudCantidad.Value == 0)
            //{
            //    errorProvider1.SetError(nudCantidad, "Ingrese la cantidad");
            //    hayError = true;
            //}
            //int numProd = 0;
            //int.TryParse(cboProducto.SelectedValue.ToString(), out numProd);
            //if (numProd > 0)
            //{
            //    bool productoDuplicado = false;
            //    foreach (DataGridViewRow dgvr in dgvDetalle.Rows)
            //    {
            //        if (int.Parse(dgvr.Cells["ProductoId"].Value.ToString()) == numProd)
            //        {
            //            productoDuplicado = true;
            //            break;
            //        }
            //    }
            //    if (productoDuplicado)
            //    {
            //        errorProvider1.SetError(cboProducto, "No se puede tener un producto duplicado en el detalle de la venta");
            //        hayError = true;
            //    }
            //}
            //if (hayError)
            //    return;
            DeshabilitarControlesProducto();
            var ventaDetalle = new VentaDetalle
            {
                Venta = new Venta(),
                Producto = new Producto
                {
                    ProductID = (int)cboProducto.SelectedValue,
                    ProductName = cboProducto.Text
                },
                UnitPrice = nudPrecio.Value,
                Quantity = (short)nudCantidad.Value,
                Discount = nudDescuento.Value / 100m
            };
            dgvDetalle.Rows.Add(new object[] 
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
                "Eliminar", 
                ventaDetalle.Producto.ProductID
            });
            CalcularTotales();
            ++numDetalle;
            cboCategoria.SelectedIndex = cboProducto.SelectedIndex = 0;
            InicializarValoresAgregarProducto();
            cboCategoria.Focus();
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvDetalle.Columns["Eliminar"].Index)
                return;
            dgvDetalle.Rows.RemoveAt(e.RowIndex);
            CalcularTotales();
        }

        private void tabcOperacion_Selected(object sender, TabControlEventArgs e)
        {
            numDetalle = 1;
            BorrarDatosVenta();
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab == tabpRegistrar)
            {
                if (EventoCargado)
                {
                    dgvVentas.CellClick -= new DataGridViewCellEventHandler(dgvVentas_CellClick);
                    EventoCargado = false;
                }
                VentaGenerada = false;
                BorrarDatosBusqueda();
                HabilitarControles();
                btnGenerar.Text = "Generar venta";
                btnGenerar.Enabled = true;
                btnAgregar.Visible = true;
                btnAgregar.Enabled = true;
                dgvDetalle.Columns["Eliminar"].Visible = true;
                grbProducto.Enabled = true;
                btnNota.Enabled = false;
                btnNuevo.Enabled = false;
            }
            else
            {
                if (!EventoCargado)
                {
                    dgvVentas.CellClick += new DataGridViewCellEventHandler(dgvVentas_CellClick);
                    EventoCargado = true;
                }
                DeshabilitarControles();
                btnGenerar.Enabled = false;
                dgvDetalle.Columns["Eliminar"].Visible = false;
                grbProducto.Enabled = false;
                if (tabcOperacion.SelectedTab == tabpConsultar)
                {
                    btnGenerar.Enabled = false;
                    btnAgregar.Visible = false;
                    btnNota.Enabled = false;
                    btnNuevo.Enabled = false;
                }
                else if (tabcOperacion.SelectedTab == tabpModificar)
                {
                    VentaGenerada = false;
                    btnGenerar.Text = "Modificar venta";
                    btnGenerar.Enabled = true;
                    btnAgregar.Visible = false;
                    btnNota.Enabled = false;
                    btnNuevo.Enabled = false;
                }
                else if (tabcOperacion.SelectedTab == tabpEliminar)
                {
                    btnGenerar.Text = "Eliminar venta";
                    btnGenerar.Enabled = true;
                    btnAgregar.Visible = false;
                    btnNota.Enabled = false;
                    btnNuevo.Enabled = false;
                }
            }
            CargarValoresOriginales();
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (tabcOperacion.SelectedTab != tabpRegistrar)
            {
                BorrarDatosVenta();
                BorrarMensajesError();
                DataGridViewRow dgvr = dgvVentas.CurrentRow;
                txtId.Text = dgvr.Cells["OrderId"].Value.ToString();
                LlenarDatosVenta(Convert.ToInt32(txtId.Text));
                LlenarDatosDetalleVenta(string.IsNullOrEmpty(txtId.Text) ? 0 : Convert.ToInt32(txtId.Text));
                DeshabilitarControles();
                if (tabcOperacion.SelectedTab == tabpConsultar)
                {
                    btnNota.Enabled = true;
                    btnNuevo.Enabled = false;
                }
                else if (tabcOperacion.SelectedTab == tabpModificar)
                {
                    HabilitarControles();
                    btnGenerar.Enabled = true;
                    btnNota.Enabled = false;
                    btnNuevo.Enabled = false;
                }
                else if (tabcOperacion.SelectedTab == tabpEliminar)
                {
                    btnGenerar.Enabled = true;
                    btnNota.Enabled = false;
                    btnNuevo.Enabled = false;
                }
            }
            CargarValoresOriginales();
        }

        private void LlenarDatosVenta(int orderId)
        {
            if (orderId == 0) return;
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var venta = _ventaBLL.ObtenerVentaPorId(orderId);
                if (venta != null)
                {
                    txtId.Text = venta.OrderID.ToString();
                    cboCliente.SelectedIndexChanged -= new EventHandler(cboCliente_SelectedIndexChanged);
                    cboCliente.SelectedValue = venta.Cliente.CustomerID;
                    cboCliente.SelectedIndexChanged += new EventHandler(cboCliente_SelectedIndexChanged);
                    cboEmpleado.SelectedValue = venta.Empleado.EmployeeID;
                    cboTransportista.SelectedValue = venta.Transportista.ShipperID;
                    txtDirigidoa.Text = venta.ShipName ?? "";
                    txtDomicilio.Text = venta.ShipAddress ?? "";
                    txtCiudad.Text = venta.ShipCity ?? "";
                    txtRegion.Text = venta.ShipRegion ?? "";
                    txtCP.Text = venta.ShipPostalCode ?? "";
                    txtPais.Text = venta.ShipCountry ?? "";
                    nudFlete.Value = venta.Freight ?? 0;
                    if (venta.OrderDate.HasValue)
                    {
                        dtpVenta.Value = venta.OrderDate.Value;
                        dtpHoraVenta.Value = venta.OrderDate.Value;
                        dtpVenta.Checked = true;
                        dtpHoraVenta.Enabled = true;
                    }
                    else
                    {
                        dtpVenta.Value = dtpVenta.MinDate;
                        dtpVenta.Checked = false;
                        dtpHoraVenta.Value = dtpHoraVenta.MinDate;
                        dtpHoraVenta.Enabled = false;
                    }
                    if (venta.RequiredDate.HasValue)
                    {
                        dtpRequerido.Value = venta.RequiredDate.Value;
                        dtpHoraRequerido.Value = venta.RequiredDate.Value;
                        dtpRequerido.Checked = true;
                        dtpHoraRequerido.Enabled = true;
                    }
                    else
                    {
                        dtpRequerido.Value = dtpRequerido.MinDate;
                        dtpRequerido.Checked = false;
                        dtpHoraRequerido.Value = dtpHoraRequerido.MinDate;
                        dtpHoraRequerido.Enabled = false;
                    }
                    if (venta.ShippedDate.HasValue)
                    {
                        dtpEnvio.Value = venta.ShippedDate.Value;
                        dtpHoraEnvio.Value = venta.ShippedDate.Value;
                        dtpEnvio.Checked = true;
                        dtpHoraEnvio.Enabled = true;
                    }
                    else
                    {
                        dtpEnvio.Value = dtpEnvio.MinDate;
                        dtpEnvio.Checked = false;
                        dtpHoraEnvio.Value = dtpHoraEnvio.MinDate;
                        dtpHoraEnvio.Enabled = false;
                    }
                    txtId.Tag = venta.RowVersion;
                    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registro(s) en ventas");
                }
                else
                {
                    txtId.Text = string.Empty;
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
                var ventaDetalles = _ventaDetalleBLL.ObtenerVentaDetallePorVentaId(orderId);
                if (ventaDetalles.Count == 0)
                    U.NotificacionWarning("No se encontraron detalles para la venta especificada");
                else
                {
                    foreach (var ventaDetalle in ventaDetalles)
                    {
                        dgvDetalle.Rows.Add(new object[]
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
                            "Eliminar",
                            ventaDetalle.Producto.ProductID,
                            ventaDetalle.RowVersion
                        });
                        ++numDetalle;
                    }
                }
                CalcularTotales();
                MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registro(s) en ventas");
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            int numRegs = 0;
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab == tabpRegistrar)
            {
                try
                {
                    if (ValidarControlesVenta())
                    {
                        MDIPrincipal.ActualizarBarraDeEstado(Utils.insertandoRegistro);
                        DeshabilitarControles();
                        btnGenerar.Enabled = false;
                        Venta venta = new Venta();
                        venta.Cliente.CustomerID = cboCliente.SelectedValue.ToString().Trim();
                        venta.Empleado.EmployeeID = Convert.ToInt32(cboEmpleado.SelectedValue);
                        if (dtpVenta != null && dtpHoraVenta != null)
                            venta.OrderDate = Utils.ObtenerFechaHora(dtpVenta, dtpHoraVenta);
                        if (dtpRequerido != null && dtpHoraRequerido != null)
                            venta.RequiredDate = Utils.ObtenerFechaHora(dtpRequerido, dtpHoraRequerido);
                        if (dtpEnvio != null && dtpHoraEnvio != null)
                            venta.ShippedDate = Utils.ObtenerFechaHora(dtpEnvio, dtpHoraEnvio);
                        venta.Transportista.ShipperID = int.Parse(cboTransportista.SelectedValue.ToString());
                        venta.ShipName = txtDirigidoa.Text.Trim();
                        venta.ShipAddress = txtDomicilio.Text.Trim();
                        venta.ShipCity = txtCiudad.Text.Trim();
                        venta.ShipRegion = txtRegion.Text.Trim();
                        venta.ShipPostalCode = txtCP.Text.Trim();
                        venta.ShipCountry = txtPais.Text.Trim();
                        venta.Freight = nudFlete.Value;
                        // llenado de elementos hijos
                        foreach (DataGridViewRow dgvr in dgvDetalle.Rows)
                        {
                            // defensiva: ignorar filas nuevas o vacías
                            if (dgvr.IsNewRow) continue;
                            VentaDetalle ventaDetalles = new VentaDetalle
                            {
                                Producto = new Producto
                                {
                                    ProductID = int.Parse(dgvr.Cells["ProductoId"].Value.ToString()),
                                    ProductName = dgvr.Cells["Producto"].Value.ToString()
                                },
                                UnitPrice = decimal.Parse(dgvr.Cells["Precio"].Value.ToString()),
                                Quantity = short.Parse(dgvr.Cells["Cantidad"].Value.ToString()),
                                Discount = decimal.Parse(dgvr.Cells["Descuento"].Value.ToString())
                            };
                            venta.VentaDetalles.Add(ventaDetalles);
                        }
                        int orderId = 0;
                        numRegs = _ventaBLL.InsertarVentaCompleta(venta, out orderId);
                        txtId.Text = orderId.ToString();
                        MDIPrincipal.ActualizarBarraDeEstado($"Se insertaron {numRegs - (numRegs - 1)} registro(s) en ventas y {numRegs - 1} registro(s) en el detalle de ventas");
                        string paraNotificacion = $"La venta con Id: {txtId.Text} del Cliente: {cboCliente.Text}:";
                        if (numRegs > 0) 
                            U.NotificacionInformation(paraNotificacion + Utils.srs);
                        else 
                            U.NotificacionError(paraNotificacion + Utils.nfrs);
                    }
                }
                catch (Exception ex)
                {
                    U.MsgCatchOue(ex);
                }
                if (numRegs > 0)
                {
                    VentaGenerada = true;
                    numDetalle = 1;
                    btnNota.Enabled = true;
                    btnNuevo.Enabled = true;
                    BorrarDatosBusqueda();
                    LlenarDgvVentas(false);
                    dgvDetalle.Rows.Clear();
                    dgvDetalle.Columns["Eliminar"].Visible = false;
                    LlenarDatosDetalleVenta(Convert.ToInt32(txtId.Text));
                }
            }
            else if (tabcOperacion.SelectedTab == tabpModificar)
            {
                try
                {
                    if (ValidarControlesVenta())
                    {
                        if (!ChkRowVersion())
                        {
                            U.NotificacionWarning("El registro ha sido modificado por otro usuario de la red, no se realizará la actualización del registro, vuelva a cargar el registro para que se muestre la venta con los datos proporcionados por el otro usuario");
                            return;
                        }
                        MDIPrincipal.ActualizarBarraDeEstado(Utils.modificandoRegistro);
                        DeshabilitarControles();
                        btnGenerar.Enabled = false;
                        Venta venta = new Venta();
                        venta.OrderID = int.Parse(txtId.Text);
                        venta.Cliente.CustomerID = cboCliente.SelectedValue.ToString().Trim();
                        venta.Empleado.EmployeeID = Convert.ToInt32(cboEmpleado.SelectedValue);
                        if (!dtpVenta.Checked)
                            venta.OrderDate = null;
                        else
                            venta.OrderDate = Utils.ObtenerFechaHora(dtpVenta, dtpHoraVenta);
                        if (!dtpRequerido.Checked) 
                            venta.RequiredDate = null;
                        else 
                            venta.RequiredDate = Utils.ObtenerFechaHora(dtpRequerido, dtpHoraRequerido);
                        if (!dtpEnvio.Checked) 
                            venta.ShippedDate = null;
                        else 
                            venta.ShippedDate = Utils.ObtenerFechaHora(dtpEnvio, dtpHoraEnvio);
                        venta.Transportista.ShipperID = Convert.ToInt32(cboTransportista.SelectedValue);
                        venta.ShipName = txtDirigidoa.Text.Trim();
                        venta.ShipAddress = txtDomicilio.Text.Trim();
                        venta.ShipCity = txtCiudad.Text.Trim();
                        venta.ShipRegion = txtRegion.Text.Trim();
                        venta.ShipPostalCode = txtCP.Text.Trim();
                        venta.ShipCountry = txtPais.Text.Trim();
                        venta.Freight = nudFlete.Value;
                        venta.RowVersion = (byte[])txtId.Tag;
                        numRegs = _ventaBLL.Actualizar(venta);
                        txtId.Tag = venta.RowVersion; // se tiene que actualizar por la nota de remision no detecte un cambio
                        MDIPrincipal.ActualizarBarraDeEstado($"Se actualizaron {(numRegs < 0 ? 0 : numRegs)} registro(s)");
                        string idVentaCliente = $"La venta con Id: {venta.OrderID} - Cliente: {cboCliente.Text}:";
                        if (numRegs > 0)
                            U.NotificacionInformation(idVentaCliente + Utils.sms);
                        else if (numRegs == -1)
                            U.NotificacionError(idVentaCliente + Utils.nfmfe);
                        else if (numRegs == -2)
                            U.NotificacionError(idVentaCliente + Utils.nfmfm);
                        else
                            U.NotificacionError(idVentaCliente + Utils.nfmmd);
                    }
                }
                catch (Exception ex)
                {
                    U.MsgCatchOue(ex);
                }
                if (numRegs > 0)
                {
                    VentaGenerada = true;
                    btnNota.Enabled = true;
                    btnNuevo.Enabled = false;
                    LlenarDgvVentas(false);
                }
            }
            else if (tabcOperacion.SelectedTab == tabpEliminar)
            {
                if (U.NotificacionQuestion($"[orange]¿Esta seguro de eliminar la venta con Id: {txtId.Text} del Cliente: {cboCliente.Text}?") == DialogResult.Yes)
                {
                    if (!ChkRowVersion())
                    {
                        U.NotificacionWarning("El registro ha sido modificado por otro usuario de la red, no se realizará la eliminación del registro, vuelva a cargar el registro para que se muestre la venta con los datos proporcionados por el otro usuario");
                        return;
                    }
                    MDIPrincipal.ActualizarBarraDeEstado(Utils.eliminandoRegistro);
                    btnGenerar.Enabled = false;
                    try
                    {
                        Venta venta = new Venta();
                        venta.OrderID = int.Parse(txtId.Text);
                        venta.RowVersion = (byte[])txtId.Tag;
                        numRegs = _ventaBLL.Eliminar(venta);
                        string idVentaCliente = $"La venta con Id: {txtId.Text} - Cliente: {cboCliente.Text}:";
                        if (numRegs > 0)
                            U.NotificacionInformation(idVentaCliente + Utils.ses);
                        else if (numRegs == -1)
                            U.NotificacionError(idVentaCliente + Utils.nfefe);
                        else if (numRegs == -2)
                            U.NotificacionError(idVentaCliente + Utils.nfefm);
                        else
                            U.NotificacionError(idVentaCliente + Utils.nfemd);
                    }
                    catch (Exception ex)
                    {
                        U.MsgCatchOue(ex);
                    }
                    if (numRegs > 0)
                    {
                        BorrarDatosBusqueda();
                        LlenarDgvVentas(false);
                        BorrarDatosVenta();
                    }
                }
                else
                {
                    BorrarDatosVenta();
                    btnGenerar.Enabled = false;
                }
            }
            CargarValoresOriginales();
        }

        private void tabcOperacion_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!VentaGenerada && Utils.HayCambios(this, valoresOriginales, errorProvider1))
                if (U.NotificacionQuestion("[orange]Se detectaron cambios en los datos de la venta que no han sido guardados.\n[blue]Si cambia de pestaña se perderan los datos no guardados.\n[red]¿Desea cambiar de pestaña?") == DialogResult.No)
                    e.Cancel = true;
        }

        private void btnNota_Click(object sender, EventArgs e)
        {
            if (!ChkRowVersion())
            {
                U.NotificacionWarning("El registro ha sido modificado por otro usuario de la red, se mostrará la nota de remisión con los datos proporcionados por el otro usuario");
            }
            FrmRptNotaRemision8 frmRptNotaRemision8 = new FrmRptNotaRemision8();
            frmRptNotaRemision8.Id = int.Parse(txtId.Text);
            frmRptNotaRemision8.ShowDialog();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BorrarDatosVenta();
            HabilitarControles();
            btnNota.Enabled = false;
            btnNuevo.Enabled = false;
            VentaGenerada = false;
            dgvDetalle.Columns["Eliminar"].Visible = true;
            numDetalle = 1;
            CargarValoresOriginales();
        }

        private bool ChkRowVersion()
        {
            bool rowVersionOk = true;
            if (txtId.Tag == null)
                return true;
            if (!int.TryParse(txtId.Text, out int ventaId))
                return false;
            byte[] rowVersion = (byte[])txtId.Tag;
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                Venta venta = _ventaBLL.ObtenerVentaPorId(ventaId);
                if (venta == null || !rowVersion.SequenceEqual(venta.RowVersion))
                    return false;
                // Validar filas del grid contra DB 
                // 1) Validar que cada fila del grid exista en DB y coincida RowVersion
                foreach (DataGridViewRow dgvr in dgvDetalle.Rows)
                {
                    if (!int.TryParse(dgvr.Cells["ProductoId"].Value?.ToString(), out int productoId))
                        return false;
                    byte[] rowVersionGrid = (byte[])dgvr.Cells["RowVersion"].Value;
                    byte[] rowVersionDetalleEnDB = _ventaDetalleBLL.ObtenerVentaDetalleRowVersion(ventaId, productoId);
                    if (!rowVersionGrid.SequenceEqual(rowVersionDetalleEnDB))
                        return false;
                }
                // Validar que DB no tenga detalles adicionales
                // 2) Validar que cada detalle en DB exista en el grid y coincida RowVersion
                List<VentaDetalle> ventaDetalles = _ventaDetalleBLL.ObtenerVentaDetallePorVentaId(ventaId);

                if (ventaDetalles != null)
                {
                    // Construir diccionario del grid para búsquedas O(1)
                    var gridMap = new Dictionary<int, byte[]>(); // productoId -> rowVersionGrid
                    foreach (DataGridViewRow dgvr in dgvDetalle.Rows)
                    {
                        if (int.TryParse(dgvr.Cells["ProductoId"].Value?.ToString(), out int pid))
                            if (dgvr.Cells["RowVersion"].Value is byte[] rv)
                                gridMap[pid] = rv;
                    }
                    foreach (var pd in ventaDetalles)
                    {
                        if (!gridMap.TryGetValue(pd.Producto.ProductID, out byte[] rowVersionGrid) || !rowVersionGrid.SequenceEqual(pd.RowVersion))
                            return false;
                    }
                }
                else
                {
                    // Política: si DB no tiene detalles y el grid sí, considerarlo inconsistente
                    if (dgvDetalle.Rows.Count > 0)
                        return false;
                }
                MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registro(s) en ventas");
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
                return false;
            }
            return rowVersionOk;
        }
    }
}
