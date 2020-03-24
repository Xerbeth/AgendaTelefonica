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
    /// Clase ListDto para transportar la información de las listas 
    /// </summary>
    public class ListDto
    {

        public ListDto()
        {

        }

        public int Value { get; set; }

        public string Text { get; set; }

    }
}
