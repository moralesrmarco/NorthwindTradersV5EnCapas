using DAL;

namespace BLL
{
    public class PedidoBLL
    {
        private readonly PedidoDAL _pedidoDAL;

        public PedidoBLL(string _connectionString)
        {
            _pedidoDAL = new PedidoDAL(_connectionString);
        }
    }
}
