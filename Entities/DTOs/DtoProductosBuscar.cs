namespace Entities.DTOs
{
    public class DtoProductosBuscar
    {
        public int IdIni { get; set; }
        public int IdFin { get; set; }
        public string Producto { get; set; }
        public int Categoria { get; set; }
        public int Proveedor { get; set; }
    }
}
