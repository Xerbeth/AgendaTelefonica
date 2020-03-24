#region referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Common.Models
{
    /// <summary>
    /// Clase RequestDto que contiene las propiedades de las peticiones de la aplicación
    /// </summary>
    public class RequestDto
    {
        #region propiedades
        /// <summary>
        /// Enum para los posibles estados de las peticiones 
        /// </summary>
        public enum Status
        {
            Success,
            Failure
        }

        /// <summary>
        /// Estado de la petición 
        /// </summary>
        public Status RequestStatus;
        /// <summary>
        /// Resultado de la petición.
        /// </summary>
        public object Result;
        /// <summary>
        /// Mensaje para el usuraio de la ejecución de la petición
        /// </summary>
        public string Message;
        /// <summary>
        /// Contiene la excepcion cuando ocurré un error
        /// </summary>
        public Exception Exception;
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Método constructor 
        /// </summary>
        public RequestDto() 
        {
            RequestStatus = Status.Failure;
            Result = string.Empty;
            Message = string.Empty;
            Exception = null;
        }
        #endregion
    }
}
