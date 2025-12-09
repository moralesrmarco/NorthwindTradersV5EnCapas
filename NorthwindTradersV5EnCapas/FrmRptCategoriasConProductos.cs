using BLL;
using Entities.DTOs;
using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmRptCategoriasConProductos: Form
    {

        string _connectionString = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        CategoriaBLL _categoriaBLL;


        public FrmRptCategoriasConProductos()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _categoriaBLL = new CategoriaBLL(_connectionString);
        }

        private void GrbPaint(object sender, PaintEventArgs e) => Utils.GrbPaint2(this, sender, e);

        private void FrmRptCategoriasConProductos_FormClosed(object sender, FormClosedEventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void FrmRptCategoriasConProductos_Load(object sender, EventArgs e)
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var categoriasConProductos = _categoriaBLL.ObtenerCategoriasConProductos();
                var productos = categoriasConProductos.SelectMany(c => c.Productos.DefaultIfEmpty(), (c, p) => new DtoCategoriasConProductos
                {
                    ProductID = p?.ProductID,
                    ProductName = p?.ProductName,
                    QuantityPerUnit = p?.QuantityPerUnit,
                    UnitPrice = p?.UnitPrice,
                    UnitsInStock = p?.UnitsInStock,
                    UnitsOnOrder = p?.UnitsOnOrder,
                    ReorderLevel = p?.ReorderLevel,
                    Discontinued = p?.Discontinued ?? false,
                    CategoryName = c.CategoryName,
                    CompanyName = p?.Proveedor?.CompanyName
                }).ToList();
                int totalProveedores = productos
                    .Where(p => !string.IsNullOrEmpty(p.CompanyName))
                    .Select(p => p.CompanyName)
                    .Distinct()
                    .Count();
                MDIPrincipal.ActualizarBarraDeEstado(
                    $"Se encontraron {categoriasConProductos.Count} categoría(s), {productos.Count(p => p.ProductID != null)} producto(s) y {totalProveedores} proveedor(es) distinto(s)"
                );
                if (categoriasConProductos.Count > 0)
                {
                    ReportDataSource reportDataSource = new ReportDataSource("DataSet1", productos);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                    reportViewer1.LocalReport.Refresh();
                    reportViewer1.RefreshReport();
                }
                else
                {
                    reportViewer1.LocalReport.DataSources.Clear();
                    var dt = new DataTable();

                    // Definimos las columnas tal como están en tu DTO
                    dt.Columns.Add("ProductID", typeof(int));
                    dt.Columns.Add("ProductName", typeof(string));
                    dt.Columns.Add("QuantityPerUnit", typeof(string));
                    dt.Columns.Add("UnitPrice", typeof(decimal));
                    dt.Columns.Add("UnitsInStock", typeof(short));
                    dt.Columns.Add("UnitsOnOrder", typeof(short));
                    dt.Columns.Add("ReorderLevel", typeof(short));
                    dt.Columns.Add("Discontinued", typeof(bool));
                    dt.Columns.Add("CategoryName", typeof(string));
                    dt.Columns.Add("CompanyName", typeof(string));

                    ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dt);
                    reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                    reportViewer1.LocalReport.Refresh();
                    reportViewer1.RefreshReport();
                    MDIPrincipal.ActualizarBarraDeEstado("No se encontraron registros");
                    U.NotificacionWarning(Utils.noDatos);
                }
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }

        }
    }
}
