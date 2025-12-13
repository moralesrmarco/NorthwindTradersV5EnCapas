using BLL.Services;
using Entities.DTOs;
using NorthwindTradersV5EnCapas.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmRptProductos: Form
    {

        string _connectionString = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        private readonly CategoriaService _categoriaService;
        private readonly ProveedorService _proveedorService;
        string strProcedure = "";
        string titulo = "» Reporte de productos «";
        string subtitulo = "";

        // esto es un campo - Un campo es una variable declarada dentro de la clase, que guarda datos asociados a las instancias de esa clase.
        private readonly List<KeyValuePair<string, string>> _itemsOrdenadoPor =
            new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("ProductID", "ID Producto"),
                new KeyValuePair<string, string>("ProductName", "Producto"),
                new KeyValuePair<string, string>("QuantityPerUnit", "Cantidad por unidad"),
                new KeyValuePair<string, string>("UnitPrice", "Precio"),
                new KeyValuePair<string, string>("UnitsInStock", "Unidades en inventario"),
                new KeyValuePair<string, string>("UnitsOnOrder", "Unidades en pedido"),
                new KeyValuePair<string, string>("ReorderLevel", "Nivel de reorden"),
                new KeyValuePair<string, string>("Discontinued", "Descontinuado"),
                new KeyValuePair<string, string>("CategoryName", "Categoría"),
                new KeyValuePair<string, string>("CompanyName", "Proveedor")
            };

        // esto tambien es un campo
        private readonly List<KeyValuePair<string, string>> _itemsAscDesc = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("ASC", "Ascendente"),
                new KeyValuePair<string, string>("DESC", "Descendente")
            };

        public FrmRptProductos()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _categoriaService = new CategoriaService(_connectionString);
            _proveedorService = new ProveedorService(_connectionString);
            nudBIdIni.Leave += nudBIdIni_Leave;
            nudBIdFin.Leave += nudBIdFin_Leave;
            tabcOperacion.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabcOperacion.DrawItem += tabcOperacion_DrawItem;
        }

        private void GrbPaint(object sender, PaintEventArgs e) => Utils.GrbPaint2(this, sender, e);

        private void FrmRptProductos_FormClosed(object sender, FormClosedEventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void tabcOperacion_DrawItem(object sender, DrawItemEventArgs e) => Utils.DibujarPestañas(sender as TabControl, e);
        
        private void FrmRptProductos_Load(object sender, EventArgs e)
        {
            LlenarCboCategoria();
            LlenarCboProveedor();

            Cbo1OrdenadoPor.DataSource = _itemsOrdenadoPor.ToList();
            Cbo1OrdenadoPor.DisplayMember = "Value";
            Cbo1OrdenadoPor.ValueMember = "Key";
            Cbo2OrdenadoPor.DataSource = _itemsOrdenadoPor.ToList();
            Cbo2OrdenadoPor.DisplayMember = "Value";
            Cbo2OrdenadoPor.ValueMember = "Key";
            Cbo1AscDesc.DataSource = _itemsAscDesc.ToList();
            Cbo1AscDesc.DisplayMember = "Value";
            Cbo1AscDesc.ValueMember = "Key";
            Cbo2AscDesc.DataSource = _itemsAscDesc.ToList();
            Cbo2AscDesc.DisplayMember = "Value";
            Cbo2AscDesc.ValueMember = "Key";
            Cbo1OrdenadoPor.SelectedIndex = Cbo1AscDesc.SelectedIndex = 0;
        }

        private void LlenarCboCategoria()
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var dtCategorias = _categoriaService.ObtenerCategoriasCbo();
                ComboBoxHelper.LlenarCbo(cboCategoria, dtCategorias, "CategoryName", "CategoryId");
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
                var dtProveedores = _proveedorService.ObtenerProveedoresCbo();
                ComboBoxHelper.LlenarCbo(cboProveedor, dtProveedores, "CompanyName", "SupplierId");
                MDIPrincipal.ActualizarBarraDeEstado();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            nudBIdIni.Value = nudBIdFin.Value = 0;
            txtProducto.Text = "";
            cboCategoria.SelectedIndex = cboProveedor.SelectedIndex = 0;
            Cbo1OrdenadoPor.SelectedIndex = Cbo1AscDesc.SelectedIndex = 0;
            Cbo2OrdenadoPor.SelectedIndex = Cbo2AscDesc.SelectedIndex = 0;
            MDIPrincipal.ActualizarBarraDeEstado();
        }

        private void btnImprimirTodos_Click(object sender, EventArgs e)
        {
            strProcedure = "spProductosV2";
            LlenarReporte(sender);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            strProcedure = "spProductosBuscarV2";
            LlenarReporte(sender);
        }

        private void tabcOperacion_Selected(object sender, TabControlEventArgs e) => btnLimpiar.PerformClick();
        
        private void tabcOperacion_SelectedIndexChanged(object sender, EventArgs e) => btnLimpiar.PerformClick();

        private void LlenarReporte(object sender)
        {
            //try
            //{
            //    titulo = "» Reporte de todos los productos «";
            //    subtitulo = "";
            //    MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
            //    DtoProductosBuscar criterios = null;
            //    if (((Button)sender).Tag.ToString() == "Imprimir")
            //    {
            //        criterios = new DtoProductosBuscar
            //        {
            //            IdIni = Convert.ToInt32(nudBIdIni.Value),
            //            IdFin = Convert.ToInt32(nudBIdFin.Value),
            //            Producto = txtProducto.Text.Trim(),
            //            Categoria = cboCategoria.SelectedIndex <= 0 ? 0 : Convert.ToInt32(cboCategoria.SelectedValue),
            //            Proveedor = cboProveedor.SelectedIndex <= 0 ? 0 : Convert.ToInt32(cboProveedor.SelectedValue),
            //            OrdenadoPor = Cbo2OrdenadoPor.SelectedValue.ToString(),
            //            AscDesc = Cbo2AscDesc.SelectedValue.ToString()
            //        };
            //        titulo = "» Reporte filtrado de productos «";
            //        subtitulo = $"Filtrado por: ";
            //        if (txtIdInicial.Text != "" & txtIdFinal.Text != "")
            //            subtitulo += $" [ Id: {txtIdInicial.Text} al {txtIdFinal.Text} ] ";
            //        if (txtProducto.Text != "")
            //            subtitulo += $" [ Producto: {txtProducto.Text} ] ";
            //        if (cboCategoria.SelectedIndex > 0)
            //            subtitulo += $" [ Categoría: {cboCategoria.Text}] ";
            //        if (cboProveedor.SelectedIndex > 0)
            //            subtitulo += $" [ Proveedor: {cboProveedor.Text}] ";
            //        if (subtitulo == "Filtrado por: ")
            //        {
            //            titulo = "» Reporte de todos los productos «";
            //            subtitulo = "";
            //        }
            //        subtitulo += $" Ordenado por: [ {Cbo2OrdenadoPor.Text} ] [ {Cbo2AscDesc.Text} ]";
            //    }
            //    else
            //    {
            //        criterios = new DtoProductosBuscar
            //        {
            //            OrdenadoPor = Cbo1OrdenadoPor.SelectedValue.ToString(),
            //            AscDesc = Cbo1AscDesc.SelectedValue.ToString()
            //        };
            //        subtitulo = $"Ordenado por: [ {Cbo1OrdenadoPor.Text} ] [ {Cbo1AscDesc.Text} ]";
            //    }
            //    groupBox1.Text = titulo + " | » " + subtitulo + " «";
            //    var dt = new ProductoRepository(cnStr).RptProductosListado(dtoProductosBuscar, strProcedure);
            //    MDIPrincipal.ActualizarBarraDeEstado($"Se encontraron {dt.Rows.Count} registros");
            //    if (dt.Rows.Count > 0)
            //    {
            //        ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dt);
            //        reportViewer1.LocalReport.DataSources.Clear();
            //        reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            //        ReportParameter rp = new ReportParameter("titulo", titulo);
            //        ReportParameter rp2 = new ReportParameter("subtitulo", subtitulo);
            //        reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp, rp2 });
            //        reportViewer1.RefreshReport();
            //    }
            //    else
            //    {
            //        reportViewer1.LocalReport.DataSources.Clear();
            //        ReportDataSource reportDataSource = new ReportDataSource("DataSet1", new DataTable());
            //        reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            //        ReportParameter rp = new ReportParameter("titulo", titulo);
            //        ReportParameter rp2 = new ReportParameter("subtitulo", subtitulo);
            //        reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp, rp2 });
            //        reportViewer1.RefreshReport();
            //        U.NotificacionWarning(Utils.noDatos);
            //    }
            //}
            //catch (Exception ex) { U.MsgCatchOue(ex); }
        }

        private void nudBIdIni_Leave(object sender, EventArgs e) => Utils.ValidarRango(sender, nudBIdIni, nudBIdFin);

        private void nudBIdFin_Leave(object sender, EventArgs e) => Utils.ValidarRango(sender, nudBIdIni, nudBIdFin);
    }
}
