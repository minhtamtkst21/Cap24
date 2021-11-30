using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Areas.Faculty.Controllers
{
    public class ChuongTrinhDaoTaoController : Controller
    {
        private Cap24 db = new Cap24();

        public ActionResult ListKhoaDT()
        {
            return View(db.KhoaDaoTaos.ToList());
        }

        public ActionResult TaoMoiKhoa()
        {
            return View();
        }
        // POST: Faculty/Nganh/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoMoiKhoa(KhoaDaoTao khoaDaoTao)
        {
            if (ModelState.IsValid)
            {
                db.KhoaDaoTaos.Add(khoaDaoTao);
                db.SaveChanges();
                return RedirectToAction("ListKhoaDT");
            }
            return View(khoaDaoTao);
        }

        public ActionResult SuaKhoaDT(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoaDaoTao khoaDaoTao = db.KhoaDaoTaos.Find(id);
            if (khoaDaoTao == null)
            {
                return HttpNotFound();
            }
            return View(khoaDaoTao);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaKhoaDT(KhoaDaoTao khoaDaoTao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khoaDaoTao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListKhoaDT");
            }
            return View(khoaDaoTao);
        }

        public ActionResult ListNganhDT()
        {
            return View(db.NganhDaoTaos.ToList());
        }

        public ActionResult TaoMoiNganh()
        {
            return View();
        }
        // POST: Faculty/Nganh/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoMoiNganh(NganhDaoTao nganhDaoTao)
        {
            if (ModelState.IsValid)
            {
                db.NganhDaoTaos.Add(nganhDaoTao);
                db.SaveChanges();
                return RedirectToAction("ListNganhDT");
            }
            return View(nganhDaoTao);
        }

        public ActionResult SuaNganhDT(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NganhDaoTao nganhDaoTao = db.NganhDaoTaos.Find(id);
            if (nganhDaoTao == null)
            {
                return HttpNotFound();
            }
            return View(nganhDaoTao);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaNganhDT(NganhDaoTao nganhDaoTao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nganhDaoTao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListNganhDT");
            }
            return View(nganhDaoTao);
        }

        public ActionResult ListCTDaoTao()
        {
            var ListChuongTrinhDaoTao = db.ChuongTrinhDaoTaos.Include(h => h.NganhDaoTao).Include(h => h.KhoaDaoTao).Include(h => h.HocKyDaoTao);
            return View(ListChuongTrinhDaoTao.ToList());
        }

        // GET: Faculty/ChuongTrinhDaoTao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocPhanDaoTao hocPhanDaoTao = db.HocPhanDaoTaos.Find(id);
            if (hocPhanDaoTao == null)
            {
                return HttpNotFound();
            }
            return View(hocPhanDaoTao);
        }

        // GET: Faculty/ChuongTrinhDaoTao/Create
        public ActionResult Create()
        {
            ViewBag.ID_KhoiKienThuc = new SelectList(db.KhoiKienThucs, "ID", "MaKhoiKienThuc");
            ViewBag.ID_HocPhanTuChon = new SelectList(db.HocPhanDaoTaos, "ID", "MaHocPhan");
            return View();
        }

        // POST: Faculty/ChuongTrinhDaoTao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MaHocPhan,TenHocPhan,SoTinChi,HocKy,ID_KhoiKienThuc,ID_HocPhanTuChon")] HocPhanDaoTao hocPhanDaoTao)
        {
            if (ModelState.IsValid)
            {
                db.HocPhanDaoTaos.Add(hocPhanDaoTao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_KhoiKienThuc = new SelectList(db.KhoiKienThucs, "ID", "MaKhoiKienThuc", hocPhanDaoTao.ID_KhoiKienThuc);
            ViewBag.ID_HocPhanTuChon = new SelectList(db.HocPhanDaoTaos, "ID", "MaHocPhan", hocPhanDaoTao.ID_HocPhanTuChon);
            return View(hocPhanDaoTao);
        }

        // GET: Faculty/ChuongTrinhDaoTao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocPhanDaoTao hocPhanDaoTao = db.HocPhanDaoTaos.Find(id);
            if (hocPhanDaoTao == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_KhoiKienThuc = new SelectList(db.KhoiKienThucs, "ID", "MaKhoiKienThuc", hocPhanDaoTao.ID_KhoiKienThuc);
            ViewBag.ID_HocPhanTuChon = new SelectList(db.HocPhanDaoTaos, "ID", "MaHocPhan", hocPhanDaoTao.ID_HocPhanTuChon);
            return View(hocPhanDaoTao);
        }

        // POST: Faculty/ChuongTrinhDaoTao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaHocPhan,TenHocPhan,SoTinChi,HocKy,ID_KhoiKienThuc,ID_HocPhanTuChon")] HocPhanDaoTao hocPhanDaoTao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hocPhanDaoTao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_KhoiKienThuc = new SelectList(db.KhoiKienThucs, "ID", "MaKhoiKienThuc", hocPhanDaoTao.ID_KhoiKienThuc);
            ViewBag.ID_HocPhanTuChon = new SelectList(db.HocPhanDaoTaos, "ID", "MaHocPhan", hocPhanDaoTao.ID_HocPhanTuChon);
            return View(hocPhanDaoTao);
        }

        // GET: Faculty/ChuongTrinhDaoTao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocPhanDaoTao hocPhanDaoTao = db.HocPhanDaoTaos.Find(id);
            if (hocPhanDaoTao == null)
            {
                return HttpNotFound();
            }
            return View(hocPhanDaoTao);
        }

        // POST: Faculty/ChuongTrinhDaoTao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HocPhanDaoTao hocPhanDaoTao = db.HocPhanDaoTaos.Find(id);
            db.HocPhanDaoTaos.Remove(hocPhanDaoTao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
