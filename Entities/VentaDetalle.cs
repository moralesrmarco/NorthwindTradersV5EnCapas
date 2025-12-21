//https://www.youtube.com/watch?v=VjBAQV_cFxM&list=PLgvaYP_E7xkKhk3QYJCvNXndiypRugCrf&index=6
using Utilities;

namespace Entities
{
    public class VentaDetalle
    {
        // un item de ventadetalle tiene una venta
        public Venta Venta { get; set; }
        // un item de ventadetalle tiene un producto
        public Producto Producto { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public decimal Discount { get; set; }
        public byte[] RowVersion { get; set; }

        public decimal Importe
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }

        public decimal ImporteDelDescuento
        {
            get
            {
                return UnitPrice * Quantity * Discount;
            }
        }

        public decimal ImporteConDescuento
        {
            get
            {
                return UnitPrice * Quantity * (1 - Discount);
            }
        }

        public decimal TasaIVA
        {
            get
            {
                return Utils.TasaIVA; // 16% de IVA
            }
        }

        public decimal ImporteDelIVA
        {
            get
            {
                return ImporteConDescuento * TasaIVA;
            }
        }

        public decimal Subtotal
        {
            get
            {
                return ImporteConDescuento + ImporteDelIVA;
            }
        }
    }
}
