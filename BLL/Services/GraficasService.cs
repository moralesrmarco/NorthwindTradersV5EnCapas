using DAL;
using Entities.DTOs;
using System.Collections.Generic;
using System.Data;

namespace BLL.Services
{
    public class GraficasService
    {
        private readonly GraficasDAL _graficasDAL;

        public GraficasService(string _connectionString)
        {
            _graficasDAL = new GraficasDAL(_connectionString);
        }

        public DataTable ObtenerAñosDeVentas()
        {
            DataTable dt = _graficasDAL.ObtenerAñosDeVentas();
            DataRow filaSeleccione = dt.NewRow();
            filaSeleccione["YearOrderDate"] = "»--- Seleccione ---«";
            dt.Rows.InsertAt(filaSeleccione, 0);
            return dt;
        }

        public List<DtoVentasMensuales> ObtenerVentasMensuales(int year)
        {
            return _graficasDAL.ObtenerVentasMensuales(year);
        }

        public int ObtenerTotalAñosConVentas()
        {
            return _graficasDAL.ObtenerTotalAñosConVentas();
        }

        public List<DtoVentasMensualesPorAños> ObtenerVentasMensualesPorAños(int years)
        {
            return _graficasDAL.ObtenerVentasMensualesPorAños(years);
        }
    }
}
