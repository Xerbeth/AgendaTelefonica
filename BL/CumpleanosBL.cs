#region Referencias 
using Common.Models;
using DataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace BL
{
    /// <summary>
    /// Clase para la Bussiness Layer de la vista de cumpleaños
    /// </summary>
    public class CumpleanosBL
    {
        #region Propiedades
        protected DbContextApp _dbContextApp;
        #endregion

        #region Métodos

        #region Métodos públicos 

        public CumpleanosBL()
        {

        }

        /// <summary>
        /// Método para consulytar y generar la información respectiva de la vista cumpleaños
        /// </summary>
        /// <returns></returns>
        public RequestDto GetInfoCumpleanos()
        {
            _dbContextApp = new DbContextApp();
            RequestDto request = new RequestDto();
            string jsonResult = string.Empty;

            try
            {

                BaseRepository<empleados> baseRepositoryEmpleados = new BaseRepository<empleados>(_dbContextApp);
                var getEmpleados = baseRepositoryEmpleados.Get().ToList();

                BaseRepository<tiposdocumentos> baseRepositoryTiposDocumentos = new BaseRepository<tiposdocumentos>(_dbContextApp);
                var getTiposDocumentos = baseRepositoryTiposDocumentos.Get().ToList();

                var infoCumpleanos = from e in getEmpleados
                                     join td in getTiposDocumentos on e.Tipo_Documento_Id equals td.Tipo_Documento_Id
                                     select new
                                     {
                                         Documento = td.Tipo_Documento + " " + e.NumeroDocumento,
                                         Nombre = e.Primer_Nombre + " " + e.Primer_Apellido,
                                         FechaNacimiento = e.Fecha_Nacimiento,
                                         Edad = 0,
                                         ProximoCumpleanos = 0
                                     };

                jsonResult = JsonConvert.SerializeObject(infoCumpleanos, Formatting.Indented);

                List<InfoCumpleanosDto> infoCumpleanosDto = new List<InfoCumpleanosDto>();

                infoCumpleanosDto = JsonConvert.DeserializeObject<List<InfoCumpleanosDto>>(jsonResult);

                foreach (var item in infoCumpleanosDto)
                {
                    item.Edad = this.CalculateAge(item.FechaNacimiento);
                    item.ProximoCumpleanos = this.DaysUntilBirthday(item.FechaNacimiento);
                }


                jsonResult = JsonConvert.SerializeObject(infoCumpleanosDto, Formatting.Indented);

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

        #region Métodos privados

        /// <summary>
        /// Método privado para calcular la edad
        /// </summary>
        /// <param name="fechaNacimiento"> Fecha de nacimiento </param>
        /// <returns> Edad </returns>
        private int CalculateAge(DateTime fechaNacimiento)
        {
            // Obtiene la fecha actual:
            DateTime fechaActual = DateTime.Today;

            // Comprueba que la se haya introducido una fecha válida; si
            // la fecha de nacimiento es mayor a la fecha actual se muestra mensaje
            // de advertencia:
            if (fechaNacimiento > fechaActual)
            {
                Console.WriteLine("La fecha de nacimiento es mayor que la actual.");
                return -1;
            }
            else
            {
                int edad = fechaActual.Year - fechaNacimiento.Year;

                // Comprueba que el mes de la fecha de nacimiento es mayor
                // que el mes de la fecha actual:
                if (fechaNacimiento.Month > fechaActual.Month)
                {
                    --edad;
                }

                return edad;
            }
        }

        /// <summary>
        /// Método para obtener lpos dias hasta el proximo cumpleaños
        /// </summary>
        /// <param name="fechaNacimiento"> fecha de nacieminto </param>
        /// <returns> dias para el cumpleaños </returns>
        private int DaysUntilBirthday(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Now;
            DateTime fechaProximoCumpleaños;

            if (fechaActual.Month < fechaNacimiento.Month)
            {
                fechaProximoCumpleaños = new DateTime(DateTime.Now.Year, fechaNacimiento.Month, fechaNacimiento.Day);
            }
            else if (fechaActual.Month == fechaNacimiento.Month && fechaActual.Day == fechaNacimiento.Day)
            {
                // Hoy es tu cumpleaños
                return 0;
            }
            else
            {
                fechaProximoCumpleaños = new DateTime(DateTime.Now.Year + 1, fechaNacimiento.Month, fechaNacimiento.Day);
            }

            // Diferencia en dias, horas y minutos
            TimeSpan ts = fechaProximoCumpleaños - fechaActual;

            // Diferencia en dias
            return ts.Days;

        }

        #endregion

        #endregion
    }
}
