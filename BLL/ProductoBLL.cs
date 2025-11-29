using DAL;
using Entities;
using Entities.DTOs;
using System.Collections.Generic;
using System.Data;

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

    }
}
