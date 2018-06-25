using System;
using System.Collections.Generic;
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
    public class FlightServicesTestFixtures
    {
    


        private  IUnitOfWork _unitOfWork;


        [TestMethod]
        public void CreateTestFixture()
        {
            //Create a mock object of a Flight class 
            var mockFlight = new Mock<Flight>();
            var mockFlightServices = new Mock<IFlight>();

            //Mock the properties of mockFlight
            mockFlight.SetupProperty(client => client.Id, 1)
                .SetupProperty(client => client.AirPlaneId, 1)
                .SetupProperty(client => client.ArrivalAirportId, 1)
                .SetupProperty(client => client.DepartureAirportId, 1)
                .SetupProperty(client => client.AddedDate, System.DateTime.Now)
                .SetupProperty(client => client.ModifiedDate, System.DateTime.Now); ;

            //Configure dummy method so that it return true when it gets any string as parameters to the method

            mockFlightServices.Setup(r => r.Create(It.IsAny<Flight>())).Throws(new Exception("TestException"));

            IFlight FlightHelpersServices = new FlightService(_unitOfWork);

            //Use the mock object of FlightHelpersServices instead of actual object
            FlightHelpersServices.Create(mockFlight.Object);

            //Verify that it return true


            //Verify that the mockFlightHelpersServices AddOrUpdate methods gets called exactly once when Flight is passed as parameters
            mockFlightServices.Verify(client => client.Create(It.IsAny<Flight>()));
        }


        [TestMethod]
        public void GetAllTestFixture()
        {
            //Create a mock object of a Flight class 
            var mockFlight = new Mock<Flight>();
            var mockFlightServices = new Mock<IFlight>();

           
            //Configure dummy method so that it return true when it gets any string as parameters to the method

            mockFlightServices.Setup(r => r.GetAll()).Returns(new List<Flight>());

            IFlight FlightHelpersServices = new FlightService(_unitOfWork);

            var result = FlightHelpersServices.GetAll();
            //Verify the result is what is expected
            Assert.IsTrue(result.Count>0);

            //Verify that our mock has been called
            mockFlightServices.Verify(m => m.GetAll());
        }


        [TestMethod]
        public void GetByIdTestFixture()
        {
            //Create a mock object of a Flight class 
            var mockFlight = new Mock<Flight>();
            var mockFlightServices = new Mock<IFlight>();


            //Configure dummy method so that it return true when it gets any string as parameters to the method

            mockFlightServices.Setup(r => r.GetById(It.IsAny<int>())).Returns(new Flight());

            IFlight FlightHelpersServices = new FlightService(_unitOfWork);

            var result = FlightHelpersServices.GetById(1);
            //Verify the result is what is expected
            Assert.IsTrue(result!= null);

            //Verify that our mock has been called
            mockFlightServices.Verify(m => m.GetById(1));
        }
    }
}
