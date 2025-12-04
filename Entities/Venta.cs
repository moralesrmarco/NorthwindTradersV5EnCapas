//https://www.youtube.com/watch?v=VjBAQV_cFxM&list=PLgvaYP_E7xkKhk3QYJCvNXndiypRugCrf&index=6
using System;
using System.Collections.Generic;

namespace Entities
{
    public class Venta
    {
        public int OrderID { get; set; }
        // una venta tiene un cliente
        public Cliente Cliente { get; set; }
        // una venta tiene un empleado
        public Empleado Empleado { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        // una venta tiene un transportista
        public Transportista Transportista { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public byte[] RowVersion { get; set; }

        // del diagrama entidad-relación podemos ver que
        // una venta tiene muchos detalles de venta asociados
        public List<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();

    }
}
