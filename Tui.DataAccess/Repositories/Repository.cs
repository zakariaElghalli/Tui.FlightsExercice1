using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tui.BusinessEntities;
using Tui.DataAccess.Context;
using Tui.DataAccessInterfaces.Repositories;

namespace Tui.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T>  where T  : BaseEntity
    {
        private readonly TuiTestContext _context;
        private IDbSet<T> _entities;
        string _errorMessage = string.Empty;

        public Repository(TuiTestContext context)
        {
            this._context = context;
        }

        public Repository()
        {
            
        }
        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Add(entity);
                this._context.SaveChanges();

}
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(_errorMessage, dbEx);
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw new Exception(_errorMessage, dbEx);
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Remove(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw new Exception(_errorMessage, dbEx);
            }
        }

       

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = Entities;
            return query;
        }


        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }
    }



    //public class Repository<T> : IRepository<T> where T : class
    //{
    //    internal TuiTestContext _context;
    //    internal DbSet<T> dbSet;

    //    public Repository(TuiTestContext context)
    //    {
    //        _context = context;
    //        dbSet = context.Set<T>();
    //    }

    //    public virtual IQueryable<T> GetAll()
    //    {
    //        IQueryable<T> query = dbSet;
    //        return query;
    //    }

    //    public virtual IQueryable<T> Get(Func<T, bool> predicate)
    //    {
    //        return dbSet.Where(predicate).AsQueryable();
    //    }

    //    public virtual IQueryable<T> GetWithIncluds(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties)
    //    {
    //        IQueryable<T> query = dbSet;

    //        if (includeProperties != null)
    //            query = includeProperties.Aggregate(query, (current, include) => current.Include(include));

    //        if (predicate != null)
    //            query = query.Where(predicate).AsQueryable();

    //        return query;
    //    }

    //    public virtual void Insert(T entity)
    //    {
    //        dbSet.Add(entity);
    //    }

    //    public virtual void Delete(T entity)
    //    {
    //        if (_context.Entry(entity).State == EntityState.Detached)
    //            dbSet.Attach(entity);

    //        dbSet.Remove(entity);
    //    }

    //    public virtual void Update(T entityToUpdate)
    //    {
    //        dbSet.Attach(entityToUpdate);
    //        _context.Entry(entityToUpdate).State = EntityState.Modified;
    //    }



    //    public T GetById(int id)
    //    {
    //        return dbSet.Find<T>(id);
    //    }
    //}
}
