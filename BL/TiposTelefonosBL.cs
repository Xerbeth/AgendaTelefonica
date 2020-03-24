#region Referencias
using Common.Models;
using Common.Utils;
using DataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace BL
{
    /// <summary>
    /// Clase para la Bussiness Layer de la entidad Cargos
    /// </summary>
    public class TiposTelefonosBL
    {
        #region Propiedaeds
        protected DbContextApp _dbContextApp;
        private static CacheManagement cache;
        #endregion

        #region Meétodos

        #region Métodos públicos
        public TiposTelefonosBL()
        {
            cache = new CacheManagement();
        }

        /// <summary>
        /// Método para obtener la lista de los tipo de telefonos
        /// </summary>
        /// <returns> Objecto de la petición </returns>
        public RequestDto GetListTiposTelefonos()
        {
            _dbContextApp = new DbContextApp();
            RequestDto request = new RequestDto();
            string jsonResult = string.Empty;

            try
            {
                if (cache.GetCache("GetListTiposTelefonos") != null)
                {

                    request.RequestStatus = RequestDto.Status.Success;
                    request.Result = cache.GetCache("GetListTiposTelefonos");
                    request.Message = "Consulta realizada correctamente.";

                    return request;
                }

                BaseRepository<tipostelefonos> baseRepository = new BaseRepository<tipostelefonos>(_dbContextApp);
                var getTiposDocumentos = baseRepository.Get();

                var listTiposDocumentos = getTiposDocumentos.ToList()
                                            .Select(i => new
                                            {
                                                Value = i.Tipo_Telefono_Id,
                                                Text = i.Tipo_Telefono
                                            })
                                            .Distinct()
                                            .OrderBy(i => i.Text);
                
                jsonResult = JsonConvert.SerializeObject(listTiposDocumentos, Formatting.Indented);

                cache.SetCache("GetListTiposTelefonos", jsonResult);

                request.RequestStatus = RequestDto.Status.Success;
                request.Result = jsonResult;
                request.Message = "Consulta realizada correctamente.";

            }
            catch (Exception ex)
            {
                request.Exception = ex;
                request.Message = "Ocurrió un error al ejecutar la petición.";
            }
            finally
            {
                _dbContextApp.Dispose();
            }

            return request;
        }

        #endregion

        #endregion

    }
}
