using System;
using System.Windows.Forms;

namespace Utilities
{
    public static class InventarioHelper
    {
        public static void ActualizarInventarioUi(
        decimal cantidadNueva,
        decimal inventarioRealDb,
        NumericUpDown nudInventario)
        {
            // Inventario disponible solo si la cantidad reservada no supera el inventario real
            decimal inventarioNuevoUi = inventarioRealDb - cantidadNueva;

            // Si la reserva excede el inventario real, mostrar 0
            if (inventarioNuevoUi < 0)
                inventarioNuevoUi = 0;

            // Aplicar límites del NumericUpDown
            inventarioNuevoUi = Math.Min(inventarioNuevoUi, nudInventario.Maximum);
            inventarioNuevoUi = Math.Max(inventarioNuevoUi, nudInventario.Minimum);

            nudInventario.Value = inventarioNuevoUi;
        }

        ///// <summary>
        ///// Calcula el inventario remanente y actualiza el control NumericUpDown
        ///// aplicando sus límites de mínimo y máximo.
        ///// </summary>
        ///// <param name="cantidadNueva">Cantidad nueva reservada</param>
        ///// <param name="cantidadVieja">Cantidad anterior reservada</param>
        ///// <param name="inventarioViejo">Inventario actual en DB</param>
        ///// <param name="nudInventario">Control NumericUpDown a actualizar</param>
        //public static void ActualizarInventarioUi(
        //    decimal cantidadNueva,
        //    decimal cantidadVieja,
        //    decimal inventarioViejo,
        //    NumericUpDown nudInventario)
        //{
        //    // Stock total disponible para este pedido (reservado + inventario)
        //    decimal disponible = inventarioViejo + cantidadVieja;

        //    //Inventario remanente REAL en DB después de reservar la nueva cantidad
        //    decimal inventarioNuevoDb = disponible - cantidadNueva;

        //    //// Inventario remanente REAL en DB después de ajustar la reserva
        //    //decimal inventarioNuevoDb = inventarioViejo + cantidadVieja - cantidadNueva;

        //    // Aplica límites del NumericUpDown solo para mostrar en UI
        //    decimal inventarioNuevoUi = inventarioNuevoDb;
        //    inventarioNuevoUi = Math.Min(inventarioNuevoUi, nudInventario.Maximum); // evita lanzar una excepción
        //    inventarioNuevoUi = Math.Max(inventarioNuevoUi, nudInventario.Minimum); // evita lanzar una excepción

        //    nudInventario.Value = inventarioNuevoUi;
        //}
    }
}