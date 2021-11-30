//using OfficeOpenXml;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using WebApplication.Models;

//namespace WebApplication.Areas.Faculty.Controllers
//{
//    public class CurriculumsController : Controller
//    {
//        private Cap24 db = new Cap24();
//        private string KHOIKIENTHUC = "";
//        // GET: Faculty/MonHoc
//        public ActionResult IndexMonHoc()
//        {
//            var monHocs = db.MonHocs.Include(m => m.Khoa1).Include(m => m.Nganh1);
//            ViewData["Nganh"] = db.Nganhs.ToList();
//            ViewData["Khoa"] = db.Khoas.ToList();
//            ViewData["KhoiKienThuc"] = db.KhoiKienThucs.ToList();
//            ViewData["HocKy"] = db.HocKies.ToList();
//            return View(monHocs.ToList());
//        }

//        // GET: Faculty/Nganh
//        public ActionResult IndexNganh()
//        {
//            var nganhs = db.Nganhs;
//            return View(nganhs.ToList());
//        }
//        // GET: Faculty/Khoa
//        public ActionResult IndexKhoa()
//        {
//            var khoas = db.Khoas;
//            return View(khoas.ToList());
//        }

//        // GET: Faculty/MonHoc/Details
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            MonHoc monHoc = db.MonHocs.Find(id);
//            if (monHoc == null)
//            {
//                return HttpNotFound();
//            }
//            return View(monHoc);
//        }

//        // GET: Faculty/Nganh/Create
//        public ActionResult CreateNganh()
//        {
//            return View();
//        }
//        // POST: Faculty/Nganh/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult CreateNganh(Nganh nganh)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Nganhs.Add(nganh);
//                db.SaveChanges();
//                return RedirectToAction("IndexNganh");
//            }
//            return View(nganh);
//        }
//        public ActionResult CreateKhoa()
//        {
//            return View();
//        }

//        // POST: Faculty/MonHoc/Create
//        [HttpPost]
//        public ActionResult UpLoadMonHoc(FormCollection formCollection)
//        {
//            var ListMonHoc = new List<MonHoc>();
//            if (Request != null)
//            {
//                HttpPostedFileBase file = Request.Files["UploadedFile"];
//                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
//                {
//                    string fileName = file.FileName;
//                    string fileContentType = file.ContentType;
//                    byte[] fileBytes = new byte[file.ContentLength];
//                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
//                    using (var package = new ExcelPackage(file.InputStream))
//                    {
//                        var currentSheet = package.Workbook.Worksheets;
//                        var workSheet = currentSheet.First();
//                        var noOfCol = workSheet.Dimension.End.Column;
//                        var noOfRow = workSheet.Dimension.End.Row;
//                        //Hoc Ky
//                        {
//                            var listHK = new List<string>();
//                            foreach (var item in db.HocKies.ToList())
//                            {
//                                listHK.Add(item.HK.ToString());
//                            }
//                            for (int rowIterator = 4; rowIterator <= noOfRow; rowIterator++)
//                            {
//                                var HocKy = new HocKy();
//                                if (workSheet.Cells[rowIterator, 9].Value != null)
//                                {
//                                    string hocky = workSheet.Cells[rowIterator, 9].Value.ToString();
//                                    if (!FindList(hocky, listHK))
//                                    {
//                                        HocKy.HK = hocky;
//                                        db.HocKies.Add(HocKy);
//                                        db.SaveChanges();
//                                        listHK.Add(hocky);
//                                    }
//                                }
//                            }
//                        }
//                        //Nganh
//                        {
//                            var listNganh = new List<string>();
//                            foreach (var item in db.Nganhs.ToList())
//                            {
//                                listNganh.Add(item.TenNganh.ToString());
//                            }
//                            var Nganh = new Nganh();
//                            if (workSheet.Cells[1, 2].Value != null)
//                            {
//                                string nganh = workSheet.Cells[1, 2].Value.ToString();
//                                if (!FindList(nganh, listNganh))
//                                {
//                                    Nganh.TenNganh = nganh;
//                                    db.Nganhs.Add(Nganh);
//                                    db.SaveChanges();
//                                }
//                            }
//                        }
//                        //Khoa
//                        {
//                            var listKhoa = new List<string>();
//                            foreach (var item in db.Khoas.ToList())
//                            {
//                                listKhoa.Add(item.TenKhoa.ToString());
//                            }
//                            var Khoa = new Khoa();
//                            if (workSheet.Cells[1, 2].Value != null)
//                            {
//                                string khoa = workSheet.Cells[2, 2].Value.ToString();
//                                if (!FindList(khoa, listKhoa))
//                                {
//                                    Khoa.TenKhoa = khoa;
//                                    db.Khoas.Add(Khoa);
//                                    db.SaveChanges();
//                                }
//                            }
//                        }
//                        for (int rowIterator = 4; rowIterator <= noOfRow; rowIterator++)
//                        {
//                            if (workSheet.Cells[rowIterator, 2].Value != null)
//                            {
//                                var listKhoiKT = new List<string>();
//                                foreach (var item in db.KhoiKienThucs.ToList())
//                                {
//                                    listKhoiKT.Add(item.KhoiKT);
//                                }
//                                var KhoiKienThuc = new KhoiKienThuc();
//                                string khoikienthuc = workSheet.Cells[rowIterator, 2].Value.ToString();
//                                KHOIKIENTHUC = khoikienthuc;
//                                if (!FindList(khoikienthuc, listKhoiKT))
//                                {
//                                    KhoiKienThuc.KhoiKT = khoikienthuc;
//                                    KhoiKienThuc.SoTinChiTuChon = int.Parse(workSheet.Cells[rowIterator, 6].Value.ToString());
//                                    db.KhoiKienThucs.Add(KhoiKienThuc);
//                                    db.SaveChanges();
//                                    listKhoiKT.Add(khoikienthuc);
//                                }
//                            }
//                            else
//                            {
//                                var tenmonhoc = workSheet.Cells[rowIterator, 4].Value.ToString();
//                                var nganh = workSheet.Cells[1, 2].Value.ToString();
//                                var khoa = workSheet.Cells[2, 2].Value.ToString();
//                                var database = db.MonHocs.Where(s => s.Khoa1.TenKhoa == khoa).Where(s => s.Nganh1.TenNganh == nganh);
//                                var DBMonhoc = database.FirstOrDefault(s => s.TenMocHoc == tenmonhoc);
//                                if (DBMonhoc == null)
//                                {
//                                    var monhoc = new MonHoc();
//                                    var khoikt = db.KhoiKienThucs.FirstOrDefault(s => s.KhoiKT == KHOIKIENTHUC);
//                                    monhoc.KhoiKienThuc1 = khoikt;
//                                    monhoc.MaMonHoc = workSheet.Cells[rowIterator, 3].Value.ToString();
//                                    monhoc.TenMocHoc = workSheet.Cells[rowIterator, 4].Value.ToString();
//                                    monhoc.SoTinChi = workSheet.Cells[rowIterator, 5].Value.ToString();
//                                    monhoc.BBTC = workSheet.Cells[rowIterator, 6].Value.ToString();
//                                    if (workSheet.Cells[rowIterator, 7].Value != null)
//                                        monhoc.TienQuyet = workSheet.Cells[rowIterator, 7].Value.ToString();
//                                    if (workSheet.Cells[rowIterator, 8].Value != null)
//                                        monhoc.HocTruoc = workSheet.Cells[rowIterator, 8].Value.ToString();
//                                    if (workSheet.Cells[rowIterator, 9].Value != null)
//                                    {
//                                        var HocKy = workSheet.Cells[rowIterator, 9].Value.ToString();
//                                        var monhoc_hocky = db.HocKies.FirstOrDefault(s => s.HK == HocKy);
//                                        monhoc.HocKy1 = monhoc_hocky;
//                                    }

//                                    var monhoc_nganh = db.Nganhs.FirstOrDefault(s => s.TenNganh == nganh);
//                                    var monhoc_khoa = db.Khoas.FirstOrDefault(s => s.TenKhoa == khoa);

//                                    monhoc.Khoa1 = monhoc_khoa;
//                                    monhoc.Nganh1 = monhoc_nganh;

//                                    db.MonHocs.Add(monhoc);
//                                    db.SaveChanges();
//                                }
//                            }

//                        }
//                    }
//                }
//            }
//            return RedirectToAction("IndexMonHoc");
//        }
//        public ActionResult ExportExcel()
//        {
//            ExcelPackage ep = new ExcelPackage();

//            var listKhoa = db.Khoas.ToList();
//            var listNganh = db.Nganhs.ToList();
//            var listMonHoc = db.MonHocs.ToList();

//            foreach (var khoa in listKhoa)
//            {
//                foreach (var nganh in listNganh)
//                {
//                    int STT = 0;
//                    var sheet = ep.Workbook.Worksheets.Add(khoa.TenKhoa + "-" + nganh.TenNganh);
//                    sheet.Cells["A1"].Value = "Ngành:";
//                    sheet.Cells["A2"].Value = "Khóa:";
//                    sheet.Cells["B1"].Value = nganh.TenNganh;
//                    sheet.Cells["B2"].Value = khoa.TenKhoa;

//                    sheet.Cells["A3"].Value = "STT";
//                    sheet.Cells["B3"].Value = "Khối kiến thức";
//                    sheet.Cells["C3"].Value = "Mã HP";
//                    sheet.Cells["D3"].Value = "Tên học phần";
//                    sheet.Cells["E3"].Value = "Số TC";
//                    sheet.Cells["F3"].Value = "BB/TC";
//                    sheet.Cells["G3"].Value = "Tiên quyết";
//                    sheet.Cells["H3"].Value = "Học trước";
//                    sheet.Cells["I3"].Value = "Học kỳ";

//                    int row = 4;
//                    foreach (var monhoc in listMonHoc)
//                    {
//                        STT++;
//                        if (monhoc.KhoiKienThuc1.KhoiKT != KHOIKIENTHUC)
//                        {
//                            KHOIKIENTHUC = monhoc.KhoiKienThuc1.KhoiKT;
//                            sheet.Cells[string.Format("B{0}", row)].Value = KHOIKIENTHUC;
//                            sheet.Cells[string.Format("D{0}", row)].Value = "Số tín chỉ tự chọn tối thiểu:";
//                            sheet.Cells[string.Format("E{0}", row)].Value = monhoc.KhoiKienThuc1.SoTinChiTuChon;
//                            row++;
//                        }

//                        sheet.Cells[string.Format("A{0}", row)].Value = STT;
//                        sheet.Cells[string.Format("C{0}", row)].Value = monhoc.MaMonHoc;
//                        sheet.Cells[string.Format("D{0}", row)].Value = monhoc.TenMocHoc;
//                        sheet.Cells[string.Format("E{0}", row)].Value = monhoc.SoTinChi;
//                        sheet.Cells[string.Format("F{0}", row)].Value = monhoc.BBTC;
//                        sheet.Cells[string.Format("G{0}", row)].Value = monhoc.TienQuyet;
//                        sheet.Cells[string.Format("H{0}", row)].Value = monhoc.HocTruoc;
//                        if (monhoc.HocKy1 != null)
//                            sheet.Cells[string.Format("I{0}", row)].Value = monhoc.HocKy1.HK;
//                        row++;
//                    }
//                    sheet.Cells["A:AZ"].AutoFitColumns();
//                    Response.Clear();
//                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
//                    Response.AddHeader("content-disposition", "attachment; filename=" + "Xuất học phần.xlsx");
//                    Response.BinaryWrite(ep.GetAsByteArray());
//                    Response.End();
//                }
//            }
//            return RedirectToAction("IndexMonHoc");
//        }
//        public ActionResult PrintMonHoc()
//        {
//            var monHocs = db.MonHocs.Include(m => m.Khoa1).Include(m => m.Nganh1);
//            ViewData["Nganh"] = db.Nganhs.ToList();
//            ViewData["Khoa"] = db.Khoas.ToList();
//            ViewData["KhoiKienThuc"] = db.KhoiKienThucs.ToList();
//            ViewData["HocKy"] = db.HocKies.ToList();
//            return View(monHocs.ToList());
//        }
//        public bool FindList(string txt, List<string> ls)
//        {
//            for (int i = 0; i < ls.Count; i++)
//            {
//                if (txt == ls[i])
//                    return true;
//            }
//            return false;
//        }

//        // POST: Faculty/Khoa/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult CreateKhoa(Khoa khoa)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Khoas.Add(khoa);
//                db.SaveChanges();
//                return RedirectToAction("IndexKhoa");
//            }
//            return View(khoa);
//        }
//        public ActionResult EditMonHoc(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            MonHoc monHoc = db.MonHocs.Find(id);
//            if (monHoc == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.Khoa = new SelectList(db.Khoas, "ID", "TenKhoa", monHoc.Khoa);
//            ViewBag.Nganh = new SelectList(db.Nganhs, "ID", "TenNganh", monHoc.Nganh);
//            ViewBag.KhoiKienthuc = new SelectList(db.KhoiKienThucs, "ID", "KhoiKT", monHoc.KhoiKienThuc);
//            return View(monHoc);
//        }

//        // GET: Faculty/Nganh/Edit
//        public ActionResult EditNganh(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Nganh nganh = db.Nganhs.Find(id);
//            if (nganh == null)
//            {
//                return HttpNotFound();
//            }
//            return View(nganh);
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult EditNganh(Nganh nganh)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(nganh).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("IndexNganh");
//            }
//            return View(nganh);
//        }

//        // GET: Faculty/Khoa/Edit
//        public ActionResult EditKhoa(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Khoa khoa = db.Khoas.Find(id);
//            if (khoa == null)
//            {
//                return HttpNotFound();
//            }
//            return View(khoa);
//        }
//        // POST: Faculty/MonHoc/Edit
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult EditMonHoc(MonHoc monHoc)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(monHoc).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("IndexMonHoc");
//            }
//            ViewBag.Khoa = new SelectList(db.Khoas, "ID", "TenKhoa", monHoc.Khoa);
//            ViewBag.Nganh = new SelectList(db.Nganhs, "ID", "TenNganh", monHoc.Nganh);
//            return View(monHoc);
//        }

//        // POST: Faculty/Khoa/Edit
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult EditKhoa(Khoa khoa)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(khoa).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("IndexKhoa");
//            }
//            return View(khoa);
//        }

//        // GET: Faculty/MonHoc/Delete
//        public ActionResult DeleteMonHoc(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            MonHoc monHoc = db.MonHocs.Find(id);
//            if (monHoc == null)
//            {
//                return HttpNotFound();
//            }
//            return View(monHoc);
//        }

//        // GET: Faculty/Nganh/Delete
//        public ActionResult DeleteNganh(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Nganh nganh = db.Nganhs.Find(id);
//            if (nganh == null)
//            {
//                return HttpNotFound();
//            }
//            return View(nganh);
//        }

//        // GET: Faculty/Khoa/Delete
//        public ActionResult DeleteKhoa(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Khoa khoa = db.Khoas.Find(id);
//            if (khoa == null)
//            {
//                return HttpNotFound();
//            }
//            return View(khoa);
//        }

//        // POST: Faculty/Monhoc/Delete
//        [HttpPost, ActionName("DeleteMonHoc")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteMonHocConfirmed(int id)
//        {
//            MonHoc monHoc = db.MonHocs.Find(id);
//            db.MonHocs.Remove(monHoc);
//            db.SaveChanges();
//            return RedirectToAction("IndexMonHoc");
//        }

//        // POST: Faculty/Nganh/Delete
//        [HttpPost, ActionName("DeleteNganh")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteNganhConfirmed(int id)
//        {
//            Nganh nganh = db.Nganhs.Find(id);
//            db.Nganhs.Remove(nganh);
//            db.SaveChanges();
//            return RedirectToAction("IndexNganh");
//        }

//        // POST: Faculty/Khoa/Delete
//        [HttpPost, ActionName("DeleteKhoa")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteKhoaConfirmed(int id)
//        {
//            Khoa khoa = db.Khoas.Find(id);
//            db.Khoas.Remove(khoa);
//            db.SaveChanges();
//            return RedirectToAction("IndexKhoa");
//        }
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
