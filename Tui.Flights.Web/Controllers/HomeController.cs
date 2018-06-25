using System.Linq;
using System.Web.Mvc;
using Tui.BusinessEntities.Entities;

using Tui.IBusinessLogic.Services;

namespace Tui.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IAirport _airportService;
        private readonly IAirPlane _airplaneService;

        public HomeController(IAirport airportService, IAirPlane airplaneService)
        {
            _airportService = airportService;
            _airplaneService = airplaneService;
        }

        public ActionResult Index()
        {
        
            if (!_airportService.GetAll().Any())
            {
                _airportService.Create(new Airport { NameAirport = "Paris Charles-de-Gaulle",  Latitude = 69.98210702, Longitude = 24.14, AddedDate=System.DateTime.Now ,ModifiedDate= System.DateTime.Now,CityOfAirport= "Paris" });
                _airportService.Create(new Airport { NameAirport = "Paris Orly", Latitude = 68.301, Longitude = 66.006683, AddedDate = System.DateTime.Now, ModifiedDate = System.DateTime.Now, CityOfAirport = "Paris" });
                _airportService.Create(new Airport { NameAirport = "Toulouse Blagnac", Latitude = 28.2414, Longitude = 83.7024029, AddedDate = System.DateTime.Now, ModifiedDate = System.DateTime.Now, CityOfAirport = "Toulouse" });
                _airportService.Create(new Airport { NameAirport = "Lille Lesquin", Latitude = 53.55, Longitude = 10.2414, AddedDate = System.DateTime.Now, ModifiedDate = System.DateTime.Now, CityOfAirport = "Lille" });
            }

       
             if (!_airplaneService.GetAll().Any())
            {
                _airplaneService.Create(new AirPlane { AirPlaneName = "Ford Stout 4-AT-B", Speed = 500, TakeOffEffort = 5.5, Consumption = 85, AddedDate = System.DateTime.Now, ModifiedDate = System.DateTime.Now });
                _airplaneService.Create(new AirPlane { AirPlaneName = "Lockheed 1049", Speed = 600, TakeOffEffort = 5, Consumption = 55, AddedDate = System.DateTime.Now, ModifiedDate = System.DateTime.Now });
                _airplaneService.Create(new AirPlane { AirPlaneName = "DH Comet 1", Speed = 700, TakeOffEffort = 2.5, Consumption = 55, AddedDate = System.DateTime.Now, ModifiedDate = System.DateTime.Now });
                _airplaneService.Create(new AirPlane { AirPlaneName = "Lockheed 149", Speed = 800, TakeOffEffort = 2, Consumption = 20, AddedDate = System.DateTime.Now, ModifiedDate = System.DateTime.Now });
            }            

            return View();
        }
    }
}
