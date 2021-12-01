using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
using System;
using System.Web.Mvc;
using WebApplication.Areas.Faculty.Controllers;
using System.Collections.Generic;
using WebApplication.Models;
using System.Linq;

namespace WebApplication.Tests.Controllers
{
    [TestClass]
    public class ChuongTrinhDTTest
    {
        //Unit test index nganh
        [TestMethod]
        public void IndexNganhTest()
        {
            ChuongTrinhDaoTaoController controller = new ChuongTrinhDaoTaoController();
            //Return view
            var result = controller.ListNganhDT() as ViewResult;
            Assert.IsNotNull(result);
            //Return list Nganh
            var model = result.Model as List<NganhDaoTao>;
            Assert.IsNotNull(model);
            var db = new Cap24();
            Assert.AreEqual(db.NganhDaoTaos.Count(), model.Count);
        }

        //Unit test create nganh
        [TestMethod]
        public void CreateNganhViewTest()
        {
            var controller = new ChuongTrinhDaoTaoController();

            var result = controller.TaoMoiNganh() as ViewResult;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CreateNganhTest()
        {
            var rand = new Random();
            var nganh = new NganhDaoTao
            {
                Nganh = rand.NextDouble().ToString()

            };
            var controller = new ChuongTrinhDaoTaoController();

            var result = controller.TaoMoiNganh(nganh);

            Assert.IsNotNull(result);
        }
        //[TestMethod]
        //public void CreateNganhNullTest()
        //{
        //    var nganh = new NganhDaoTao
        //    {
        //        Nganh = null
        //    };
        //    var controller = new ChuongTrinhDaoTaoController();

        //    var result = controller.TaoMoiNganh(nganh);

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual("Không được để trống", controller.ModelState["tenNganh"].Errors[0].ErrorMessage);
        //}

        //Unit test Edit nganh
        [TestMethod]
        public void EditNganhViewTest()
        {
            var controller = new ChuongTrinhDaoTaoController();
            var result0 = controller.SuaNganhDT(1) as HttpNotFoundResult;
            Assert.IsNotNull(result0);

            var db = new Cap24();
            var nganh = db.NganhDaoTaos.First();
            var result = controller.SuaNganhDT(nganh.ID) as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as NganhDaoTao;
            Assert.IsNotNull(model);
            Assert.AreEqual(nganh.Nganh, model.Nganh);
        }

        [TestMethod]
        public void EditNganhTest()
        {
            var db = new Cap24();
            var nganh = db.NganhDaoTaos.AsNoTracking().First();
            nganh.Nganh = "y dược";
            var controller = new ChuongTrinhDaoTaoController();
            var result = controller.SuaNganhDT(nganh);
            Assert.IsNotNull(result);
        }
        //Unit test index Khoa
        [TestMethod]
        public void IndexKhoaTest()
        {
            ChuongTrinhDaoTaoController controller = new ChuongTrinhDaoTaoController();
            //Return view
            var result = controller.ListKhoaDT() as ViewResult;
            Assert.IsNotNull(result);
            //Return list khoa
            var model = result.Model as List<KhoaDaoTao>;
            Assert.IsNotNull(model);
            var db = new Cap24();
            Assert.AreEqual(db.KhoaDaoTaos.Count(), model.Count);
        }

        //Unit test create khoa
        [TestMethod]
        public void CreateKhoaViewTest()
        {
            var controller = new ChuongTrinhDaoTaoController();

            var result = controller.TaoMoiKhoa() as ViewResult;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CreateKhoaTest()
        {
            var rand = new Random();
            var khoa = new KhoaDaoTao
            {
                Khoa = rand.NextDouble().ToString()

            };
            var controller = new ChuongTrinhDaoTaoController();

            var result = controller.TaoMoiKhoa(khoa);

            Assert.IsNotNull(result);
        }
        //[TestMethod]
        //public void CreateKhoaNullTest()
        //{
        //    var nganh = new NganhDaoTao
        //    {
        //        Nganh = null
        //    };
        //    var controller = new ChuongTrinhDaoTaoController();

        //    var result = controller.TaoMoiNganh(nganh);

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual("Không được để trống", controller.ModelState["tenNganh"].Errors[0].ErrorMessage);
        //}

        //Unit test Edit nganh
        [TestMethod]
        public void EditKhoaViewTest()
        {
            var controller = new ChuongTrinhDaoTaoController();
            var result0 = controller.SuaKhoaDT(0) as HttpNotFoundResult; //id 1000 chưa có
            Assert.IsNotNull(result0);

            var db = new Cap24();
            var khoa = db.KhoaDaoTaos.First();
            var result = controller.SuaKhoaDT(khoa.ID) as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as KhoaDaoTao;
            Assert.IsNotNull(model);
            Assert.AreEqual(khoa.Khoa, model.Khoa);
        }

        [TestMethod]
        public void EditKhoaTest()
        {
            var db = new Cap24();
            var khoa = db.KhoaDaoTaos.AsNoTracking().First();
            khoa.Khoa = "300";
            var controller = new ChuongTrinhDaoTaoController();
            var result = controller.SuaKhoaDT(khoa);
            Assert.IsNotNull(result);
        }
    }
}
