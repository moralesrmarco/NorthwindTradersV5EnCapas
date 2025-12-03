using BLL;
using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmRptCategorias : Form
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        CategoriaBLL _categoriaBLL;

        public FrmRptCategorias()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _categoriaBLL = new CategoriaBLL(_connectionString);
        }

        private void GrbPaint(object sender, PaintEventArgs e) => Utils.GrbPaint2(this, sender, e);

        private void FrmRptCategorias_FormClosed(object sender, FormClosedEventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void FrmRptCategorias_Load(object sender, EventArgs e)
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var categorias = _categoriaBLL.ObtenerCategorias(false, null, true);
                OleImageHelper.CleanOleHeader(categorias, "CategoryID", "Picture", 1, 8);
                // esto si lo ubieramos hecho "a mano"
                //foreach (var cat in categorias)
                //{
                //    if (cat.Picture != null)
                //    {
                //        if (cat.CategoryID >= 1 && cat.CategoryID <= 8)
                //        {
                //            // El encabezado OLE en Northwind suele ser de 78 bytes
                //            const int OLE_HEADER_LENGTH = 78;

                //            if (cat.Picture.Length > OLE_HEADER_LENGTH)
                //            {
                //                byte[] cleanImage = new byte[cat.Picture.Length - OLE_HEADER_LENGTH];
                //                Array.Copy(cat.Picture, OLE_HEADER_LENGTH, cleanImage, 0, cleanImage.Length);

                //                // Reemplazamos la imagen con la versión limpia
                //                cat.Picture = cleanImage;
                //            }
                //        }
                //        // Si es mayor que 8, no hacemos nada
                //    }
                //}
                MDIPrincipal.ActualizarBarraDeEstado($"Se encontraron {categorias.Count} registros");
                ReportDataSource reportDataSource = new ReportDataSource("DataSet1", categorias);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }
    }
}
