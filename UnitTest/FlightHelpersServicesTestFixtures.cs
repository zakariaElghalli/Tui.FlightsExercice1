using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tui.BusinessEntities.Entities;
using Tui.BusinessLogic.Services;
using Tui.DataAccessInterfaces.Repositories;
using Tui.DataAccessInterfaces.UnitOfWork;
using Tui.IBusinessLogic.Services;

namespace Tui.UnitTest
{
    [TestClass]
    public class FlightHelpersServicesTestFixtures
    {
    


        private  IUnitOfWork _unitOfWork;


        [TestMethod]
        public void AddOrUpdateTestFixture()
        {
            //Create a mock object of a Flight class 
            var mockFlight = new Mock<Flight>();
            var mockFlightHelpersServices = new Mock<IFlightHelpersServices>();

            //Mock the properties of mockFlight
            mockFlight.SetupProperty(client => client.Id, 1)
                .SetupProperty(client => client.AirPlaneId, 1)
                .SetupProperty(client => client.ArrivalAirportId, 1)
                .SetupProperty(client => client.DepartureAirportId, 1)
                .SetupProperty(client => client.AddedDate, System.DateTime.Now)
                .SetupProperty(client => client.ModifiedDate, System.DateTime.Now); ;

            //Configure dummy method so that it return true when it gets any string as parameters to the method

            mockFlightHelpersServices.Setup(r => r.AddOrUpdate(It.IsAny<Flight>())).Throws(new Exception("TestException"));

            IFlightHelpersServices FlightHelpersServices = new FlightHelpersServices(_unitOfWork);

            //Use the mock object of FlightHelpersServices instead of actual object
            FlightHelpersServices.AddOrUpdate(mockFlight.Object);

            //Verify that it return true


            //Verify that the mockFlightHelpersServices AddOrUpdate methods gets called exactly once when Flight is passed as parameters
            mockFlightHelpersServices.Verify(client => client.AddOrUpdate(It.IsAny<Flight>()));
        }



      


    }
}
