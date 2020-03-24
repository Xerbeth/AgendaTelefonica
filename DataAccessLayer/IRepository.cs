#region Referencias 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace DataAccessLayer
{
    /// <summary>
    /// Clase Interface para definir los metodos genericos del repository
    /// </summary>
    /// <typeparam name="TEntity"> Objecto entidad del EF </typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        string Delete(TEntity entityToDelete);
        string Delete(object id);
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TEntity GetByID(object id);
        IEnumerable<TEntity> GetWithRawSql(string query,
            params object[] parameters);
        string Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}
