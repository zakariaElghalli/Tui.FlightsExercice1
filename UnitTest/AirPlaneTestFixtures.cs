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
    public class AirPlaneTestFixtures
    {
    


        private  IUnitOfWork _unitOfWork;

        [TestMethod]
        public void GetAllTestFixture()
        {
            //Create a mock object of a Flight class 
 
            var mockAirPlane = new Mock<IAirPlane>();


            //Configure dummy method so that it return true when it gets any string as parameters to the method

            mockAirPlane.Setup(r => r.GetAll()).Returns(new List<AirPlane>());

            IAirPlane airPlaneServices = new AirPlaneService(_unitOfWork);

            var result = airPlaneServices.GetAll();
            //Verify the result is what is expected
            Assert.IsTrue(result.Count > 0);

            //Verify that our mock has been called
            mockAirPlane.Verify(m => m.GetAll());
        }


        [TestMethod]
        public void GetByIdTestFixture()
        {
            //Create a mock object of a Flight class 

            var mockAirPlane = new Mock<IAirPlane>();


            //Configure dummy method so that it return true when it gets any string as parameters to the method

            mockAirPlane.Setup(r => r.GetById(0)).Returns(new AirPlane());

            IAirPlane airplaneServices = new AirPlaneService(_unitOfWork);

            var result = airplaneServices.GetById(0);
            //Verify the result is what is expected
            Assert.IsTrue(result!= null);

            //Verify that our mock has been called
            mockAirPlane.Verify(m => m.GetById(0));



       
        }






    }
}
