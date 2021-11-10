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
    public class CurriculumsController : Controller
    {
        private Cap24 db = new Cap24();

        // GET: Faculty/MonHoc
        public ActionResult IndexMonHoc()
        {
            var monHocs = db.MonHocs.Include(m => m.Khoa1).Include(m => m.Nganh1);
            return View(monHocs.ToList());
        }

        // GET: Faculty/Nganh
        public ActionResult IndexNganh()
        {
            var nganhs = db.Nganhs;
            return View(nganhs.ToList());
        }
        public ActionResult IndexKhoa()
        {
            var khoas = db.Khoas;
            return View(khoas.ToList());
        }

        // GET: Faculty/MonHoc/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = db.MonHocs.Find(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // GET: Faculty/MonHoc/Create
        public ActionResult CreateMonHoc()
        {
            ViewBag.Khoa = new SelectList(db.Khoas, "ID", "TenKhoa");
            ViewBag.Nganh = new SelectList(db.Nganhs, "ID", "TenNganh");
            return View();
        }

        // GET: Faculty/Nganh/Create
        public ActionResult CreateNganh()
        {
            return View();
        }

        // POST: Faculty/MonHoc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMonHoc(MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                db.MonHocs.Add(monHoc);
                db.SaveChanges();
                return RedirectToAction("IndexMonHoc");
            }

            ViewBag.Khoa = new SelectList(db.Khoas, "ID", "TenKhoa", monHoc.Khoa);
            ViewBag.Nganh = new SelectList(db.Nganhs, "ID", "TenNganh", monHoc.Nganh);
            return View(monHoc);
        }

        // POST: Faculty/Nganh/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNganh(Nganh nganh)
        {
            if (ModelState.IsValid)
            {
                db.Nganhs.Add(nganh);
                db.SaveChanges();
                return RedirectToAction("IndexNganh");
            }
            return View(nganh);
        }

        // GET: Faculty/MonHoc/Edit
        public ActionResult EditMonHoc(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = db.MonHocs.Find(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.Khoa = new SelectList(db.Khoas, "ID", "TenKhoa", monHoc.Khoa);
            ViewBag.Nganh = new SelectList(db.Nganhs, "ID", "TenNganh", monHoc.Nganh);
            return View(monHoc);
        }
        public ActionResult EditNganh(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nganh nganh = db.Nganhs.Find(id);
            if (nganh == null)
            {
                return HttpNotFound();
            }
            return View(nganh);
        }
        // POST: Faculty/MonHoc/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]  
        public ActionResult EditMonHoc(MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexMonHoc");
            }
            ViewBag.Khoa = new SelectList(db.Khoas, "ID", "TenKhoa", monHoc.Khoa);
            ViewBag.Nganh = new SelectList(db.Nganhs, "ID", "TenNganh", monHoc.Nganh);
            return View(monHoc);
        }

        // POST: Faculty/Nganh/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNganh(Nganh nganh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nganh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexNganh");
            }
            return View(nganh);
        }

        // GET: Faculty/MonHoc/Delete
        public ActionResult DeleteMonHoc(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = db.MonHocs.Find(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // GET: Faculty/MonHoc/Delete
        public ActionResult DeleteNganh(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nganh nganh = db.Nganhs.Find(id);
            if (nganh == null)
            {
                return HttpNotFound();
            }
            return View(nganh);
        }
        // POST: Faculty/Monhoc/Delete
        [HttpPost, ActionName("DeleteMonHoc")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMonHocConfirmed(int id)
        {
            MonHoc monHoc = db.MonHocs.Find(id);
            db.MonHocs.Remove(monHoc);
            db.SaveChanges();
            return RedirectToAction("IndexMonHoc");
        }
        // POST: Faculty/Nganh/Delete
        [HttpPost, ActionName("DeleteNganh")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteNganhConfirmed(int id)
        {
            Nganh nganh = db.Nganhs.Find(id);
            db.Nganhs.Remove(nganh);
            db.SaveChanges();
            return RedirectToAction("IndexNganh");
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
