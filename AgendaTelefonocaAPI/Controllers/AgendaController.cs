#region Referencias
using BL;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
#endregion


namespace AgendaTelefonocaAPI.Controllers
{
    /// <summary>
    /// Clase ApiController para la exponer las funcionalidades de la vista Agenda
    /// </summary>
    public class AgendaController : ApiController
    {

        #region Propiedades
        private TiposDocumentosBL TiposDocumentosBl;
        private RequestDto RequestDto;
        private EmpleadosBL EmpleadosBL;
        private CargosBL CargosBL;
        private TiposTelefonosBL TiposTelefonosBL;
        private TelefonosBL TelefonosBL;
        #endregion

        #region Métodos 

        #region Métodos públicos

        public AgendaController()
        {
            RequestDto = new RequestDto();
        }

        // GET: api/Agenda/GetInfoEmpleados
        /// <summary>
        /// Método para obtener la informacion de los empleados 
        /// </summary>
        /// <returns> Lista con la informacion referente a empleados </returns>
        public IEnumerable<InfoEmpleadosDto> GetInfoEmpleados()
        {
            EmpleadosBL = new EmpleadosBL();
            RequestDto = new RequestDto();
            RequestDto = EmpleadosBL.GetInfoEmpleados();
            List<InfoEmpleadosDto> infoEmpleadosDto = new List<InfoEmpleadosDto>();
            infoEmpleadosDto = JsonConvert.DeserializeObject<List<InfoEmpleadosDto>>(RequestDto.Result.ToString());
            return infoEmpleadosDto;
        }

        // DELETE: /api/Agenda/DeleteEmpleado/1
        /// <summary>
        /// Método para eliminar un registro de empleados
        /// </summary>
        /// <param name="Empleado_Id"> Id del empleado </param>
        /// <param name="Telefono_Id"> Id de telefono </param>
        /// <returns> Mensaje de la tra</returns>
        [HttpDelete]
        public string DeleteEmpleado(int Empleado_Id, int Telefono_Id = 0)
        {
            EmpleadosBL = new EmpleadosBL();
            RequestDto = new RequestDto();
            RequestDto = EmpleadosBL.DeleteEmpleado(Empleado_Id, Telefono_Id);            
            return RequestDto.Message.ToString();
        }

        // DELETE: /api/Agenda/Insertempleado
        /// <summary>
        /// Método para inserta un empleado 
        /// </summary>
        /// <param name="empleadoDto"> Entidad de empleado </param>
        [HttpPost]
        public string Insertempleado([FromBody]EmpleadoDto empleadoDto)
        {
            EmpleadosBL = new EmpleadosBL();
            RequestDto = new RequestDto();
            RequestDto = EmpleadosBL.InsertEmpleado(empleadoDto);
            return RequestDto.Message.ToString();
        }

        /// <summary>
        /// Método para obtener la información de los cargos registrados 
        /// </summary>
        /// <returns> Lista de cargos registrados </returns>
        [HttpGet]
        public IEnumerable<ListDto> GetListCargos()
        {
            CargosBL = new CargosBL();
            RequestDto = new RequestDto();
            RequestDto = CargosBL.GetListCargos();
            List<ListDto> infoEmpleadosDto = new List<ListDto>();
            infoEmpleadosDto = JsonConvert.DeserializeObject<List<ListDto>>(RequestDto.Result.ToString());
            return infoEmpleadosDto;
        }

        #endregion

        #endregion


    }
}
