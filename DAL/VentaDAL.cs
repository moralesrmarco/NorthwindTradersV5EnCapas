using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class VentaDAL
    {
        private readonly string _connectionString;

        public VentaDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Venta> ObtenerVentas(bool selectorRealizaBusqueda, DtoVentasBuscar criterios, bool top100)
        {
            var ventas = new List<Venta>();
            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (selectorRealizaBusqueda)
                    {
                        cmd.CommandText = "SpVentaBuscar";
                        // Numéricos
                        cmd.Parameters.Add("@IdIni", SqlDbType.Int).Value = criterios.IdIni;
                        cmd.Parameters.Add("@IdFin", SqlDbType.Int).Value = criterios.IdFin;

                        // Strings
                        cmd.Parameters.Add("@Cliente", SqlDbType.NVarChar, 40).Value = criterios.Cliente;
                        cmd.Parameters.Add("@Empleado", SqlDbType.NVarChar, 31).Value = criterios.Empleado;
                        cmd.Parameters.Add("@CompañiaT", SqlDbType.NVarChar, 40).Value = criterios.CompañiaT;
                        cmd.Parameters.Add("@Dirigidoa", SqlDbType.NVarChar, 40).Value = criterios.DirigidoA;
                        // Bits
                        cmd.Parameters.Add("@FVenta", SqlDbType.Bit).Value = criterios.FVenta;
                        cmd.Parameters.Add("@FVentaNull", SqlDbType.Bit).Value = criterios.FVentaNull;

                        cmd.Parameters.Add("@FRequerido", SqlDbType.Bit).Value = criterios.FRequerido;
                        cmd.Parameters.Add("@FRequeridoNull", SqlDbType.Bit).Value = criterios.FRequeridoNull;

                        cmd.Parameters.Add("@FEnvio", SqlDbType.Bit).Value = criterios.FEnvio;
                        cmd.Parameters.Add("@FEnvioNull", SqlDbType.Bit).Value = criterios.FEnvioNull;

                        // Fechas (si son null, se manda DBNull)
                        cmd.Parameters.Add("@FVentaIni", SqlDbType.DateTime).Value =
                            criterios.FVentaIni.HasValue ? (object)criterios.FVentaIni.Value : DBNull.Value;

                        cmd.Parameters.Add("@FVentaFin", SqlDbType.DateTime).Value =
                            criterios.FVentaFin.HasValue ? (object)criterios.FVentaFin.Value : DBNull.Value;

                        cmd.Parameters.Add("@FRequeridoIni", SqlDbType.DateTime).Value =
                            criterios.FRequeridoIni.HasValue ? (object)criterios.FRequeridoIni.Value : DBNull.Value;

                        cmd.Parameters.Add("@FRequeridoFin", SqlDbType.DateTime).Value =
                            criterios.FRequeridoFin.HasValue ? (object)criterios.FRequeridoFin.Value : DBNull.Value;

                        cmd.Parameters.Add("@FEnvioIni", SqlDbType.DateTime).Value =
                            criterios.FEnvioIni.HasValue ? (object)criterios.FEnvioIni.Value : DBNull.Value;

                        cmd.Parameters.Add("@FEnvioFin", SqlDbType.DateTime).Value =
                            criterios.FEnvioFin.HasValue ? (object)criterios.FEnvioFin.Value : DBNull.Value;
                    }
                    else
                    {
                        cmd.CommandText = "SpVentaObtener";
                        cmd.Parameters.AddWithValue("@Top100", top100);
                    }
                    con.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var venta = new Venta()
                            {
                                OrderID = rdr["OrderID"] as int? ?? 0,
                                Cliente = new Cliente
                                {
                                    CustomerID = rdr["CustomerID"] as string ?? string.Empty,
                                    CompanyName = rdr["CustomerCompanyName"] as string ?? string.Empty,
                                    ContactName = rdr["ContactName"] as String ?? string.Empty
                                },
                                Empleado = new Empleado
                                {
                                    EmployeeID = rdr["EmployeeID"] as int? ?? 0,
                                    FirstName = rdr["FirstName"] as String ?? string.Empty,
                                    LastName = rdr["LastName"] as String ?? string.Empty
                                },
                                OrderDate = rdr["OrderDate"] as DateTime?,
                                RequiredDate = rdr["RequiredDate"] as DateTime?,
                                ShippedDate = rdr["ShippedDate"] as DateTime?,
                                Transportista = new Transportista
                                {
                                    ShipperID = rdr["ShipperID"] as int? ?? 0,
                                    CompanyName = rdr["ShipperCompanyName"] as string ?? string.Empty
                                },
                                Freight = rdr["Freight"] as decimal? ?? 0.00m,
                                ShipName = rdr["ShipName"] as string ?? string.Empty,
                                ShipAddress = rdr["ShipAddress"] as string ?? string.Empty,
                                ShipCity = rdr["ShipCity"] as string ?? string.Empty,
                                ShipRegion = rdr["ShipRegion"] as string ?? string.Empty,
                                ShipPostalCode = rdr["ShipPostalCode"] as string ?? string.Empty,
                                ShipCountry = rdr["ShipCountry"] as string ?? String.Empty,
                            };
                            ventas.Add(venta);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ventas; 
        }
    }
}
