using BLL;
using BLL.Services;
using Entities.DTOs;
using NorthwindTradersV5EnCapas.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmVentasCrud : Form
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        private VentaBLL _ventaBLL;
        private readonly ClienteService _clienteService;
        private readonly EmpleadoService _empleadoService;
        private readonly TransportistaService _transportistaService;
        private readonly CategoriaService _categoriaService;
        private bool EjecutarConfDgv = true;
        private Dictionary<string, object> valoresOriginales;
        bool EventoCargado = true; // esta variable es necesaria para controlar el manejador de eventos de la celda del dgv ojo no quitar
        private TabPage lastSelectedTab;
        int numDetalle = 1;
        bool VentaGenerado = false;

        public FrmVentasCrud()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _ventaBLL = new VentaBLL(_connectionString);
            _clienteService = new ClienteService(_connectionString);
            _empleadoService = new EmpleadoService(_connectionString);
            _transportistaService = new TransportistaService(_connectionString);
            _categoriaService = new CategoriaService(_connectionString);
        }

        private void GrbPaint(object sender, PaintEventArgs e) => Utils.GrbPaint(this, sender, e);

        private void GrbPaint2(object sender, PaintEventArgs e) => Utils.GrbPaint2(this, sender, e);

        private void FrmVentasCrud_FormClosed(object sender, FormClosedEventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void FrmVentasCrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tabcOperacion.SelectedTab != tabpConsultar)
                if (tabcOperacion.SelectedTab != tabpConsultar & tabcOperacion.SelectedTab != tabpEliminar)
                    if (Utils.HayCambios(this, valoresOriginales, errorProvider1))
                        if (U.NotificacionQuestion(Utils.preguntaCerrar) == DialogResult.No)
                            e.Cancel = true;
        }

        private void tabcOperacion_DrawItem(object sender, DrawItemEventArgs e) => Utils.DibujarPestañas(sender as TabControl, e);

        private void FrmVentasCrud_Load(object sender, EventArgs e)
        {
            tabcOperacion.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabcOperacion.DrawItem += tabcOperacion_DrawItem;
            // Obtener el símbolo de moneda según la configuración regional del equipo
            string simboloMoneda = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
            // Mostrarlo en el Label
            LblPrecio.Text = "Precio " + simboloMoneda + ":";
            LblTotal.Text = "Total " + simboloMoneda + ":";
            dtpHoraRequerido.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtpHoraEnvio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
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
            //txtPrecio.Text = txtFlete.Text = "$0.00";
            //txtDescuento.Text = "0.00";
            //txtUInventario.Text = "0";
        }

        private void DeshabilitarControles()
        {
            cboCliente.Enabled = cboEmpleado.Enabled = cboTransportista.Enabled = cboCategoria.Enabled = cboProducto.Enabled = false;
            dtpVenta.Enabled = dtpHoraVenta.Enabled = dtpRequerido.Enabled = dtpHoraRequerido.Enabled = dtpEnvio.Enabled = dtpHoraEnvio.Enabled = false;
            txtDirigidoa.ReadOnly = txtDomicilio.ReadOnly = txtCiudad.ReadOnly = txtRegion.ReadOnly = txtCP.ReadOnly = txtPais.ReadOnly = true;
            nudFlete.ReadOnly = nudCantidad.ReadOnly = nudDescuento.ReadOnly = true;
            btnAgregar.Enabled = btnGenerar.Enabled = false;
        }

        private void HabilitarControles()
        {
            cboCliente.Enabled = cboEmpleado.Enabled = cboTransportista.Enabled = cboCategoria.Enabled = cboProducto.Enabled = true;
            dtpVenta.Enabled = dtpRequerido.Enabled = dtpEnvio.Enabled = true;
            txtDirigidoa.ReadOnly = txtDomicilio.ReadOnly = txtCiudad.ReadOnly = txtRegion.ReadOnly = txtCP.ReadOnly = txtPais.ReadOnly = false;
            nudFlete.ReadOnly = false;
            btnAgregar.Enabled = btnGenerar.Enabled = true;
        }

        private void HabilitarControlesProducto()
        {
            nudCantidad.ReadOnly = nudDescuento.ReadOnly = false;
        }

        private void DeshabilitarControlesProducto()
        {
            nudCantidad.ReadOnly = nudDescuento.ReadOnly = true;
        }

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

        private bool ValidarControles()
        {
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
                errorProvider1.SetError(dtpVenta, "Ingrese la fecha de venta");
            }
            if (cboTransportista.SelectedIndex == 0)
            {
                valida = false;
                errorProvider1.SetError(cboTransportista, "Ingrese la compañía transportista");
            }
            //string total = txtTotal.Text;
            //total = total.Replace("$", "");
            if (nudTotal.Value == 0)
            {
                valida = false;
                errorProvider1.SetError(btnAgregar, "Ingrese el detalle de la venta");
                errorProvider1.SetError(nudTotal, "El total de la venta no puede ser cero");
            }
            if (cboProducto.SelectedIndex > 0)
            {
                valida = false;
                errorProvider1.SetError(cboProducto, "Ha seleccionado un producto y no lo ha agregado al venta");
            }
            return valida;
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
                    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran los últimos {dgvVentas.RowCount} Ventas registrados");
                else
                    MDIPrincipal.ActualizarBarraDeEstado($"Se encontraron {dgvVentas.RowCount} registros");
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

        private void ConfDgvVentas()
        {
            //dgvVentas.Columns["OrderId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //dgvVentas.Columns["OrderDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvVentas.Columns["RequiredDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvVentas.Columns["ShippedDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvVentas.Columns["Shipper"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvVentas.Columns["Employee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvVentas.Columns["OrderDate"].DefaultCellStyle.Format = "ddd dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";
            //dgvVentas.Columns["RequiredDate"].DefaultCellStyle.Format = "ddd dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";
            //dgvVentas.Columns["ShippedDate"].DefaultCellStyle.Format = "ddd dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";

            //dgvVentas.Columns["OrderId"].HeaderText = "Id";
            //dgvVentas.Columns["Customer"].HeaderText = "Cliente";
            //dgvVentas.Columns["ContactName"].HeaderText = "Nombre de contacto";
            //dgvVentas.Columns["OrderDate"].HeaderText = "Fecha de venta";
            //dgvVentas.Columns["RequiredDate"].HeaderText = "Fecha de entrega";
            //dgvVentas.Columns["ShippedDate"].HeaderText = "Fecha de envío";
            //dgvVentas.Columns["Employee"].HeaderText = "Vendedor";
            //dgvVentas.Columns["Shipper"].HeaderText = "Compañía transportista";
            //dgvVentas.Columns["ShipName"].HeaderText = "Enviar a";
        }

        private void ConfDgvDetalle()
        {
            dgvDetalle.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BorrarDatosVenta();
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab != tabpRegistrar)
                DeshabilitarControles();
            LlenarDgvVentas(true);
            dgvVentas.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            BorrarDatosVenta();
            BorrarMensajesError();
            BorrarDatosBusqueda();
            if (tabcOperacion.SelectedTab != tabpRegistrar)
                DeshabilitarControles();
            LlenarDgvVentas(false);
            dgvVentas.Focus();
        }

        private void BorrarDatosVenta()
        {
            txtId.Text = "";
            txtId.Tag = null;
            cboCliente.SelectedIndex = cboEmpleado.SelectedIndex = cboTransportista.SelectedIndex = cboCategoria.SelectedIndex = 0;
            cboProducto.DataSource = null;
            dtpVenta.Value = dtpRequerido.Value = dtpEnvio.Value = DateTime.Now;
            dtpHoraVenta.Value = DateTime.Now;
            dtpHoraRequerido.Value = dtpHoraEnvio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtpRequerido.Checked = dtpEnvio.Checked = false;
            txtDirigidoa.Text = txtDomicilio.Text = txtCiudad.Text = txtRegion.Text = txtCP.Text = txtPais.Text = "";
            txtFlete.Text = txtPrecio.Text = "$0.00";
            txtCantidad.Text = txtUInventario.Text = "0";
            txtDescuento.Text = "0.00";
            txtTotal.Text = "$0.00";
            btnNota.Visible = false;
            dgvDetalle.Rows.Clear();
        }

        private void BorrarMensajesError() => errorProvider1.Clear();

        private void BorrarDatosBusqueda()
        {
            //txtBIdInicial.Text = txtBIdFinal.Text = 
            nudBIdIni.Value = nudBIdFin.Value = 0;
            txtBCliente.Text = txtBEmpleado.Text = txtBCompañiaT.Text = txtBDirigidoa.Text = "";
            dtpBFVentaIni.Value = dtpBFVentaFin.Value = dtpBFRequeridoIni.Value = dtpBFRequeridoFin.Value = dtpBFEnvioIni.Value = dtpBFEnvioFin.Value = DateTime.Today;
            dtpBFVentaIni.Checked = dtpBFVentaFin.Checked = dtpBFRequeridoIni.Checked = dtpBFRequeridoFin.Checked = dtpBFEnvioIni.Checked = dtpBFEnvioFin.Checked = false;
            chkbBFVentaNull.Checked = chkbBFRequeridoNull.Checked = chkbBFEnvioNull.Checked = false;
        }

        //private void txtBIdInicial_KeyPress(object sender, KeyPressEventArgs e) => Utils.ValidarDigitosSinPunto(sender, e);

        //private void txtBIdFinal_KeyPress(object sender, KeyPressEventArgs e) => Utils.ValidarDigitosSinPunto(sender, e);

        //private void txtBIdInicial_Leave(object sender, EventArgs e) => Utils.ValidaTxtBIdIni(txtBIdInicial, txtBIdFinal);

        //private void txtBIdFinal_Leave(object sender, EventArgs e) => Utils.ValidaTxtBIdFin(txtBIdInicial, txtBIdFinal);

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

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrecio.Text = "$0.00";
            txtUInventario.Text = "0";
            txtCantidad.Text = "0";
            if (cboCategoria.SelectedIndex > 0)
            {
                //try
                //{
                //    MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                //    var dt = new VentaRepository(cnStr).ObtenerProductosPorCategorias(int.Parse(cboCategoria.SelectedValue.ToString()));
                //    cboProducto.DataSource = dt;
                //    cboProducto.DisplayMember = "Producto";
                //    cboProducto.ValueMember = "Id";
                //    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registros en Ventas");
                //}
                //catch (Exception ex)
                //{
                //    Utils.MsgCatchOue(ex);
                //}
            }
            else
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                DataTable tbl = new DataTable();
                tbl.Columns.Add("Id", typeof(int));
                tbl.Columns.Add("Producto", typeof(string));
                DataRow dr = tbl.NewRow();
                dr["Id"] = 0;
                dr["Producto"] = "«--- Seleccione ---»";
                tbl.Rows.Add(dr);
                cboProducto.DataSource = tbl;
                cboProducto.DisplayMember = "Producto";
                cboProducto.ValueMember = "Id";
                MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registros en Ventas");
            }
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex > 0)
            {
                //try
                //{
                //    MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                //    var customerId = cboCliente.SelectedValue?.ToString();
                //    var dtoEnvioInformacion = new VentaRepository(cnStr).ObtenerInformacionEnvio(customerId);
                //    if (dtoEnvioInformacion != null)
                //    {
                //        txtDirigidoa.Text = dtoEnvioInformacion.ShipName ?? "";
                //        txtDomicilio.Text = dtoEnvioInformacion.ShipAddress ?? "";
                //        txtCiudad.Text = dtoEnvioInformacion.ShipCity ?? "";
                //        txtRegion.Text = dtoEnvioInformacion.ShipRegion ?? "";
                //        txtCP.Text = dtoEnvioInformacion.ShipPostalCode ?? "";
                //        txtPais.Text = dtoEnvioInformacion.ShipCountry ?? "";
                //    }
                //    else
                //        txtDirigidoa.Text = txtDomicilio.Text = txtCiudad.Text = txtRegion.Text = txtCP.Text = txtPais.Text = "";
                //    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registros en Ventas");
                //}
                //catch (Exception ex)
                //{
                //    Utils.MsgCatchOue(ex);
                //}
            }
            else
                txtDirigidoa.Text = txtDomicilio.Text = txtCiudad.Text = txtRegion.Text = txtCP.Text = txtPais.Text = "";
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex > 0)
            {
                //try
                //{
                //    MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                //    var productId = cboProducto.SelectedValue?.ToString();
                //    var dtoProductoCostoInventario = new VentaRepository(cnStr).ObtenerProductoCostoInventario(int.Parse(productId));
                //    if (dtoProductoCostoInventario != null)
                //    {
                //        txtPrecio.Text = dtoProductoCostoInventario.UnitPrice.ToString("c");
                //        txtUInventario.Text = dtoProductoCostoInventario.UnitsInStock.ToString();
                //        if (dtoProductoCostoInventario.UnitsInStock == 0)
                //        {
                //            DeshabilitarControlesProducto();
                //            Utils.MensajeExclamation("No hay este producto en existencia");
                //            cboProducto.SelectedIndex = 0;
                //            txtPrecio.Text = "$0.00";
                //            txtUInventario.Text = "0";
                //            txtCantidad.Text = "0";
                //            txtDescuento.Text = "0.00";
                //        }
                //        else
                //            HabilitarControlesProducto();
                //    }
                //    else
                //    {
                //        DeshabilitarControlesProducto();
                //        txtPrecio.Text = "$0.00";
                //        txtUInventario.Text = "0";
                //        txtCantidad.Text = "0";
                //        txtDescuento.Text = "0.00";
                //    }
                //    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registros en Ventas");
                //}
                //catch (Exception ex)
                //{
                //    Utils.MsgCatchOue(ex);
                //}
            }
            else
            {
                DeshabilitarControlesProducto();
                txtPrecio.Text = "$0.00";
                txtUInventario.Text = "0";
                txtCantidad.Text = "0";
                txtDescuento.Text = "0.00";
            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow dgvr in dgvDetalle.Rows)
            {
                decimal importe = decimal.Parse(dgvr.Cells["Importe"].Value.ToString());
                total += importe;
            }
            txtTotal.Text = string.Format("{0:c}", total);
        }

        private void txtDescuento_Enter(object sender, EventArgs e) => txtDescuento.Text = "";

        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            if (txtDescuento.Text.Trim() == "")
                txtDescuento.Text = "0.00";
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (txtCantidad.Text.Trim() == "" || int.Parse(txtCantidad.Text) == 0) txtCantidad.Text = "1";
        }

        private void txtFlete_Enter(object sender, EventArgs e)
        {
            if (txtFlete.Text.Contains("$")) txtFlete.Text = txtFlete.Text.Replace("$", "");
            if (decimal.Parse(txtFlete.Text) == 0) txtFlete.Text = "";
        }

        private void txtFlete_Leave(object sender, EventArgs e)
        {
            if (txtFlete.Text.Trim() == "") txtFlete.Text = "0.00";
            decimal flete = decimal.Parse(txtFlete.Text.Trim());
            txtFlete.Text = flete.ToString("c");
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BorrarMensajesError();
            if (cboCategoria.SelectedIndex <= 0)
            {
                errorProvider1.SetError(cboCategoria, "Seleccione la categoría");
                return;
            }
            if (cboProducto.SelectedIndex <= 0)
            {
                errorProvider1.SetError(cboProducto, "Seleccione el producto");
                return;
            }
            if (txtCantidad.Text.Trim() == "" || int.Parse(txtCantidad.Text) == 0)
            {
                errorProvider1.SetError(txtCantidad, "Ingrese la cantidad");
                return;
            }
            if (decimal.Parse(txtDescuento.Text) > 1 || decimal.Parse(txtDescuento.Text) < 0)
            {
                errorProvider1.SetError(txtDescuento, "El descuento no puede ser mayor que 1 o menor que 0");
                return;
            }
            if (int.Parse(txtCantidad.Text) > int.Parse(txtUInventario.Text))
            {
                errorProvider1.SetError(txtCantidad, "La cantidad de productos en la venta excede el inventario disponible");
                return;
            }
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
                errorProvider1.SetError(cboProducto, "No se puede tener un producto duplicado en el detalle de la venta");
                return;
            }
            DeshabilitarControlesProducto();
            txtPrecio.Text = txtPrecio.Text.Replace("$", "");
            dgvDetalle.Rows.Add(new object[] { numDetalle, cboProducto.Text, txtPrecio.Text, txtCantidad.Text, txtDescuento.Text, ((decimal.Parse(txtPrecio.Text) * decimal.Parse(txtCantidad.Text)) * (1 - decimal.Parse(txtDescuento.Text))).ToString(), "Eliminar", cboProducto.SelectedValue });
            CalcularTotal();
            ++numDetalle;
            cboCategoria.SelectedIndex = cboProducto.SelectedIndex = 0;
            txtPrecio.Text = "$0.00";
            txtCantidad.Text = txtUInventario.Text = "0";
            txtDescuento.Text = "0.00";
            cboCategoria.Focus();
        }

        private void dgvDetalle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null) e.Value = decimal.Parse(e.Value.ToString()).ToString("c");
            if (e.ColumnIndex == 3 && e.Value != null) e.Value = decimal.Parse(e.Value.ToString()).ToString("n0");
            if (e.ColumnIndex == 4 && e.Value != null) e.Value = decimal.Parse(e.Value.ToString()).ToString("n2");
            if (e.ColumnIndex == 5 && e.Value != null) e.Value = decimal.Parse(e.Value.ToString()).ToString("c");
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvDetalle.Columns["Eliminar"].Index)
                return;
            dgvDetalle.Rows.RemoveAt(e.RowIndex);
            CalcularTotal();
        }

        private void txtFlete_KeyPress(object sender, KeyPressEventArgs e) => Utils.ValidarDigitosConPunto(sender, e);

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e) => Utils.ValidarDigitosSinPunto(sender, e);

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e) => Utils.ValidarDigitosConPunto(sender, e);

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            if (txtCantidad.Text.Trim() != "")
            {
                if (int.Parse(txtCantidad.Text.Replace(",", "")) > 32767)
                {
                    errorProvider1.SetError(txtCantidad, "La cantidad no puede ser mayor a 32767");
                    e.Cancel = true;
                    return;
                }
                else
                    errorProvider1.SetError(txtCantidad, "");
                if (int.Parse(txtCantidad.Text) > int.Parse(txtUInventario.Text))
                {
                    errorProvider1.SetError(txtCantidad, "La cantidad de productos en la venta excede el inventario disponible");
                    e.Cancel = true;
                }
            }
        }

        private void tabcOperacion_Selected(object sender, TabControlEventArgs e)
        {
            lastSelectedTab = e.TabPage;  // actualizar la pestaña actual
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
                VentaGenerado = false;
                BorrarDatosBusqueda();
                HabilitarControles();
                btnGenerar.Text = "Generar venta";
                btnGenerar.Visible = true;
                btnGenerar.Enabled = true;
                btnAgregar.Visible = true;
                btnAgregar.Enabled = true;
                dgvDetalle.Columns["Eliminar"].Visible = true;
                grbProducto.Enabled = true;
                btnNota.Visible = true;
                btnNota.Enabled = false;
                btnNuevo.Visible = true;
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
                    btnGenerar.Visible = false;
                    btnAgregar.Visible = false;
                    btnNota.Visible = true;
                    btnNota.Enabled = false;
                    btnNuevo.Visible = false;
                    btnNuevo.Enabled = false;
                }
                else if (tabcOperacion.SelectedTab == tabpModificar)
                {
                    VentaGenerado = false;
                    btnGenerar.Text = "Modificar venta";
                    btnGenerar.Visible = true;
                    btnAgregar.Visible = false;
                    btnNota.Visible = true;
                    btnNota.Enabled = false;
                    btnNuevo.Visible = false;
                    btnNuevo.Enabled = false;
                }
                else if (tabcOperacion.SelectedTab == tabpEliminar)
                {
                    btnGenerar.Text = "Eliminar venta";
                    btnGenerar.Visible = true;
                    btnAgregar.Visible = false;
                    btnNota.Visible = false;
                    btnNota.Enabled = false;
                    btnNuevo.Visible = false;
                    btnNuevo.Enabled = false;
                }
            }
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tabcOperacion.SelectedTab != tabpRegistrar)
            {
                BorrarDatosVenta();
                BorrarMensajesError();
                DataGridViewRow dgvr = dgvVentas.CurrentRow;
                txtId.Text = dgvr.Cells["OrderId"].Value.ToString();
                LlenarDatosVenta();
                LlenarDatosDetalleVenta();
                DeshabilitarControles();
                if (tabcOperacion.SelectedTab == tabpConsultar)
                {
                    btnNota.Visible = true;
                    btnNota.Enabled = true;
                    btnNuevo.Visible = false;
                }
                else if (tabcOperacion.SelectedTab == tabpModificar)
                {
                    HabilitarControles();
                    btnGenerar.Enabled = true;
                    btnNota.Visible = true;
                    btnNota.Enabled = false;
                    btnNuevo.Visible = false;
                }
                else if (tabcOperacion.SelectedTab == tabpEliminar)
                {
                    btnGenerar.Enabled = true;
                    btnNota.Visible = false;
                    btnNuevo.Visible = false;
                }
            }
        }

        private void LlenarDatosVenta()
        {
            //try
            //{
            //    MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
            //    var venta = new VentaRepository(cnStr).ObtenerVentaPorId(int.Parse(txtId.Text));
            //    if (venta != null)
            //    {
            //        txtId.Text = venta.OrderID.ToString();
            //        cboCliente.SelectedIndexChanged -= new EventHandler(cboCliente_SelectedIndexChanged);
            //        cboCliente.SelectedValue = string.IsNullOrEmpty(venta.CustomerID) ? 0 : (object)venta.CustomerID;
            //        cboCliente.SelectedIndexChanged += new EventHandler(cboCliente_SelectedIndexChanged);
            //        cboEmpleado.SelectedValue = venta.EmployeeID ?? 0;
            //        cboTransportista.SelectedValue = venta.ShipVia ?? 0;
            //        txtDirigidoa.Text = venta.ShipName ?? "";
            //        txtDomicilio.Text = venta.ShipAddress ?? "";
            //        txtCiudad.Text = venta.ShipCity ?? "";
            //        txtRegion.Text = venta.ShipRegion ?? "";
            //        txtCP.Text = venta.ShipPostalCode ?? "";
            //        txtPais.Text = venta.ShipCountry ?? "";
            //        decimal flete = venta.Freight ?? 0;
            //        txtFlete.Text = flete.ToString("c2");
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
            //        txtId.Tag = venta.RowVersion;
            //        MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registros en Ventas");
            //    }
            //    else
            //        Utils.MensajeExclamation("No se encontró la venta especificado, es posible que el registro haya sido eliminado por otro usuario de la red");
            //}
            //catch (Exception ex)
            //{
            //    Utils.MsgCatchOue(ex);
            //}
        }

        private void LlenarDatosDetalleVenta()
        {
            //try
            //{
            //    numDetalle = 1;
            //    MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
            //    using (var repo = new VentaRepository(cnStr))
            //    {
            //        var detalles = repo.ObtenerDetalleVentaPorVentaId(int.Parse(txtId.Text));
            //        if (detalles.Count == 0)
            //            Utils.MensajeExclamation("No se encontraron detalles para la venta especificado");
            //        else
            //        {
            //            foreach (var ventaDetalle in detalles)
            //            {
            //                var totalLinea = (ventaDetalle.UnitPrice * ventaDetalle.Quantity) * (1 - ventaDetalle.Discount);
            //                dgvDetalle.Rows.Add(new object[]
            //                {
            //                    numDetalle,
            //                    ventaDetalle.ProductName,
            //                    ventaDetalle.UnitPrice,
            //                    ventaDetalle.Quantity,
            //                    ventaDetalle.Discount,
            //                    totalLinea,
            //                    "Eliminar",
            //                    ventaDetalle.ProductID,
            //                    ventaDetalle.RowVersion
            //                });
            //                ++numDetalle;
            //            }
            //        }
            //    }
            //    CalcularTotal();
            //    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registros en Ventas");
            //}
            //catch (Exception ex)
            //{
            //    Utils.MsgCatchOue(ex);
            //}
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            int numRegs = 0;
            BorrarMensajesError();
            //if (tabcOperacion.SelectedTab == tabpRegistrar)
            //{
            //    try
            //    {
            //        if (ValidarControles())
            //        {
            //            MDIPrincipal.ActualizarBarraDeEstado(Utils.insertandoRegistro);
            //            DeshabilitarControles();
            //            btnGenerar.Enabled = false;
            //            List<VentaDetalle> lstDetalle = new List<VentaDetalle>();
            //            // llenado de elementos hijos
            //            foreach (DataGridViewRow dgvr in dgvDetalle.Rows)
            //            {
            //                VentaDetalle detalle = new VentaDetalle();
            //                detalle.ProductID = int.Parse(dgvr.Cells["ProductoId"].Value.ToString());
            //                detalle.ProductName = dgvr.Cells["Producto"].Value.ToString();
            //                detalle.UnitPrice = decimal.Parse(dgvr.Cells["Precio"].Value.ToString());
            //                detalle.Quantity = short.Parse(dgvr.Cells["Cantidad"].Value.ToString());
            //                detalle.Discount = decimal.Parse(dgvr.Cells["Descuento"].Value.ToString());
            //                lstDetalle.Add(detalle);
            //            }
            //            Venta venta = new Venta();
            //            venta.CustomerID = cboCliente.SelectedValue.ToString();
            //            venta.EmployeeID = Convert.ToInt32(cboEmpleado.SelectedValue);
            //            if (dtpVenta != null && dtpHoraVenta != null)
            //                venta.OrderDate = Utils.ObtenerFechaHora(dtpVenta, dtpHoraVenta);
            //            if (dtpRequerido != null && dtpHoraRequerido != null)
            //                venta.RequiredDate = Utils.ObtenerFechaHora(dtpRequerido, dtpHoraRequerido);
            //            if (dtpEnvio != null && dtpHoraEnvio != null)
            //                venta.ShippedDate = Utils.ObtenerFechaHora(dtpEnvio, dtpHoraEnvio);
            //            venta.ShipVia = int.Parse(cboTransportista.SelectedValue.ToString());
            //            venta.ShipName = txtDirigidoa.Text;
            //            venta.ShipAddress = txtDomicilio.Text;
            //            venta.ShipCity = txtCiudad.Text;
            //            venta.ShipRegion = txtRegion.Text;
            //            venta.ShipPostalCode = txtCP.Text;
            //            venta.ShipCountry = txtPais.Text;
            //            if (txtFlete.Text.Contains("$")) txtFlete.Text = txtFlete.Text.Replace("$", "");
            //            venta.Freight = decimal.Parse(txtFlete.Text);
            //            int orderId = 0;
            //            numRegs = new VentaRepository(cnStr).Insertar(venta, lstDetalle, out orderId);
            //            txtId.Text = orderId.ToString();
            //            txtId.Tag = 1;
            //            if (numRegs > 0) Utils.MensajeInformation($"El venta con Id: {txtId.Text} del Cliente: {cboCliente.Text}, se registró satisfactoriamente");
            //            else Utils.MensajeExclamation("No se pudo realizar el registro, es posible que la venta ya exista");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Utils.MsgCatchOue(ex);
            //    }
            //    if (numRegs > 0)
            //    {
            //        VentaGenerado = true;
            //        numDetalle = 1;
            //        btnNota.Enabled = true;
            //        btnNota.Visible = true;
            //        btnNuevo.Enabled = true;
            //        btnNuevo.Visible = true;
            //        BorrarDatosBusqueda();
            //        LlenarDgvVentas(false);
            //        dgvDetalle.Rows.Clear();
            //        dgvDetalle.Columns["Eliminar"].Visible = false;
            //        LlenarDatosDetalleVenta();
            //    }
            //}
            //else if (tabcOperacion.SelectedTab == tabpModificar)
            //{
            //    try
            //    {
            //        if (ValidarControles())
            //        {
            //            if (!ChkRowVersion())
            //            {
            //                Utils.MensajeExclamation("El registro ha sido modificado por otro usuario de la red, no se realizará la actualización del registro, vuelva a cargar el registro para que se muestre la venta con los datos proporcionados por el otro usuario");
            //                return;
            //            }
            //            MDIPrincipal.ActualizarBarraDeEstado(Utils.modificandoRegistro);
            //            DeshabilitarControles();
            //            btnGenerar.Enabled = false;
            //            Venta venta = new Venta();
            //            venta.OrderID = int.Parse(txtId.Text);
            //            venta.CustomerID = cboCliente.SelectedValue.ToString();
            //            venta.EmployeeID = Convert.ToInt32(cboEmpleado.SelectedValue);
            //            if (!dtpVenta.Checked) venta.OrderDate = null;
            //            else venta.OrderDate = Convert.ToDateTime(dtpVenta.Value.ToShortDateString() + " " + dtpHoraVenta.Value.ToLongTimeString());
            //            if (!dtpRequerido.Checked) venta.RequiredDate = null;
            //            else venta.RequiredDate = Convert.ToDateTime(dtpRequerido.Value.ToShortDateString() + " " + dtpHoraRequerido.Value.ToLongTimeString());
            //            if (!dtpEnvio.Checked) venta.ShippedDate = null;
            //            else venta.ShippedDate = Convert.ToDateTime(dtpEnvio.Value.ToShortDateString() + " " + dtpHoraEnvio.Value.ToLongTimeString());
            //            venta.ShipVia = Convert.ToInt32(cboTransportista.SelectedValue);
            //            venta.ShipName = txtDirigidoa.Text;
            //            venta.ShipAddress = txtDomicilio.Text;
            //            venta.ShipCity = txtCiudad.Text;
            //            venta.ShipRegion = txtRegion.Text;
            //            venta.ShipPostalCode = txtCP.Text;
            //            venta.ShipCountry = txtPais.Text;
            //            if (txtFlete.Text.Contains("$")) txtFlete.Text = txtFlete.Text.Replace("$", "");
            //            venta.Freight = decimal.Parse(txtFlete.Text);
            //            numRegs = new VentaRepository(cnStr).Actualizar(venta, out int rowVersion);
            //            if (rowVersion > 0)
            //                txtId.Tag = rowVersion;
            //            if (numRegs > 0)
            //                Utils.MensajeInformation($"El venta con Id: {venta.OrderID} del Cliente: {cboCliente.Text}, se actualizó satisfactoriamente");
            //            else
            //                Utils.MensajeError("No se pudo realizar la modificación, es posible que el registro se haya eliminado previamente por otro usuario de la red");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Utils.MsgCatchOue(ex);
            //    }
            //    if (numRegs > 0)
            //    {
            //        VentaGenerado = true;
            //        btnNota.Enabled = true;
            //        btnNota.Visible = true;
            //        btnNuevo.Visible = false;
            //        LlenarDgvVentas(false);
            //    }
            //}
            //else if (tabcOperacion.SelectedTab == tabpEliminar)
            //{
            //    if (txtId.Text == "")
            //    {
            //        Utils.MensajeExclamation("Seleccione la venta a eliminar");
            //        return;
            //    }
            //    if (Utils.MensajeQuestion($"¿Esta seguro de eliminar la venta con Id: {txtId.Text} del Cliente: {cboCliente.Text}?") == DialogResult.Yes)
            //    {
            //        if (!ChkRowVersion())
            //        {
            //            Utils.MensajeExclamation("El registro ha sido modificado por otro usuario de la red, no se realizará la eliminación del registro, vuelva a cargar el registro para que se muestre la venta con los datos proporcionados por el otro usuario");
            //            return;
            //        }
            //        MDIPrincipal.ActualizarBarraDeEstado(Utils.eliminandoRegistro);
            //        btnGenerar.Enabled = false;
            //        try
            //        {
            //            Venta venta = new Venta();
            //            venta.OrderID = int.Parse(txtId.Text);
            //            numRegs = new VentaRepository(cnStr).Eliminar(venta);
            //            if (numRegs > 0)
            //                Utils.MensajeInformation($"El venta con Id: {venta.OrderID} del Cliente: {cboCliente.Text}, se eliminó satisfactoriamente");
            //            else
            //                Utils.MensajeError("No se pudo realizar la eliminación, es posible que el registro haya sido eliminado previamente por otro usuario de la red");
            //        }
            //        catch (Exception ex)
            //        {
            //            Utils.MsgCatchOue(ex);
            //        }
            //        if (numRegs > 0)
            //        {
            //            BorrarDatosBusqueda();
            //            LlenarDgvVentas(false);
            //        }
            //    }
            //    else
            //    {
            //        BorrarDatosVenta();
            //        btnGenerar.Enabled = false;
            //    }
            //}
        }

        private void tabcOperacion_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //if (!VentaGenerado & (lastSelectedTab == tabpRegistrar && e.TabPage != tabpRegistrar && dgvDetalle.RowCount > 0))
            //{
            //    if (Utils.MensajeQuestion("Se han agregado productos al detalle de la venta, si cambia de pestaña se perderan los datos no guardados.\n¿Desea cambiar de pestaña?") == DialogResult.No)
            //        e.Cancel = true;
            //}
        }

        private void btnNota_Click(object sender, EventArgs e)
        {
            //if (!ChkRowVersion())
            //{
            //    Utils.MensajeInformation("El registro ha sido modificado por otro usuario de la red, se mostrará la nota de remisión con los datos proporcionados por el otro usuario");
            //}
            //FrmRptNotaRemision8 frmRptNotaRemision8 = new FrmRptNotaRemision8();
            //frmRptNotaRemision8.Id = int.Parse(txtId.Text);
            //frmRptNotaRemision8.ShowDialog();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BorrarDatosVenta();
            HabilitarControles();
            btnNota.Enabled = false;
            btnNota.Visible = true;
            btnNuevo.Enabled = false;
            btnNuevo.Visible = true;
            VentaGenerado = false;
            dgvDetalle.Columns["Eliminar"].Visible = true;
            numDetalle = 1;
        }

        private bool ChkRowVersion()
        {
            bool rowVersionOk = true;
            //if (txtId.Tag == null)
            //    return true;
            //if (!int.TryParse(txtId.Text, out int ventaId))
            //    return false;
            //int rowVersion = (int)txtId.Tag;
            //try
            //{
            //    MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
            //    var repo = new VentaRepository(cnStr);
            //    Venta venta = repo.ObtenerVentaPorId(ventaId);
            //    if (venta == null || venta.RowVersion != rowVersion)
            //        return false;
            //    // Validar filas del grid contra DB 
            //    // 1) Validar que cada fila del grid exista en DB y coincida RowVersion
            //    foreach (DataGridViewRow dgvr in dgvDetalle.Rows)
            //    {
            //        if (!int.TryParse(dgvr.Cells["ProductoId"].Value?.ToString(), out int productoId))
            //            return false;
            //        if (!int.TryParse(dgvr.Cells["RowVersion"].Value?.ToString(), out int rowVersionGrid))
            //            return false;
            //        int? rowVersionDetalleEnDB = repo.DetalleVentasChkRowVersion(ventaId, productoId);
            //        if (!rowVersionDetalleEnDB.HasValue || rowVersionGrid != rowVersionDetalleEnDB.Value)
            //            return false;
            //    }
            //    // Validar que DB no tenga detalles adicionales
            //    // 2) Validar que cada detalle en DB exista en el grid y coincida RowVersion
            //    List<VentaDetalle> ventaDetalles = repo.ObtenerDetalleVentaPorVentaId(ventaId);

            //    if (ventaDetalles != null)
            //    {
            //        // Construir diccionario del grid para búsquedas O(1)
            //        var gridMap = new Dictionary<int, int>(); // productoId -> rowVersionGrid
            //        foreach (DataGridViewRow dgvr in dgvDetalle.Rows)
            //        {
            //            if (int.TryParse(dgvr.Cells["ProductoId"].Value?.ToString(), out int pid) &&
            //                int.TryParse(dgvr.Cells["RowVersion"].Value?.ToString(), out int rv))
            //            {
            //                gridMap[pid] = rv;
            //            }
            //        }
            //        foreach (var pd in ventaDetalles)
            //        {
            //            if (!gridMap.TryGetValue(pd.ProductID, out int rowVersionGrid) || rowVersionGrid != pd.RowVersion)
            //                return false;
            //        }
            //    }
            //    else
            //    {
            //        // Política: si DB no tiene detalles y el grid sí, considerarlo inconsistente
            //        if (dgvDetalle.Rows.Count > 0)
            //            return false;
            //    }
            //    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran {dgvVentas.RowCount} registros en Ventas");
            //}
            //catch (Exception ex)
            //{
            //    Utils.MsgCatchOue(ex);
            //    return false;
            //}
            return rowVersionOk;
        }

        private void frmVentasCrud_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
