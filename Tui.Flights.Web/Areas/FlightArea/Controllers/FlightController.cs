using System;
using System.Collections.Generic;
using System.Web.Mvc;

using System.Linq;
using AutoMapper;

using Tui.Presentation.Models;
using Tui.IBusinessLogic.Services;

using Tui.Presentation.Controllers;
using Tui.BusinessEntities.Entities;

namespace Tui.Flights.Web.Areas.FlightArea.Controllers
{
    public class FlightController : BaseController

    {
        private readonly IFlight _flightService;
        private readonly IAirPlane _airPlaneService;

        private readonly IAirport _airportService;

        private readonly IFlightHelpersServices _flightHelpersServices;

        public FlightController(IFlight flightService, IAirport airportService, IAirPlane airPlaneService, IFlightHelpersServices flightHelpersServices)
        {
            _airportService = airportService;
            _airPlaneService = airPlaneService;
            _flightService = flightService;
            _flightHelpersServices = flightHelpersServices;
        }


        public ActionResult add()
        {


            FlightViewModel flightViewModel = new FlightViewModel();


            SetAirPortPlaneListInFlights(flightViewModel);

            return View(flightViewModel);
        }


        public ActionResult Edit(int id)
        {
            var flight = Mapper.Map<FlightViewModel>(_flightService.GetById(id));

            SetAirPortPlaneListInFlights(flight);



            return View(flight);
        }

        public ActionResult Delete (int id)
        {
            var flight = Mapper.Map<FlightViewModel>(_flightService.GetById(id));

            SetAirPortPlaneListInFlights(flight);



            return View(flight);
        }


        public ActionResult deleteflight(FlightViewModel flight)
        {
            try
            {

                var flightDelete = _flightService.GetById(flight.Id);
                _flightService.Delete(flightDelete);


                return Json(new { valid = true });
        }
            catch (Exception ex)
            {

                return Json(new { valid = false, message = ex.Message
    });
            }



        }




        public ActionResult index()
        {
            var flights = Mapper.Map<List<FlightViewModel>>(_flightService.GetAll());
            SetAirPortPlaneNamesInFlights(flights);

            return View(flights);
        }

        [HttpPost]
        public ActionResult AddOrUpdateflight(FlightViewModel flight)
        {
            try
            {

                if (ModelState.IsValid)
                {


                    _flightHelpersServices.AddOrUpdate(Mapper.Map<Tui.BusinessEntities.Entities.Flight>(flight));
                    return Json(new { valid = true });

                }
                else
                {
                    var errors = ModelState.Select(x => x.Value.Errors)
                           .FirstOrDefault(y => y.Count > 0);

                    throw new Exception(errors[0].ErrorMessage);

                }
            }
            catch (Exception ex)
            {

                return Json(new { valid = false, message = ex.Message });
            }
        }

        #region Helper


        private void SetAirPortPlaneNamesInFlights(List<FlightViewModel> flights)
        {

            var airports = _airportService.GetAll();
            var aircrafts = _airPlaneService.GetAll();
            foreach (var flight in flights)
            {
                flight.DeparturAirport = airports.FirstOrDefault(i => i.Id == flight.DepartureAirportId)?.NameAirport;
                flight.ArrivalAirport = airports.FirstOrDefault(i => i.Id == flight.ArrivalAirportId)?.NameAirport;
                flight.AirPlaine = aircrafts.FirstOrDefault(i => i.Id == flight.AirPlaneId)?.AirPlaneName;
            }
        }

        private void SetAirPortPlaneListInFlights(FlightViewModel flight)
        {


            var aeroports = Mapper.Map<List<AirPortViewModel>>(_airportService.GetAll());
            var airplanes = Mapper.Map<List<AirPlaneViewModel>>(_airPlaneService.GetAll());


            flight.ArrivalAeroports = aeroports;
            flight.DeparturAeroports = aeroports;
            flight.AirPlanes = airplanes;
        }


        #endregion
    }
}