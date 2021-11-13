using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        //Unit test index nganh
        [TestMethod]
        public void IndexNganhTest()
        {
            CurriculumsController controller = new CurriculumsController();
            //Return view
            var result = controller.IndexNganh() as ViewResult;
            Assert.IsNotNull(result);
            //Return list Nganh
            var model = result.Model as List<Nganh>;                      
            Assert.IsNotNull(model);
            var db = new CAPK24Entities();
            Assert.AreEqual(db.Nganhs.Count(), model.Count);
        }

        //Unit test create nganh
        [TestMethod]
        public void CreateNganhViewTest()
        {
            var controller = new CurriculumsController();

            var result = controller.CreateNganh() as ViewResult;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CreateNganhTest()
        {
            var rand = new Random();
            var nganh = new Nganh
            {
                TenNganh = rand.NextDouble().ToString()
                
            };
            var controller = new CurriculumsController();

            var result = controller.CreateNganh(nganh);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CreateNganhNullTest()
        {            
            var nganh = new Nganh
            {
                TenNganh = null
            };
            var controller = new CurriculumsController();

            var result = controller.CreateNganh(nganh);

            Assert.IsNotNull(result);
            Assert.AreEqual("Không được để trống", controller.ModelState["tenNganh"].Errors[0].ErrorMessage);
        }

        //Unit test Edit nganh
        [TestMethod]
        public void EditNganhViewTest()
        {
            var controller = new CurriculumsController();
            var result0 = controller.EditNganh(1000) as HttpNotFoundResult; //id 1000 chưa có
            Assert.IsNotNull(result0);

            var db = new CAPK24Entities();
            var nganh = db.Nganhs.First();
            var result = controller.EditNganh(nganh.ID) as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as Nganh;
            Assert.IsNotNull(model);
            Assert.AreEqual(nganh.TenNganh, model.TenNganh);
        }

        [TestMethod]
        public void EditNganhTest()
        {           
            var db = new CAPK24Entities();
            var nganh = db.Nganhs.AsNoTracking().First();
            nganh.TenNganh = "y dược";
            var controller = new CurriculumsController();
            var result = controller.EditNganh(nganh);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void EditNganhNullTest()
        {
            var db = new CAPK24Entities();
            var nganh = db.Nganhs.AsNoTracking().First();
            nganh.TenNganh = null;
            var controller = new CurriculumsController();
            var result = controller.EditNganh(nganh);
            Assert.IsNotNull(result);
            Assert.AreEqual("Không được để trống", controller.ModelState["tenNganh"].Errors[0].ErrorMessage);
        }

        //Unit test delete nganh
        [TestMethod]
        public void DeleteNganhView()
        {
            var db = new CAPK24Entities();
            var nganh = db.Nganhs.AsNoTracking().First();

            var controller = new CurriculumsController();

            var result = controller.DeleteNganh(nganh.ID);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void DeleteNganh()
        {
            var db = new CAPK24Entities();
            var nganh = db.Nganhs.AsNoTracking().First();

            var controller = new CurriculumsController();

            var result = controller.DeleteNganhConfirmed(nganh.ID);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestDispose()
        {
            using (var controller = new CurriculumsController()) { }
        }
    }
}
