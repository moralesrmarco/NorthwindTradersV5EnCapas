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

        private readonly EmpleadoDAL empleadoDAL;

        public EmpleadoBLL(string connectionString)
        {
            empleadoDAL = new EmpleadoDAL(connectionString);
        }

        public int Insertar(Empleado empleado)
        {
            try
            {
                int numRegs = 0;
                numRegs = empleadoDAL.Insertar(empleado);
                return numRegs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Empleado ObtenerEmpleadoPorId(Empleado empleado)
        {
            try
            {
                empleado = empleadoDAL.ObtenerEmpleadoPorId(empleado);
                return empleado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ObtenerEmpleadoReportaaCbo()
        {
            try
            {
                var empleados = new DataTable();
                empleados = empleadoDAL.ObtenerEmpleadoReportaaCbo();
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
                employees = empleadoDAL.ObtenerEmpleadosDgv(selectorRealizaBusqueda, dtoEmpleadosBuscar);
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
                paises = empleadoDAL.ObtenerEmpleadosPaisesCbo();
                return paises;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
