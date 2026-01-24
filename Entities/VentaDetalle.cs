//https://www.youtube.com/watch?v=VjBAQV_cFxM&list=PLgvaYP_E7xkKhk3QYJCvNXndiypRugCrf&index=6 tiene un ejemplo de como armar una clase cuando existe relacion con otras clases

using System;
using Utilities;

namespace Entities
{
    /*
    En los calculos se considero que el precio unitario ya incluye el iva.

    El IVA se calcula sobre el valor real de la transacción, es decir, el precio neto después de aplicar descuentos.
    - Si el producto tiene un descuento comercial (por promoción, volumen, etc.), ese descuento reduce la base.
    - Por lo tanto, el importe del IVA se determina sobre el precio con descuento, no sobre el precio original.
    En resumen: el IVA se calcula sobre el precio con descuento, porque ese es el valor real de la operación.


    Fórmula general cuando el precio ya incluye IVA
    Si el precio final PrecioConIVA ya incluye el IVA, y la tasa de IVA es TasaIVA (por ejemplo, 16% = 0.16), entonces:
    BaseSinIVA= PrecioConIVA / (1+TasaIVA)
    IVA = PrecioConIVA - BaseSinIVA
    */

    public class VentaDetalle
    {
        // Relación con la venta
        // un item de ventadetalle tiene una venta
        public Venta Venta { get; set; }
        // Relación con el producto
        // un item de ventadetalle tiene un producto
        public Producto Producto { get; set; }

        public decimal UnitPrice { get; set; } // Precio unitario YA incluye IVA
        public short Quantity { get; set; }
        public decimal Discount { get; set; } // Descuento en proporción (ej. 0.10 = 10%)
        public byte[] RowVersion { get; set; }

        // Propiedad expuesta para reportes
        public string ProductName => Producto.ProductName; // esta linea es equivalente a la comentada abajo y la aplique a los demas calculos para ahorrar lineas
        //{ 
        //    get
        //    {
        //        return Producto.ProductName;
        //    }
        //}

        // Importe bruto (con IVA incluido)
        public decimal Importe => Math.Round(UnitPrice * Quantity, 2, MidpointRounding.AwayFromZero);

        // Importe del descuento
        public decimal ImporteDelDescuento => Math.Round(Importe * Discount, 2, MidpointRounding.AwayFromZero);

        // Importe neto con descuento (todavía incluye IVA)
        public decimal ImporteConDescuento => Math.Round(Importe * (1 - Discount), 2, MidpointRounding.AwayFromZero);

        // Tasa de IVA (ej. 0.16 = 16%)
        public decimal TasaIVA => Utils.TasaIVA; // no es necesario redondear tasa porque ya es exacto.

        // Base sin IVA (separando el impuesto del precio con IVA)
        public decimal BaseSinIva => Math.Round(ImporteConDescuento / (1 + TasaIVA), 2, MidpointRounding.AwayFromZero);

        // Importe del IVA (diferencia entre precio con IVA y base neta)
        public decimal ImporteDelIVA => Math.Round(ImporteConDescuento - BaseSinIva, 2, MidpointRounding.AwayFromZero);

        public decimal ImporteSinIVA => BaseSinIva; // ya viene redondeado

        // Subtotal = Importe con descuento (ya incluye IVA)
        public decimal Subtotal => ImporteConDescuento; // ya viene redondeado

        /*****************************************************/
        public decimal PrecioPorUnidadSinIVAAntesDeDescuento => Math.Round(UnitPrice / (1 + TasaIVA), 2, MidpointRounding.AwayFromZero); // ok

        public decimal IVADelPrecioPorUnidadAntesDescuento => Math.Round(UnitPrice - PrecioPorUnidadSinIVAAntesDeDescuento, 2, MidpointRounding.AwayFromZero); // ok

        public decimal PrecioPorUnidadConIVADespuesDescuento => Math.Round(UnitPrice * (1 - Discount), 2, MidpointRounding.AwayFromZero); // ok

        public decimal IVADelPrecioporUnidadDespuesDescuento => Math.Round(PrecioPorUnidadConIVADespuesDescuento - PrecioPorUnidadSinIVADepuesDescuento, 2, MidpointRounding.AwayFromZero); // ok

        public decimal PrecioPorUnidadSinIVADepuesDescuento => Math.Round(PrecioPorUnidadConIVADespuesDescuento / (1 + TasaIVA), 2, MidpointRounding.AwayFromZero); // ok
        
        public decimal AhorroPorUnidadSinIVA => Math.Round(PrecioPorUnidadSinIVAAntesDeDescuento - PrecioPorUnidadSinIVADepuesDescuento, 2, MidpointRounding.AwayFromZero);

        public decimal AhorroEnIVAPorUnidadDespuesDescuento => Math.Round(IVADelPrecioPorUnidadAntesDescuento - IVADelPrecioporUnidadDespuesDescuento, 2, MidpointRounding.AwayFromZero); 

        public decimal AhorroPorUnidadConIVA => Math.Round(UnitPrice - PrecioPorUnidadConIVADespuesDescuento, 2, MidpointRounding.AwayFromZero);


        public decimal AhorroTotalPorProducto => 0; // Math.Round(AhorroPorUnidad * Quantity, 2, MidpointRounding.AwayFromZero);



        // Tasas expresadas en porcentaje
        public decimal TasaDescuentoPorcentaje => Math.Round(Discount * 100, 2, MidpointRounding.AwayFromZero);
        public decimal TasaIVAPorcentaje => Math.Round(TasaIVA * 100, 2, MidpointRounding.AwayFromZero);

        public VentaDetalle()
        {
            Venta = new Venta();
            Producto = new Producto();
        }
    }
}