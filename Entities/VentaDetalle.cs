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
        
        public string ProductName // expongo una propiedad para que sea accesible por el reporte
        { 
            get
            {
                return Producto.ProductName;
            }
        }

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
                return Importe * Discount;
            }
        }

        public decimal ImporteConDescuento
        {
            get
            {
                return Importe * (1 - Discount);
            }
        }

        public decimal TasaIVA
        {
            get
            {
                return Utils.TasaIVA; // 16% de IVA
            }
        }

        public decimal BaseSinIva
        {
            get
            {
                return ImporteConDescuento / (1 + TasaIVA);
            }
        }

        public decimal ImporteDelIVA
        {
            get
            {
                return ImporteConDescuento - BaseSinIva;
            }
        }

        public decimal Subtotal
        {
            get
            {
                return ImporteConDescuento + ImporteDelIVA;
            }
        }

        public decimal TasaDescuentoPorcentaje
        {
            get
            {
                return Discount * 100;
            }
        }

        public decimal TasaIVAPorcentaje
        {
            get
            {
                return TasaIVA * 100;
            }
        }

        public VentaDetalle()
        {
            Venta = new Venta();
            Producto = new Producto();
        }
    }
}

/*
El IVA se calcula sobre el valor real de la transacción, es decir, el precio neto después de aplicar descuentos.
- Si el producto tiene un descuento comercial (por promoción, volumen, etc.), ese descuento reduce la base.
- Por lo tanto, el importe del IVA se determina sobre el precio con descuento, no sobre el precio original.
En resumen: el IVA se calcula sobre el precio con descuento, porque ese es el valor real de la operación.


Fórmula general cuando el precio ya incluye IVA
Si el precio final PrecioConIVA ya incluye el IVA, y la tasa de IVA es TasaIVA (por ejemplo, 16% = 0.16), entonces:
BaseSinIVA= PrecioConIVA / (1+TasaIVA)
IVA = PrecioConIVA - BaseSinIVA
*/
