using System.Linq;
using Tui.Flights.Data.Helpers;
using Tui.Flights.Domain.Entities;
using Tui.Flights.Domain.Repositories;
using NHibernate;
using NHibernate.Linq;
using Tui.Flights.Domain.Helpers;

namespace Tui.Flights.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly UnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork){
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        protected ISession Session => _unitOfWork.Session;

        public IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public T GetById(int id)
        {
            return Session.Get<T>(id);
        }

        public void Create(T entity)
        {
            Session.Save(entity);
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }

        public void Delete(int id)
        {
            Session.Delete(Session.Load<T>(id));
        }
    }
}
