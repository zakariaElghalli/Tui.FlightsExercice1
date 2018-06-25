using System.Collections.Generic;
using System.Linq;
using Tui.Flights.Domain.Entities;
using Tui.Flights.Domain.Repositories;

namespace Tui.Flights.Domain.Services
{
    public interface IAirPortService
    {
        IList<AirPort> GetAll();
        AirPort GetById(int id);
        void Create(AirPort airport);
        void Update(AirPort airport);
        void Delete(int id);
    }

    public class AirPortService : IAirPortService
    {
        private readonly IRepository<AirPort> _airportRepository;

        public AirPortService(IRepository<AirPort> airportRepository)
        {
            _airportRepository = airportRepository;
        }

        /// <summary>
        /// Get all airport
        /// </summary>
        /// <returns></returns>
        public IList<AirPort> GetAll()
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
        public AirPort GetById(int id)
        {
            return _airportRepository.GetById(id);
        }

        /// <summary>
        /// Create an airport
        /// </summary>
        /// <param name="airport"></param>
        public void Create(AirPort airport)
        {
            _airportRepository.Create(airport);
        }

        /// <summary>
        /// Update an airport
        /// </summary>
        /// <param name="airport"></param>
        public void Update(AirPort airport)
        {
            _airportRepository.Update(airport);
        }

        /// <summary>
        /// Delete an airport
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            _airportRepository.Delete(id);
        }

    }
}
