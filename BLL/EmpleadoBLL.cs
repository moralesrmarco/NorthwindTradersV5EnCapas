using DAL;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class EmpleadoBLL
    {

        private readonly EmpleadoDAL employeeDAL;

        public EmpleadoBLL(string connectionString)
        {
            employeeDAL = new EmpleadoDAL(connectionString);
        }

        public DataTable ObtenerEmpleadosReportaaCbo()
        {
            try
            {
                var empleados = new DataTable();
                empleados = employeeDAL.ObtenerEmpleadosReportaaCbo();
                return empleados;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DtoEmpleadosDgv> ObtenerEmpleadosDgv(bool selectorRealizaBusqueda, DtoEmpleadosBuscar dtoEmpleadosBuscar)
        {
            try
            {
                List<DtoEmpleadosDgv> employees = new List<DtoEmpleadosDgv>();
                employees = employeeDAL.ObtenerEmpleadosDgv(selectorRealizaBusqueda, dtoEmpleadosBuscar);
                return employees;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DtoEmpleadosPaisesCbo> ObtenerEmpleadosPaisesCbo()
        {
            try
            {
                List<DtoEmpleadosPaisesCbo> paises = new List<DtoEmpleadosPaisesCbo>();
                paises = employeeDAL.ObtenerEmpleadosPaisesCbo();
                return paises;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
