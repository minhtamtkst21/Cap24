using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using WebApplication.Areas.Faculty.Controllers;
using System.Collections.Generic;
using WebApplication.Models;
using System.Linq;

namespace WebApplication.Tests.Controllers
{
    [TestClass]
    public class CurriculumManagementTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            CurriculumsController controller = new CurriculumsController();
            // Act
            var result = controller.IndexNganh() as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as List<Nganh>;                      
            Assert.IsNotNull(model);

            var db = new CAPK24Entities();
            Assert.AreEqual(db.Nganhs.Count(), model.Count);
        }
    }
}
