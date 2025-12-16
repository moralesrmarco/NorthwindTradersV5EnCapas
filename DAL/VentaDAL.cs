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
                        cmd.CommandText = "SpVentasBuscar";
                        cmd.Parameters.AddWithValue("@IdIni", criterios.IdIni);
                        cmd.Parameters.AddWithValue("@IdFin", criterios.IdFin);
                        cmd.Parameters.AddWithValue("@Cliente", criterios.Cliente);
                        cmd.Parameters.AddWithValue("@FVenta", criterios.FVenta);
                        cmd.Parameters.AddWithValue("@FVentaNull", criterios.FVentaNull);
                        cmd.Parameters.AddWithValue("@FVentaIni", criterios.FVentaIni);
                        cmd.Parameters.AddWithValue("@FVentaFin", criterios.FVentaFin);
                        cmd.Parameters.AddWithValue("@FRequerido", criterios.FRequerido);
                        cmd.Parameters.AddWithValue("@FRequeridoNull", criterios.FRequeridoNull);
                        cmd.Parameters.AddWithValue("@FRequeridoIni", criterios.FRequeridoIni);
                        cmd.Parameters.AddWithValue("@FRequeridoFin", criterios.FRequeridoFin);
                        cmd.Parameters.AddWithValue("@FEnvio", criterios.FEnvio);
                        cmd.Parameters.AddWithValue("@FEnvioNull", criterios.FEnvioNull);
                        cmd.Parameters.AddWithValue("@FEnvioIni", criterios.FEnvioIni);
                        cmd.Parameters.AddWithValue("@FEnvioFin", criterios.FEnvioFin);
                        cmd.Parameters.AddWithValue("@Empleado", criterios.Empleado);
                        cmd.Parameters.AddWithValue("@CompañiaT", criterios.CompañiaT);
                        cmd.Parameters.AddWithValue("@DirigidoA", criterios.DirigidoA);
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
                                    CompanyName = rdr["CompanyName"] as string ?? string.Empty,
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
                                    CompanyName = rdr["CompanyName"] as string ?? string.Empty
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
