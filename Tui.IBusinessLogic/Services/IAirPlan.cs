using System.Collections.Generic;
using System.Linq;
using Tui.BusinessEntities.Entities;

namespace  Tui.IBusinessLogic.Services
{
    public interface IAirPlane
    {
        IList<AirPlane> GetAll();
        AirPlane GetById(int id);
        void Create(AirPlane airPlane);
        void Update(AirPlane airPlane);
        void Delete(AirPlane airPlane);
    }

  
    
}
