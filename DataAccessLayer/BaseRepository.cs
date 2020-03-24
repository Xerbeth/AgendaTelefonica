#region Referencias 
using Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace DataAccessLayer
{
    /// <summary>
    /// Clase con la implementación generica del repository
    /// </summary>
    /// <typeparam name="TEntity"> Objecto entidad del EF </typeparam>
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DbContextApp context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(DbContextApp context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetWithRawSql(string query,
            params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters).ToList();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual string Insert(TEntity entity)
        {
            try {                
                dbSet.Add(entity);
                context.SaveChanges();

                if (entity is IHasAutoID)
                {
                    return ((IHasAutoID)entity).getAutoId().ToString();
                }
                return "-1";
            }
            catch (Exception e) 
            {
                return e.InnerException.ToString();
            }            
        }

        public virtual string Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            return Delete(entityToDelete);
        }

        public virtual string Delete(TEntity entityToDelete)
        {
            try
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
                context.SaveChanges();
                return true.ToString();
            }
            catch (Exception e)
            {
                return e.InnerException.ToString();
            }            
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

    }
}
