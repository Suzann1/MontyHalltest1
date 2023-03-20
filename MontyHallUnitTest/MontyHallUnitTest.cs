using Microsoft.VisualStudio.TestTools.UnitTesting;
using MontyHall.Controllers;
using System;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;

namespace MontyHallUnitTest
{
    [TestClass]
    public class MontyHallUnitTest
    {
        [TestMethod]
        public void Get_OK_Result()
        {
            //Arrange
            MontyHallController montyHallController = GetMontyHallController();            
            //Act
            var result = montyHallController.Get(2000, 0);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result,typeof(OkNegotiatedContentResult<MontyHall.Models.WinLoose>));
        }

        [TestMethod]
        public void Get_OK_Result_When_Simulations_Is_Negative()
        {
            //Arrange
            MontyHallController montyHallController = GetMontyHallController();
            //Act
            var result = montyHallController.Get(-1, 0);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<MontyHall.Models.WinLoose>));
        }

        public MontyHallController GetMontyHallController()
        { 
            return new MontyHallController();
        }
    }
}
