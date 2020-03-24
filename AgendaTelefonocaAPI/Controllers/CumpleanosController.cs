#region Referencias
using Common.Models;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
#endregion

namespace AgendaTelefonocaAPI.Controllers
{
    public class CumpleanosController : ApiController
    {
        #region Propiedades 
        private CumpleanosBL CumpleanosBL;
        private RequestDto RequestDto;
        #endregion

        #region Métodos

        #region Métodos públicos
        public CumpleanosController() 
        {
            CumpleanosBL = new CumpleanosBL();
            RequestDto = new RequestDto();
        }

        // GET: api/Cumpleanos/GetInfoCumpleEmpleados
        /// <summary>
        /// Método para obtener la información de los cumpleaños de las personas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<InfoCumpleanosDto> GetInfoCumpleanos() 
        {
            List<InfoCumpleanosDto> infoEmpleadosDto = new List<InfoCumpleanosDto>();
            RequestDto = CumpleanosBL.GetInfoCumpleanos();
            List<InfoCumpleanosDto> infoCumpleanosDto = new List<InfoCumpleanosDto>();
            infoCumpleanosDto = JsonConvert.DeserializeObject<List<InfoCumpleanosDto>>(RequestDto.Result.ToString());
            return infoCumpleanosDto.ToList();            
        }

        #endregion

        #endregion

    }
}
