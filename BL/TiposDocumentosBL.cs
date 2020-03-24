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
    /// Clase para la Bussiness Layer de la entidad TiposDocumentos
    /// </summary>
    public class TiposDocumentosBL
    {
        #region Propiedades
        protected DbContextApp _dbContextApp;
        private static CacheManagement cache;
        #endregion

        #region Métodos

        #region Métodos públicos
        public TiposDocumentosBL()
        {
            cache = new CacheManagement();
        }

        /// <summary>
        /// Método para obtener la lista de los tipos de documentos registrados
        /// </summary>
        /// <returns></returns>
        public RequestDto GetListTiposDocumentos()
        {

            _dbContextApp = new DbContextApp();
            RequestDto request = new RequestDto();
            string jsonResult = string.Empty;

            try
            {
                if (cache.GetCache("GetListTiposDocumentos") != null)
                {

                    request.RequestStatus = RequestDto.Status.Success;
                    request.Result = cache.GetCache("GetListTiposDocumentos");
                    request.Message = "Consulta realizada correctamente.";

                    return request;
                }

                BaseRepository<tiposdocumentos> baseRepository = new BaseRepository<tiposdocumentos>(_dbContextApp);
                var getTiposDocumentos = baseRepository.Get();

                var listTiposDocumentos = getTiposDocumentos.ToList()
                                            .Select(i => new
                                            {
                                                Value = i.Tipo_Documento_Id,
                                                Text = i.Descripcion
                                            })
                                            .Distinct()
                                            .OrderBy(i => i.Text);

                jsonResult = JsonConvert.SerializeObject(listTiposDocumentos, Formatting.Indented);

                cache.SetCache("GetListTiposDocumentos", jsonResult);

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
