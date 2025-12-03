using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CategoriaDAL
    {

        private readonly string _connectionString;

        public CategoriaDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Insertar(Categoria categoria)
        {
            int numRegs = 0;
            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SpCategoriaInsertar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryID", 0);
                    cmd.Parameters["@CategoryID"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@CategoryName", categoria.CategoryName);
                    cmd.Parameters.AddWithValue("@Description", categoria.Description);
                    var byteFoto = cmd.Parameters.Add("@Picture", SqlDbType.VarBinary, categoria.Picture?.Length ?? -1);
                    byteFoto.Value = (object)categoria.Picture ?? DBNull.Value;
                    con.Open();
                    numRegs = cmd.ExecuteNonQuery();
                    categoria.CategoryID = (int)cmd.Parameters["@CategoryID"].Value;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return numRegs;
        }

        public int Actualizar(Categoria categoria)
        {
            int numRegs = 0;
            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SpCategoriaActualizar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryID", categoria.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryName", categoria.CategoryName);
                    cmd.Parameters.AddWithValue("@Description", categoria.Description);
                    var byteFoto = cmd.Parameters.Add("@Picture", SqlDbType.Image);
                    byteFoto.Value = (object)categoria.Picture ?? DBNull.Value;
                    var rowVersion = cmd.Parameters.Add("@RowVersion", SqlDbType.Binary, 8);
                    rowVersion.Value = categoria.RowVersion ?? (object)DBNull.Value;
                    // Parámetro de retorno
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    numRegs = (int)returnParameter.Value;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return numRegs;
        }

        public int Eliminar(int categoriaId, byte[] rowVersion)
        {
            int numRegs = 0;
            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SpCategoriaEliminar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryID", categoriaId);
                    cmd.Parameters.AddWithValue("@RowVersion", rowVersion);
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    numRegs = Convert.ToInt32(returnParameter.Value);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return numRegs;
        }

        public List<Categoria> ObtenerCategorias(bool selectorRealizaBusqueda, DtoCategoriasBuscar criterios, bool top100)
        {
            var categorias = new List<Categoria>();
            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (selectorRealizaBusqueda)
                    {
                        cmd.CommandText = "SpCategoriaBuscar";
                        cmd.Parameters.AddWithValue("@IdIni", criterios.IdIni);
                        cmd.Parameters.AddWithValue("@IdFin", criterios.IdFin);
                        cmd.Parameters.AddWithValue("@CategoryName", criterios.CategoryName);
                    }
                    else
                    {
                        cmd.CommandText = "SpCategoriaObtener";
                        cmd.Parameters.AddWithValue("@top100", top100);
                    }
                    con.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var categoria = new Categoria()
                            {
                                CategoryID = dr["CategoryID"] != DBNull.Value ? Convert.ToInt32(dr["CategoryID"]) : 0,
                                CategoryName = dr["CategoryName"] != DBNull.Value ? dr["CategoryName"].ToString() : null,
                                Description = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : null,
                                Picture = (byte[])dr["Picture"],
                                RowVersion = dr["RowVersion"] != DBNull.Value ? (byte[])dr["RowVersion"] : null
                            };
                            categorias.Add(categoria);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return categorias;
        }

        public DataSet ObtenerCategoriasProductosDgv()
        {
            var ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    using (var dapCategorias = new SqlDataAdapter("SpCategoriaObtener", con))
                    {
                        dapCategorias.SelectCommand.CommandType = CommandType.StoredProcedure;
                        dapCategorias.SelectCommand.Parameters.AddWithValue("@top100", true);
                        dapCategorias.Fill(ds, "Categorias");
                    }
                    using (var dapProductos = new SqlDataAdapter("SpProductosConCategoriaProveedorDgv", con))
                    {
                        dapProductos.SelectCommand.CommandType = CommandType.StoredProcedure;
                        dapProductos.SelectCommand.Parameters.AddWithValue("@top100", true);
                        dapProductos.Fill(ds, "Productos");
                    }
                }
                // Quitar columnas que me causan conflicto al pintar el DataGridView
                ds.Tables["Categorias"].Columns.Remove("RowVersion");
                // en la siguiente instrucción se deben de proporcionar los nombres de los campos (alias) que devuelve el store procedure
                DataRelation dataRelation = new DataRelation("CategoriasProductos", ds.Tables["Categorias"].Columns["CategoryID"], ds.Tables["Productos"].Columns["CategoryID"]);
                ds.Relations.Add(dataRelation);
            }
            catch (Exception)
            {
                throw;
            }
            return ds;
        }

        public DataTable ObtenerProductosPorCategoriaListado()
        {
            var dt = new DataTable();
            try 
            { 
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand
                {
                    Connection = con,
                    CommandText = "SELECT * FROM VwProductosPorCategoriaListado order by CategoryName, ProductName;",
                    CommandType = CommandType.Text
                })
                {
                    using (var dap = new SqlDataAdapter(cmd))
                    {
                        dap.Fill(dt);
                    }
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
