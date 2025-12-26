using BLL;
using Entities;
using Entities.DTOs;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmRptNotaRemision8 : Form
    {

        public int Id;
        private string cnStr = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        private VentaBLL _ventaBLL;
        private VentaDetalleBLL _ventaDetalleBLL;

        public FrmRptNotaRemision8()
        {
            InitializeComponent();
            _ventaBLL = new VentaBLL(cnStr);
            _ventaDetalleBLL = new VentaDetalleBLL(cnStr);
        }

        private void GrbPaint(object sender, PaintEventArgs e) => Utils.GrbPaint(this, sender, e);

        private void FrmRptNotaRemision8_FormClosed(object sender, FormClosedEventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void FrmRptNotaRemision8_Load(object sender, EventArgs e)
        {
            try
            {
                ReportParameter[] parameters = new ReportParameter[1];
                parameters[0] = new ReportParameter("PedidoId", Id.ToString());
                this.reportViewer1.LocalReport.SetParameters(parameters);
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                DataTable dt = _ventaBLL.ObtenerVentaPorIdDt(Id);
                MDIPrincipal.ActualizarBarraDeEstado();
                ReportDataSource rds2 = new ReportDataSource("DataSet2", dt);
                reportViewer1.LocalReport.DataSources.Add(rds2);
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                // Obtenemos los datos detallados para la nota de remisión específica  
                List<VentaDetalle> ventaDetalles = _ventaDetalleBLL.ObtenerVentaDetallePorVentaId(Id);
                MDIPrincipal.ActualizarBarraDeEstado();
                ReportDataSource rds1 = new ReportDataSource("DataSet1", ventaDetalles);
                reportViewer1.LocalReport.DataSources.Add(rds1);
                reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }
    }
}
