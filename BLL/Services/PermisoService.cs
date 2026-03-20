using DAL;
using System.Data;

namespace BLL.Services
{
    public class PermisoService
    {
        private readonly PermisoDAL _permisoDAL;

        public PermisoService(string connectionString)
        {
            _permisoDAL = new PermisoDAL(connectionString);
        }

        public DataTable ObtenerPermisosDeCatalogo()
        {
            return _permisoDAL.ObtenerPermisosDeCatalogo();
        }

        public DataTable ObtenerPermisosConcedidos(int usuarioId)
        {
            return _permisoDAL.ObtenerPermisosConcedidos(usuarioId);
        }
    }
}
