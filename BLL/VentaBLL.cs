using DAL;
using Entities;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class VentaBLL
    {
        private readonly VentaDAL _ventaDAL;

        public VentaBLL(string _connectionString)
        {
            _ventaDAL = new VentaDAL(_connectionString);
        }

        public List<DtoVentaDgv> ObtenerVentas(bool selectorRealizaBusqueda, DtoVentasBuscar criterios, bool top100)
        {
            var ventasTemp = _ventaDAL.ObtenerVentas(selectorRealizaBusqueda, criterios, top100);
            var ventas = ventasTemp.Select(v => new DtoVentaDgv
            {
                OrderID = v.OrderID,
                CustomerName = v.Cliente.CompanyName,
                CustomerContactName = v.Cliente.ContactName,
                OrderDate = v.OrderDate,
                RequiredDate = v.RequiredDate,
                ShippedDate = v.ShippedDate,
                EmployeeName = v.Empleado.NameByLastName,
                ShipCompanyName = v.Transportista.CompanyName,
                ShipName = v.ShipName
            }).ToList();
            return ventas;
        }
    }
}
