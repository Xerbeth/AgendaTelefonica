#region Referencias 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Common.Utils
{
    /// <summary>
    /// Clase para gestionar la cache a nivel del servidor
    /// </summary>
    public class CacheManagement
    {
        #region Propiedaes
        private static ObjectCache cache;
        private CacheItemPolicy policy;
        #endregion

        #region Métodos

        #region Métodos públicos 
        public CacheManagement() 
        {
            cache = MemoryCache.Default;
            policy = new CacheItemPolicy();
            // Duración de la cache 1 minuto
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(1);

        }

        /// <summary>
        /// Método para insertar un item en la cache
        /// </summary>
        public void SetCache(string key, Object value)
        {
            cache.Set(key, value, policy);
        }

        /// <summary>
        /// Método para objtener una 
        /// </summary>
        /// <returns></returns>
        public Object GetCache(string key)
        {
            string fileContents = cache[key] as string;
            if (fileContents == null)
            {
                return null;
            }

            return cache.Get(key);
        }

        /// <summary>
        /// Método para remover de la cache un item
        /// </summary>
        /// <param name="key"> Nombre del item de la cache </param>
        public void RemoveCache(string key) 
        {
            cache.Remove(key);
        }

        #endregion

        #endregion

    }

}
