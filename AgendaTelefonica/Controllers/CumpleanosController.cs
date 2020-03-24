#region Referencias 
using BL;
using Common.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;
#endregion

namespace AgendaTelefonica.Controllers
{
    /// <summary>
    /// Clase ApiController para exponer las funcionalidades la vista de cumpleanos
    /// </summary>
    public class CumpleanosController : Controller
    {
        #region Propiedades
        private RequestDto RequestDto;
        private CumpleanosBL CumpleanosBL;
        #endregion

        #region Métodos 

        #region Métodos públicos
        // GET: Cumpleanos
        public ActionResult Index()
        {
            JsonResult jsonResult = new JsonResult();
            RequestDto = new RequestDto();
            List<InfoCumpleanosDto> infoEmpleadosDto = new List<InfoCumpleanosDto>();
            CumpleanosBL = new CumpleanosBL();

            RequestDto = CumpleanosBL.GetInfoCumpleanos();

            infoEmpleadosDto = JsonConvert.DeserializeObject<List<InfoCumpleanosDto>>(RequestDto.Result.ToString());

            return View("Cumpleanos",infoEmpleadosDto);
        }

        #endregion

        #endregion
    }
}