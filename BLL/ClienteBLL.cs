using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClienteBLL
    {

        private readonly ClienteDAL _clienteDAL;

        public ClienteBLL(string _connectionString)
        {
            _clienteDAL = new ClienteDAL(_connectionString);
        }

        public DataTable ObtenerClientesPaisesCbo()
        {
            var paises = _clienteDAL.ObtenerClientesPaisesCbo();
            DataRow filaSeleccione = paises.NewRow();
            filaSeleccione["Id"] = "";
            filaSeleccione["Pais"] = "»--- Seleccione ---«";
            paises.Rows.InsertAt(filaSeleccione, 0);
            return paises;
        }

    }
}
