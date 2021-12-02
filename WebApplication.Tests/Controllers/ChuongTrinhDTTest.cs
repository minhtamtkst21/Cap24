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
            var result0 = controller.SuaNganhDT(1000) as HttpNotFoundResult; //Hoc phan thu tu 1000 chua co
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

        //Unit test delete nganh
        [TestMethod]
        public void DeleteNganhView()
        {
            var db = new Cap24();
            var nganh = db.NganhDaoTaos.AsNoTracking().First();

            var controller = new ChuongTrinhDaoTaoController();

            var result = controller.XoaNganhDT(nganh.ID);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void DeleteNganh()
        {
            var db = new Cap24();
            var nganh = db.NganhDaoTaos.AsNoTracking().First();

            var controller = new ChuongTrinhDaoTaoController();

            var result = controller.XacNhanXoaNganhDT(nganh.ID);
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

        //Unit test create Khoa
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

        //Unit test Edit khoa
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
        //Unit test delete khoa
        [TestMethod]
        public void DeleteKhoaView()
        {
            var db = new Cap24();
            var khoa = db.KhoaDaoTaos.AsNoTracking().First();

            var controller = new ChuongTrinhDaoTaoController();

            var result = controller.XoaKhoaDT(khoa.ID);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void DeleteKhoa()
        {
            var db = new Cap24();
            var khoa = db.KhoaDaoTaos.AsNoTracking().First();

            var controller = new ChuongTrinhDaoTaoController();

            var result = controller.XacNhanXoaKhoaDT(khoa.ID);
            Assert.IsNotNull(result);
        }

        //Unit test index hoc ky
        [TestMethod]
        public void IndexHocKyTest()
        {
            ChuongTrinhDaoTaoController controller = new ChuongTrinhDaoTaoController();
            //Return view
            var result = controller.ListHocKyDT() as ViewResult;
            Assert.IsNotNull(result);
            //Return list khoa
            var model = result.Model as List<HocKyDaoTao>;
            Assert.IsNotNull(model);
            var db = new Cap24();
            Assert.AreEqual(db.HocKyDaoTaos.Count(), model.Count);
        }

        //Unit test create hoc ky
        [TestMethod]
        public void CreateHocKyViewTest()
        {
            var controller = new ChuongTrinhDaoTaoController();

            var result = controller.TaoMoiHocKy() as ViewResult;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CreateHocKyTest()
        {
            var rand = new Random();
            var HK = new HocKyDaoTao
            {
                HocKy = rand.Next()

            };
            var controller = new ChuongTrinhDaoTaoController();

            var result = controller.TaoMoiHocKy(HK);

            Assert.IsNotNull(result);
        }
        //Unit test Edit hoc ky
        [TestMethod]
        public void EditHocKyViewTest()
        {
            var controller = new ChuongTrinhDaoTaoController();
            var result0 = controller.SuaHocKyDT(1000) as HttpNotFoundResult; //id 1000 chưa có
            Assert.IsNotNull(result0);

            var db = new Cap24();
            var HK = db.HocKyDaoTaos.First();
            var result = controller.SuaHocKyDT(HK.ID) as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as HocKyDaoTao;
            Assert.IsNotNull(model);
            Assert.AreEqual(HK.HocKy, model.HocKy);
        }

        [TestMethod]
        public void EditHocKyTest()
        {
            var db = new Cap24();
            var HK = db.HocKyDaoTaos.AsNoTracking().First();
            HK.HocKy = 3000;
            var controller = new ChuongTrinhDaoTaoController();
            var result = controller.SuaHocKyDT(HK);
            Assert.IsNotNull(result);
        }
        //Unit test delete hoc ky
        [TestMethod]
        public void DeleteHocKyView()
        {
            var db = new Cap24();
            var HK = db.HocKyDaoTaos.AsNoTracking().First();

            var controller = new ChuongTrinhDaoTaoController();

            var result = controller.XoaHocKyDT(HK.ID);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void DeleteHocKy()
        {
            var db = new Cap24();
            var HK = db.HocKyDaoTaos.AsNoTracking().First();

            var controller = new ChuongTrinhDaoTaoController();

            var result = controller.XacNhanXoaHocKyDT(HK.ID);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestDispose()
        {
            using (var controller = new ChuongTrinhDaoTaoController()) { }
        }
    }
}
