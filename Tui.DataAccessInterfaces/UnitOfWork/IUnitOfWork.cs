using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tui.BusinessEntities;
using Tui.DataAccessInterfaces.Repositories;

namespace Tui.DataAccessInterfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
         void Dispose();

        void Save();
        IRepository<T> Repository<T>() where T : BaseEntity;

      
        void Dispose(bool disposing);


    }
}
