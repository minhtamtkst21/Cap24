using OfficeOpenXml;
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

        public ActionResult ListHocKyDT()
        {
            return View(db.HocKyDaoTaos.ToList());
        }

        public ActionResult TaoMoiHocKy()
        {
            return View();
        }
        // POST: Faculty/Nganh/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoMoiHocKy(HocKyDaoTao hocKyDaoTao)
        {
            if (ModelState.IsValid)
            {
                db.HocKyDaoTaos.Add(hocKyDaoTao);
                db.SaveChanges();
                return RedirectToAction("ListHocKyDT");
            }
            return View(hocKyDaoTao);
        }

        public ActionResult SuaHocKyDT(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocKyDaoTao hocKyDaoTao = db.HocKyDaoTaos.Find(id);
            if (hocKyDaoTao == null)
            {
                return HttpNotFound();
            }
            return View(hocKyDaoTao);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaHocKyDT(HocKyDaoTao hocKyDaoTao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hocKyDaoTao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListHocKyDT");
            }
            return View(hocKyDaoTao);
        }

        public ActionResult XoaHocKyDT(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocKyDaoTao hocKyDaoTao = db.HocKyDaoTaos.Find(id);
            if (hocKyDaoTao == null)
            {
                return HttpNotFound();
            }
            return View(hocKyDaoTao);
        }

        // POST: Faculty/NganhDaoTaos/Delete/5
        [HttpPost, ActionName("XoaHocKyDT")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoaHocKyDT(int id)
        {
            HocKyDaoTao hocKyDaoTao = db.HocKyDaoTaos.Find(id);
            db.HocKyDaoTaos.Remove(hocKyDaoTao);
            db.SaveChanges();
            return RedirectToAction("ListHocKyDT");
        }

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

        public ActionResult SuaKhoaDT(int? id)
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

        public ActionResult XoaKhoaDT(int? id)
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

        // POST: Faculty/NganhDaoTaos/Delete/5
        [HttpPost, ActionName("XoaKhoaDT")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoaKhoaDT(int id)
        {
            KhoaDaoTao khoaDaoTao = db.KhoaDaoTaos.Find(id);
            db.KhoaDaoTaos.Remove(khoaDaoTao);
            db.SaveChanges();
            return RedirectToAction("ListKhoaDT");
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

        public ActionResult SuaNganhDT(int? id)
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

        public ActionResult XoaNganhDT(int? id)
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

        // POST: Faculty/NganhDaoTaos/Delete/5
        [HttpPost, ActionName("XoaNganhDT")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoaNganhDT(int id)
        {
            NganhDaoTao nganhDaoTao = db.NganhDaoTaos.Find(id);
            db.NganhDaoTaos.Remove(nganhDaoTao);
            db.SaveChanges();
            return RedirectToAction("ListNganhDT");
        }

        public ActionResult ListCTDaoTao()
        {
            var ListChuongTrinhDaoTao = db.ChuongTrinhDaoTaos.Include(h => h.NganhDaoTao).Include(h => h.KhoaDaoTao).Include(h => h.HocKyDaoTao);
            ViewData["NganhDaoTao"] = db.NganhDaoTaos.ToList();
            ViewData["KhoaDaoTao"] = db.KhoaDaoTaos.ToList();
            ViewData["HocKyDaoTao"] = db.HocKyDaoTaos.ToList();
            return View(ListChuongTrinhDaoTao.ToList());
        }

        public ActionResult UploadCTDaoTao(FormCollection formCollection, string Nganh, string Khoa, string HocKy)
        {
            if (Nganh is null)
            {
                throw new ArgumentNullException(nameof(Nganh));
            }

            if (Khoa is null)
            {
                throw new ArgumentNullException(nameof(Khoa));
            }

            if (HocKy is null)
            {
                throw new ArgumentNullException(nameof(HocKy));
            }
            if (Request != null)
            {
                ChuongTrinhDaoTao chuongTrinhDaoTao = new ChuongTrinhDaoTao();
                chuongTrinhDaoTao.KhoaDaoTao = db.KhoaDaoTaos.ToList().FirstOrDefault(s => s.Khoa == Khoa);
                chuongTrinhDaoTao.NganhDaoTao = db.NganhDaoTaos.ToList().FirstOrDefault(s => s.Nganh == Nganh);
                chuongTrinhDaoTao.HocKyDaoTao = db.HocKyDaoTaos.ToList().FirstOrDefault(s => s.HocKy.ToString() == HocKy);
                db.ChuongTrinhDaoTaos.Add(chuongTrinhDaoTao);
                db.SaveChanges();
                var CHUONGTRINHDAOTAO = db.ChuongTrinhDaoTaos.Where(s => s.NganhDaoTao.Nganh == Nganh).FirstOrDefault(s => s.KhoaDaoTao.Khoa == Khoa);

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
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        string KHOIKIENTHUC = "";
                        string HPBATBUOC = "";
                        string khoikienthuc = "";
                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            if (workSheet.Cells[rowIterator, 1].Value != null)
                            {
                                khoikienthuc = workSheet.Cells[rowIterator, 1].Value.ToString();
                            }
                            if (int.TryParse(khoikienthuc, out int stt))
                            {
                                HocPhanDaoTao hocPhanDaoTao = new HocPhanDaoTao();
                                if (workSheet.Cells[rowIterator, 2].Value != null)
                                {
                                    hocPhanDaoTao.MaHocPhan = workSheet.Cells[rowIterator, 2].Value.ToString();
                                }
                                if (workSheet.Cells[rowIterator, 3].Value != null)
                                {
                                    hocPhanDaoTao.TenHocPhan = workSheet.Cells[rowIterator, 3].Value.ToString();
                                }
                                if (workSheet.Cells[rowIterator, 4].Value != null)
                                {
                                    hocPhanDaoTao.SoTinChi = workSheet.Cells[rowIterator, 4].Value.ToString();
                                }
                                if (workSheet.Cells[rowIterator, 5].Value != null)
                                {
                                    var LoaiHP = workSheet.Cells[rowIterator, 5].Value.ToString();
                                    if (LoaiHP == "TC")
                                    {
                                        hocPhanDaoTao.HocPhanDaoTao2 = db.HocPhanDaoTaos.FirstOrDefault(s => s.TenHocPhan == HPBATBUOC);
                                    }
                                    else
                                    {
                                        HPBATBUOC = workSheet.Cells[rowIterator, 3].Value.ToString();
                                    }
                                }
                                if (workSheet.Cells[rowIterator, 9].Value != null)
                                {
                                    hocPhanDaoTao.HocKy = int.Parse(workSheet.Cells[rowIterator, 9].Value.ToString());
                                }
                                hocPhanDaoTao.KhoiKienThuc = db.KhoiKienThucs.FirstOrDefault(s => s.TenKhoiKienThuc == KHOIKIENTHUC);
                                db.HocPhanDaoTaos.Add(hocPhanDaoTao);
                                db.SaveChanges();
                            }
                            else
                            {
                                KhoiKienThuc taoKKT = new KhoiKienThuc();
                                taoKKT.MaKhoiKienThuc = khoikienthuc;
                                taoKKT.TenKhoiKienThuc = workSheet.Cells[rowIterator, 2].Value.ToString();
                                taoKKT.ChuongTrinhDaoTao = CHUONGTRINHDAOTAO;
                                db.KhoiKienThucs.Add(taoKKT);
                                db.SaveChanges();
                                KHOIKIENTHUC = taoKKT.TenKhoiKienThuc;
                            }
                        }
                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            if(workSheet.Cells[rowIterator, 6].Value != null)
                            {
                                RangBuocHocPhan rangBuocHocPhan = new RangBuocHocPhan();
                                string HocPhanRangBuoc = workSheet.Cells[rowIterator, 6].Value.ToString();
                                string HocPhan = workSheet.Cells[rowIterator, 3].Value.ToString();
                                string[] ListHP = HocPhanRangBuoc.Split(new char[] { ',' });
                                foreach(string HP in ListHP)
                                {
                                    var mahocphan = db.HocPhanDaoTaos.FirstOrDefault(s => s.MaHocPhan == HP);
                                    if (mahocphan == null)
                                    {
                                        var tenhocphan = db.HocPhanDaoTaos.FirstOrDefault(s => s.TenHocPhan == HP);
                                        if(tenhocphan != null)
                                        {
                                            rangBuocHocPhan.HocPhanDaoTao = tenhocphan;
                                            rangBuocHocPhan.HocPhanDaoTao1 = db.HocPhanDaoTaos.FirstOrDefault(s => s.TenHocPhan == HocPhan);
                                            rangBuocHocPhan.LoaiRangBuoc = "Tiên quyết";
                                            db.RangBuocHocPhans.Add(rangBuocHocPhan);
                                            db.SaveChanges();
                                        }
                                    }
                                    else
                                    {
                                        rangBuocHocPhan.HocPhanDaoTao = mahocphan;
                                        rangBuocHocPhan.HocPhanDaoTao1 = db.HocPhanDaoTaos.FirstOrDefault(s => s.TenHocPhan == HocPhan);
                                        rangBuocHocPhan.LoaiRangBuoc = "Tiên quyết";
                                        db.RangBuocHocPhans.Add(rangBuocHocPhan);
                                        db.SaveChanges();
                                    }
                                }
                            }
                            if (workSheet.Cells[rowIterator, 7].Value != null)
                            {
                                RangBuocHocPhan rangBuocHocPhan = new RangBuocHocPhan();
                                string HocPhanRangBuoc = workSheet.Cells[rowIterator, 7].Value.ToString();
                                string HocPhan = workSheet.Cells[rowIterator, 3].Value.ToString();
                                string[] ListHP = HocPhanRangBuoc.Split(new char[] { ',' });
                                foreach (string HP in ListHP)
                                {
                                    var mahocphan = db.HocPhanDaoTaos.FirstOrDefault(s => s.MaHocPhan == HP);
                                    if (mahocphan == null)
                                    {
                                        var tenhocphan = db.HocPhanDaoTaos.FirstOrDefault(s => s.TenHocPhan == HP);
                                        if (tenhocphan != null)
                                        {
                                            rangBuocHocPhan.HocPhanDaoTao = tenhocphan;
                                            rangBuocHocPhan.HocPhanDaoTao1 = db.HocPhanDaoTaos.FirstOrDefault(s => s.TenHocPhan == HocPhan);
                                            rangBuocHocPhan.LoaiRangBuoc = "Học trước";
                                            db.RangBuocHocPhans.Add(rangBuocHocPhan);
                                            db.SaveChanges();
                                        }
                                    }
                                    else
                                    {
                                        rangBuocHocPhan.HocPhanDaoTao = mahocphan;
                                        rangBuocHocPhan.HocPhanDaoTao1 = db.HocPhanDaoTaos.FirstOrDefault(s => s.TenHocPhan == HocPhan);
                                        rangBuocHocPhan.LoaiRangBuoc = "Học trước";
                                        db.RangBuocHocPhans.Add(rangBuocHocPhan);
                                        db.SaveChanges();
                                    }
                                }
                            }
                            if (workSheet.Cells[rowIterator, 8].Value != null)
                            {
                                RangBuocHocPhan rangBuocHocPhan = new RangBuocHocPhan();
                                string HocPhanRangBuoc = workSheet.Cells[rowIterator, 8].Value.ToString();
                                string HocPhan = workSheet.Cells[rowIterator, 3].Value.ToString();
                                string[] ListHP = HocPhanRangBuoc.Split(new char[] { ',' });
                                foreach (string HP in ListHP)
                                {
                                    var mahocphan = db.HocPhanDaoTaos.FirstOrDefault(s => s.MaHocPhan == HP);
                                    if (mahocphan == null)
                                    {
                                        var tenhocphan = db.HocPhanDaoTaos.FirstOrDefault(s => s.TenHocPhan == HP);
                                        if (tenhocphan != null)
                                        {
                                            rangBuocHocPhan.HocPhanDaoTao = tenhocphan;
                                            rangBuocHocPhan.HocPhanDaoTao1 = db.HocPhanDaoTaos.FirstOrDefault(s => s.TenHocPhan == HocPhan);
                                            rangBuocHocPhan.LoaiRangBuoc = "Song hành";
                                            db.RangBuocHocPhans.Add(rangBuocHocPhan);
                                            db.SaveChanges();
                                        }
                                    }
                                    else
                                    {
                                        rangBuocHocPhan.HocPhanDaoTao = mahocphan;
                                        rangBuocHocPhan.HocPhanDaoTao1 = db.HocPhanDaoTaos.FirstOrDefault(s => s.TenHocPhan == HocPhan);
                                        rangBuocHocPhan.LoaiRangBuoc = "Song hành";
                                        db.RangBuocHocPhans.Add(rangBuocHocPhan);
                                        db.SaveChanges();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return RedirectToAction("ListCTDaoTao");
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
