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

        public int Insertar(Producto producto)
        {
            return _productoDAL.Insertar(producto);
        }

        public int Actualizar(Producto producto)
        {
            return _productoDAL.Actualizar(producto);
        }

        public int Eliminar(int productId, byte[] rowVersion)
        {
            return _productoDAL.Eliminar(productId, rowVersion);
        }

        public DataTable ObtenerCategoriasCbo()
        {
            var categorias = _productoDAL.ObtenerCategoriasCbo();
            DataRow filaSeleccione = categorias.NewRow();
            filaSeleccione["CategoryID"] = 0;
            filaSeleccione["CategoryName"] = "»--- Seleccione ---«";
            categorias.Rows.InsertAt(filaSeleccione, 0);
            return categorias;
        }

        public DataTable ObtenerProveedoresCbo()
        {
            var proveedores = _productoDAL.ObtenerProveedoresCbo();
            DataRow filaSeleccione = proveedores.NewRow();
            filaSeleccione["SupplierID"] = 0;
            filaSeleccione["CompanyName"] = "»--- Seleccione ---«";
            proveedores.Rows.InsertAt(filaSeleccione, 0);
            return proveedores;
        }

        public List<Producto> ObtenerProductos(bool selectorRealizaBusqueda, DtoProductosBuscar criterios, bool top100)
        {
            return _productoDAL.ObtenerProductos(selectorRealizaBusqueda, criterios, top100);
        }

        public Producto ObtenerProductoPorId(int productId)
        {
            return _productoDAL.ObtenerProductoPorId(productId);
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
