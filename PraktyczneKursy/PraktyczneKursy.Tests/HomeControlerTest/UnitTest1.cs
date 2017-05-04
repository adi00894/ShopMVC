using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PraktyczneKursy.Controllers;

namespace PraktyczneKursy.Tests.HomeControlerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            var result = controller.Index() as ViewResult;
            // Assert
            Assert.AreEqual("Index",result.ViewName);

        }
    }
}
