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

        private readonly EmpleadoDAL _empleadoDAL;

        public EmpleadoBLL(string _connectionString)
        {
            _empleadoDAL = new EmpleadoDAL(_connectionString);
        }

        public int Insertar(Empleado empleado)
        {
            return _empleadoDAL.Insertar(empleado);
        }

        public int Actualizar(Empleado empleado)
        {
            return _empleadoDAL.Actualizar(empleado);
        }

        public int Eliminar(int empleadoId, byte[] rowVersion)
        {
            return _empleadoDAL.Eliminar(empleadoId, rowVersion);
        }

        public DataTable ObtenerEmpleadoReportaaCbo()
        {
            return _empleadoDAL.ObtenerEmpleadoReportaaCbo();
        }

        public List<DtoEmpleadosDgv> ObtenerEmpleadosDgv(bool selectorRealizaBusqueda, DtoEmpleadosBuscar dtoEmpleadosBuscar)
        {
            return _empleadoDAL.ObtenerEmpleadosDgv(selectorRealizaBusqueda, dtoEmpleadosBuscar);
        }

        public List<DtoEmpleadosPaisesCbo> ObtenerEmpleadosPaisesCbo()
        {
            return _empleadoDAL.ObtenerEmpleadosPaisesCbo();
        }


        /// <summary>
        /// Obtiene un empleado por su ID.
        /// </summary>
        public Empleado ObtenerEmpleadoPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del empleado debe ser mayor a cero.", nameof(id));

            //return _empleadoDAL.ObtenerEmpleadoPorId(id);
            var empleado = _empleadoDAL.ObtenerEmpleadoPorId(id);
            if (empleado != null && empleado.ReportsTo.HasValue)
            {
                empleado.Jefe = _empleadoDAL.ObtenerEmpleadoPorId(empleado.ReportsTo.Value);
            }
            return empleado;
        }

        /// <summary>
        /// Obtiene un empleado con su jefe y subordinados.
        /// </summary>
        public Empleado ObtenerEmpleadoConJerarquia(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del empleado debe ser mayor a cero.", nameof(id));

            return _empleadoDAL.ObtenerEmpleadoConJerarquia(id);
        }

        /// <summary>
        /// Obtiene la lista de empleados que reportan a un jefe específico.
        /// </summary>
        public List<Empleado> ObtenerEmpleadoConSubordinados(int managerId)
        {
            if (managerId <= 0)
                throw new ArgumentException("El ID del jefe debe ser mayor a cero.", nameof(managerId));

            return _empleadoDAL.ObtenerEmpleadoConSubordinados(managerId);
        }

        /// <summary>
        /// Ejemplo de regla de negocio: validar si un empleado tiene jefe asignado.
        /// </summary>
        public bool TieneJefe(int id)
        {
            var empleado = _empleadoDAL.ObtenerEmpleadoPorId(id);
            return empleado?.ReportsTo != null;
        }

        /// <summary>
        /// Ejemplo de regla de negocio: obtener el nombre completo del jefe de un empleado.
        /// </summary>
        public string ObtenerNombreDelJefe(int id)
        {
            var empleado = _empleadoDAL.ObtenerEmpleadoPorId(id);
            if (empleado?.ReportsTo != null)
            {
                var jefe = _empleadoDAL.ObtenerEmpleadoPorId(empleado.ReportsTo.Value);
                return jefe?.NameByLastName ?? "Sin jefe";
            }
            return "Sin jefe";
        }


    }
}
