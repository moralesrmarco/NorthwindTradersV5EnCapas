using DAL;
using Entities;
using System.Collections.Generic;

namespace BLL
{
    public class VentaDetalleBLL
    {
        private readonly VentaDetalleDAL _ventaDetalleDAL;

        public VentaDetalleBLL(string _connectionString) 
        { 
            _ventaDetalleDAL = new VentaDetalleDAL(_connectionString);
        }

        public List<VentaDetalle> ObtenerVentaDetallePorVentaId(int orderId)
        {
            return _ventaDetalleDAL.ObtenerVentaDetallePorVentaId(orderId);
        }
    }
}
