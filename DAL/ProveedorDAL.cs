using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ProveedorDAL
    {
        private readonly string _connectionString;

        public ProveedorDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataSet ObtenerProveedoresProductosDgv()
        {
            var ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    using (var dapProveedores = new SqlDataAdapter("SpProveedorObtener", con))
                    {
                        dapProveedores.SelectCommand.CommandType = CommandType.StoredProcedure;
                        dapProveedores.SelectCommand.Parameters.AddWithValue("@top100", true);
                        dapProveedores.Fill(ds, "Proveedores");
                    }
                    using (var dapProductos = new SqlDataAdapter("SpProductosConCategoriaProveedorDgv", con))
                    {
                        dapProductos.SelectCommand.CommandType = CommandType.StoredProcedure;
                        dapProductos.SelectCommand.Parameters.AddWithValue("@top100", true);
                        dapProductos.Fill(ds, "Productos");
                    }
                }
                // Quitar columnas que me causan conflicto al pintar el DataGridView
                ds.Tables["Proveedores"].Columns.Remove("RowVersion");
                ds.Tables["Proveedores"].Columns.Remove("HomePage");
                // en la siguiente instrucción se deben de proporcionar los nombres de los campos (alias) que devuelve el store procedure
                DataRelation dataRelation = new DataRelation("ProveedoresProductos", ds.Tables["Proveedores"].Columns["SupplierID"], ds.Tables["Productos"].Columns["SupplierID"]);
                ds.Relations.Add(dataRelation);
            }
            catch (Exception)
            {
                throw;
            }
            return ds;
        }
    }
}
