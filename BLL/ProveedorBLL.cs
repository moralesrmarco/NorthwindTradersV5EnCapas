using DAL;
using Entities;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class ProveedorBLL
    {
        private readonly ProveedorDAL _proveedorDAL;

        public ProveedorBLL(string _connectionString)
        {
            _proveedorDAL = new ProveedorDAL(_connectionString);
        }

        public List<Proveedor> ObtenerProveedores(bool selectorRealizaBusqueda, Proveedor criterios, bool top100)
        {
            return _proveedorDAL.ObtenerProveedores(selectorRealizaBusqueda, criterios, top100);
        }

        public DataSet ObtenerProveedoresProductosDgv()
        {
            return _proveedorDAL.ObtenerProveedoresProductosDgv();
        }
    }
}
