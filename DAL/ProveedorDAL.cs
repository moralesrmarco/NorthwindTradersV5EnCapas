using Entities;
using System;
using System.Collections.Generic;
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

        public List<Proveedor> ObtenerProveedores(bool selectorRealizaBusqueda, Proveedor criterios, bool top100)
        {
            var proveedores = new List<Proveedor>();
            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SpProveedorObtener", con))
                { 
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@top100", top100);
                    con.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var proveedor = new Proveedor
                            {
                                SupplierID = dr["SupplierID"] != DBNull.Value ? Convert.ToInt32(dr["SupplierID"]) : 0,
                                CompanyName = dr["CompanyName"] != DBNull.Value ? dr["CompanyName"].ToString() : null,
                                ContactName = dr["ContactName"] != DBNull.Value ? dr["ContactName"].ToString() : null,
                                ContactTitle = dr["ContactTitle"] != DBNull.Value ? dr["ContactTitle"].ToString() : null,
                                Address = dr["Address"] != DBNull.Value ? dr["Address"].ToString() : null,
                                City = dr["City"] != DBNull.Value ? dr["City"].ToString() : null,
                                Region = dr["Region"] != DBNull.Value ? dr["Region"].ToString() : null,
                                PostalCode = dr["PostalCode"] != DBNull.Value ? dr["PostalCode"].ToString() : null,
                                Country = dr["Country"] != DBNull.Value ? dr["Country"].ToString() : null,
                                Phone = dr["Phone"] != DBNull.Value ? dr["Phone"].ToString() : null,
                                Fax = dr["Fax"] != DBNull.Value ? dr["Fax"].ToString() : null
                            };
                            proveedores.Add(proveedor);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return proveedores;
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
