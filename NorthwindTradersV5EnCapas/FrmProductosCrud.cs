using BLL;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmProductosCrud : Form
    {

        string _connectionString = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        private ProductoBLL _productoBLL;
        private bool EjecutarConfDgv = true;
        private Dictionary<string, object> valoresOriginales;
        bool EventoCargado = true; // esta variable es necesaria para controlar el manejador de eventos de la celda del dgv ojo no quitar

        public FrmProductosCrud()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _productoBLL = new ProductoBLL(_connectionString);
        }

        private void GrbPaint(object sender, PaintEventArgs e) => Utils.GrbPaint(this, sender, e);

        private void FrmProductosCrud_FormClosed(object sender, FormClosedEventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void FrmProductosCrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tabcOperacion.SelectedTab != tbpConsultar)
            {
                if (tabcOperacion.SelectedTab != tbpConsultar & tabcOperacion.SelectedTab != tbpEliminar)
                    if (Utils.HayCambios(this, valoresOriginales, errorProvider1))
                        if (U.NotificacionQuestion(Utils.preguntaCerrar) == DialogResult.No)
                            e.Cancel = true;
            }
        }

        private void tabcOperacion_DrawItem(object sender, DrawItemEventArgs e) => Utils.DibujarPestañas(sender as TabControl, e);

        private void FrmProductosCrud_Load(object sender, EventArgs e)
        {
            tabcOperacion.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabcOperacion.DrawItem += tabcOperacion_DrawItem;
            // Obtener el símbolo de moneda según la configuración regional del equipo
            string simboloMoneda = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
            // Mostrarlo en el Label
            LblPrecio.Text = "Precio " + simboloMoneda +":";
            DeshabilitarControles();
            LlenarCboCategoria();
            LlenarCboProveedor();
            Utils.ConfDgv(Dgv);
            LlenarDgv(false);
        }

        private void DeshabilitarControles()
        {
            txtProducto.ReadOnly = txtCantidadxU.ReadOnly = true;
            nudPPedido.ReadOnly = nudUPedido.ReadOnly = nudUInventario.ReadOnly = nudPrecio.ReadOnly = true;
            chkbDescontinuado.Enabled = false;
            cboCategoria.Enabled = cboProveedor.Enabled = false;
        }

        private void HabilitarControles()
        {
            txtProducto.ReadOnly = txtCantidadxU.ReadOnly = false;
            nudPPedido.ReadOnly = nudUPedido.ReadOnly = nudUInventario.ReadOnly = nudPrecio.ReadOnly = false;
            chkbDescontinuado.Enabled = true;
            cboCategoria.Enabled = cboProveedor.Enabled = true;
        }

        private void LlenarCboCategoria()
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var dtCboCategoria = _productoBLL.ObtenerCategoriasCbo();
                var dtBCboCategoria = dtCboCategoria.Copy();
                cboCategoria.DataSource = dtCboCategoria;
                cboCategoria.DisplayMember = "CategoryName";
                cboCategoria.ValueMember = "CategoryID";
                cboBCategoria.DataSource = dtBCboCategoria;
                cboBCategoria.DisplayMember = "CategoryName";
                cboBCategoria.ValueMember = "CategoryID";
                MDIPrincipal.ActualizarBarraDeEstado();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

        private void LlenarCboProveedor()
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var dtCboProveedor = _productoBLL.ObtenerProveedoresCbo();
                var dtBCboProveedor = dtCboProveedor.Copy();
                cboProveedor.DataSource = dtCboProveedor;
                cboProveedor.DisplayMember = "CompanyName";
                cboProveedor.ValueMember = "SupplierID";
                cboBProveedor.DataSource = dtBCboProveedor;
                cboBProveedor.DisplayMember = "CompanyName";
                cboBProveedor.ValueMember = "SupplierID";
                MDIPrincipal.ActualizarBarraDeEstado();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }
        
        private void LlenarDgv(bool selectorRealizaBusqueda)
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                DtoProductosBuscar criterios;
                if (selectorRealizaBusqueda)
                    criterios = new DtoProductosBuscar()
                    {
                        IdIni = Convert.ToInt32(nudBIdIni.Value),
                        IdFin = Convert.ToInt32(nudBIdFin.Value),
                        Producto = txtBProducto.Text.Trim(),
                        Categoria = cboBCategoria.SelectedValue == null ? 0 : Convert.ToInt32(cboBCategoria.SelectedValue),
                        Proveedor = cboBProveedor.SelectedValue == null ? 0 : Convert.ToInt32(cboBProveedor.SelectedValue)
                    };
                else
                    criterios = null;
                var productos = _productoBLL.ObtenerProductos(selectorRealizaBusqueda, criterios, false);
                var dtoProductos = productos.Select(p => new DtoProducto
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    QuantityPerUnit = p.QuantityPerUnit,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock,
                    UnitsOnOrder = p.UnitsOnOrder,
                    ReorderLevel = p.ReorderLevel,
                    Discontinued = p.Discontinued,
                    CategoryName = p.Categoria?.CategoryName,
                    Description = p.Categoria?.Description,
                    CompanyName = p.Proveedor?.CompanyName,
                    CategoryID = p.Categoria?.CategoryID ?? 0,
                    SupplierID = p.Proveedor?.SupplierID ?? 0
                }).ToList();
                Dgv.DataSource = dtoProductos;
                if (EjecutarConfDgv)
                {
                    ConfDgv();
                    EjecutarConfDgv = false;
                }
                if (selectorRealizaBusqueda)
                    MDIPrincipal.ActualizarBarraDeEstado($"Se encontraron {Dgv.RowCount} registro(s)");
                else
                    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran los últimos {Dgv.RowCount} producto(s) registrado(s)");
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

        private void ConfDgv()
        {
            Dgv.Columns["CategoryID"].Visible = false;
            Dgv.Columns["SupplierID"].Visible = false;

            Dgv.Columns["ProductID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Dgv.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Dgv.Columns["QuantityPerUnit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Dgv.Columns["UnitPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Dgv.Columns["UnitsInStock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Dgv.Columns["UnitsOnOrder"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Dgv.Columns["ReorderLevel"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Dgv.Columns["Discontinued"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Dgv.Columns["CategoryName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Dgv.Columns["CompanyName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            Dgv.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv.Columns["UnitsInStock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv.Columns["UnitsOnOrder"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv.Columns["ReorderLevel"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Dgv.Columns["UnitPrice"].DefaultCellStyle.Format = "c";
            Dgv.Columns["UnitsInStock"].DefaultCellStyle.Format = "N0";
            Dgv.Columns["UnitsOnOrder"].DefaultCellStyle.Format = "N0";
            Dgv.Columns["ReorderLevel"].DefaultCellStyle.Format = "N0";

            Dgv.Columns["ProductID"].HeaderText = "Id";
            Dgv.Columns["ProductName"].HeaderText = "Producto";
            Dgv.Columns["QuantityPerUnit"].HeaderText = "Cantidad por unidad";
            Dgv.Columns["UnitPrice"].HeaderText = "Precio";
            Dgv.Columns["UnitsInStock"].HeaderText = "Unidades en inventario";
            Dgv.Columns["UnitsOnOrder"].HeaderText = "Unidades en pedido";
            Dgv.Columns["ReorderLevel"].HeaderText = "Nivel de reorden";
            Dgv.Columns["Discontinued"].HeaderText = "Descontinuado";
            Dgv.Columns["CategoryName"].HeaderText = "Categoría";
            Dgv.Columns["Description"].HeaderText = "Descripción de categoría";
            Dgv.Columns["CompanyName"].HeaderText = "Proveedor";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BorrarDatosProducto();
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab != tbpRegistrar)
                DeshabilitarControles();
            LlenarDgv(true);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            BorrarDatosProducto();
            BorrarMensajesError();
            BorrarDatosBusqueda();
            if (tabcOperacion.SelectedTab != tbpRegistrar)
                DeshabilitarControles();
            LlenarDgv(false);
        }

        private void BorrarDatosProducto()
        {
            txtId.Text = txtProducto.Text = txtCantidadxU.Text = "";
            nudPPedido.Value = nudUPedido.Value = nudUInventario.Value = nudPrecio.Value = 0;
            chkbDescontinuado.Checked = false;
            cboCategoria.SelectedIndex = cboProveedor.SelectedIndex = 0;
        }

        private void BorrarMensajesError() => errorProvider1.Clear();

        private void BorrarDatosBusqueda()
        {
            nudBIdIni.Value = nudBIdFin.Value = 0;
            txtBProducto.Text = "";
            cboBCategoria.SelectedIndex = cboBProveedor.SelectedIndex = 0;
        }

        private bool ValidarControles()
        {
            bool valida = true;
            if (cboCategoria.SelectedIndex == 0 || cboCategoria.SelectedIndex == -1)
            {
                valida = false;
                errorProvider1.SetError(cboCategoria, "Seleccione una categoría");
            }
            if (cboProveedor.SelectedIndex == 0 || cboProveedor.SelectedIndex == -1)
            {
                valida = false;
                errorProvider1.SetError(cboProveedor, "Seleccione un proveedor");
            }
            if (txtProducto.Text.Trim() == "")
            {
                valida = false;
                errorProvider1.SetError(txtProducto, "Ingrese producto");
            }
            if (nudPrecio.Value == 0)
            {
                valida = false;
                errorProvider1.SetError(nudPrecio, "Ingrese precio");
            }
            return valida;
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab != tbpRegistrar)
            {
                DeshabilitarControles();
                DataGridViewRow dgvr = Dgv.CurrentRow;
                txtId.Text = dgvr.Cells["ProductID"].Value.ToString();
                Producto producto = new Producto();
                try
                {
                    producto = _productoBLL.ObtenerProductoPorId(Convert.ToInt32(txtId.Text));
                    if (producto != null)
                    {
                        txtId.Tag = producto.RowVersion;
                        cboCategoria.SelectedValue = producto.Categoria?.CategoryID ?? 0;
                        cboProveedor.SelectedValue = producto.Proveedor?.SupplierID ?? 0;
                        txtProducto.Text = producto.ProductName ?? "";
                        txtCantidadxU.Text = producto.QuantityPerUnit ?? "";
                        nudPrecio.Value = producto.UnitPrice ?? 0m;
                        nudUInventario.Value = producto.UnitsInStock ?? 0;
                        nudUPedido.Value = producto.UnitsOnOrder ?? 0;
                        nudPPedido.Value = producto.ReorderLevel ?? 0;
                        chkbDescontinuado.Checked = producto.Discontinued;
                        // esta linea funciona para detectar cambios en los controles del formulario cuando se selecciona la opción modificar
                        CargarValoresOriginales();
                    }
                    else
                    {
                        U.NotificacionWarning($"No se encontró el producto con Id: {txtId.Text}." + Utils.erfep);
                        ActualizaDgv();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    U.MsgCatchOue(ex);
                }
                if (tabcOperacion.SelectedTab == tbpModificar)
                {
                    HabilitarControles();
                    btnOperacion.Enabled = true;
                }
                else if (tabcOperacion.SelectedTab == tbpEliminar)
                    btnOperacion.Enabled = true;
            }
        }

        private void Dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // debe estar vinculado a la clase List<> a la cual esta vinculado el DataGridView.DataSource
            Utils.OrdenarPorColumna<DtoProducto>(Dgv, e);
        }

        private void tabcOperacion_Selected(object sender, TabControlEventArgs e)
        {
            BorrarDatosProducto();
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab == tbpRegistrar)
            {
                if (EventoCargado)
                {
                    Dgv.CellClick -= new DataGridViewCellEventHandler(Dgv_CellClick);
                    EventoCargado = false;
                }
                BorrarDatosBusqueda();
                HabilitarControles();
                btnOperacion.Text = "Registrar producto";
                btnOperacion.Visible = true;
                btnOperacion.Enabled = true;
                // esta linea funciona para detectar cambios en los controles del formulario cuando se selecciona la opción Registrar
                CargarValoresOriginales();
            }
            else
            {
                if (!EventoCargado)
                {
                    Dgv.CellClick += new DataGridViewCellEventHandler(Dgv_CellClick);
                    EventoCargado = true;
                }
                DeshabilitarControles();
                btnOperacion.Enabled = false;
                if (tabcOperacion.SelectedTab == tbpConsultar)
                {
                    btnOperacion.Visible = false;
                    btnOperacion.Enabled = false;
                }
                else if (tabcOperacion.SelectedTab == tbpModificar)
                {
                    btnOperacion.Text = "Modificar producto";
                    btnOperacion.Visible = true;
                    btnOperacion.Enabled = false;
                }
                else if (tabcOperacion.SelectedTab == tbpEliminar)
                {
                    btnOperacion.Text = "Eliminar producto";
                    btnOperacion.Visible = true;
                    btnOperacion.Enabled = false;
                }
            }
        }

        private void Nud_ValueChanged(object sender, EventArgs e)
        {
            // El sender es el control que disparó el evento
            var nud = sender as NumericUpDown;
            if (nud == null) return;
            // Formatear con separador de miles y 2 decimales
            nud.Text = nud.Value.ToString("N0");
        }

        private void Nud_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Bloquear punto y coma
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                e.Handled = true; // Ignora la tecla
            }
        }

        private void Nud_Enter(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            // El NumericUpDown contiene un TextBox interno en Controls[1]
            if (nud.Controls[1] is TextBox tb)
            {
                tb.SelectAll();
            }
        }

        private void nudPrecio_ValueChanged(object sender, EventArgs e)
        {
            nudPrecio.Text = nudPrecio.Value.ToString("C2", CultureInfo.CurrentCulture);
        }

        private void nudBIdIni_Leave(object sender, EventArgs e) => Utils.ValidarRango(sender, nudBIdIni, nudBIdFin);

        private void nudBIdFin_Leave(object sender, EventArgs e) => Utils.ValidarRango(sender, nudBIdIni, nudBIdFin);

        private void btnOperacion_Click(object sender, EventArgs e)
        {
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab == tbpRegistrar)
            {
                if (ValidarControles())
                {
                    MDIPrincipal.ActualizarBarraDeEstado(Utils.insertandoRegistro);
                    DeshabilitarControles();
                    btnOperacion.Enabled = false;
                    try
                    {
                        var producto = new Producto
                        {
                            // Relación con Categoria
                            Categoria = new Categoria
                            {
                                CategoryID = Convert.ToInt32(cboCategoria.SelectedValue)
                            },

                            // Relación con Proveedor
                            Proveedor = new Proveedor
                            {
                                SupplierID = Convert.ToInt32(cboProveedor.SelectedValue)
                            },
                            ProductName = txtProducto.Text,
                            QuantityPerUnit = string.IsNullOrEmpty(txtCantidadxU.Text) ? null : txtCantidadxU.Text,
                            UnitPrice = nudPrecio.Value,
                            UnitsInStock = Convert.ToInt16(nudUInventario.Value),
                            UnitsOnOrder = Convert.ToInt16(nudUPedido.Value),
                            ReorderLevel = Convert.ToInt16(nudPPedido.Value),
                            Discontinued = chkbDescontinuado.Checked
                        };
                        int numRegs = _productoBLL.Insertar(producto);
                        MDIPrincipal.ActualizarBarraDeEstado($"Se insertaron {numRegs} registro(s)");
                        string idNombreProducto = $"El producto con Id: {txtId.Text} - Nombre de producto: {txtProducto.Text}:";
                        if (numRegs > 0)
                        {
                            txtId.Text = producto.ProductID.ToString();
                            idNombreProducto = $"El producto con Id: {txtId.Text} - Nombre de producto: {txtProducto.Text}:";
                            U.NotificacionInformation(idNombreProducto + Utils.srs);
                        }
                        else
                            U.NotificacionError(idNombreProducto + Utils.nfrs);
                    }
                    catch (Exception ex)
                    {
                        U.MsgCatchOue(ex);
                    }
                    HabilitarControles();
                    btnOperacion.Enabled = true;
                    LlenarCombos();
                    ActualizaDgv();
                    // esta linea funciona para detectar cambios en los controles del formulario cuando se selecciona la opción Registrar
                    CargarValoresOriginales();
                }
            }
            //else if (tabcOperacion.SelectedTab == tbpModificar)
            //{
            //    if (txtId.Text == "")
            //    {
            //        Utils.MensajeExclamation("Seleccione el producto a modificar");
            //        return;
            //    }
            //    if (ValidarControles())
            //    {
            //        MDIPrincipal.ActualizarBarraDeEstado(Utils.modificandoRegistro);
            //        DeshabilitarControles();
            //        btnOperacion.Enabled = false;
            //        try
            //        {
            //            var producto = new Producto
            //            {
            //                ProductID = int.Parse(txtId.Text),
            //                CategoryID = Convert.ToInt32(cboCategoria.SelectedValue),
            //                SupplierID = Convert.ToInt32(cboProveedor.SelectedValue),
            //                ProductName = txtProducto.Text,
            //                QuantityPerUnit = string.IsNullOrEmpty(txtCantidadxU.Text) ? null : txtCantidadxU.Text,
            //                UnitPrice = decimal.Parse(txtPrecio.Text),
            //                UnitsInStock = short.Parse(txtUInventario.Text),
            //                UnitsOnOrder = short.Parse(txtUPedido.Text),
            //                ReorderLevel = short.Parse(txtPPedido.Text),
            //                Discontinued = chkbDescontinuado.Checked,
            //                RowVersion = (int)txtId.Tag
            //            };
            //            int numRegs = repo.Actualizar(producto);
            //            if (numRegs > 0)
            //                Utils.MensajeInformation($"El producto con Id: {txtId.Text} y Nombre de producto: {txtProducto.Text} se modificó satisfactoriamente");
            //            else
            //                Utils.MensajeError($"El producto con Id: {txtId.Text} y Nombre de producto: {txtProducto.Text} NO fue modificado en la base de datos, es posible que otro usuario lo haya modificado o eliminado previamente");
            //        }
            //        catch (Exception ex)
            //        {
            //            Utils.MsgCatchOue(ex);
            //        }
            //        LlenarCombos();
            //        ActualizaDgv();
            //    }
            //}
            //else if (tabcOperacion.SelectedTab == tbpEliminar)
            //{
            //    if (txtId.Text == "")
            //    {
            //        Utils.MensajeExclamation("Seleccione el producto a eliminar");
            //        return;
            //    }
            //    if (Utils.MensajeQuestion($"¿Está seguro de eliminar el producto con Id: {txtId.Text} y Nombre de producto: {txtProducto.Text}?") == DialogResult.Yes)
            //    {
            //        MDIPrincipal.ActualizarBarraDeEstado(Utils.eliminandoRegistro);
            //        btnOperacion.Enabled = false;
            //        try
            //        {
            //            var producto = new Producto
            //            {
            //                ProductID = int.Parse(txtId.Text),
            //                RowVersion = (int)txtId.Tag
            //            };
            //            int numRegs = repo.Eliminar(producto);
            //            if (numRegs > 0)
            //                Utils.MensajeInformation($"El producto con Id: {txtId.Text} y Nombre de producto: {txtProducto.Text} se eliminó satisfactoriamente");
            //            else
            //                Utils.MensajeExclamation($"El producto con Id: {txtId.Text} y Nombre de producto: {txtProducto.Text} NO se eliminó en la base de datos, es posible que otro usuario de la red lo haya modificado o eliminado previamente");
            //        }
            //        catch (Exception ex)
            //        {
            //            Utils.MsgCatchOue(ex);
            //        }
            //        LlenarCombos();
            //        ActualizaDgv();
            //    }
            //}
        }

        private void ActualizaDgv() => btnLimpiar.PerformClick();

        private void LlenarCombos()
        {
            LlenarCboCategoria();
            LlenarCboProveedor();
        }

        private void CargarValoresOriginales()
        {
            // Captura inicial usando la utilidad
            valoresOriginales = Utils.CapturarValoresOriginales(this);
        }
    }
}
