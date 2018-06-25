using System.Collections.Generic;
using System.Linq;
using Tui.BusinessEntities.Entities;


namespace Tui.IBusinessLogic.Services
{
    public interface IAirport
    {
        IList<Airport> GetAll();
        Airport GetById(int id);
        void Create(Airport airport);
        void Update(Airport airport);
        void Delete(Airport airport);
    }

    
}
