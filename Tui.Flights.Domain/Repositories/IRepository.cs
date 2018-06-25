using System.Linq;
using Tui.Flights.Domain.Entities;

namespace Tui.Flights.Domain.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
