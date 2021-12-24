using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HocPhanDaoTaoController : Controller
    {
        private Cap24 db = new Cap24();

        // GET: HocPhanDaoTao
        public ActionResult Index()
        {
            var hocPhanDaoTaos = db.HocPhanDaoTaos.Include(h => h.KhoiKienThuc).Include(h => h.HocPhanDaoTao2);
            ViewData["NganhDaoTao"] = db.NganhDaoTaos.ToList();
            ViewData["KhoaDaoTao"] = db.KhoaDaoTaos.ToList();
            ViewData["HocKyDaoTao"] = db.HocKyDaoTaos.ToList();
            ViewData["RangBuocHocPhan"] = db.RangBuocHocPhans.ToList();
            var listHK = new List<string>();
            var listHP = db.HocPhanDaoTaos.ToList();
            foreach (var item in hocPhanDaoTaos)
            {
                if (!CheckTonTai(item.HocKy.ToString(), listHK))
                {
                    listHK.Add(item.HocKy.ToString());
                }
            }
            ViewData["listHK"] = listHK;
            return View(hocPhanDaoTaos.ToList());
        }
        public bool CheckTonTai(string element, List<string> list)
        {
            foreach (var item in list)
            {
                if (element == item)
                {
                    return true;
                }
            }
            return false;
        }
        // GET: HocPhanDaoTao/Details/5
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

        // GET: HocPhanDaoTao/Create
        public ActionResult Create()
        {
            ViewBag.ID_KhoiKienThuc = new SelectList(db.KhoiKienThucs, "ID", "MaKhoiKienThuc");
            ViewBag.ID_HocPhanTuChon = new SelectList(db.HocPhanDaoTaos, "ID", "MaHocPhan");
            return View();
        }

        // POST: HocPhanDaoTao/Create
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

        // GET: HocPhanDaoTao/Edit/5
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

        // POST: HocPhanDaoTao/Edit/5
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

        // GET: HocPhanDaoTao/Delete/5
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

        // POST: HocPhanDaoTao/Delete/5
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
