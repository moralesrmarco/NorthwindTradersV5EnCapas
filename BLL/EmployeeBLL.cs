using DAL;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class EmployeeBLL
    {

        private readonly EmployeeDAL employeeDAL;

        public EmployeeBLL(string connectionString)
        {
            employeeDAL = new EmployeeDAL(connectionString);
        }

        public List<DtoEmpleadosGrid> ObtenerEmpleados(bool selectorRealizaBusqueda, DtoEmpleadosBuscar dtoEmpleadosBuscar)
        {
            try
            {
                List<DtoEmpleadosGrid> employees = new List<DtoEmpleadosGrid>();
                employees = employeeDAL.ObtenerEmpleados(selectorRealizaBusqueda, dtoEmpleadosBuscar);
                return employees;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
