//https://www.youtube.com/watch?v=VjBAQV_cFxM&list=PLgvaYP_E7xkKhk3QYJCvNXndiypRugCrf&index=6
namespace Entities
{
    public class VentaDetalle
    {
        // un item de ventadetalle tiene una venta
        public Venta Venta { get; set; }
        // un item de ventadetalle tiene un producto
        public Producto Producto { get; set; }
        // esta propiedad ya esta de mas, pero la dejo para facilitar el acceso al ProductName desde el reportviewer, lo tengo que corregir o ver si se queda asi
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public decimal Discount { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
