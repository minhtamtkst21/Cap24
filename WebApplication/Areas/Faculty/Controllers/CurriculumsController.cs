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
        // GET: Faculty/Khoa
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
        // GET: Faculty/Khoa/Create
        public ActionResult CreateKhoa()
        {
            return View();
        }
        // POST: Faculty/Khoa/Create
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

        // POST: Faculty/MonHoc/Create
        [HttpPost]
        public ActionResult UpLoadMonHoc(FormCollection formCollection)
        {
            var ListMonHoc = new List<MonHoc>();
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    using (var package = new Exc    elPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            var user = new SinhVien();
                            user.MSSV = (workSheet.Cells[rowIterator, 1].Value).ToString();
                            user.HoTen = (workSheet.Cells[rowIterator, 2].Value).ToString();
                            user.NienKhoa = workSheet.Cells[rowIterator, 3].Value.ToString();
                            if (workSheet.Cells[rowIterator, 4].Value != null)
                            {
                                user.SoDienThoai = int.Parse(workSheet.Cells[rowIterator, 4].Value.ToString());
                            }
                            user.mail = (workSheet.Cells[rowIterator, 5].Value).ToString();
                            usersList.Add(user);
                        }
                    }
                }
                else
                {
                    SetAlert("Bạn không thêm sinh viên thành công", "warning");
                }
            }
            foreach (var item in usersList)
            {
                db.SinhViens.Add(item);
                var sv = new Login();
                sv.username = item.mail.Substring(0, item.mail.Length - 14);
                sv.password = "VLU" + sv.username.Substring(sv.username.Length - 10, 10);
                db.Logins.Add(sv);
            }
            db.SaveChanges();
            SetAlert("Bạn đã tạo thành công", "success");
            ViewBag.Khoa = new SelectList(db.Khoas, "ID", "TenKhoa");
            ViewBag.Nganh = new SelectList(db.Nganhs, "ID", "TenNganh");
            return View();
        }

        public void validateNganh(Nganh nganh)
        {
            if (nganh.TenNganh == null)
            {
                ModelState.AddModelError("tenNganh", "Không được để trống");
            }
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

        // GET: Faculty/Khoa/Edit
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
        

        

        // POST: Faculty/Khoa/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditKhoa(Khoa khoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexKhoa");
            }
            return View(khoa);
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

        // GET: Faculty/Khoa/Delete
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
                
        // POST: Faculty/Khoa/Delete
        [HttpPost, ActionName("DeleteKhoa")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteKhoaConfirmed(int id)
        {
            Khoa khoa = db.Khoas.Find(id);
            db.Khoas.Remove(khoa);
            db.SaveChanges();
            return RedirectToAction("IndexKhoa");
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
