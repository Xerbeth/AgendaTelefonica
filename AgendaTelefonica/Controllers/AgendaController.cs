#region Referencias
using Common.Models;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Collections;
#endregion

namespace AgendaTelefonica.Controllers
{
    /// <summary>
    /// Clase Controller para la vista Agenda 
    /// </summary>
    public class AgendaController : Controller
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

        // GET: Agenda
        public ActionResult Index()
        {
            JsonResult jsonResult = new JsonResult();

            RequestDto = new RequestDto();

            List<InfoEmpleadosDto> infoEmpleadosDto = new List<InfoEmpleadosDto>();
            
            jsonResult = this.GetInfoEmpleados();

            RequestDto = (RequestDto)jsonResult.Data;

            infoEmpleadosDto = JsonConvert.DeserializeObject<List<InfoEmpleadosDto>>(RequestDto.Result.ToString());

            return View("Agenda",infoEmpleadosDto);
        }

        /// <summary>
        /// Método en el controlador para obtener la lista de los tipos de documentos
        /// </summary>
        /// <returns> Objeto Json con la información de la petición </returns>
        [HttpGet]
        public JsonResult GetListTiposDocumentos()
        {
            TiposDocumentosBl = new TiposDocumentosBL();
            RequestDto = new RequestDto();

            RequestDto = TiposDocumentosBl.GetListTiposDocumentos();

            if (RequestDto.RequestStatus == RequestDto.Status.Failure)
            {
                return new JsonResult() { Data = RequestDto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { Data = RequestDto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// Método del controlador para obtener la lista de los cargos
        /// </summary>
        /// <returns> Objeto Json con la información de la petición </returns>
        [HttpGet]
        public JsonResult GetListCargos()
        {
            CargosBL = new CargosBL();
            RequestDto = new RequestDto();

            RequestDto = CargosBL.GetListCargos();

            if (RequestDto.RequestStatus == RequestDto.Status.Failure)
            {
                return new JsonResult() { Data = RequestDto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { Data = RequestDto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// Método del controlador para obtener la lista de los empleados para la lista de jefes
        /// </summary>
        /// <returns> Objeto Json con la información de la petición </returns>
        [HttpGet]
        public JsonResult GetListJefes()
        {
            EmpleadosBL = new EmpleadosBL();
            RequestDto = new RequestDto();

            RequestDto = EmpleadosBL.GetListJefes();

            //if ((string.IsNullOrEmpty((string)RequestDto.Result)))
            //{
            //    ViewBag.viewJefe = false;
            //}

            if (RequestDto.RequestStatus == RequestDto.Status.Failure)
            {
                return new JsonResult() { Data = RequestDto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { Data = RequestDto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// Método para obtener los tipos de telefonos 
        /// </summary>
        /// <returns> Objeto Json con la información de la petición </returns>
        [HttpGet]
        public JsonResult GetListTiposTelefonos()
        {
            TiposTelefonosBL = new TiposTelefonosBL();
            RequestDto = new RequestDto();

            RequestDto = TiposTelefonosBL.GetListTiposTelefonos();

            if (RequestDto.RequestStatus == RequestDto.Status.Failure)
            {
                return new JsonResult() { Data = RequestDto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { Data = RequestDto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }        

        [HttpPost]
        public JsonResult InsertEmpleado(EmpleadoDto empleado)
        {
            EmpleadosBL = new EmpleadosBL();
            RequestDto = new RequestDto();

            RequestDto = EmpleadosBL.InsertEmpleado(empleado);

            if (RequestDto.RequestStatus == RequestDto.Status.Failure)
            {
                return new JsonResult() { Data = RequestDto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { Data = RequestDto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// Método para agregar un empleados
        /// </summary>
        /// <returns> Objeto Json con la información de la petición </returns>
        [HttpPost]
        public JsonResult InsertTelefono(telefonos telefonos)
        {
            TelefonosBL = new TelefonosBL();
            RequestDto = new RequestDto();

            if (!ModelState.IsValid)
            {
                new JsonResult();
            }

            RequestDto = TelefonosBL.InsertTelefono(telefonos);

            if (RequestDto.RequestStatus == RequestDto.Status.Failure)
            {
                return new JsonResult() { Data = RequestDto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { Data = RequestDto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> Objeto Json con la información de la petición </returns>
        [HttpGet]
        public JsonResult GetInfoEmpleados()
        {
            EmpleadosBL = new EmpleadosBL();
            RequestDto = new RequestDto();

            RequestDto = EmpleadosBL.GetInfoEmpleados();

            List<InfoEmpleadosDto> infoEmpleadosDto = new List<InfoEmpleadosDto>();

            //infoEmpleadosDto = JsonConvert.DeserializeObject<List<InfoEmpleadosDto>>(RequestDto.Result.ToString());

            if (RequestDto.RequestStatus == RequestDto.Status.Failure)
            {
                return new JsonResult() { Data = RequestDto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { Data = RequestDto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// Método para eliminar la informacion de un empleado 
        /// </summary>
        /// <returns> Objeto Json con la información de la petición </returns>
        [HttpDelete]
        public JsonResult DeleteEmpleado(int Empleado_Id, int Telefono_Id = 0)
        {
            EmpleadosBL = new EmpleadosBL();
            RequestDto = new RequestDto();


            RequestDto = EmpleadosBL.DeleteEmpleado(Empleado_Id, Telefono_Id);

            List<InfoEmpleadosDto> infoEmpleadosDto = new List<InfoEmpleadosDto>();

            return new JsonResult() { Data = RequestDto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        #endregion

        #endregion

    }
}