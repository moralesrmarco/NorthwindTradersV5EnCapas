using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace DAL
{
    public class EmpleadoDAL
    {

        private readonly string _connectionString;

        public EmpleadoDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Insertar(Empleado empleado)
        {
            int numRegs = 0;
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    using (var cmd = new SqlCommand("SpEmpleadoInsertar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Id", 0);
                        cmd.Parameters["Id"].Direction = ParameterDirection.Output;
                        cmd.Parameters.AddWithValue("Nombres", empleado.FirstName);
                        cmd.Parameters.AddWithValue("Apellidos", empleado.LastName);
                        cmd.Parameters.AddWithValue("Titulo", empleado.Title);
                        cmd.Parameters.AddWithValue("TitCortesia", empleado.TitleOfCourtesy);
                        cmd.Parameters.AddWithValue("FNacimiento", empleado.BirthDate);
                        cmd.Parameters.AddWithValue("FContratacion", empleado.HireDate);
                        cmd.Parameters.AddWithValue("Domicilio", empleado.Address);
                        cmd.Parameters.AddWithValue("Ciudad", empleado.City);
                        cmd.Parameters.AddWithValue("Region", string.IsNullOrWhiteSpace(empleado.Region) ? (object)DBNull.Value : (object)empleado.Region);
                        cmd.Parameters.AddWithValue("CodigoP", string.IsNullOrWhiteSpace(empleado.PostalCode) ? (object)DBNull.Value : (object)empleado.PostalCode);
                        cmd.Parameters.AddWithValue("Pais",empleado.Country);
                        cmd.Parameters.AddWithValue("Telefono", string.IsNullOrWhiteSpace(empleado.HomePhone) ? (object)DBNull.Value : (object)empleado.HomePhone);
                        cmd.Parameters.AddWithValue("Extension", string.IsNullOrWhiteSpace(empleado.Extension) ? (object)DBNull.Value : (object)empleado.Extension);
                        cmd.Parameters.AddWithValue("Notas", string.IsNullOrWhiteSpace(empleado.Notes) ? (object)DBNull.Value : (object)empleado.Notes);
                        var reportaA = cmd.Parameters.Add("Reportaa", SqlDbType.Int);
                        reportaA.Value = empleado.ReportsTo.HasValue && empleado.ReportsTo.Value != 0
                            ? (object)empleado.ReportsTo.Value
                            : DBNull.Value;
                        var byteFoto = cmd.Parameters.Add("Foto", SqlDbType.VarBinary, empleado.Photo?.Length ?? -1);
                        byteFoto.Value = (object)empleado.Photo ?? DBNull.Value;
                        numRegs = cmd.ExecuteNonQuery();
                        empleado.EmployeeID = (int)cmd.Parameters["Id"].Value;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return numRegs;
        }

        public int Actualizar(Empleado empleado)
        {
            int numRegs = 0;
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    using (var cmd = new SqlCommand("SpEmpleadoActualizar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Id", empleado.EmployeeID);
                        cmd.Parameters.AddWithValue("Nombres", empleado.FirstName);
                        cmd.Parameters.AddWithValue("Apellidos", empleado.LastName);
                        cmd.Parameters.AddWithValue("Titulo", empleado.Title);
                        cmd.Parameters.AddWithValue("TitCortesia", empleado.TitleOfCourtesy);
                        cmd.Parameters.AddWithValue("FNacimiento", empleado.BirthDate);
                        cmd.Parameters.AddWithValue("FContratacion", empleado.HireDate);
                        cmd.Parameters.AddWithValue("Domicilio", empleado.Address);
                        cmd.Parameters.AddWithValue("Ciudad", empleado.City);
                        cmd.Parameters.AddWithValue("Region", string.IsNullOrWhiteSpace(empleado.Region) ? (object)DBNull.Value : (object)empleado.Region);
                        cmd.Parameters.AddWithValue("CodigoP", string.IsNullOrWhiteSpace(empleado.PostalCode) ? (object)DBNull.Value : (object)empleado.PostalCode);
                        cmd.Parameters.AddWithValue("Pais", empleado.Country);
                        cmd.Parameters.AddWithValue("Telefono", string.IsNullOrWhiteSpace(empleado.HomePhone) ? (object)DBNull.Value : (object)empleado.HomePhone);
                        cmd.Parameters.AddWithValue("Extension", string.IsNullOrWhiteSpace(empleado.Extension) ? (object)DBNull.Value : (object)empleado.Extension);
                        cmd.Parameters.AddWithValue("Notas", string.IsNullOrWhiteSpace(empleado.Notes) ? (object)DBNull.Value : (object)empleado.Notes);
                        var reportaA = cmd.Parameters.Add("Reportaa", SqlDbType.Int);
                        reportaA.Value = empleado.ReportsTo.HasValue && empleado.ReportsTo.Value != 0
                            ? (object)empleado.ReportsTo.Value
                            : DBNull.Value;
                        var byteFoto = cmd.Parameters.Add("Foto", SqlDbType.VarBinary, empleado.Photo?.Length ?? -1);
                        byteFoto.Value = (object)empleado.Photo ?? DBNull.Value;
                        var rowVersion = cmd.Parameters.Add("RowVersion", SqlDbType.Timestamp);
                        rowVersion.Value = empleado.RowVersion ?? (object)DBNull.Value;
                        // Parámetro de retorno
                        var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;
                        cmd.ExecuteNonQuery();
                        numRegs = (int)returnParameter.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return numRegs;
        }

        public Empleado ObtenerEmpleadoPorId(Empleado empleado)
        {
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    using (var cmd = new SqlCommand("SpEmpleadoObtenerPorId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Id", empleado.EmployeeID);
                        using (var rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                empleado.RowVersion = (byte[])rdr["RowVersion"];
                                empleado.FirstName = rdr["FirstName"].ToString();
                                empleado.LastName = rdr["LastName"].ToString();
                                empleado.Title = rdr.IsDBNull(rdr.GetOrdinal("Title")) ? null : rdr.GetString(rdr.GetOrdinal("Title"));
                                empleado.TitleOfCourtesy = rdr.IsDBNull(rdr.GetOrdinal("TitleOfCourtesy")) ? null : rdr.GetString(rdr.GetOrdinal("TitleOfCourtesy"));
                                empleado.BirthDate = rdr.IsDBNull(rdr.GetOrdinal("BirthDate")) ? (DateTime?)null : rdr.GetDateTime(rdr.GetOrdinal("BirthDate"));
                                empleado.HireDate = rdr.IsDBNull(rdr.GetOrdinal("HireDate")) ? (DateTime?)null : rdr.GetDateTime(rdr.GetOrdinal("HireDate"));
                                empleado.Address = rdr.IsDBNull(rdr.GetOrdinal("Address")) ? null : rdr.GetString(rdr.GetOrdinal("Address"));
                                empleado.City = rdr.IsDBNull(rdr.GetOrdinal("City")) ? null : rdr.GetString(rdr.GetOrdinal("City"));
                                empleado.Region = rdr.IsDBNull(rdr.GetOrdinal("Region")) ? null : rdr.GetString(rdr.GetOrdinal("Region"));
                                empleado.PostalCode = rdr.IsDBNull(rdr.GetOrdinal("PostalCode")) ? null : rdr.GetString(rdr.GetOrdinal("PostalCode"));
                                empleado.Country = rdr.IsDBNull(rdr.GetOrdinal("Country")) ? null : rdr.GetString(rdr.GetOrdinal("Country"));
                                empleado.HomePhone = rdr.IsDBNull(rdr.GetOrdinal("HomePhone")) ? null : rdr.GetString(rdr.GetOrdinal("HomePhone"));
                                empleado.Extension = rdr.IsDBNull(rdr.GetOrdinal("Extension")) ? null : rdr.GetString(rdr.GetOrdinal("Extension"));
                                empleado.Notes = rdr.IsDBNull(rdr.GetOrdinal("Notes")) ? null : rdr.GetString(rdr.GetOrdinal("Notes"));
                                empleado.ReportsTo = rdr.IsDBNull(rdr.GetOrdinal("ReportsTo")) ? (int?)null : rdr.GetInt32(rdr.GetOrdinal("ReportsTo"));
                                empleado.Photo = rdr.IsDBNull(rdr.GetOrdinal("Photo"))
                                            ? null
                                            : Utils.StripOleHeader(
                                                (byte[])rdr["Photo"],                            // cast directo a byte[]
                                                rdr.GetInt32(rdr.GetOrdinal("EmployeeID")));
                            }
                            else
                                empleado = null;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return empleado;
        }

        public DataTable ObtenerEmpleadoReportaaCbo()
        {
            var dt = new DataTable();
            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SpEmpleadoObtenerReportaaCbo", con))
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
            }
            catch (Exception)
            {
                throw;
            }
            return employees;
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
