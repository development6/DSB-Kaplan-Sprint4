using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nutrición.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nutrición.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexExiste()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
        

        [TestMethod()]
        public void AjaxMethodTest1()
        {
            HomeController controller = new HomeController();
            var instancia = new HomeController();

            var paciente = instancia.AjaxMethod("16");

            Assert.AreEqual(true, paciente);
        }

        [TestMethod()]
        public void AjaxMethodTestVacio()
        {
            //Arrange
            var instancia = new HomeController();
            //Act
            var paciente = instancia.AjaxMethod(string.Empty);
            //Assert
            Assert.AreEqual(false, paciente);
        }


        [TestMethod()]
        public void AjaxMethodTest2()
        {
            HomeController controller = new HomeController();
            var instancia = new HomeController();

            var paciente = instancia.AjaxMethod("17");

            Assert.IsNotNull(paciente);
        }

        [TestMethod()]
        public void AjaxMethod2Test()
        {
            HomeController controller = new HomeController();
            var instancia = new HomeController();

            var paciente = instancia.AjaxMethod2("Masculino", "5", "HTA-DMIR", "2018--08-29");
            Assert.AreEqual(true, paciente);
        }

        [TestMethod()]
        public void AjaxMethod2Test2()
        {
            HomeController controller = new HomeController();
            var instancia = new HomeController();

            var paciente = instancia.AjaxMethod2("Masculino", "4", "HTA-DMIR", "2018--08-29");
            Assert.AreEqual(true, paciente);
        }

    }
}