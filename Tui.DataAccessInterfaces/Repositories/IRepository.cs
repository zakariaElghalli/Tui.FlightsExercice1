using System;
using System.Linq;
using Tui.BusinessEntities;

namespace Tui.DataAccessInterfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);


         void Insert(T entity);


        void Update(T entity);

         void Delete(T entity);

      

        IQueryable<T> Table { get; }


        IQueryable<T> GetAll();

    }
    //public interface IRepository<T> where T : class
    //{
    //    IQueryable<T> GetAll();
    //    T GetById(int id);
    //    IQueryable<T> Get(Func<T, bool> predicate);
    //    IQueryable<T> GetWithIncluds(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);
    //    void Insert(T entity);
    //    void Delete(T entity);
    //    void Update(T entity);
    //}
}
