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
    /// Clase InfoCumpleanosDto que contiene las propiedades para la información de los cumpleaños de los empleados
    /// </summary>
    public class InfoCumpleanosDto
    {

        public InfoCumpleanosDto(){}
        public string Documento { get; set; }
        public string Nombre{ get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public int ProximoCumpleanos { get; set; }

    }
}
