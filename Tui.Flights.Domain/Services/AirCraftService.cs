using System.Collections.Generic;
using System.Linq;
using Tui.Flights.Domain.Entities;
using Tui.Flights.Domain.Repositories;

namespace Tui.Flights.Domain.Services
{
   public interface IAirCraftService
    {
        IList<AirCraft> GetAll();
        AirCraft GetById(int id);
        void Create(AirCraft airCraft);
        void Update(AirCraft airCraft);
        void Delete(int id);
    }

    public class AirCraftService : IAirCraftService
    {
        private readonly IRepository<AirCraft> _airCraftRepository;

        public AirCraftService(IRepository<AirCraft> airCraftRepository)
        {
            _airCraftRepository = airCraftRepository;
        }

        /// <summary>
        /// Get all aircraft
        /// </summary>
        /// <returns></returns>
        public IList<AirCraft> GetAll()
        {
            return _airCraftRepository
                .GetAll()
                .ToList();
        }

        /// <summary>
        /// Get aircraft by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AirCraft GetById(int id)
        {
            return _airCraftRepository.GetById(id);
        }

        /// <summary>
        /// Create an aircraft
        /// </summary>
        /// <param name="airCraft"></param>
        public void Create(AirCraft airCraft)
        {
            _airCraftRepository.Create(airCraft);
        }

        /// <summary>
        /// Update an aircraft
        /// </summary>
        /// <param name="airCraft"></param>
        public void Update(AirCraft airCraft)
        {
            _airCraftRepository.Update(airCraft);
        }

        /// <summary>
        /// Delete an aircraft
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            _airCraftRepository.Delete(id);
        }

    }
}
