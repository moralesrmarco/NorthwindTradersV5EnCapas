using DAL;
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

        public DataSet ObtenerProveedoresProductosDgv()
        {
            return _proveedorDAL.ObtenerProveedoresProductosDgv();
        }
    }
}
