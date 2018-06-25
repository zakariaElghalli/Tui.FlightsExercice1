using System.Collections.Generic;
using System.Linq;
using Tui.BusinessEntities.Entities;
using Tui.DataAccessInterfaces.Repositories;
using Tui.DataAccessInterfaces.UnitOfWork;
using Tui.IBusinessLogic.Services;

namespace Tui.BusinessLogic.Services
{


    public class AirportService : IAirport
    {
        private readonly IRepository<Airport> _airportRepository;
        private readonly IUnitOfWork _unitOfWork;



        

        public AirportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _airportRepository = _unitOfWork.Repository<Airport>();
        }

       
        public IList<Airport> GetAll()
        {
            return _airportRepository
                .GetAll()
                .ToList();
        }

        /// <summary>
        /// Get airport by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Airport GetById(int id)
        {
            return _airportRepository.GetById(id);
        }

        /// <summary>
        /// Create an airport
        /// </summary>
        /// <param name="airport"></param>
        public void Create(Airport airport)
        {
            _airportRepository.Insert(airport);
        }

        /// <summary>
        /// Update an airport
        /// </summary>
        /// <param name="airport"></param>
        public void Update(Airport airport)
        {
            _airportRepository.Update(airport);
        }

        /// <summary>
        /// Delete an airport
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Airport airport)
        {
            _airportRepository.Delete(airport);
        }

    }
}
