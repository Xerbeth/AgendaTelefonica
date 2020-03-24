#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Common.Models
{
    /// <summary>
    /// Clase para el grid de la vista Agenda
    /// </summary>
    public class InfoEmpleadosDto
    {

        public InfoEmpleadosDto() { }

        public int Empleado_Id { get; set; }

        public int Telefono_Id { get; set; }

        public string Documento { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Cargo { get; set; }

        public string Salario { get; set; }

        public string Jefe { get; set; }
    }
}
