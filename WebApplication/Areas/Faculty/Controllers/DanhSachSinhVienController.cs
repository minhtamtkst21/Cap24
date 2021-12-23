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

        public ActionResult Details(int ID)
        {
            var model = db.SinhViens.Find(ID);
            if (model == null)
            {
                return HttpNotFound();

            }
            return View(model);
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
            var lop = db.LopQuanLies.ToList();
            var khoa = new List<KhoaDaoTao>();
            var stringkhoa = new List<string>();
            foreach (var item in lop)
            {
                if (!CheckTonTai(item.KhoaDaoTao.Khoa.ToString(), stringkhoa))
                {
                    khoa.Add(item.KhoaDaoTao);
                    stringkhoa.Add(item.KhoaDaoTao.Khoa.ToString());
                }
            }
            return View(khoa);
        }

        public ActionResult NganhSinhVien(int ID)
        {
            var khoa = db.KhoaDaoTaos.Find(ID);
            var lop = db.LopQuanLies.Where(s => s.KhoaDaoTao.ID == khoa.ID).ToList();
            var nganh = new List<NganhDaoTao>();
            var stringnganh = new List<string>();
            if (lop != null)
                foreach (var item in lop)
                {
                    if (!CheckTonTai(item.NganhDaoTao.Nganh, stringnganh))
                    {
                        nganh.Add(item.NganhDaoTao);
                        stringnganh.Add(item.NganhDaoTao.Nganh);
                    }
                }
            ViewData["KhoaDaoTao"] = khoa;
            return View(nganh);
        }
        public ActionResult LopSinhVien(int idnganh, int idkhoa)
        {
            var khoa = db.KhoaDaoTaos.Find(idkhoa);
            var nganh = db.NganhDaoTaos.Find(idnganh);
            var lop = db.LopQuanLies.Where(s => s.NganhDaoTao.ID == idnganh).Where(s => s.KhoaDaoTao.ID == idkhoa).ToList();
            return View(lop);
        }
        // GET: Faculty/DanhSachSinhVien
        public ActionResult ListSinhVien(int id)
        {
            var sinhvien = db.SinhViens.OrderBy(s => s.TinhTrang.DoUuTien).Where(s => s.LopQuanLy.ID == id).ToList();
            return View(sinhvien);
        }
        [HttpPost]
        public ActionResult XemTruocThongKe(FormCollection formCollection)
        {
            var LuuSinhVien = new List<SinhVien>();
            var LuuLop = new List<LopQuanLy>();
            var LuuTinhTrang = new List<TinhTrang>();
            var soluong = 0;
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
                                soluong = noOfRow - 1;
                                var listTenLop = new List<string>();
                                foreach (var item in LuuLop)
                                {
                                    listTenLop.Add(item.TenLop);
                                }
                                var listTinhTrangMoi = new List<string>();
                                foreach (var item in LuuTinhTrang)
                                {
                                    listTinhTrangMoi.Add(item.TenTinhTrang);
                                }
                                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                {
                                    if (workSheet.Cells[rowIterator, 8].Value != null)
                                    {
                                        var tenLop = workSheet.Cells[rowIterator, 8].Value.ToString();
                                        var maNganh = workSheet.Cells[rowIterator, 11].Value.ToString();
                                        var maKhoa = workSheet.Cells[rowIterator, 7].Value.ToString().Replace("K", string.Empty);

                                        if (!CheckTonTai(tenLop, listTenLop))
                                        {
                                            var lopQL = new LopQuanLy();
                                            lopQL.TenLop = tenLop;
                                            lopQL.NganhDaoTao = db.NganhDaoTaos.FirstOrDefault(s => s.MaNganh.ToString() == maNganh);
                                            lopQL.KhoaDaoTao = db.KhoaDaoTaos.FirstOrDefault(s => s.Khoa.ToString() == maKhoa);
                                            LuuLop.Add(lopQL);
                                            listTenLop.Add(tenLop);
                                        }
                                    }
                                    if (workSheet.Cells[rowIterator, 6].Value != null)
                                    {
                                        var tenTinhTrang = workSheet.Cells[rowIterator, 6].Value.ToString();

                                        if (!CheckTonTai(tenTinhTrang, listTinhTrangMoi))
                                        {
                                            var TinhTrangMoi = new TinhTrang();
                                            TinhTrangMoi.TenTinhTrang = tenTinhTrang;
                                            var douutien = 0;
                                            if (db.TinhTrangs.ToList().Count != 0)
                                            {
                                                douutien = db.TinhTrangs.OrderByDescending(s => s.DoUuTien).ToList().First().DoUuTien;
                                            }
                                            TinhTrangMoi.DoUuTien = douutien + 1;
                                            LuuTinhTrang.Add(TinhTrangMoi);
                                            listTinhTrangMoi.Add(tenTinhTrang);
                                        }
                                    }
                                }
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
                                        var tenLop = workSheet.Cells[rowIterator, 8].Value.ToString();
                                        SaveSV.LopQuanLy = LuuLop.FirstOrDefault(s => s.TenLop == tenLop);
                                    }
                                    if (workSheet.Cells[rowIterator, 6].Value != null)
                                    {
                                        var tinhtrang = workSheet.Cells[rowIterator, 6].Value.ToString();
                                        SaveSV.TinhTrang = LuuTinhTrang.FirstOrDefault(s => s.TenTinhTrang == tinhtrang);
                                    }

                                    LuuSinhVien.Add(SaveSV);
                                }
                            }
                        }
                    }
                }
            }
            Session["LuuSinhVien"] = LuuSinhVien;
            Session["LuuLop"] = LuuLop;
            Session["LuuTinhTrang"] = LuuTinhTrang;
            //Session["ThongBao"]
            string thongbao = "<table class='table table-hover mb-0'>";
            thongbao += "<tr>";
            thongbao += "<td>Số lượng sinh viên: " + soluong + "</td>";
            thongbao += "</tr>";
            foreach (var khoa in db.KhoaDaoTaos)
            {
                thongbao += "<tr>"; 
                thongbao += "<td>Lớp thuộc khóa " + khoa.Khoa + " là: " + LuuLop.Where(s => s.KhoaDaoTao.Khoa == khoa.Khoa).Count() + "</td>";
                thongbao += "<td></td><td>Sinh viên khóa " + khoa.Khoa + " là: " +LuuSinhVien.Where(s=>s.LopQuanLy.KhoaDaoTao.Khoa == khoa.Khoa).Count() + "</td>";
                thongbao += "<td></td></tr>";
                foreach (var nganh in db.NganhDaoTaos)
                {
                    thongbao += "<tr>";
                    thongbao += "<td></td><td>Lớp thuộc ngành " + nganh.Nganh + " là: " + LuuLop.Where(s => s.KhoaDaoTao.Khoa == khoa.Khoa).Where(s => s.NganhDaoTao.Nganh == nganh.Nganh).Count() + "</td>";
                    thongbao += "<td></td><td>Sinh viên ngành " + nganh.Nganh + " là: " + LuuSinhVien.Where(s => s.LopQuanLy.KhoaDaoTao.Khoa == khoa.Khoa).Where(s => s.LopQuanLy.NganhDaoTao.Nganh == nganh.Nganh).Count() + "</td>";
                    thongbao += "</tr>";
                    foreach (var lop in LuuLop.Where(s => s.KhoaDaoTao.Khoa == khoa.Khoa).Where(s => s.NganhDaoTao.Nganh == nganh.Nganh))
                    {
                        thongbao += "<tr>";
                        thongbao += "<td></td><td></td><td></td><td>Sinh viên lớp " + lop.TenLop + " là: " + LuuSinhVien.Where(s => s.LopQuanLy.KhoaDaoTao.Khoa == khoa.Khoa).Where(s => s.LopQuanLy.NganhDaoTao.Nganh == nganh.Nganh).Where(s=>s.LopQuanLy.TenLop == lop.TenLop).Count() + "</td>";
                        thongbao += "</tr>";
                    }
                }
            }
            thongbao += "</table>";
            Session["ThongBao"] = thongbao;
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult TaiLenSinhVien()
        {
            var listSV = Session["LuuSinhVien"] as List<SinhVien>;
            var listLop = Session["LuuLop"] as List<LopQuanLy>;
            var listTinhTrang = Session["LuuTinhTrang"] as List<TinhTrang>;
            Session["ThongBao"] = null;
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
                                var listLop = db.LopQuanLies.ToList();
                                var listTenLop = new List<string>();
                                foreach (var item in listLop)
                                {
                                    listTenLop.Add(item.TenLop);
                                }
                                var listTinhTrang = db.TinhTrangs.ToList();
                                var listTinhTrangMoi = new List<string>();
                                foreach (var item in listTinhTrang)
                                {
                                    listTinhTrangMoi.Add(item.TenTinhTrang);
                                }
                                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                {
                                    if (workSheet.Cells[rowIterator, 8].Value != null)
                                    {
                                        var tenLop = workSheet.Cells[rowIterator, 8].Value.ToString();
                                        var maNganh = workSheet.Cells[rowIterator, 11].Value.ToString();
                                        var maKhoa = workSheet.Cells[rowIterator, 7].Value.ToString().Replace("K", string.Empty);

                                        if (!CheckTonTai(tenLop, listTenLop))
                                        {
                                            var lopQL = new LopQuanLy();
                                            lopQL.TenLop = tenLop;
                                            lopQL.NganhDaoTao = db.NganhDaoTaos.FirstOrDefault(s => s.MaNganh.ToString() == maNganh);
                                            lopQL.KhoaDaoTao = db.KhoaDaoTaos.FirstOrDefault(s => s.Khoa.ToString() == maKhoa);
                                            db.LopQuanLies.Add(lopQL);
                                            listTenLop.Add(tenLop);
                                            db.SaveChanges();
                                        }
                                    }
                                    if (workSheet.Cells[rowIterator, 6].Value != null)
                                    {
                                        var tenTinhTrang = workSheet.Cells[rowIterator, 6].Value.ToString();

                                        if (!CheckTonTai(tenTinhTrang, listTinhTrangMoi))
                                        {
                                            var TinhTrangMoi = new TinhTrang();
                                            TinhTrangMoi.TenTinhTrang = tenTinhTrang;
                                            var douutien = 0;
                                            if (db.TinhTrangs.ToList().Count != 0)
                                            {
                                                douutien = db.TinhTrangs.OrderByDescending(s => s.DoUuTien).ToList().First().DoUuTien;
                                            }
                                            TinhTrangMoi.DoUuTien = douutien + 1;
                                            db.TinhTrangs.Add(TinhTrangMoi);
                                            db.SaveChanges();
                                            listTinhTrangMoi.Add(tenTinhTrang);
                                        }
                                    }
                                }
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
                                        var tenLop = workSheet.Cells[rowIterator, 8].Value.ToString();
                                        SaveSV.LopQuanLy = db.LopQuanLies.FirstOrDefault(s => s.TenLop == tenLop);
                                    }
                                    if (workSheet.Cells[rowIterator, 6].Value != null)
                                    {
                                        var tinhtrang = workSheet.Cells[rowIterator, 6].Value.ToString();
                                        SaveSV.TinhTrang = db.TinhTrangs.FirstOrDefault(s => s.TenTinhTrang == tinhtrang);
                                    }
                                    db.Configuration.AutoDetectChangesEnabled = false;
                                    db.Configuration.ValidateOnSaveEnabled = false;
                                    db.SinhViens.Add(SaveSV);
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
            db.SaveChanges();
            return RedirectToAction("KhoaSinhVien");
        }

        public ActionResult XuatDSSV(int? idnganh, int? idkhoa, int? idlop)
        {
            ExcelPackage ep = new ExcelPackage();
            var sheet = ep.Workbook.Worksheets.Add("Danh Sách Sinh Viên");
            var sinhvien = db.SinhViens.ToList();
            if (idkhoa != null)
            {
                sinhvien = sinhvien.Where(s => s.LopQuanLy.ID_Khoa == idkhoa).ToList();
            }
            if (idnganh != null)
            {
                sinhvien = sinhvien.Where(s => s.LopQuanLy.ID_Nganh == idnganh).ToList();
            }
            if (idlop != null)
            {
                sinhvien = sinhvien.Where(s => s.LopQuanLy.ID == idlop).ToList();
            }
            sheet.Cells["A1"].Value = "MSSV";
            sheet.Cells["B1"].Value = "Họ";
            sheet.Cells["C1"].Value = "Tên";
            sheet.Cells["D1"].Value = "Ngày Sinh";
            sheet.Cells["E1"].Value = "Giới tính";
            sheet.Cells["F1"].Value = "Tình Trạng";
            sheet.Cells["G1"].Value = "Khóa";
            sheet.Cells["H1"].Value = "Lớp";
            sheet.Cells["I1"].Value = "Email 1";
            sheet.Cells["J1"].Value = "Email 2";
            sheet.Cells["K1"].Value = "Mã Ngành";
            sheet.Cells["L1"].Value = "ĐTDĐ";
            sheet.Cells["M1"].Value = "ĐT Cha";
            sheet.Cells["N1"].Value = "ĐT Mẹ";
            sheet.Cells["O1"].Value = "Địa chỉ";
            sheet.Cells["A1:O1"].Style.Font.Bold = true;

            int row = 2;
            foreach (var item in sinhvien)
            {
                sheet.Cells[string.Format("A{0}", row)].Value = item.MSSV;
                sheet.Cells[string.Format("B{0}", row)].Value = item.Ho;
                sheet.Cells[string.Format("C{0}", row)].Value = item.Ten;
                sheet.Cells[string.Format("D{0}", row)].Value = item.NgaySinh;
                sheet.Cells[string.Format("E{0}", row)].Value = item.GioiTinh;
                sheet.Cells[string.Format("F{0}", row)].Value = item.TinhTrang.TenTinhTrang;
                sheet.Cells[string.Format("I{0}", row)].Value = item.Email_1;
                sheet.Cells[string.Format("J{0}", row)].Value = item.Email_2;
                sheet.Cells[string.Format("L{0}", row)].Value = item.DTDD;
                sheet.Cells[string.Format("M{0}", row)].Value = item.DTCha;
                sheet.Cells[string.Format("N{0}", row)].Value = item.DTMe;
                sheet.Cells[string.Format("O{0}", row)].Value = item.DiaChi;
                sheet.Cells[string.Format("H{0}", row)].Value = item.LopQuanLy.TenLop;
                sheet.Cells[string.Format("G{0}", row)].Value = "K" + item.LopQuanLy.KhoaDaoTao.Khoa;
                sheet.Cells[string.Format("K{0}", row)].Value = item.LopQuanLy.NganhDaoTao.MaNganh;
                row++;
            }
            sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment; filename=" + "Danh sách sinh viên.xlsx");
            Response.BinaryWrite(ep.GetAsByteArray());
            Response.End();
            return Redirect(Request.UrlReferrer.ToString());
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