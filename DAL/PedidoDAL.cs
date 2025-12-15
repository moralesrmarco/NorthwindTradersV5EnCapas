namespace DAL
{
    public class PedidoDAL
    {
        private readonly string _connectionString;

        public PedidoDAL(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
