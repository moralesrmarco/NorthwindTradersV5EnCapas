using BLL;
using BLL.Services;
using Entities;
using Entities.DTOs;
using NorthwindTradersV5EnCapas.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmVentasCrudV2 : Form
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        private VentaBLL _ventaBLL;
        private VentaDetalleBLL _ventaDetalleBLL;
        private ClienteService _clienteService;
        private EmpleadoService _empleadoService;
        private TransportistaService _transportistaService;
        private CategoriaService _categoriaService;
        private ProductoService _productoService;
        private VentaService _ventaService;
        private Dictionary<string, object> valoresOriginales;
        bool EventoCargado = true; // esta variable es necesaria para controlar el manejador de eventos de la celda del dgv ojo no quitar
        int numDetalle = 1;
        bool VentaGenerada = false;
        private short CantidadOld = 0;
        private short UInventarioOld = 0;

        public FrmVentasCrudV2()
        {
            InitializeComponent();
            headerOperacion.TabControl = tabcOperacion;
            headerOperacion.IconOn = Properties.Resources.pestanaOn;
            headerOperacion.IconOff = Properties.Resources.pestanaOff;
            headerOperacion.Build();
            this.Load += FrmVentasCrud_Load;
            this.FormClosed += FrmVentasCrud_FormClosed;
            this.FormClosing += FrmVentasCrud_FormClosing;
            tabcOperacion.Selected += tabcOperacion_Selected;
            tabcOperacion.Selecting += tabcOperacion_Selecting;
            grbVentas.Paint += GrbPaint;
            grbVenta.Paint += GrbPaint;
            grbTransportista.Paint += GrbPaint2;
            GrbOperaciones.Paint += GrbPaint;

            // Hacer que se pinten en negro los groupboxes de los controles anidados
            foreach (var gb in controlBuscarVenta.Controls.OfType<GroupBox>())
                gb.Paint += GrbPaint;
            foreach (var gb in controlTotalesDeLaVenta.Controls.OfType<GroupBox>())
                gb.Paint += GrbPaint;
            foreach (var gb in controlDetalleDeLaVenta.Controls.OfType<GroupBox>())
                gb.Paint += GrbPaint;
            // los groupboxes de controlAgregarProducto se pintaran directamente desde el control... porque se pintan de dos distintas maneras

            dgvVentas.ColumnHeaderMouseClick += dgvVentas_ColumnHeaderMouseClick;

            dgvVentas.CellClick += dgvVentas_CellClick;

            dtpVenta.ValueChanged += dtpVenta_ValueChanged;
            dtpRequerido.ValueChanged += dtpRequerido_ValueChanged;
            dtpEnvio.ValueChanged += dtpEnvio_ValueChanged;

            // Suscripción al evento del UserControl
            controlBuscarVenta.LimpiarClick += ControlBuscarVenta_LimpiarClick;
            controlBuscarVenta.BuscarClick += ControlBuscarVenta_BuscarClick;
            controlBuscarVenta.NudEnter += NudEnterHandler;
            controlBuscarVenta.NudBIdLeave += NudBIdLeaveHandler;
            controlBuscarVenta.NudBIdValueChanged += NudBIdValueChangedHandler;

            nudFlete.Enter += NudEnterHandler;

            controlAgregarProducto.NudEnter += NudEnterHandler;
            controlAgregarProducto.NudCantidadDescuento_LeaveValueChanged += NudCantidadDescuento_LeaveValueChangedHandler;
            controlAgregarProducto.CboCategoria_SelectedIndexChanged += CboCategoria_SelectedIndexChangedHandler;
            controlAgregarProducto.CboProducto_SelectedIndexChanged += CboProducto_SelectedIndexChangedHandler;
            controlAgregarProducto.BtnAgregar_Click += BtnAgregar_ClickHandler;

            cboCliente.SelectedIndexChanged += cboCliente_SelectedIndexChanged;

            btnNuevo.Click += btnNuevo_Click;
            btnNota.Click += btnNota_Click;
            btnGenerar.Click += btnGenerar_Click;

            controlDetalleDeLaVenta.DgvDetalle_CellClick += DgvDetalle_CellClickHandler;
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

        private void FrmVentasCrud_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            _ventaBLL = new VentaBLL(_connectionString);
            _ventaDetalleBLL = new VentaDetalleBLL(_connectionString);
            _clienteService = new ClienteService(_connectionString);
            _empleadoService = new EmpleadoService(_connectionString);
            _transportistaService = new TransportistaService(_connectionString);
            _categoriaService = new CategoriaService(_connectionString);
            _productoService = new ProductoService(_connectionString);
            _ventaService = new VentaService(_connectionString);

            tabcOperacion.Appearance = TabAppearance.Normal;
            tabcOperacion.ItemSize = new Size(0, 1);
            tabcOperacion.SizeMode = TabSizeMode.Fixed;

            dtpHoraRequerido.Value = DateTime.Today;
            dtpHoraEnvio.Value = DateTime.Today;

            DeshabilitarNudsNoSeleccionables();
            DeshabilitarControles();
            LlenarCboCliente();
            LlenarCboEmpleado();
            LlenarCboTransportista();
            LlenarCboCategoria();
            Utils.ConfDgv(dgvVentas);
            Utils.ConfDgv(controlDetalleDeLaVenta.DgvDetalle);
            LlenarDgvVentas(false);
            ConfDgvVentas();
            ConfDgvDetalle();
            controlDetalleDeLaVenta.DgvDetalle.Columns["Modificar"].Visible = false;
            controlDetalleDeLaVenta.DgvDetalle.Columns["Eliminar"].Visible = false;
            InicializarCboProducto();
            CargarValoresOriginales();
            // algoritmo para colapsar tablelayout2
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            grbVenta.AutoSize = true;
            grbVenta.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            tableLayoutPanel2.RowStyles[1].SizeType = SizeType.Absolute;
            tableLayoutPanel2.RowStyles[1].Height = 10;
            tableLayoutPanel2.RowStyles[3].SizeType = SizeType.Absolute;
            tableLayoutPanel2.RowStyles[3].Height = 10;

            tableLayoutPanel2.RowStyles[0].SizeType = SizeType.AutoSize;
            tableLayoutPanel2.RowStyles[2].SizeType = SizeType.AutoSize;
            tableLayoutPanel2.RowStyles[4].SizeType = SizeType.AutoSize;

            tableLayoutPanel1.RowStyles[5].SizeType = SizeType.AutoSize; // fila 6 → índice 5
            
            controlBuscarVenta.AutoSize = true;
            controlBuscarVenta.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            controlAgregarProducto.Visible = false;
            tableLayoutPanel2.RowStyles[4].Height = 0;
            tableLayoutPanel2.RowStyles[4].SizeType = SizeType.Absolute;
            tableLayoutPanel2.PerformLayout();   // fuerza recalculo
            grbVenta.PerformLayout();            // fuerza recalculo
            tableLayoutPanel1.PerformLayout();   // fuerza recalculo
            this.PerformLayout(); // fuerza al formulario entero
        }

        private void CargarValoresOriginales()
        {
            valoresOriginales = Utils.CapturarValoresOriginales(this);
        }

        private void DeshabilitarNudsNoSeleccionables()
        {
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudPrecioConIVAIncluido, false);
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudUInventario, false);

            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudPrecioPorUnidadSinIVAIncluidoAntesDescuento, false);
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudIVADelPrecioPorUnidadAntesDescuento, false);
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudPrecioPorUnidadSinIVADepuesDescuento, false);
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudAhorroPorUnidadSinIVA, false);
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudIVADelPrecioPorUnidadDespuesDescuento, false);
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudAhorroEnIVAPorUnidadDespuesDescuento, false);
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudPrecioPorUnidadConIVADespuesDescuento, false);
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudAhorroTotalPorUnidadConIVA, false);

            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudSubtotalDelImporteConIVAIncluido2, false);
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudSubtotalDelImporteSinIVASinDescuento2, false);
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudSubtotalDelImporteDelIVASinDescuento2, false);
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudSubtotalDelImporteSinIVAConDescuento2, false);
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudSubtotalIVADespuesDelDescuento2, false);
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudSubtotalDelAhorroSinIvaDespuesDescuento2, false);
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudSubtotalDelAhorroEnIVADespuesDescuento2, false);
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudSubtotalDelAhorroTotalDespuesDescuento2, false);
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudTotal2, false);

            Utilities.NudHelper.SetEnabled(controlTotalesDeLaVenta.NudNumProd, false);
            Utilities.NudHelper.SetEnabled(controlTotalesDeLaVenta.NudTotalDeUnidades, false);
            Utilities.NudHelper.SetEnabled(controlTotalesDeLaVenta.NudSubtotalDelImporte, false);
            Utilities.NudHelper.SetEnabled(controlTotalesDeLaVenta.NudSubtotalDelImporteDelDescuento, false);
            Utilities.NudHelper.SetEnabled(controlTotalesDeLaVenta.NudSubtotalDelImporteConDescuento, false);
            Utilities.NudHelper.SetEnabled(controlTotalesDeLaVenta.NudSubtotalDelImporteSinIVA, false);
            Utilities.NudHelper.SetEnabled(controlTotalesDeLaVenta.NudSubtotalDelImporteDelIVA, false);
            Utilities.NudHelper.SetEnabled(controlTotalesDeLaVenta.NudTotal, false);
            DeshabilitarFlete();
        }

        private void DeshabilitarCantidadDescuento()
        {
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudCantidad, false);
            Utilities.NudHelper.SetEnabled(controlAgregarProducto.NudDescuento, false);
        }

        private void DeshabilitarFlete()
        {
            Utilities.NudHelper.SetEnabled(nudFlete, false);
        }

        private void HabilitarFlete()
        {
            //Utilities.NudHelper.SetEnabled(nudFlete, true);
        }

        private void HabilitarCantidadDescuento()
        {
            //Utilities.NudHelper.SetEnabled(nudCantidad, true);
            //Utilities.NudHelper.SetEnabled(nudDescuento, true);
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
            controlAgregarProducto.CboProducto.DataSource = dtCboProductos;
            controlAgregarProducto.CboProducto.DisplayMember = "ProductName";
            controlAgregarProducto.CboProducto.ValueMember = "ProductID";
            controlAgregarProducto.CboProducto.Enabled = false;
        }

        private void DeshabilitarControles()
        {
            cboCliente.Enabled = cboEmpleado.Enabled = cboTransportista.Enabled = false;
            dtpVenta.Enabled = dtpHoraVenta.Enabled = dtpRequerido.Enabled = dtpHoraRequerido.Enabled = dtpEnvio.Enabled = dtpHoraEnvio.Enabled = false;
            txtDirigidoa.ReadOnly = txtDomicilio.ReadOnly = txtCiudad.ReadOnly = txtRegion.ReadOnly = txtCP.ReadOnly = txtPais.ReadOnly = true;
            btnGenerar.Enabled = btnNuevo.Enabled = btnNota.Enabled = false;

            controlAgregarProducto.CboCategoria.Enabled = controlAgregarProducto.CboProducto.Enabled = false;
            controlAgregarProducto.BtnAgregar.Enabled = false;

            DeshabilitarCantidadDescuento();
            DeshabilitarFlete();
        }

        private void HabilitarControles()
        {
            //cboCliente.Enabled = cboEmpleado.Enabled = cboTransportista.Enabled = cboCategoria.Enabled = true;
            //cboProducto.Enabled = false;
            //btnAgregar.Enabled = false;
            //dtpVenta.Enabled = dtpRequerido.Enabled = dtpEnvio.Enabled = true;
            //txtDirigidoa.ReadOnly = txtDomicilio.ReadOnly = txtCiudad.ReadOnly = txtRegion.ReadOnly = txtCP.ReadOnly = txtPais.ReadOnly = false;
            //HabilitarFlete();
            //btnGenerar.Enabled = true;
        }

        private void DeshabilitarControlesProducto()
        {
            //DeshabilitarCantidadDescuento();
            //OcultarIconosValidacion();
            //btnAgregar.Enabled = false;
            //cboProducto.Enabled = false;
        }

        private void DeshabilitarTodosControles()
        {
            DeshabilitarControles();
            DeshabilitarControlesProducto();
        }

        private void OcultarIconosValidacion()
        {
            //StatusIconHelper.HideIcons(pbError, pbInfo, pbWarning);
            //StatusIconHelper.HideIcons(pbError1, pbInfo1, pbWarning1);
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
                ComboBoxHelper.LlenarCbo(controlAgregarProducto.CboCategoria, dtCboCategoria, "CategoryName", "CategoryID");
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
                        IdIni = Convert.ToInt32(controlBuscarVenta.NudBIdIni.Value),
                        IdFin = Convert.ToInt32(controlBuscarVenta.NudBIdFin.Value),
                        Cliente = controlBuscarVenta.TxtBCliente.Text.Trim(),

                        FVenta = controlBuscarVenta.DtpFVentaIni.Checked && controlBuscarVenta.DtpFVentaFin.Checked,
                        FVentaIni = controlBuscarVenta.DtpFVentaIni.Checked ? controlBuscarVenta.DtpFVentaIni.Value.Date : (DateTime?)null,
                        FVentaFin = controlBuscarVenta.DtpFVentaFin.Checked ? controlBuscarVenta.DtpFVentaFin.Value.Date.AddDays(1) : (DateTime?)null,
                        FVentaNull = controlBuscarVenta.ChkbFVentaNull.Checked,

                        FRequerido = controlBuscarVenta.DtpFRequeridoIni.Checked && controlBuscarVenta.DtpFRequeridoFin.Checked,
                        FRequeridoIni = controlBuscarVenta.DtpFRequeridoIni.Checked ? controlBuscarVenta.DtpFRequeridoIni.Value.Date : (DateTime?)null,
                        FRequeridoFin = controlBuscarVenta.DtpFRequeridoFin.Checked ? controlBuscarVenta.DtpFRequeridoFin.Value.Date.AddDays(1) : (DateTime?)null,
                        FRequeridoNull = controlBuscarVenta.ChkbFRequeridoNull.Checked,

                        FEnvio = controlBuscarVenta.DtpFEnvioIni.Checked && controlBuscarVenta.DtpFEnvioFin.Checked,
                        FEnvioIni = controlBuscarVenta.DtpFEnvioIni.Checked ? controlBuscarVenta.DtpFEnvioIni.Value.Date : (DateTime?)null,
                        FEnvioFin = controlBuscarVenta.DtpFEnvioFin.Checked ? controlBuscarVenta.DtpFEnvioFin.Value.Date.AddDays(1) : (DateTime?)null,
                        FEnvioNull = controlBuscarVenta.ChkbFEnvioNull.Checked,

                        Empleado = controlBuscarVenta.TxtBEmpleado.Text.Trim(),
                        CompañiaT = controlBuscarVenta.TxtBCompañiaT.Text.Trim(),
                        DirigidoA = controlBuscarVenta.TxtBDirigidoa.Text.Trim()
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
            controlDetalleDeLaVenta.DgvDetalle.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            controlDetalleDeLaVenta.DgvDetalle.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            controlDetalleDeLaVenta.DgvDetalle.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            controlDetalleDeLaVenta.DgvDetalle.Columns["Descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            controlDetalleDeLaVenta.DgvDetalle.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            controlDetalleDeLaVenta.DgvDetalle.Columns["ImporteDelDescuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            controlDetalleDeLaVenta.DgvDetalle.Columns["ImporteConDescuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            controlDetalleDeLaVenta.DgvDetalle.Columns["TasaIVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            controlDetalleDeLaVenta.DgvDetalle.Columns["ImporteSinIVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            controlDetalleDeLaVenta.DgvDetalle.Columns["ImporteDelIVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            controlDetalleDeLaVenta.DgvDetalle.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            controlDetalleDeLaVenta.DgvDetalle.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            controlDetalleDeLaVenta.DgvDetalle.Columns["Precio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            controlDetalleDeLaVenta.DgvDetalle.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            controlDetalleDeLaVenta.DgvDetalle.Columns["Importe"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            controlDetalleDeLaVenta.DgvDetalle.Columns["Descuento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            controlDetalleDeLaVenta.DgvDetalle.Columns["ImporteDelDescuento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            controlDetalleDeLaVenta.DgvDetalle.Columns["ImporteConDescuento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            controlDetalleDeLaVenta.DgvDetalle.Columns["TasaIVA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            controlDetalleDeLaVenta.DgvDetalle.Columns["ImporteSinIVA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            controlDetalleDeLaVenta.DgvDetalle.Columns["ImporteDelIVA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            controlDetalleDeLaVenta.DgvDetalle.Columns["Subtotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            controlDetalleDeLaVenta.DgvDetalle.Columns["Modificar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            controlDetalleDeLaVenta.DgvDetalle.Columns["Eliminar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            controlDetalleDeLaVenta.DgvDetalle.Columns["Precio"].HeaderText = "Precio\ncon IVA\nincluido";
            controlDetalleDeLaVenta.DgvDetalle.Columns["ImporteDelDescuento"].HeaderText = "Importe\ndel\ndescuento";
            controlDetalleDeLaVenta.DgvDetalle.Columns["ImporteConDescuento"].HeaderText = "Importe\ncon\ndescuento";

            controlDetalleDeLaVenta.DgvDetalle.Columns["Precio"].DefaultCellStyle.Format = "c2";
            controlDetalleDeLaVenta.DgvDetalle.Columns["Cantidad"].DefaultCellStyle.Format = "n0";
            controlDetalleDeLaVenta.DgvDetalle.Columns["Descuento"].DefaultCellStyle.Format = "p2";
            controlDetalleDeLaVenta.DgvDetalle.Columns["Importe"].DefaultCellStyle.Format = "c2";
            controlDetalleDeLaVenta.DgvDetalle.Columns["ImporteDelDescuento"].DefaultCellStyle.Format = "c2";
            controlDetalleDeLaVenta.DgvDetalle.Columns["ImporteConDescuento"].DefaultCellStyle.Format = "c2";
            controlDetalleDeLaVenta.DgvDetalle.Columns["TasaIVA"].DefaultCellStyle.Format = "p2";
            controlDetalleDeLaVenta.DgvDetalle.Columns["ImporteSinIVA"].DefaultCellStyle.Format = "c2";
            controlDetalleDeLaVenta.DgvDetalle.Columns["ImporteDelIVA"].DefaultCellStyle.Format = "c2";
            controlDetalleDeLaVenta.DgvDetalle.Columns["Subtotal"].DefaultCellStyle.Format = "c2";
        }

        private void dgvVentas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // debe estar vinculado a la clase List<> a la cual esta vinculado el DataGridView.DataSource
            Utils.OrdenarPorColumna<DtoVentaDgv>(dgvVentas, e);
        }

        private void ControlBuscarVenta_LimpiarClick(object sender, EventArgs e)
        {
            //BorrarDatosVenta();
            //BorrarDatosDetalleVenta();
            //BorrarMensajesError();
            //BorrarDatosBusqueda();
            //if (tabcOperacion.SelectedTab != tabpRegistrar)
            //    DeshabilitarControles();
            //LlenarDgvVentas(false);
            //dgvVentas.Focus();
        }

        private void ControlBuscarVenta_BuscarClick(object sender, EventArgs e)
        {
            //BorrarDatosVenta();
            //BorrarDatosDetalleVenta();
            //BorrarMensajesError();
            //if (tabcOperacion.SelectedTab != tabpRegistrar)
            //    DeshabilitarControles();
            //LlenarDgvVentas(true);
            //dgvVentas.Focus();
        }

        private void BorrarDatosVenta()
        {
            //errorProvider1.Clear();
            //txtId.Text = "";
            //txtId.Tag = null;
            //cboCliente.SelectedIndex = cboEmpleado.SelectedIndex = cboTransportista.SelectedIndex = 0;
            //dtpVenta.Value = dtpRequerido.Value = dtpEnvio.Value = DateTime.Now;
            //dtpHoraVenta.Value = DateTime.Now;
            //dtpHoraRequerido.Value = dtpHoraEnvio.Value = DateTime.Today;
            //dtpRequerido.Checked = dtpEnvio.Checked = false;
            //txtDirigidoa.Text = txtDomicilio.Text = txtCiudad.Text = txtRegion.Text = txtCP.Text = txtPais.Text = "";
            //nudFlete.Value = 0;
            //btnNota.Enabled = false;
        }

        private void BorrarDatosDetalleVenta()
        {
            //cboCategoria.SelectedIndex = 0;
            //InicializarValoresAgregarProducto();
            //InicializarCboProducto();
            //InicializarNuds();
            //dgvDetalle.Rows.Clear();
        }

        //private void InicializarValoresAgregarProducto() => nudPrecioConIVAIncluido.Value = nudCantidad.Value = nudUInventario.Value = nudDescuento.Value = 0;

        private void InicializarValoresEnvio() => txtDirigidoa.Text = txtDomicilio.Text = txtCiudad.Text = txtRegion.Text = txtCP.Text = txtPais.Text = "";

        private void InicializarNuds()
        {
            //nudNumProd.Value = nudTotalDeUnidades.Value = nudSubtotalDelImporte.Value = nudSubtotalDelImporteDelDescuento.Value = nudSubtotalDelImporteConDescuento.Value = nudSubtotalDelImporteSinIVA.Value = nudSubtotalDelImporteDelIVA.Value = nudTotal.Value = 0;
            //InicializarNudsProducto();
        }

        private void InicializarNudsProducto()
        {
            //nudPrecioPorUnidadSinIVAIncluidoAntesDescuento.Value = nudIVADelPrecioPorUnidadAntesDescuento.Value = nudPrecioPorUnidadConIVADespuesDescuento.Value = nudIVADelPrecioPorUnidadDespuesDescuento.Value = nudPrecioPorUnidadSinIVADepuesDescuento.Value = nudAhorroPorUnidadSinIVA.Value = nudAhorroEnIVAPorUnidadDespuesDescuento.Value = nudAhorroTotalPorUnidadConIVA.Value = 0;

            //nudSubtotalDelImporteConIVAIncluido2.Value = nudSubtotalDelImporteSinIVASinDescuento2.Value = nudSubtotalDelImporteDelIVASinDescuento2.Value = nudSubtotalIVADespuesDelDescuento2.Value = nudSubtotalDelImporteSinIVAConDescuento2.Value = nudSubtotalDelAhorroSinIvaDespuesDescuento2.Value = nudSubtotalDelAhorroEnIVADespuesDescuento2.Value = nudSubtotalDelAhorroTotalDespuesDescuento2.Value = 0;

            //nudTotal2.Value = 0;
        }

        private void BorrarMensajesError() => errorProvider1.Clear();

        private void BorrarDatosBusqueda()
        {
            //nudBIdIni.Value = nudBIdFin.Value = 0;
            //txtBCliente.Text = txtBEmpleado.Text = txtBCompañiaT.Text = txtBDirigidoa.Text = "";
            //dtpBFVentaIni.Value = dtpBFVentaFin.Value = dtpBFRequeridoIni.Value = dtpBFRequeridoFin.Value = dtpBFEnvioIni.Value = dtpBFEnvioFin.Value = DateTime.Today;
            //dtpBFVentaIni.Checked = dtpBFVentaFin.Checked = dtpBFRequeridoIni.Checked = dtpBFRequeridoFin.Checked = dtpBFEnvioIni.Checked = dtpBFEnvioFin.Checked = false;
            //chkbBFVentaNull.Checked = chkbBFRequeridoNull.Checked = chkbBFEnvioNull.Checked = false;
        }

        private bool ValidarControlesVenta()
        {
            errorProvider1.Clear();
            bool valida = true;
            //if (cboCliente.SelectedIndex == 0)
            //{
            //    valida = false;
            //    errorProvider1.SetError(cboCliente, "Ingrese el cliente");
            //}
            //if (cboEmpleado.SelectedIndex == 0)
            //{
            //    valida = false;
            //    errorProvider1.SetError(cboEmpleado, "Ingrese el empleado");
            //}
            //if (dtpVenta.Checked == false)
            //{
            //    valida = false;
            //    errorProvider1.SetError(dtpVenta, "Ingrese la fecha de la venta");
            //}
            //if (cboTransportista.SelectedIndex == 0)
            //{
            //    valida = false;
            //    errorProvider1.SetError(cboTransportista, "Ingrese la compañía transportista");
            //}
            //if (nudTotal.Value == 0)
            //{
            //    valida = false;
            //    errorProvider1.SetError(btnAgregar, "Ingrese el detalle de la venta");
            //    errorProvider1.SetError(nudTotal, "El total de la venta no puede ser cero");
            //}
            //if (cboProducto.SelectedIndex > 0)
            //{
            //    valida = false;
            //    errorProvider1.SetError(cboProducto, "Se ha seleccionado un producto y no lo ha agregado a la venta");
            //}
            return valida;
        }

        private bool ValidarControlesProducto()
        {
            errorProvider1.Clear();
            bool valida = true;
            //if (cboCategoria.SelectedIndex <= 0)
            //{
            //    valida = false;
            //    errorProvider1.SetError(cboCategoria, "Seleccione la categoría");
            //}
            //if (cboProducto.SelectedIndex <= 0)
            //{
            //    valida = false;
            //    errorProvider1.SetError(cboProducto, "Seleccione el producto");
            //}
            //if (cboProducto.SelectedIndex > 0)
            //{
            //    int numProd = int.Parse(cboProducto.SelectedValue.ToString());
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
            //        valida = false;
            //        errorProvider1.SetError(cboProducto, "No se puede tener un producto duplicado en el detalle del pedido");
            //    }
            //}
            //// necesario crear un objeto temporal para calcular el subtotal con la formulas ya definidas en la clase VentaDetalle
            //VentaDetalle ventaDetalle = new VentaDetalle();
            //ventaDetalle.UnitPrice = nudPrecioConIVAIncluido.Value;
            //ventaDetalle.Quantity = (short)nudCantidad.Value;
            //ventaDetalle.Discount = nudDescuento.Value / 100m;
            //CalcularTotalProducto(ventaDetalle);
            //if (ventaDetalle.Subtotal == 0)
            //{
            //    valida = false;
            //    if (nudCantidad.Value == 0)
            //        errorProvider1.SetError(btnAgregar, "Ingrese el detalle del pedido");
            //    else if (ventaDetalle.Subtotal == 0)
            //    {
            //        errorProvider1.SetError(btnAgregar, "El valor del subtotal del producto no puede ser cero");
            //        errorProvider1.SetError(nudTotal2, "El valor del subtotal del producto no puede ser cero");
            //    }
            //}
            //InventarioHelper.ActualizarInventarioUi
            //(
            //    nudCantidad.Value,
            //    CantidadOld,
            //    UInventarioOld,
            //    nudUInventario
            //);
            //// Validación informativa (inventario)
            //// no afecta el retorno, solo muestra íconos
            //ValidarCantidadEInventarioHelper.ValidarInventario
            //(
            //    nudCantidad.Value,
            //    CantidadOld,
            //    UInventarioOld,
            //    nudUInventario.Value,
            //    nudUInventario,
            //    toolTip1,
            //    pbError1,
            //    pbInfo1,
            //    pbWarning1,
            //    errorProvider1
            //);

            //// Valida reglas de negocio con StatusIconHelper
            //// Validación restrictiva (cantidad)
            //if (!ValidarCantidadEInventarioHelper.ValidarCantidad
            //    (
            //        nudCantidad.Value,
            //        CantidadOld,
            //        UInventarioOld,
            //        nudUInventario.Value,
            //        nudCantidad,
            //        toolTip1,
            //        pbError,
            //        pbInfo,
            //        pbWarning,
            //        errorProvider1
            //    )
            //)
            //{
            //    valida = false;
            //    btnAgregar.Enabled = false;
            //}
            //else
            //    btnAgregar.Enabled = true;

            return valida;
        }

        private void CalcularTotalProducto(VentaDetalle ventaDetalle)
        {
            //nudPrecioPorUnidadSinIVAIncluidoAntesDescuento.Value = ventaDetalle.PrecioPorUnidadSinIVASinDescuento;
            //nudIVADelPrecioPorUnidadAntesDescuento.Value = ventaDetalle.IVADelPrecioPorUnidadSinDescuento;
            //nudPrecioPorUnidadConIVADespuesDescuento.Value = ventaDetalle.PrecioPorUnidadConIVADespuesDescuento;
            //nudIVADelPrecioPorUnidadDespuesDescuento.Value = ventaDetalle.IVADelPrecioporUnidadDespuesDescuento;
            //nudPrecioPorUnidadSinIVADepuesDescuento.Value = ventaDetalle.PrecioPorUnidadSinIVADepuesDescuento;
            //nudAhorroPorUnidadSinIVA.Value = ventaDetalle.AhorroPorUnidadSinIVA;
            //nudAhorroEnIVAPorUnidadDespuesDescuento.Value = ventaDetalle.AhorroEnIVAPorUnidadDespuesDescuento;
            //nudAhorroTotalPorUnidadConIVA.Value = ventaDetalle.AhorroTotalPorUnidadConIVA;

            //nudSubtotalDelImporteConIVAIncluido2.Value = ventaDetalle.SubtotalDelImporteConIVAIncluido;
            //nudSubtotalDelImporteSinIVASinDescuento2.Value = ventaDetalle.SubtotalDelImporteSinIVASinDescuento;
            //nudSubtotalDelImporteDelIVASinDescuento2.Value = ventaDetalle.SubtotalDelImporteDelIVASinDescuento;
            //nudSubtotalIVADespuesDelDescuento2.Value = ventaDetalle.SubtotalIVADespuesDelDescuento;
            //nudSubtotalDelImporteSinIVAConDescuento2.Value = ventaDetalle.SubtotalDelImporteSinIVAConDescuento;
            //nudSubtotalDelAhorroSinIvaDespuesDescuento2.Value = ventaDetalle.SubtotalDelAhorroSinIvaDespuesDescuento;
            //nudSubtotalDelAhorroEnIVADespuesDescuento2.Value = ventaDetalle.SubtotalDelAhorroEnIVADespuesDescuento;
            //nudSubtotalDelAhorroTotalDespuesDescuento2.Value = ventaDetalle.SubtotalDelAhorroTotalDespuesDescuento;

            //nudTotal2.Value = ventaDetalle.Subtotal;
        }

        private void CalcularTotales()
        {
            //decimal importe, total, totalDeUnidades, subtotalDelImporte, subtotalDelImporteDelDescuento, subtotalDelImporteConDescuento, subtotalDelImporteSinIVA, subtotalDelImporteDelIVA;
            //importe = total = totalDeUnidades = subtotalDelImporte = subtotalDelImporteDelDescuento = subtotalDelImporteConDescuento = subtotalDelImporteSinIVA = subtotalDelImporteDelIVA = 0;
            //numDetalle = 0;
            //foreach (DataGridViewRow dgvr in dgvDetalle.Rows)
            //{
            //    totalDeUnidades += decimal.Parse(dgvr.Cells["Cantidad"].Value.ToString());
            //    subtotalDelImporte += decimal.Parse(dgvr.Cells["Importe"].Value.ToString());
            //    subtotalDelImporteDelDescuento += decimal.Parse(dgvr.Cells["ImporteDelDescuento"].Value.ToString());
            //    subtotalDelImporteConDescuento += decimal.Parse(dgvr.Cells["ImporteConDescuento"].Value.ToString());
            //    subtotalDelImporteSinIVA += decimal.Parse(dgvr.Cells["ImporteSinIVA"].Value.ToString());
            //    subtotalDelImporteDelIVA += decimal.Parse(dgvr.Cells["ImporteDelIVA"].Value.ToString());
            //    total += decimal.Parse(dgvr.Cells["Subtotal"].Value.ToString());
            //    dgvr.Cells["Id"].Value = ++numDetalle;
            //}
            //nudNumProd.Value = numDetalle;
            //nudTotalDeUnidades.Value = totalDeUnidades;
            //nudSubtotalDelImporte.Value = subtotalDelImporte;
            //nudSubtotalDelImporteDelDescuento.Value = subtotalDelImporteDelDescuento;
            //nudSubtotalDelImporteConDescuento.Value = subtotalDelImporteConDescuento;
            //nudSubtotalDelImporteSinIVA.Value = subtotalDelImporteSinIVA;
            //nudSubtotalDelImporteDelIVA.Value = subtotalDelImporteDelIVA;
            //nudTotal.Value = total;
        }

        private void NudEnterHandler(object sender, EventArgs e)
        {
            if (sender is NumericUpDown nud && nud.Controls[1] is TextBox tb)
            {
                // Diferir la selección para que ocurra después de que el TextBox reciba el foco
                tb.BeginInvoke((Action)(() => tb.SelectAll()));
            }
        }

        private void NudBIdLeaveHandler(object sender, EventArgs e) => Utils.ValidarRango(sender, controlBuscarVenta.NudBIdIni, controlBuscarVenta.NudBIdFin);

        private void NudBIdValueChangedHandler(object sender, EventArgs e) => Utils.ValidarRango(sender, controlBuscarVenta.NudBIdIni, controlBuscarVenta.NudBIdFin);

        private void NudCantidadDescuento_LeaveValueChangedHandler(object sender, EventArgs e) => ValidarControlesVenta();

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

        private void CboCategoria_SelectedIndexChangedHandler(object sender, EventArgs e)
        {
            //InicializarValoresAgregarProducto();
            //BorrarMensajesError();
            //if (cboCategoria.SelectedIndex > 0)
            //{
            //    try
            //    {
            //        MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
            //        var dtCboProductos = _productoService.ObtenerProductosPorCategoriaCbo(int.Parse(cboCategoria.SelectedValue.ToString()));
            //        cboProducto.DataSource = dtCboProductos;
            //        cboProducto.DisplayMember = "ProductName";
            //        cboProducto.ValueMember = "ProductID";
            //        cboProducto.Enabled = true;
            //        MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registro(s) en ventas");
            //    }
            //    catch (Exception ex)
            //    {
            //        U.MsgCatchOue(ex);
            //    }
            //}
            //else
            //{
            //    MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
            //    InicializarCboProducto();
            //    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registro(s) en ventas");
            //}
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboCliente.SelectedIndex > 0)
            //{
            //    try
            //    {
            //        MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
            //        var dtoEnvioInformacion = _ventaService.ObtenerUltimaInformacionDeEnvio(cboCliente.SelectedValue?.ToString());
            //        if (dtoEnvioInformacion != null)
            //        {
            //            txtDirigidoa.Text = dtoEnvioInformacion.ShipName ?? "";
            //            txtDomicilio.Text = dtoEnvioInformacion.ShipAddress ?? "";
            //            txtCiudad.Text = dtoEnvioInformacion.ShipCity ?? "";
            //            txtRegion.Text = dtoEnvioInformacion.ShipRegion ?? "";
            //            txtCP.Text = dtoEnvioInformacion.ShipPostalCode ?? "";
            //            txtPais.Text = dtoEnvioInformacion.ShipCountry ?? "";
            //        }
            //        else
            //            InicializarValoresEnvio();
            //        MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registro(s) en ventas");
            //    }
            //    catch (Exception ex)
            //    {
            //        U.MsgCatchOue(ex);
            //    }
            //}
            //else
            //    InicializarValoresEnvio();
        }

        private void CboProducto_SelectedIndexChangedHandler(object sender, EventArgs e)
        {
            BorrarMensajesError();
            //if (cboProducto.SelectedIndex > 0)
            //{
            //    try
            //    {
            //        MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
            //        var productId = cboProducto.SelectedValue?.ToString();
            //        InicializarValoresAgregarProducto();
            //        var dtoProductoCostoEInventario = _productoService.ObtenerProductoCostoEInventario(int.Parse(productId));
            //        if (dtoProductoCostoEInventario != null)
            //        {
            //            nudPrecioConIVAIncluido.Value = dtoProductoCostoEInventario.UnitPrice;
            //            nudUInventario.Value = dtoProductoCostoEInventario.UnitsInStock;
            //            UInventarioOld = short.Parse(dtoProductoCostoEInventario.UnitsInStock.ToString());
            //            ValidarCantidadEInventarioHelper.ValidarInventario
            //            (
            //                nudCantidad.Value,
            //                CantidadOld,
            //                UInventarioOld,
            //                nudUInventario.Value,
            //                nudUInventario,
            //                toolTip1,
            //                pbError1,
            //                pbInfo1,
            //                pbWarning1,
            //                errorProvider1
            //            );
            //            ValidarCantidadEInventarioHelper.ValidarCantidad
            //            (
            //                nudCantidad.Value,
            //                CantidadOld,
            //                UInventarioOld,
            //                nudUInventario.Value,
            //                nudCantidad,
            //                toolTip1,
            //                pbError,
            //                pbInfo,
            //                pbWarning,
            //                errorProvider1
            //            );
            //            if (dtoProductoCostoEInventario.UnitsInStock == 0)
            //            {
            //                DeshabilitarControlesProducto();
            //                U.NotificacionWarning("No hay este producto en existencia.");
            //                cboProducto.SelectedIndex = 0;
            //                InicializarValoresAgregarProducto();
            //            }
            //            else
            //                HabilitarControlesProducto();
            //        }
            //        else
            //        {
            //            DeshabilitarControlesProducto();
            //            InicializarValoresAgregarProducto();
            //            InicializarCboProducto();
            //        }
            //        MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registro(s) en ventas");
            //    }
            //    catch (Exception ex)
            //    {
            //        U.MsgCatchOue(ex);
            //    }
            //}
            //else
            //{
            //    DeshabilitarControlesProducto();
            //    InicializarValoresAgregarProducto();
            //}
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            //btnNota.Enabled = false;
            //if (tabcOperacion.SelectedTab != tabpRegistrar)
            //{
            //    BorrarDatosVenta();
            //    BorrarDatosDetalleVenta();
            //    BorrarMensajesError();
            //    DataGridViewRow dgvr = dgvVentas.CurrentRow;
            //    txtId.Text = dgvr.Cells["OrderId"].Value.ToString();
            //    // se tiene que definir aqui para verificar la concurrencia porque como lo venia haciendo habia un lapso de tiempo que podia cambiar el registro, se tiene que comparar contra lo que esta definido en el dgvVentas
            //    txtId.Tag = dgvr.Cells["RowVersionStr"].Value;
            //    int orderId = string.IsNullOrEmpty(txtId.Text) ? 0 : Convert.ToInt32(txtId.Text);
            //    LlenarDatosVenta(ref orderId);
            //    if (orderId != 0)
            //    {
            //        LlenarDatosDetalleVenta(orderId);
            //        DeshabilitarTodosControles();
            //        if (tabcOperacion.SelectedTab == tabpConsultar)
            //        {
            //            btnNota.Enabled = true;
            //            btnNuevo.Enabled = false;
            //        }
            //        else if (tabcOperacion.SelectedTab == tabpModificar)
            //        {
            //            HabilitarControles();
            //            btnGenerar.Enabled = true;
            //            btnNota.Enabled = false;
            //            btnNuevo.Enabled = false;
            //        }
            //        else if (tabcOperacion.SelectedTab == tabpEliminar)
            //        {
            //            btnGenerar.Enabled = true;
            //            btnNota.Enabled = false;
            //            btnNuevo.Enabled = false;
            //        }
            //    }
            //    else
            //    {
            //        LlenarDgvVentas(false);
            //        DeshabilitarTodosControles();
            //    }
            //}
            //CargarValoresOriginales();
            //dgvDetalle.Focus();
        }

        private void LlenarDatosVenta(ref int orderId)
        {
            if (orderId == 0) return;
            //try
            //{
            //    MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
            //    var venta = _ventaBLL.ObtenerVentaPorId(orderId);
            //    if (venta != null)
            //    {
            //        cboCliente.SelectedIndexChanged -= new EventHandler(cboCliente_SelectedIndexChanged);
            //        cboCliente.SelectedValue = venta.Cliente.CustomerID;
            //        cboCliente.SelectedIndexChanged += new EventHandler(cboCliente_SelectedIndexChanged);
            //        cboEmpleado.SelectedValue = venta.Empleado.EmployeeID;
            //        cboTransportista.SelectedValue = venta.Transportista.ShipperID;
            //        txtDirigidoa.Text = venta.ShipName ?? "";
            //        txtDomicilio.Text = venta.ShipAddress ?? "";
            //        txtCiudad.Text = venta.ShipCity ?? "";
            //        txtRegion.Text = venta.ShipRegion ?? "";
            //        txtCP.Text = venta.ShipPostalCode ?? "";
            //        txtPais.Text = venta.ShipCountry ?? "";
            //        nudFlete.Value = venta.Freight ?? 0;
            //        if (venta.OrderDate.HasValue)
            //        {
            //            dtpVenta.Value = venta.OrderDate.Value;
            //            dtpHoraVenta.Value = venta.OrderDate.Value;
            //            dtpVenta.Checked = true;
            //            dtpHoraVenta.Enabled = true;
            //        }
            //        else
            //        {
            //            dtpVenta.Value = dtpVenta.MinDate;
            //            dtpVenta.Checked = false;
            //            dtpHoraVenta.Value = dtpHoraVenta.MinDate;
            //            dtpHoraVenta.Enabled = false;
            //        }
            //        if (venta.RequiredDate.HasValue)
            //        {
            //            dtpRequerido.Value = venta.RequiredDate.Value;
            //            dtpHoraRequerido.Value = venta.RequiredDate.Value;
            //            dtpRequerido.Checked = true;
            //            dtpHoraRequerido.Enabled = true;
            //        }
            //        else
            //        {
            //            dtpRequerido.Value = dtpRequerido.MinDate;
            //            dtpRequerido.Checked = false;
            //            dtpHoraRequerido.Value = dtpHoraRequerido.MinDate;
            //            dtpHoraRequerido.Enabled = false;
            //        }
            //        if (venta.ShippedDate.HasValue)
            //        {
            //            dtpEnvio.Value = venta.ShippedDate.Value;
            //            dtpHoraEnvio.Value = venta.ShippedDate.Value;
            //            dtpEnvio.Checked = true;
            //            dtpHoraEnvio.Enabled = true;
            //        }
            //        else
            //        {
            //            dtpEnvio.Value = dtpEnvio.MinDate;
            //            dtpEnvio.Checked = false;
            //            dtpHoraEnvio.Value = dtpHoraEnvio.MinDate;
            //            dtpHoraEnvio.Enabled = false;
            //        }
            //        MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registro(s) en ventas");
            //    }
            //    else
            //    {
            //        txtId.Text = string.Empty;
            //        txtId.Tag = null;
            //        orderId = 0;
            //        U.NotificacionWarning("[orange]No se encontró la venta especificada." + Utils.erfep);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    U.MsgCatchOue(ex);
            //}
        }

        private void LlenarDatosDetalleVenta(int orderId)
        {
            if (orderId == 0) return;
            //try
            //{
            //    numDetalle = 1;
            //    MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
            //    var ventaDetalles = _ventaDetalleBLL.ObtenerVentaDetallePorVentaId(orderId);
            //    dgvDetalle.Columns["Eliminar"].Visible = false;
            //    if (ventaDetalles.Count == 0)
            //    {
            //        U.NotificacionWarning("No se encontraron detalles para la venta especificada");
            //    }
            //    else
            //    {
            //        foreach (var ventaDetalle in ventaDetalles)
            //        {
            //            dgvDetalle.Rows.Add(new object[]
            //            {
            //                numDetalle,
            //                ventaDetalle.Producto.ProductName,
            //                ventaDetalle.UnitPrice,
            //                ventaDetalle.Quantity,
            //                ventaDetalle.SubtotalDelImporteConIVAIncluido,
            //                ventaDetalle.Discount,
            //                ventaDetalle.SubtotalDelAhorroTotalDespuesDescuento,
            //                ventaDetalle.SubtotalDelImporteConIVAConDescuento,
            //                ventaDetalle.TasaIVA,
            //                ventaDetalle.SubtotalDelImporteSinIVAConDescuento,
            //                ventaDetalle.SubtotalIVADespuesDelDescuento,
            //                ventaDetalle.Subtotal,
            //                "Eliminar",
            //                ventaDetalle.Producto.ProductID,
            //                ventaDetalle.RowVersion
            //            });
            //            ++numDetalle;
            //        }
            //    }
            //    CalcularTotales();
            //    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registro(s) en ventas");
            //}
            //catch (Exception ex)
            //{
            //    U.MsgCatchOue(ex);
            //}
        }

        private void BtnAgregar_ClickHandler(object sender, EventArgs e)
        {
            //if (!ValidarControlesProducto())
            //    return;
            //DeshabilitarControlesProducto();
            //var ventaDetalle = new VentaDetalle
            //{
            //    Producto = new Producto
            //    {
            //        ProductID = (int)cboProducto.SelectedValue,
            //        ProductName = cboProducto.Text
            //    },
            //    UnitPrice = nudPrecioConIVAIncluido.Value,
            //    Quantity = (short)nudCantidad.Value,
            //    Discount = nudDescuento.Value / 100m
            //};
            //dgvDetalle.Rows.Add(new object[]
            //{
            //    numDetalle,
            //    ventaDetalle.Producto.ProductName,
            //    ventaDetalle.UnitPrice,
            //    ventaDetalle.Quantity,
            //    ventaDetalle.SubtotalDelImporteConIVAIncluido,
            //    ventaDetalle.Discount,
            //    ventaDetalle.SubtotalDelAhorroTotalDespuesDescuento,
            //    ventaDetalle.SubtotalDelImporteConIVAConDescuento,
            //    ventaDetalle.TasaIVA,
            //    ventaDetalle.SubtotalDelImporteSinIVAConDescuento,
            //    ventaDetalle.SubtotalIVADespuesDelDescuento,
            //    ventaDetalle.Subtotal,
            //    "Eliminar",
            //    ventaDetalle.Producto.ProductID
            //});
            //CalcularTotales();
            //++numDetalle;
            //cboCategoria.SelectedIndex = 0;
            //InicializarCboProducto();
            //InicializarValoresAgregarProducto();
            //InicializarNudsProducto();
            //dgvDetalle.Focus();
            //cboCategoria.Focus();
        }

        private void DgvDetalle_CellClickHandler(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0 || e.ColumnIndex != dgvDetalle.Columns["Eliminar"].Index)
            //    return;
            //dgvDetalle.Rows.RemoveAt(e.RowIndex);
            //CalcularTotales();
        }

        private void tabcOperacion_Selected(object sender, TabControlEventArgs e)
        {
            numDetalle = 1;
            BorrarDatosVenta();
            BorrarDatosDetalleVenta();
            BorrarMensajesError();
            controlAgregarProducto.Visible = false;
            if (tabcOperacion.SelectedTab == tabpRegistrar)
            {
                if (EventoCargado)
                {
                    dgvVentas.CellClick -= new DataGridViewCellEventHandler(dgvVentas_CellClick);
                    EventoCargado = false;
                }
                controlAgregarProducto.Visible = true;
                VentaGenerada = false;
                BorrarDatosBusqueda();
                HabilitarControles();
                btnGenerar.Text = "Generar venta";
                controlDetalleDeLaVenta.DgvDetalle.Columns["Eliminar"].Visible = true;
                controlDetalleDeLaVenta.DgvDetalle.Columns["Modificar"].Visible = true;
                dtpHoraRequerido.Enabled = dtpHoraEnvio.Enabled = false;
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
                controlDetalleDeLaVenta.DgvDetalle.Columns["Modificar"].Visible = false;
                controlDetalleDeLaVenta.DgvDetalle.Columns["Eliminar"].Visible = false;
                if (tabcOperacion.SelectedTab == tabpConsultar)
                {
                    btnGenerar.Text = "Generar venta";
                    btnNota.Enabled = false;
                    btnNuevo.Enabled = false;
                }
                else if (tabcOperacion.SelectedTab == tabpModificar)
                {
                    VentaGenerada = false;
                    btnGenerar.Text = "Modificar venta";
                    btnNota.Enabled = false;
                    btnNuevo.Enabled = false;
                }
                else if (tabcOperacion.SelectedTab == tabpEliminar)
                {
                    btnGenerar.Text = "Eliminar venta";
                    btnNota.Enabled = false;
                    btnNuevo.Enabled = false;
                }
            }
            CargarValoresOriginales();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            int numRegs = 0;
            BorrarMensajesError();
            //if (tabcOperacion.SelectedTab == tabpRegistrar)
            //{
            //    try
            //    {
            //        if (ValidarControlesVenta())
            //        {
            //            MDIPrincipal.ActualizarBarraDeEstado(Utils.insertandoRegistro);
            //            DeshabilitarControles();
            //            btnGenerar.Enabled = false;
            //            Venta venta = new Venta();
            //            venta.Cliente.CustomerID = cboCliente.SelectedValue.ToString().Trim();
            //            venta.Empleado.EmployeeID = Convert.ToInt32(cboEmpleado.SelectedValue);
            //            if (dtpVenta != null && dtpHoraVenta != null)
            //                venta.OrderDate = Utils.ObtenerFechaHora(dtpVenta, dtpHoraVenta);
            //            if (dtpRequerido != null && dtpHoraRequerido != null)
            //                venta.RequiredDate = Utils.ObtenerFechaHora(dtpRequerido, dtpHoraRequerido);
            //            if (dtpEnvio != null && dtpHoraEnvio != null)
            //                venta.ShippedDate = Utils.ObtenerFechaHora(dtpEnvio, dtpHoraEnvio);
            //            venta.Transportista.ShipperID = int.Parse(cboTransportista.SelectedValue.ToString());
            //            venta.ShipName = txtDirigidoa.Text.Trim();
            //            venta.ShipAddress = txtDomicilio.Text.Trim();
            //            venta.ShipCity = txtCiudad.Text.Trim();
            //            venta.ShipRegion = txtRegion.Text.Trim();
            //            venta.ShipPostalCode = txtCP.Text.Trim();
            //            venta.ShipCountry = txtPais.Text.Trim();
            //            venta.Freight = nudFlete.Value;
            //            // llenado de elementos hijos
            //            foreach (DataGridViewRow dgvr in dgvDetalle.Rows)
            //            {
            //                // defensiva: ignorar filas nuevas o vacías
            //                if (dgvr.IsNewRow) continue;
            //                VentaDetalle ventaDetalles = new VentaDetalle
            //                {
            //                    Producto = new Producto
            //                    {
            //                        ProductID = int.Parse(dgvr.Cells["ProductoId"].Value.ToString()),
            //                        ProductName = dgvr.Cells["Producto"].Value.ToString()
            //                    },
            //                    UnitPrice = decimal.Parse(dgvr.Cells["Precio"].Value.ToString()),
            //                    Quantity = short.Parse(dgvr.Cells["Cantidad"].Value.ToString()),
            //                    Discount = decimal.Parse(dgvr.Cells["Descuento"].Value.ToString())
            //                };
            //                venta.VentaDetalles.Add(ventaDetalles);
            //            }
            //            numRegs = _ventaBLL.InsertarVentaCompleta(venta, out int orderId, out byte[] rowVersion);
            //            txtId.Text = orderId.ToString();
            //            venta.RowVersion = rowVersion;
            //            txtId.Tag = venta.RowVersionStr;
            //            MDIPrincipal.ActualizarBarraDeEstado($"Se insertaron 1 registro en ventas y {venta.VentaDetalles.Count} registro(s) en el detalle de ventas");
            //            string paraNotificacion = $"La venta con Id: {txtId.Text} del Cliente: {cboCliente.Text}:";
            //            if (numRegs > 0)
            //                U.NotificacionInformation(paraNotificacion + Utils.srs);
            //            else
            //                U.NotificacionError(paraNotificacion + Utils.nfrs);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        U.MsgCatchOue(ex);
            //        btnNuevo.Enabled = true;
            //        btnNuevo.PerformClick();
            //        btnNuevo.Enabled = false;
            //    }
            //    if (numRegs > 0)
            //    {
            //        VentaGenerada = true;
            //        numDetalle = 1;
            //        btnNota.Enabled = true;
            //        btnNuevo.Enabled = true;
            //        BorrarDatosBusqueda();
            //        LlenarDgvVentas(false);
            //        dgvDetalle.Rows.Clear();
            //        LlenarDatosDetalleVenta(Convert.ToInt32(txtId.Text));
            //        txtId.Focus();
            //    }
            //}
            //else if (tabcOperacion.SelectedTab == tabpModificar)
            //{
            //    try
            //    {
            //        if (ValidarControlesVenta())
            //        {
            //            MDIPrincipal.ActualizarBarraDeEstado(Utils.modificandoRegistro);
            //            DeshabilitarControles();
            //            btnGenerar.Enabled = false;
            //            Venta venta = new Venta();
            //            venta.OrderID = int.Parse(txtId.Text);
            //            venta.Cliente.CustomerID = cboCliente.SelectedValue.ToString().Trim();
            //            venta.Empleado.EmployeeID = Convert.ToInt32(cboEmpleado.SelectedValue);
            //            if (!dtpVenta.Checked)
            //                venta.OrderDate = null;
            //            else
            //                venta.OrderDate = Utils.ObtenerFechaHora(dtpVenta, dtpHoraVenta);
            //            if (!dtpRequerido.Checked)
            //                venta.RequiredDate = null;
            //            else
            //                venta.RequiredDate = Utils.ObtenerFechaHora(dtpRequerido, dtpHoraRequerido);
            //            if (!dtpEnvio.Checked)
            //                venta.ShippedDate = null;
            //            else
            //                venta.ShippedDate = Utils.ObtenerFechaHora(dtpEnvio, dtpHoraEnvio);
            //            venta.Transportista.ShipperID = Convert.ToInt32(cboTransportista.SelectedValue);
            //            venta.ShipName = txtDirigidoa.Text.Trim();
            //            venta.ShipAddress = txtDomicilio.Text.Trim();
            //            venta.ShipCity = txtCiudad.Text.Trim();
            //            venta.ShipRegion = txtRegion.Text.Trim();
            //            venta.ShipPostalCode = txtCP.Text.Trim();
            //            venta.ShipCountry = txtPais.Text.Trim();
            //            venta.Freight = nudFlete.Value;
            //            venta.RowVersion = RowVersionHelper.RowVersionObjToByteArray(txtId.Tag);
            //            numRegs = _ventaBLL.Actualizar(venta);
            //            txtId.Tag = venta.RowVersionStr; // se tiene que actualizar por la nota de remision no detecte un cambio
            //            MDIPrincipal.ActualizarBarraDeEstado($"Se actualizaron {(numRegs < 0 ? 0 : numRegs)} registro(s)");
            //            string idVentaCliente = $"La venta con Id: {venta.OrderID} - Cliente: {cboCliente.Text}:";
            //            if (numRegs > 0)
            //                U.NotificacionInformation(idVentaCliente + Utils.sms);
            //            else if (numRegs == -1)
            //                U.NotificacionError(idVentaCliente + Utils.nfmfe);
            //            else if (numRegs == -2)
            //                U.NotificacionError(idVentaCliente + Utils.nfmfm);
            //            else
            //                U.NotificacionError(idVentaCliente + Utils.nfmmd);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        U.MsgCatchOue(ex);
            //    }
            //    if (numRegs > 0)
            //    {
            //        VentaGenerada = true;
            //        btnNota.Enabled = true;
            //        btnNuevo.Enabled = false;
            //        LlenarDgvVentas(false);
            //    }
            //    else if (numRegs >= -2)
            //    {
            //        LlenarDgvVentas(false);
            //        BorrarDatosVenta();
            //        BorrarDatosDetalleVenta();
            //    }
            //}
            //else if (tabcOperacion.SelectedTab == tabpEliminar)
            //{
            //    if (U.NotificacionQuestion($"[orange]¿Esta seguro de eliminar la venta con Id: {txtId.Text} del Cliente: {cboCliente.Text}?") == DialogResult.Yes)
            //    {
            //        MDIPrincipal.ActualizarBarraDeEstado(Utils.eliminandoRegistro);
            //        btnGenerar.Enabled = false;
            //        try
            //        {
            //            Venta venta = new Venta();
            //            venta.OrderID = int.Parse(txtId.Text);
            //            venta.RowVersion = RowVersionHelper.RowVersionObjToByteArray(txtId.Tag);
            //            numRegs = _ventaBLL.Eliminar(venta, out string productoExcede);
            //            string idVentaCliente = $"La venta con Id: {txtId.Text} - Cliente: {cboCliente.Text}:";
            //            if (numRegs > 0)
            //                U.NotificacionInformation(idVentaCliente + Utils.ses);
            //            else if (numRegs == -1)
            //                U.NotificacionError(idVentaCliente + Utils.nfefe);
            //            else if (numRegs == -2)
            //                U.NotificacionError(idVentaCliente + Utils.nfefm);
            //            else if (numRegs == -7)
            //                U.NotificacionError(idVentaCliente + $"\n[red]No fue eliminada de la base de datos, el nuevo inventario del producto {productoExcede}, excedió el límite máximo que se puede almacenar en la base de datos (32,767 unidades)"); // Stock excedió el máximo permitido
            //            else if (numRegs == -8)
            //                U.NotificacionError(idVentaCliente + $"\n[red]No fue eliminada de la base de datos, el nuevo inventario del producto {productoExcede}, sería invalido (negativo)"); // stock negativo, este caso nunca ocurre porque la base de datos no lo permite con un check constraint
            //            else
            //                U.NotificacionError(idVentaCliente + Utils.nfemd);
            //        }
            //        catch (Exception ex)
            //        {
            //            U.MsgCatchOue(ex);
            //        }
            //        if (numRegs >= -8)
            //        {
            //            LlenarDgvVentas(false);
            //            BorrarDatosVenta();
            //            BorrarDatosDetalleVenta();
            //        }
            //    }
            //    else
            //    {
            //        BorrarDatosVenta();
            //        BorrarDatosDetalleVenta();
            //        btnGenerar.Enabled = false;
            //    }
            //}
            //CargarValoresOriginales();
        }

        private void tabcOperacion_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!VentaGenerada && Utils.HayCambios(this, valoresOriginales, errorProvider1))
                if (U.NotificacionQuestion("[gold]Se detectaron cambios en los datos de la venta que no han sido guardados.\n[blue]Si cambia de pestaña se perderan los datos no guardados.\n[red]¿Desea cambiar de pestaña?") == DialogResult.No)
                    e.Cancel = true;
        }

        private void btnNota_Click(object sender, EventArgs e)
        {
            //int result = ChkRowVersion();
            //string strVenta = $"La venta con Id: {txtId.Text}:";
            //if (result == -1)
            //    U.NotificacionError(strVenta + Utils.oevvd);
            //else if (result == -2)
            //    U.NotificacionError(strVenta + Utils.fepou);
            //else if (result == -3)
            //    U.NotificacionError(strVenta + Utils.fmpousmn);
            //else if (result == -4)
            //    U.NotificacionError(strVenta + Utils.oed);
            //if (result == 1 || result == -3)
            //{
            //    FrmRptNotaRemision8 frmRptNotaRemision8 = new FrmRptNotaRemision8();
            //    frmRptNotaRemision8.Id = int.Parse(txtId.Text);
            //    frmRptNotaRemision8.ShowDialog();
            //}
            //if (result == -2)
            //{
            //    nudCantidad.Leave -= nudCantidad_Leave;
            //    nudDescuento.Leave -= nudDescuento_Leave;
            //    nudCantidad.ValueChanged -= nudCantidad_ValueChanged;
            //    nudDescuento.ValueChanged -= nudDescuento_ValueChanged;
            //    DeshabilitarControles();
            //    btnNota.Enabled = false;
            //    BorrarDatosVenta();
            //    BorrarDatosDetalleVenta();
            //    LlenarDgvVentas(false);
            //    CargarValoresOriginales();
            //    tabcOperacion.Focus();
            //    nudCantidad.Leave += nudCantidad_Leave;
            //    nudDescuento.Leave += nudDescuento_Leave;
            //    nudCantidad.ValueChanged += nudCantidad_ValueChanged;
            //    nudDescuento.ValueChanged += nudDescuento_ValueChanged;
            //}
            return;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //BorrarDatosVenta();
            //BorrarDatosDetalleVenta();
            //HabilitarControles();
            //btnNota.Enabled = false;
            //btnNuevo.Enabled = false;
            //VentaGenerada = false;
            //numDetalle = 1;
            //CargarValoresOriginales();
            //tabcOperacion.Focus();
        }

        private int ChkRowVersion()
        {
            return 1;
            //if (txtId.Tag == null)
            //    return -1;
            //byte[] rowVersion = RowVersionHelper.RowVersionObjToByteArray(txtId.Tag);
            //try
            //{
            //    MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
            //    Venta venta = _ventaBLL.ObtenerVentaPorId(int.Parse(txtId.Text));
            //    if (venta == null)
            //        return -2;
            //    // no se necesita checar los rowversions de los detalles de la venta porque si un detalle cambia o es eliminado o es insertado uno nuevo, el rowversion de la venta también cambia, es suficiente con checar el rowversion de la venta
            //    if (!venta.RowVersion.SequenceEqual(rowVersion))
            //        return -3;
            //    MDIPrincipal.ActualizarBarraDeEstado();
            //    return 1;
            //}
            //catch (Exception ex)
            //{
            //    U.MsgCatchOue(ex);
            //    return -4;
            //}
        }
    }
}
