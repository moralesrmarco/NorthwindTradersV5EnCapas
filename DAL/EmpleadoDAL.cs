using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class EmpleadoDAL
    {

        private readonly string _connectionString;

        public EmpleadoDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable ObtenerEmpleadosReportaaCbo()
        {
            var dt = new DataTable();
            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SpEmpleadosObtenerReportaaCbo", con))
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

        public List<DtoEmpleadosDgv> ObtenerEmpleadosDgv(bool selectorRealizaBusqueda, DtoEmpleadosBuscar dtoEmpleadosBuscar)
        {
            List<DtoEmpleadosDgv> employees = new List<DtoEmpleadosDgv>();
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
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    using (var cmd = new SqlCommand(query, con))
                    {
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
                        using (var rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    DtoEmpleadosDgv employee = new DtoEmpleadosDgv
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
                        }
                    }
                }
                return employees;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DtoEmpleadosPaisesCbo> ObtenerEmpleadosPaisesCbo()
        {
            List<DtoEmpleadosPaisesCbo> paises = new List<DtoEmpleadosPaisesCbo>();
            string query = "SELECT '' As Id, '»--- Seleccione ---«' As Pais UNION ALL SELECT DISTINCT Country As Id, Country As Pais FROM Employees ORDER BY Pais;";
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    using (var cmd = new SqlCommand(query, con))
                    {
                        using (var rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    DtoEmpleadosPaisesCbo pais = new DtoEmpleadosPaisesCbo()
                                    {
                                        Id = rdr["Id"]?.ToString(),
                                        Pais = rdr["Pais"]?.ToString()
                                    };
                                    paises.Add(pais);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paises;
        }

    }
}
