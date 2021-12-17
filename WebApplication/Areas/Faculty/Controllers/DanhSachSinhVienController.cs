using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using System.Data;
using System.Data.Entity;
using System.Net;
using OfficeOpenXml;

namespace WebApplication.Areas.Faculty.Controllers
{
    public class DanhSachSinhVienController : Controller
    {
        public Cap24 db = new Cap24();

        public string KiemTraLop(string tenLop)
        {
            string ListLoi = "";

            if (tenLop.Length > 20)
            {
                ListLoi += "<p> Tên lớp không được quá 20 ký tự, số ký tự của lớp bạn nhập là: " + tenLop.Length + "</p>";
            }
            var listDBLop = db.LopQuanLies.ToList();
            var listLop = new List<string>();
            foreach (var item in listDBLop)
            {
                listLop.Add(item.TenLop);
            }
            if (CheckTonTai(tenLop, listLop))
            {
                ListLoi += "<p> Lớp đã tồn tại trong hệ thống, vui lòng thử lại!</p>";
            }
            return ListLoi;
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
        public ActionResult ListLop()
        {
            var lopQuanLies = db.LopQuanLies.Include(l => l.KhoaDaoTao).Include(l => l.NganhDaoTao);
            return View(lopQuanLies.ToList());
        }
        // GET: Faculty/LopQuanLies/Create
        public ActionResult TaoMoiLop()
        {
            ViewBag.ID_Khoa = new SelectList(db.KhoaDaoTaos, "ID", "ID");
            ViewBag.ID_Nganh = new SelectList(db.NganhDaoTaos, "ID", "Nganh");
            return View();
        }

        // POST: Faculty/LopQuanLies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoMoiLop(LopQuanLy lopQuanLy)
        {
            if (ModelState.IsValid)
            {
                var ListLoi = KiemTraLop(lopQuanLy.TenLop);
                if (ListLoi != "")
                {
                    TempData["Alert"] = ListLoi;
                    return RedirectToAction("TaoMoiLop");
                }
                db.LopQuanLies.Add(lopQuanLy);
                db.SaveChanges();
                return RedirectToAction("DanhSachLop");
            }

            ViewBag.ID_Khoa = new SelectList(db.KhoaDaoTaos, "ID", "Khoa", lopQuanLy.ID_Khoa);
            ViewBag.ID_Nganh = new SelectList(db.NganhDaoTaos, "ID", "Nganh", lopQuanLy.ID_Nganh);
            return View(lopQuanLy);
        }
        public ActionResult SuaLop(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopQuanLy lopQuanLy = db.LopQuanLies.Find(id);
            if (lopQuanLy == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Khoa = new SelectList(db.KhoaDaoTaos, "ID", "Khoa", lopQuanLy.ID_Khoa);
            ViewBag.ID_Nganh = new SelectList(db.NganhDaoTaos, "ID", "Nganh", lopQuanLy.ID_Nganh);
            return View(lopQuanLy);
        }

        // POST: Faculty/LopQuanLies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaLop(LopQuanLy lopQuanLy)
        {
            if (ModelState.IsValid)
            {
                var ListLoi = KiemTraLop(lopQuanLy.TenLop);
                if (ListLoi != "")
                {
                    TempData["Alert"] = ListLoi;
                    return RedirectToAction("SuaLop", new { id = lopQuanLy.ID });
                }
                db.Entry(lopQuanLy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListLop");
            }
            ViewBag.ID_Khoa = new SelectList(db.KhoaDaoTaos, "ID", "Khoa", lopQuanLy.ID_Khoa);
            ViewBag.ID_Nganh = new SelectList(db.NganhDaoTaos, "ID", "Nganh", lopQuanLy.ID_Nganh);
            return View(lopQuanLy);
        }
        // GET: Faculty/LopQuanLies/Delete/5
        public ActionResult XoaLop(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopQuanLy lopQuanLy = db.LopQuanLies.Find(id);
            if (lopQuanLy == null)
            {
                return HttpNotFound();
            }
            return View(lopQuanLy);
        }

        // POST: Faculty/LopQuanLies/Delete/5
        [HttpPost, ActionName("XoaLop")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoaLop(int id)
        {
            LopQuanLy lopQuanLy = db.LopQuanLies.Find(id);
            db.LopQuanLies.Remove(lopQuanLy);
            db.SaveChanges();
            return RedirectToAction("ListLop");
        }
        // GET: Faculty/KhoaSinhVien
        public ActionResult KhoaSinhVien()
        {
            var khoa = db.KhoaDaoTaos.ToList();
            return View(khoa);
        }

        public ActionResult NganhSinhVien(int ID)
        {
            var khoa = db.KhoaDaoTaos.Find(ID);
            ViewData["KhoaDaoTao"] = khoa.Khoa;
            var nganh = db.NganhDaoTaos.ToList();
            return View(nganh);
        }
        public ActionResult LopSinhVien(int ID, int ID2)
        {
            var khoa = db.KhoaDaoTaos.Find(ID);
            ViewData["KhoaDaoTao"] = khoa.Khoa;
            var nganh = db.NganhDaoTaos.Find(ID2);
            ViewData["NganhDaoTao"] = nganh.Nganh;
            var lop = db.LopQuanLies.ToList();
            return View(lop);
        }
            // GET: Faculty/DanhSachSinhVien
            public ActionResult ListSinhVien()
        {
            ViewData["KhoaDaoTao"] = db.KhoaDaoTaos.ToList();
            ViewData["NganhDaoTao"] = db.NganhDaoTaos.ToList();
            ViewData["LopQuanLy"] = db.LopQuanLies.ToList();
            return View();
        }   
        [HttpPost]
        public ActionResult XemTruocThongKe(FormCollection formCollection)
        {
            TempData["test"] = "ahihi";
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPost]
        public ActionResult UploadSinhVien(FormCollection formCollection)
        {
            if (Request != null)
            {

                HttpPostedFileBase file = Request.Files["UploadedFile"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {

                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        if (workSheet.Dimension != null)
                        {
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            if (noOfCol == 15 && noOfRow > 1)
                            {
                                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                {
                                    SinhVien SaveSV = new SinhVien();
                                    if (workSheet.Cells[rowIterator, 1].Value != null)
                                    {
                                        SaveSV.MSSV = workSheet.Cells[rowIterator, 1].Value.ToString();
                                    }
                                    if (workSheet.Cells[rowIterator, 2].Value != null)
                                    {
                                        SaveSV.Ho = workSheet.Cells[rowIterator, 2].Value.ToString();
                                    }
                                    if (workSheet.Cells[rowIterator, 3].Value != null)
                                    {
                                        SaveSV.Ten = workSheet.Cells[rowIterator, 3].Value.ToString();
                                    }
                                    if (workSheet.Cells[rowIterator, 4].Value != null)
                                    {
                                        SaveSV.NgaySinh = workSheet.Cells[rowIterator, 4].Value.ToString();
                                    }
                                    if (workSheet.Cells[rowIterator, 5].Value != null)
                                    {
                                        SaveSV.GioiTinh = workSheet.Cells[rowIterator, 5].Value.ToString();
                                    }
                                    if (workSheet.Cells[rowIterator, 9].Value != null)
                                    {
                                        SaveSV.Email_1 = workSheet.Cells[rowIterator, 9].Value.ToString();
                                    }
                                    if (workSheet.Cells[rowIterator, 10].Value != null)
                                    {
                                        SaveSV.Email_2 = workSheet.Cells[rowIterator, 10].Value.ToString();
                                    }
                                    if (workSheet.Cells[rowIterator, 12].Value != null)
                                    {
                                        SaveSV.DTDD = workSheet.Cells[rowIterator, 12].Value.ToString();
                                    }
                                    if (workSheet.Cells[rowIterator, 13].Value != null)
                                    {
                                        SaveSV.DTCha = workSheet.Cells[rowIterator, 13].Value.ToString();
                                    }
                                    if (workSheet.Cells[rowIterator, 14].Value != null)
                                    {
                                        SaveSV.DTMe = workSheet.Cells[rowIterator, 14].Value.ToString();
                                    }
                                    if (workSheet.Cells[rowIterator, 15].Value != null)
                                    {
                                        SaveSV.DiaChi = workSheet.Cells[rowIterator, 15].Value.ToString();
                                    }
                                    if (workSheet.Cells[rowIterator, 8].Value != null)
                                    {
                                        var listLop = db.LopQuanLies.ToList();

                                        var listTenLop = new List<string>();

                                        var tenLop = workSheet.Cells[rowIterator, 8].Value.ToString();
                                        var maNganh = workSheet.Cells[rowIterator, 11].Value.ToString();
                                        var maKhoa = workSheet.Cells[rowIterator, 7].Value.ToString().Replace("K", string.Empty);
                                        foreach (var item in listLop)
                                        {
                                            listTenLop.Add(item.TenLop);
                                        }

                                        if (CheckTonTai(tenLop, listTenLop))
                                        {
                                            var lop = db.LopQuanLies.FirstOrDefault(s => s.TenLop == tenLop);
                                            SaveSV.LopQuanLy = lop;
                                        }
                                        else
                                        {
                                            var lopQL = new LopQuanLy();
                                            lopQL.TenLop = tenLop;
                                            lopQL.NganhDaoTao = db.NganhDaoTaos.FirstOrDefault(s => s.MaNganh.ToString() == maNganh);
                                            lopQL.KhoaDaoTao = db.KhoaDaoTaos.FirstOrDefault(s => s.Khoa.ToString() == maKhoa);
                                            db.LopQuanLies.Add(lopQL);
                                            db.SaveChanges();
                                        }
                                    }
                                    if (workSheet.Cells[rowIterator, 6].Value != null)
                                    {
                                        var listTinhTrang = db.TinhTrangs.ToList();

                                        var listTinhTrangMoi = new List<string>();

                                        var tenTinhTrang = workSheet.Cells[rowIterator, 6].Value.ToString();
                                        foreach (var item in listTinhTrang)
                                        {
                                            listTinhTrangMoi.Add(item.TenTinhTrang);
                                        }
                                        if (CheckTonTai(tenTinhTrang, listTinhTrangMoi))
                                        {
                                            var tinhtrang = db.TinhTrangs.FirstOrDefault(s => s.TenTinhTrang == tenTinhTrang);
                                            SaveSV.TinhTrang = tinhtrang;
                                        }
                                        else
                                        {
                                            var TinhTrangMoi = new TinhTrang();
                                            TinhTrangMoi.TenTinhTrang = tenTinhTrang;
                                            var douutien = 0;
                                            foreach (var item in listTinhTrang)
                                            {
                                                if (item.DoUuTien > douutien)
                                                    douutien = (int)item.DoUuTien;
                                            }
                                            TinhTrangMoi.DoUuTien = douutien + 1;

                                            db.TinhTrangs.Add(TinhTrangMoi);
                                            db.SaveChanges();
                                        }
                                    }
                                    db.SinhViens.Add(SaveSV);
                                    db.SaveChanges();
                                }
                            }
                        }
                    }
                }
                else
                {
                    TempData["Alert"] = "File bị trống, vui lòng thử lại!!";
                }
            }
            return RedirectToAction("ListSinhVien");
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