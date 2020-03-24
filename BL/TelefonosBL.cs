#region Referencias
using Common.Models;
using Common.Utils;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace BL
{
    /// <summary>
    /// Clase para la Bussiness Layer de la entidad Telefonos
    /// </summary>
    public class TelefonosBL
    {
        #region Propiedades
        protected DbContextApp _dbContextApp;
        private static CacheManagement cache;
        #endregion

        #region Métodos

        #region Métodos públicos

        public TelefonosBL()
        {
            cache = new CacheManagement();
        }

        /// <summary>
        /// Método para agregar un empelado
        /// </summary>
        /// <returns> Objeto de la petición </returns>
        public RequestDto InsertTelefono(telefonos telefonos)
        {
            _dbContextApp = new DbContextApp();
            RequestDto request = new RequestDto();

            try
            {
                BaseRepository<telefonos> baseRepositoryTelefonos= new BaseRepository<telefonos>(_dbContextApp);
                var insertTelefono = baseRepositoryTelefonos.Insert(telefonos);

                if (!Int32.TryParse(insertTelefono, out Int32 result))
                {
                    throw new System.ArgumentException(insertTelefono);
                }

                request.Result = insertTelefono;
                request.RequestStatus = RequestDto.Status.Success;
                request.Message = "Telefono empleado creado satisfactoriamente.";

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

        /// <summary>
        /// Método para eliminar registros en la entidad telefono
        /// </summary>
        /// <param name="Telefono_Id"> Telefono Id </param>
        /// <returns> Objeto de la petición </returns>
        public RequestDto DeleteTelefono(int Telefono_Id)
        {
            _dbContextApp = new DbContextApp();
            RequestDto request = new RequestDto();

            BaseRepository<telefonos> baseRepositoryTelefonos = new BaseRepository<telefonos>(_dbContextApp);
            request.Result = baseRepositoryTelefonos.Delete(Telefono_Id);

            if (!request.Result.Equals(true.ToString()))
            {                
                request.Exception = (Exception)request.Result;
                request.Message = "Ocurrió un error eliminando el registro.";
            }

            request.RequestStatus = RequestDto.Status.Success;
            request.Message = "Registro eliminado satisfactoriamente.";

            return request;
        }


        #endregion

        #endregion

    }
}
