using System;
using System.Collections.Generic;
using System.Linq;
using Tui.BusinessEntities.Entities;
using Tui.DataAccessInterfaces.Repositories;
using Tui.DataAccessInterfaces.UnitOfWork;
using Tui.IBusinessLogic.Services;

namespace Tui.BusinessLogic.Services
{

    public class FlightService : IFlight
    {
        private readonly IUnitOfWork _unitOfWork;
  
        private readonly IRepository<Flight> _flightRepository;



  

        public FlightService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _flightRepository  = _unitOfWork.Repository<Flight>() ;
            
           
        }

       
        public IList<Flight> GetAll()
        {
            return _flightRepository
                .GetAll()
                .ToList();
        }

       
        public Flight GetById(int id)
        {
            return _flightRepository.GetById(id);
        }

        /// <summary>
        /// Create flight
        /// </summary>
        /// <param name="flight"></param>
        public void Create(Flight flight)
        {
            _flightRepository.Insert(flight);
        }

        /// <summary>
        /// Update flight
        /// </summary>
        /// <param name="flight"></param>
        public void Update(Flight flight)
        {
            _flightRepository.Update(flight);
        }

        /// <summary>
        /// Delete a flight
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Flight flight)
        {
            _flightRepository.Delete(flight);
        }

        /// <summary>
        /// Add or update flight
        /// </summary>
        /// <param name="flight"></param>
        

    }
}
