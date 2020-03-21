using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary3;
using DAL.DB;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Class1 obj = new Class1();
            //obj.entityFramework();

            //obj.GetTiposDocumentos();


            SqlServerAdapter sqlServerAdapter = new SqlServerAdapter();
            sqlServerAdapter.GetConnection();

        }
    }
}
