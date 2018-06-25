using System;
using System.Collections.Generic;
using System.Linq;
using Tui.Flights.Domain.Entities;
using Tui.Flights.Domain.Helpers;
using Tui.Flights.Domain.Repositories;

namespace Tui.Flights.Domain.Services
{
    public interface IFlightService
    {
        IList<Flight> GetAll();
        Flight GetById(int id);
        void Create(Flight flight);
        void Update(Flight flight);
        void Delete(int id);
        void AddOrUpdate(Flight flight);
    }

    public class FlightService : IFlightService
    {
        private readonly IRepository<Flight> _flightRepository;
        private readonly IRepository<AirPort> _airportRepository;
        private readonly IRepository<AirCraft> _airCraftRepository;

        public FlightService(IRepository<Flight> flightRepository, IRepository<AirPort> airportRepository, IRepository<AirCraft> airCraftRepository)
        {
            _flightRepository = flightRepository;
            _airportRepository = airportRepository;
            _airCraftRepository = airCraftRepository;
        }

        /// <summary>
        /// Get all flights
        /// </summary>
        /// <returns></returns>
        public IList<Flight> GetAll()
        {
            return _flightRepository
                .GetAll()
                .ToList();
        }

        /// <summary>
        /// Fetch flight by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
            _flightRepository.Create(flight);
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
        public void Delete(int id)
        {
            _flightRepository.Delete(id);
        }

        /// <summary>
        /// Add or update flight
        /// </summary>
        /// <param name="flight"></param>
        public void AddOrUpdate(Flight flight)
        {
            var departureAirport = _airportRepository.GetById(flight.DepartureAirportId);
            var arrivalAirport = _airportRepository.GetById(flight.ArrivalAirportId);
            var airCraft = _airCraftRepository.GetById(flight.AirCraftId);

            flight.Distance = Math.Round(FlightCalculation.GetDistance(departureAirport, arrivalAirport) / 100, 2);
            flight.Duration = Math.Round((flight.Distance / airCraft.AverageSpeed) / 60, 0);
            flight.FuelConsumption = Math.Round((airCraft.FuelConsumptionPerHour * airCraft.TakeOffEffort * 60) / flight.Duration, 2);

            if (flight.Id != 0)
                _flightRepository.Update(flight);
            else
                _flightRepository.Create(flight);
        }

    }
}
