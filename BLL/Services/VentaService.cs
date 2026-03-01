using DAL;
using Entities.DTOs;
using System.Data;

namespace BLL.Services
{
    public class VentaService
    {
        private readonly VentaDAL _ventaDAL;

        public VentaService(string _connectionString)
        {
            _ventaDAL = new VentaDAL(_connectionString);
        }

        public DtoEnvioInformacion ObtenerUltimaInformacionDeEnvio(string customerId)
        {
            return _ventaDAL.ObtenerUltimaInformacionDeEnvio(customerId);
        }
    }
}
