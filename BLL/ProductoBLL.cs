using DAL;
using Entities.DTOs;
using System.Collections.Generic;

namespace BLL
{
    public class ProductoBLL
    {
        private readonly ProductoDAL _productoDAL;

        public ProductoBLL(string _connectionString)
        {
            _productoDAL = new ProductoDAL(_connectionString);
        }

        public List<DtoProductosPorProveedor> ObtenerProductosPorProveedor()
        {
            return _productoDAL.ObtenerProductosPorProveedor();
        }

        public List<DtoProductosPorProveedorConDetProv> ObtenerProductosPorProveedorConDetProv()
        {
            return _productoDAL.ObtenerProductosPorProveedorConDetProv();
        }
    }
}
