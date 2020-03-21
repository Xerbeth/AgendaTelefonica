using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class Class1
    {
        static void Main()
        {            
            Console.WriteLine("Hola");
            Console.ReadKey();
        }

        public void entityFramework() {
            Console.WriteLine("Hola");
            Console.ReadKey();
        }

        public void GetTiposDocumentos() {
            using (pruebaAgendaTelefonica db = new pruebaAgendaTelefonica())
            {
                var list = db.tiposdocumentos;

                foreach (var item in list) {
                    Console.WriteLine(item.Descripcion);
                }

                Console.ReadKey();
            }

        }
            
    }
}
