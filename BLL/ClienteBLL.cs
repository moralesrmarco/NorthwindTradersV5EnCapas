using DAL;
using Entities;
using System.Collections.Generic;
using System.Data;

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

        public (List<Cliente> clientes, string mensajeEstado) ObtenerClientes(bool selectorRealizaBusqueda, Cliente criterios)
        {
            var clientes = _clienteDAL.ObtenerClientes(selectorRealizaBusqueda, criterios);
            string mensajeEstado = selectorRealizaBusqueda
                ? $"Se encontraron {clientes.Count} cliente(s)."
                : $"Se muestran los primeros {clientes.Count} cliente(s) registrados.";
            return (clientes, mensajeEstado);
        }

        public Cliente ObtenerClientePorId(string idCliente)
        {
            return _clienteDAL.ObtenerClientePorId(idCliente);
        }

        public int Insertar(Cliente cliente)
        {
            return _clienteDAL.Insertar(cliente);
        }

        public int Actualizar(Cliente cliente)
        {
            return _clienteDAL.Actualizar(cliente);
        }

        public int Eliminar(string clienteId, byte[] rowVersion)
        {
            return _clienteDAL.Eliminar(clienteId, rowVersion);
        }
    }
}
