#region Referencias 
using Common.Models;
using Common.Utils;
using DataAccessLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
    public class CargosBL
    {
        #region Propiedades 
        protected DbContextApp _dbContextApp;
        private static CacheManagement cache;
        #endregion

        #region Métodos

        #region Métodos públicos
        public CargosBL()
        {
            cache = new CacheManagement();
        }

        /// <summary>
        /// Método para obtener la lista de los cargos registrados
        /// </summary>
        /// <returns> Objecto de la petición </returns>
        public RequestDto GetListCargos()
        {
            _dbContextApp = new DbContextApp();
            RequestDto request = new RequestDto();
            string jsonResult = string.Empty;

            try
            {
                if (cache.GetCache("GetListCargos") != null)
                {

                    request.RequestStatus = RequestDto.Status.Success;
                    request.Result = cache.GetCache("GetListCargos");
                    request.Message = "Consulta realizada correctamente.";

                    return request;
                }

                BaseRepository<cargos> baseRepository = new BaseRepository<cargos>(_dbContextApp);
                var getTiposDocumentos = baseRepository.Get();

                var listTiposDocumentos = getTiposDocumentos.ToList()
                                            .Select(i => new
                                            {
                                                Value = i.Cargo_Id,
                                                Text = i.Cargo
                                            })
                                            .Distinct()
                                            .OrderBy(i => i.Text);

                jsonResult = JsonConvert.SerializeObject(listTiposDocumentos, Formatting.Indented);

                cache.SetCache("GetListCargos", jsonResult);

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
