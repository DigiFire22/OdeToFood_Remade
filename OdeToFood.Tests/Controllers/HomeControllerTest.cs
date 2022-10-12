using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFood.Controllers;
using System.Web.Mvc;
using Microsoft.Extensions.Logging;

namespace OdeToFood.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void About()
        {
            //using var logFactory = LoggerFactory.Create(builder =>
            //builder.AddConsole());
            //var logger = logFactory.CreateLogger<HomeController>();
            //HomeController controller = new HomeController(logger);
            //ViewResult result = controller.About() as ViewResult;
            //Assert.IsNotNull(result.Model);
        }
    }
}
