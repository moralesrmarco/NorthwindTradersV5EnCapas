using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class VentaDetalleDAL
    {
        private readonly string _connectionString;

        public VentaDetalleDAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public int Insertar(VentaDetalle ventaDetalle)
        {
            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SpVentaDetalleInsertar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderID", ventaDetalle.Venta.OrderID);
                    cmd.Parameters.AddWithValue("@ProductID", ventaDetalle.Producto.ProductID);
                    cmd.Parameters.AddWithValue("@UnitPrice", ventaDetalle.UnitPrice);
                    cmd.Parameters.AddWithValue("@Quantity", ventaDetalle.Quantity);
                    cmd.Parameters.AddWithValue("@Discount", ventaDetalle.Discount);
                    cmd.Parameters.AddWithValue("@TasaIVA", ventaDetalle.TasaIVA);
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el detalle de la venta: " + ex.Message, ex);
            }
        }

        public List<VentaDetalle> ObtenerVentaDetallePorVentaId(int orderId)
        {
            List<VentaDetalle> ventaDetalles = new List<VentaDetalle>();
            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SpVentaDetalleObtenerPorVentaId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    con.Open();
                    using (var rdr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        while (rdr.Read())
                        {
                            var ventaDetalle = new VentaDetalle
                            {
                                Venta = new Venta
                                {
                                    OrderID = rdr.GetInt32(rdr.GetOrdinal("OrderID"))
                                },
                                Producto = new Producto
                                {
                                    ProductID = rdr.GetInt32(rdr.GetOrdinal("ProductID")),
                                    ProductName = rdr.IsDBNull(rdr.GetOrdinal("ProductName")) ? null : rdr.GetString(rdr.GetOrdinal("ProductName"))
                                },
                                UnitPrice = rdr.GetDecimal(rdr.GetOrdinal("UnitPrice")),
                                Quantity = rdr.GetInt16(rdr.GetOrdinal("Quantity")),
                                Discount = (decimal)rdr.GetFloat(rdr.GetOrdinal("Discount")),
                                RowVersion = rdr.IsDBNull(rdr.GetOrdinal("RowVersion")) ? null : (byte[])rdr["RowVersion"]
                            };
                            ventaDetalles.Add(ventaDetalle);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los detalles de la venta: " + ex.Message);
            }
            return ventaDetalles;
        }

        public byte[] ObtenerVentaDetalleRowVersion(int orderId, int productId)
        {
            if (orderId <= 0 || productId <= 0) return null;
            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SpVentaDetalleObtenerRowVersion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    con.Open();
                    return (byte[])cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el RowVersion del detalle de la venta: " + ex.Message, ex);
            }
        }
    }
}
