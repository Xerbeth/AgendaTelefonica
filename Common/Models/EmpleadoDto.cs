#region Referencias 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Common.Models
{
    /// <summary>
    /// Clase EmpleadoDto para registrar un empleado sin exponer la entidad de la base de datos
    /// </summary>
    public class EmpleadoDto
    {
        public EmpleadoDto()
        {
            Fecha_Registro = DateTime.Now;
        }

        public int Empleado_Id { get; set; }

        public int Cargo_Id { get; set; }

        public int Tipo_Documento_Id { get; set; }

        [Required]
        [StringLength(15)]
        public string NumeroDocumento { get; set; }

        [Required]
        [StringLength(20)]
        public string Primer_Nombre { get; set; }

        [StringLength(20)]
        public string Segundo_Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string Primer_Apellido { get; set; }

        [StringLength(20)]
        public string Segundo_Apellido { get; set; }

        public DateTime Fecha_Nacimiento { get; set; }

        public int? Salario { get; set; }

        public int? Jefe { get; set; }

        public int Telefono_Id { get; set; }

        public string NumeroTelefonico { get; set; }

        public DateTime? Fecha_Registro { get; set; }

    }
}
