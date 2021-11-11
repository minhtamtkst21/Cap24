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
        private CAPK24Entities db = new CAPK24Entities();

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
        //GET: Faculty/Khoa
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

        public void validateNganh(Nganh nganh)
        {
            if (nganh.TenNganh == null)
            {
                ModelState.AddModelError("tenNganh", "Không được để trống");
            }
        }

        // GET: Faculty/Nganh/Create
        public ActionResult CreateNganh()
        {
            return View();
        }
        // POST: Faculty/Nganh/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNganh(Nganh nganh)
        {
            validateNganh(nganh);
            if (ModelState.IsValid)
            {
                db.Nganhs.Add(nganh);
                db.SaveChanges();
                return RedirectToAction("IndexNganh");
            }
            return View(nganh);
        }        
        

        // GET: Faculty/Nganh/Edit
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

        // POST: Faculty/Nganh/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNganh(Nganh nganh)
        {
            validateNganh(nganh);
            if (ModelState.IsValid)
            {
                db.Entry(nganh).State = EntityState.Modified;
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

        // GET: Faculty/Nganh/Delete
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
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
            
        // GET: Faculty/Khoas/Create
        public ActionResult CreateKhoa()
        {
            return View();
        }

        // POST: Faculty/Khoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateKhoa(Khoa khoa)
        {
            if (ModelState.IsValid)
            {
                db.Khoas.Add(khoa);
                db.SaveChanges();
                return RedirectToAction("IndexKhoa");
            }

            return View(khoa);
        }

        // GET: Faculty/Khoas/Edit/5
        public ActionResult EditKhoa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khoa khoa = db.Khoas.Find(id);
            if (khoa == null)
            {
                return HttpNotFound();
            }
            return View(khoa);
        }

        // POST: Faculty/Khoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditKhoa([Bind(Include = "ID,TenKhoa")] Khoa khoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khoa);
        }


        // GET: Faculty/Khoas/Delete/5
        public ActionResult DeleteKhoa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khoa khoa = db.Khoas.Find(id);
            if (khoa == null)
            {
                return HttpNotFound();
            }
            return View(khoa);
        }

        // POST: Faculty/Khoas/Delete/5
        [HttpPost, ActionName("DeleteKhoa")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteKhoaConfirmed(int id)
        {
            Khoa khoa = db.Khoas.Find(id);
            db.Khoas.Remove(khoa);
            db.SaveChanges();
            return RedirectToAction("IndexKhoa");
        }
    }
}
