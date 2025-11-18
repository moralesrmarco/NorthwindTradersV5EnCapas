using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class EmployeeDAL
    {

        private readonly string _connectionString;

        public EmployeeDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<DtoEmpleadosGrid> ObtenerEmpleados(bool selectorRealizaBusqueda, DtoEmpleadosBuscar dtoEmpleadosBuscar)
        {
            List<DtoEmpleadosGrid> employees = new List<DtoEmpleadosGrid>();
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(_connectionString);
                con.Open();
                string query;
                if (!selectorRealizaBusqueda)
                {
                    query = @"
                            SELECT TOP 20
                                e.EmployeeID,
                                e.FirstName,
                                e.LastName,
                                e.Title,
                                e.BirthDate,
                                e.City,
                                e.Country,
                                e.Photo,
                                e2.LastName + ', ' + e2.FirstName AS ReportsToName
                            FROM Employees AS e
                            LEFT JOIN Employees AS e2
                                ON e.ReportsTo = e2.EmployeeID
                            ORDER BY e.EmployeeID DESC;
                            ";
                }
                else
                {
                    query = @"
                            SELECT
                                e.EmployeeID,
                                e.FirstName,
                                e.LastName,
                                e.Title,
                                e.BirthDate,
                                e.City,
                                e.Country,
                                e.Photo,
                                e2.LastName + ', ' + e2.FirstName AS ReportsToName
                            FROM Employees AS e
                            LEFT JOIN Employees AS e2
                                ON e.ReportsTo = e2.EmployeeID
                            WHERE
                                (@IdIni = 0 OR e.EmployeeID BETWEEN @IdIni AND @IdFin)
                                AND (@Nombres = '' OR e.FirstName LIKE '%' + @Nombres + '%')
                                AND (@Apellidos = '' OR e.LastName LIKE '%' + @Apellidos + '%')
                                AND (@Titulo = '' OR e.Title LIKE '%' + @Titulo + '%')
                                AND (@Domicilio = '' OR e.Address LIKE '%' + @Domicilio + '%')
                                AND (@Ciudad = '' OR e.City LIKE '%' + @Ciudad + '%')
                                AND (@Region = '' OR e.Region LIKE '%' + @Region + '%')
                                AND (@CodigoP = '' OR e.PostalCode LIKE '%' + @CodigoP + '%')
                                AND (@Pais = '' OR e.Country LIKE '%' + @Pais + '%')
                                AND (@Telefono = '' OR e.HomePhone LIKE '%' + @Telefono + '%')
                            ORDER BY e.EmployeeID DESC;
                            ";
                }
                SqlCommand cmd = new SqlCommand(query, con);
                if (selectorRealizaBusqueda)
                {
                    cmd.Parameters.AddWithValue("@IdIni", dtoEmpleadosBuscar.IdIni);
                    cmd.Parameters.AddWithValue("@IdFin", dtoEmpleadosBuscar.IdFin);
                    cmd.Parameters.AddWithValue("@Nombres", dtoEmpleadosBuscar.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", dtoEmpleadosBuscar.Apellidos);
                    cmd.Parameters.AddWithValue("@Titulo", dtoEmpleadosBuscar.Titulo);
                    cmd.Parameters.AddWithValue("@Domicilio", dtoEmpleadosBuscar.Domicilio);
                    cmd.Parameters.AddWithValue("@Ciudad", dtoEmpleadosBuscar.Ciudad);
                    cmd.Parameters.AddWithValue("@Region", dtoEmpleadosBuscar.Region);
                    cmd.Parameters.AddWithValue("@CodigoP", dtoEmpleadosBuscar.CodigoP);
                    cmd.Parameters.AddWithValue("@Pais", dtoEmpleadosBuscar.Pais);
                    cmd.Parameters.AddWithValue("@Telefono", dtoEmpleadosBuscar.Telefono);
                }
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        DtoEmpleadosGrid employee = new DtoEmpleadosGrid
                        {
                            EmployeeID = Convert.ToInt32(rdr["EmployeeID"]),
                            LastName = rdr["LastName"]?.ToString(),
                            FirstName = rdr["FirstName"]?.ToString(),
                            Title = rdr["Title"]?.ToString(),
                            BirthDate = rdr["BirthDate"] is DBNull ? null : (DateTime?)Convert.ToDateTime(rdr["BirthDate"]),
                            City = rdr["City"]?.ToString(),
                            Country = rdr["Country"]?.ToString(),
                            Photo = rdr["Photo"] is DBNull ? null : (byte[])rdr["Photo"],
                            ReportsToName = rdr["ReportsToName"]?.ToString(),
                        };
                        employees.Add(employee);
                    }
                }
                rdr.Close();
                return employees;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

    }
}
