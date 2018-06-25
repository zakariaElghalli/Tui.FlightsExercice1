using System;
using System.Collections.Generic;
using System.Linq;
using Tui.BusinessEntities.Entities;

namespace Tui.IBusinessLogic.Services
{
    public interface IFlight
    {
        IList<Flight> GetAll();
        Flight GetById(int id);
        void Create(Flight flight);
        void Update(Flight flight);
        void Delete(Flight flight);
        
    }


}
