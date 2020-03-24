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
    /// Clase para la Bussiness Layer de la entidad Empleados
    /// </summary>
    public class EmpleadosBL
    {
        #region Propiedades
        protected DbContextApp _dbContextApp;
        private static CacheManagement cache;
        #endregion

        #region Métodos

        #region Métodos públicos 
        public EmpleadosBL() 
        {
            cache = new CacheManagement();
        }

        /// <summary>
        /// Método para consultar la lista de empleados para el combo de jefes
        /// </summary>
        /// <returns> Objeto de la petición </returns>s
        public RequestDto GetListJefes()
        {

            _dbContextApp = new DbContextApp();
            RequestDto request = new RequestDto();
            string jsonResult = string.Empty;

            try
            {

                BaseRepository<empleados> baseRepositoryEmpleados = new BaseRepository<empleados>(_dbContextApp);
                var getEmpleados = baseRepositoryEmpleados.Get().ToList();

                BaseRepository<cargos> baseRepositoryCargos = new BaseRepository<cargos>(_dbContextApp);
                var getCargos    = baseRepositoryCargos.Get().ToList();

                var listTiposDocumentos =   from e in getEmpleados
                                            join c in getCargos on e.Cargo_Id equals c.Cargo_Id
                                            select new
                                            {
                                                Value = e.Empleado_Id,
                                                Text = e.Primer_Nombre + " " + e.Primer_Apellido + " - " + c.Cargo
                                            };

                jsonResult = JsonConvert.SerializeObject(listTiposDocumentos, Formatting.Indented);

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

        /// <summary>
        /// Método para agregar un empelado
        /// </summary>
        /// <returns> Objeto de la petición </returns>
        public RequestDto InsertEmpleado(EmpleadoDto empleadoDto)
        {
            _dbContextApp = new DbContextApp();
            RequestDto request = new RequestDto();
            TelefonosBL telefonosBL = new TelefonosBL();
            telefonos telefonos = new telefonos();            

            empleados empleados = new empleados();
            empleados.Empleado_Id = 0;
            empleados.Cargo_Id = empleadoDto.Cargo_Id;
            empleados.Fecha_Nacimiento = empleadoDto.Fecha_Nacimiento;
            empleados.Jefe = empleadoDto.Jefe;
            empleados.NumeroDocumento = empleadoDto.NumeroDocumento;
            empleados.Primer_Nombre = empleadoDto.Primer_Nombre;
            empleados.Segundo_Nombre = empleadoDto.Segundo_Nombre;
            empleados.Primer_Apellido = empleadoDto.Primer_Apellido;
            empleados.Segundo_Apellido = empleadoDto.Segundo_Apellido;
            empleados.Salario = empleadoDto.Salario;
            empleados.Tipo_Documento_Id = empleadoDto.Tipo_Documento_Id;

            try
            {                
                BaseRepository<empleados> baseRepositoryEmpleados = new BaseRepository<empleados>(_dbContextApp);
                var insertEmpleado = baseRepositoryEmpleados.Insert(empleados);

                if (!Int32.TryParse(insertEmpleado, out Int32 result)) {
                    throw new System.ArgumentException(insertEmpleado);
                }

                telefonos.Empleado_Id = Int32.Parse(insertEmpleado);
                telefonos.Tipo_Telefono_Id = empleadoDto.Telefono_Id;
                telefonos.NumeroTelefonico = empleadoDto.NumeroTelefonico;

                request = telefonosBL.InsertTelefono(telefonos);

                if (request.RequestStatus == RequestDto.Status.Failure)
                {
                    throw new System.ArgumentException(request.Exception.ToString());
                }

                request.Result = insertEmpleado;
                request.RequestStatus = RequestDto.Status.Success;
                request.Message = "Empleado creado satisfactoriamente.";

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
        /// Método para obtener la informacion de los empleados para el grid
        /// </summary>
        /// <returns> Objeto de la petición </returns>
        public RequestDto GetInfoEmpleados()
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

                BaseRepository<cargos> baseRepositoryCargos = new BaseRepository<cargos>(_dbContextApp);
                var getCargos = baseRepositoryCargos.Get().ToList();

                var getJefes = getEmpleados;

                BaseRepository<telefonos> baseRepositoryTelefonos = new BaseRepository<telefonos>(_dbContextApp);
                var getTelefonos = baseRepositoryTelefonos.Get().ToList();

                BaseRepository<tipostelefonos> baseRepositoryTiposTelefonos = new BaseRepository<tipostelefonos>(_dbContextApp);
                var getTiposTelefonos = baseRepositoryTiposTelefonos.Get().ToList();

                var infoEmpleados = from e in getEmpleados
                                    join td in getTiposDocumentos on e.Tipo_Documento_Id equals td.Tipo_Documento_Id
                                    join c in getCargos on e.Cargo_Id equals c.Cargo_Id
                                    join j in getJefes on e.Jefe equals j.Empleado_Id into jl
                                        from j in jl.DefaultIfEmpty()
                                    join t in getTelefonos on e.Empleado_Id equals t.Empleado_Id into tl
                                        from t in tl.DefaultIfEmpty()
                                    select new
                                    {
                                        Empleado_Id = e.Empleado_Id,
                                        Documento = td.Tipo_Documento + " " +e.NumeroDocumento, 
                                        Nombre = e.Primer_Nombre + " " + e.Primer_Apellido,
                                        Telefono_Id = t == null ? 0 : t.Telefono_Id,
                                        Telefono = t == null ? "" : t.NumeroTelefonico,
                                        Cargo = c.Cargo,
                                        Salario = e.Salario == null ? 0 : e.Salario,
                                        Jefe = j == null ? "" : j.Primer_Nombre + " " + j.Primer_Apellido
                                    };
                
                jsonResult = JsonConvert.SerializeObject(infoEmpleados, Formatting.Indented);                                   

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

        /// <summary>
        /// Método para eliminar la informacion de un empleado
        /// </summary>
        /// <returns> Objeto de la petición </returns>
        public RequestDto DeleteEmpleado(int Empleado_Id, int Telefono_Id = 0)
        {
            _dbContextApp = new DbContextApp();
            RequestDto request = new RequestDto();
            TelefonosBL telefonosBL = new TelefonosBL();

            if (Telefono_Id != 0) {
                request = telefonosBL.DeleteTelefono(Telefono_Id);

                if (!request.Result.Equals(true.ToString()))
                {
                    return request;
                }
            }                

            BaseRepository<empleados> baseRepositoryEmpleados = new BaseRepository<empleados>(_dbContextApp);
            request.Result = baseRepositoryEmpleados.Delete(Empleado_Id);

            if (!request.Result.Equals(true.ToString()))
            {
                request.Result = false;
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
