using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.DB
{
    public class SqlServerAdapter : IDBAdapter
    {
        private ContextSqlServer db;
        public SqlServerAdapter() {
            db = new ContextSqlServer();
        }

        public Object GetConnection()
        {            
            return db;
        }

        public bool CloseConnection()
        {
            try {
                db.Dispose();
                Console.WriteLine("Conexión cerrada.");
                return true;
            }
            catch (Exception e) {
                Console.WriteLine("Error al cerrar la conexión. " + e.StackTrace);
                return false;
            }
            
        }

        public String getConnectionString() {
            return "";
        }
    }
}
