using System;
using Tui.BusinessEntities.Entities;
using Tui.DataAccessInterfaces.Repositories;
using Tui.DataAccessInterfaces.UnitOfWork;
using Tui.IBusinessLogic.Services;

namespace Tui.BusinessLogic.Services
{

    public class FlightHelpersServices : IFlightHelpersServices
    {
        private readonly IRepository<Airport> _airportRepository;
        private readonly IRepository<AirPlane> _airPlaneRepository;
        private readonly IRepository<Flight> _flightRepository;


        private readonly IUnitOfWork _unitOfWork;





   
     
      


        public FlightHelpersServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _airPlaneRepository = _unitOfWork.Repository<AirPlane>();
            _airportRepository = _unitOfWork.Repository<Airport>();
            _flightRepository = _unitOfWork.Repository<Flight>();
            
        }


     

        public void AddOrUpdate(Flight flight)
        {
            var departureAirport = _airportRepository.GetById(flight.DepartureAirportId);
            var arrivalAirport = _airportRepository.GetById(flight.ArrivalAirportId);
            var airPlane = _airPlaneRepository.GetById(flight.AirPlaneId);

          

            GeoCoordinate gd = new GeoCoordinate();
            GeoCoordinate ga = new GeoCoordinate();

            gd.Latitude = departureAirport.Latitude;
            gd.Longitude = departureAirport.Longitude;

            ga.Latitude = arrivalAirport.Latitude;
            ga.Longitude = arrivalAirport.Longitude;

            var geotool = new GeoCoordinateTool();
            var distance = geotool.Distance(gd, ga, 1);
            flight.Distance = Math.Round(distance, 2);

            flight.Duration = Math.Round((Math.Round(distance, 2) / airPlane.Speed) / 60, 2);
            var consumption = (airPlane.Consumption * airPlane.TakeOffEffort * 60) / flight.Duration;
            flight.FuelConsumption = Math.Round(consumption, 2);
            flight.ModifiedDate = System.DateTime.Now;
            if (flight.Id != 0)
                _flightRepository.Update(flight);
            else {
                flight.AddedDate = System.DateTime.Now;
         
            _flightRepository.Insert(flight);
            }
           
        }

    }
}
