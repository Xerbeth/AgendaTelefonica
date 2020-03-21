using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaInternal
{
    public class Class1
    {
        public Class1()
        {

        }

        public void MetodoPublico() { Console.WriteLine("Metodo Público"); }

        internal void MetodoInterno() { Console.WriteLine("Metodo Interno"); }
    }
}
