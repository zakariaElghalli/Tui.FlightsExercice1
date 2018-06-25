using System.Collections.Generic;
using System.Linq;
using Tui.BusinessEntities.Entities;
using Tui.DataAccessInterfaces.Repositories;
using Tui.DataAccessInterfaces.UnitOfWork;
using Tui.IBusinessLogic.Services;

namespace Tui.BusinessLogic.Services
{


    public class AirPlaneService : IAirPlane
    {
        private readonly IRepository<AirPlane> _airPlaneRepository;
        private readonly IUnitOfWork _unitOfWork;

       

        public AirPlaneService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _airPlaneRepository = _unitOfWork.Repository<AirPlane>();
        }

    
        public IList<AirPlane> GetAll()
        {

            return _airPlaneRepository
                .GetAll()
                .ToList();
        }

    
        public AirPlane GetById(int id)
        {
            return _airPlaneRepository.GetById(id);
        }

        public void Create(AirPlane airPlane)
        {
            _airPlaneRepository.Insert(airPlane);
        }

       
        public void Update(AirPlane airPlane)
        {
            _airPlaneRepository.Update(airPlane);
        }

        
        public void Delete(AirPlane airPlane)
        {
            _airPlaneRepository.Delete(airPlane);
        }

    }
}
