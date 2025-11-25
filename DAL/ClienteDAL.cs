using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClienteDAL
    {

        private readonly string _connectionString;

        public ClienteDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable ObtenerClientesPaisesCbo()
        {
            var dt = new DataTable();
            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SpClientesObtenerPaisesCbo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var da = new SqlDataAdapter(cmd))
                        da.Fill(dt);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

    }
}
