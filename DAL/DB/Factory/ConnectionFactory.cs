using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB.Factory
{
    public class ConnectionFactory
    {

        enum DataBases
        {
            None,
            Trivial,
            Regular,
            Important,
            Critical
        }

        //public IDBAdapter GetConnection(string connectionString)
        //{

        //}
    }
}
