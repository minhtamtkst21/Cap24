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

        public ActionResult XemTruocCTDaoTao(FormCollection formCollection, string Nganh, string Khoa, string HocKy)
        {
            var ctdtao = new ChuongTrinhDaoTao();
            var listkkt = new List<KhoiKienThuc>();
            var listhp = new List<HocPhanDaoTao>();
            var listhprb = new List<RangBuocHocPhan>();

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
            var ctdt = db.ChuongTrinhDaoTaos.Where(s => s.KhoaDaoTao.Khoa.ToString() == Khoa.ToString()).Where(s => s.NganhDaoTao.Nganh == Nganh);
            if (Request != null)
            {
                ChuongTrinhDaoTao chuongTrinhDaoTao = new ChuongTrinhDaoTao();
                chuongTrinhDaoTao.KhoaDaoTao = db.KhoaDaoTaos.ToList().FirstOrDefault(s => s.Khoa.ToString() == Khoa.ToString()); ;
                chuongTrinhDaoTao.NganhDaoTao = db.NganhDaoTaos.ToList().FirstOrDefault(s => s.Nganh == Nganh);
                chuongTrinhDaoTao.HocKyDaoTao = db.HocKyDaoTaos.ToList().FirstOrDefault(s => s.HocKy.ToString() == HocKy);
                ctdtao = chuongTrinhDaoTao;
                var CHUONGTRINHDAOTAO = db.ChuongTrinhDaoTaos.Where(s => s.NganhDaoTao.Nganh == Nganh).FirstOrDefault(s => s.KhoaDaoTao.Khoa.ToString() == Khoa.ToString()); ;

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
                                        hocPhanDaoTao.HocPhanDaoTao2 = listhp.Where(s => s.KhoiKienThuc.ChuongTrinhDaoTao.ID == CHUONGTRINHDAOTAO.ID).Where(s => s.KhoiKienThuc.TenKhoiKienThuc == KHOIKIENTHUC).FirstOrDefault(s => s.TenHocPhan == HPBATBUOC);
                                    }
                                    else
                                    {
                                        HPBATBUOC = workSheet.Cells[rowIterator, 3].Value.ToString();
                                    }
                                }
                                else
                                {
                                    HPBATBUOC = workSheet.Cells[rowIterator, 3].Value.ToString();
                                }
                                if (workSheet.Cells[rowIterator, 9].Value != null)
                                {
                                    hocPhanDaoTao.HocKy = int.Parse(workSheet.Cells[rowIterator, 9].Value.ToString());
                                }
                                hocPhanDaoTao.KhoiKienThuc = listkkt.Where(s => s.ChuongTrinhDaoTao.ID == CHUONGTRINHDAOTAO.ID).FirstOrDefault(s => s.TenKhoiKienThuc == KHOIKIENTHUC);
                                listhp.Add(hocPhanDaoTao);
                            }
                            else
                            {
                                KhoiKienThuc taoKKT = new KhoiKienThuc();
                                taoKKT.MaKhoiKienThuc = khoikienthuc;
                                taoKKT.TenKhoiKienThuc = workSheet.Cells[rowIterator, 2].Value.ToString();
                                taoKKT.ChuongTrinhDaoTao = CHUONGTRINHDAOTAO;
                                listkkt.Add(taoKKT);
                                KHOIKIENTHUC = taoKKT.TenKhoiKienThuc;
                            }
                        }
                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            if (workSheet.Cells[rowIterator, 6].Value != null)
                            {
                                RangBuocHocPhan rangBuocHocPhan = new RangBuocHocPhan();
                                string HocPhanRangBuoc = workSheet.Cells[rowIterator, 6].Value.ToString();
                                string HocPhan = workSheet.Cells[rowIterator, 3].Value.ToString();
                                string[] ListHP = HocPhanRangBuoc.Split(new char[] { ',' });
                                foreach (string HP in ListHP)
                                {
                                    var mahocphan = listhp.Where(s => s.KhoiKienThuc.ChuongTrinhDaoTao.ID == CHUONGTRINHDAOTAO.ID).FirstOrDefault(s => s.MaHocPhan == HP);
                                    if (mahocphan == null)
                                    {
                                        var tenhocphan = listhp.Where(s => s.KhoiKienThuc.ChuongTrinhDaoTao.ID == CHUONGTRINHDAOTAO.ID).FirstOrDefault(s => s.TenHocPhan.Contains(HP));
                                        if (tenhocphan != null)
                                        {
                                            rangBuocHocPhan.HocPhanDaoTao = tenhocphan;
                                            rangBuocHocPhan.HocPhanDaoTao1 = listhp.Where(s => s.KhoiKienThuc.ChuongTrinhDaoTao.ID == CHUONGTRINHDAOTAO.ID).FirstOrDefault(s => s.TenHocPhan == HocPhan);
                                            rangBuocHocPhan.LoaiRangBuoc = "Tiên quyết";
                                            listhprb.Add(rangBuocHocPhan);
                                        }
                                    }
                                    else
                                    {
                                        rangBuocHocPhan.HocPhanDaoTao = mahocphan;
                                        rangBuocHocPhan.HocPhanDaoTao1 = listhp.Where(s => s.KhoiKienThuc.ChuongTrinhDaoTao.ID == CHUONGTRINHDAOTAO.ID).FirstOrDefault(s => s.TenHocPhan == HocPhan);
                                        rangBuocHocPhan.LoaiRangBuoc = "Tiên quyết";
                                        listhprb.Add(rangBuocHocPhan);
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
                                    var mahocphan = listhp.Where(s => s.KhoiKienThuc.ChuongTrinhDaoTao.ID == CHUONGTRINHDAOTAO.ID).FirstOrDefault(s => s.MaHocPhan == HP);
                                    if (mahocphan == null)
                                    {
                                        var tenhocphan = listhp.Where(s => s.KhoiKienThuc.ChuongTrinhDaoTao.ID == CHUONGTRINHDAOTAO.ID).FirstOrDefault(s => s.TenHocPhan.Contains(HP));
                                        if (tenhocphan != null)
                                        {
                                            rangBuocHocPhan.HocPhanDaoTao = tenhocphan;
                                            rangBuocHocPhan.HocPhanDaoTao1 = listhp.Where(s => s.KhoiKienThuc.ChuongTrinhDaoTao.ID == CHUONGTRINHDAOTAO.ID).FirstOrDefault(s => s.TenHocPhan == HocPhan);
                                            rangBuocHocPhan.LoaiRangBuoc = "Học trước";
                                            listhprb.Add(rangBuocHocPhan);
                                        }
                                    }
                                    else
                                    {
                                        rangBuocHocPhan.HocPhanDaoTao = mahocphan;
                                        rangBuocHocPhan.HocPhanDaoTao1 = listhp.Where(s => s.KhoiKienThuc.ChuongTrinhDaoTao.ID == CHUONGTRINHDAOTAO.ID).FirstOrDefault(s => s.TenHocPhan == HocPhan);
                                        rangBuocHocPhan.LoaiRangBuoc = "Học trước";
                                        listhprb.Add(rangBuocHocPhan);
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
                                    var mahocphan = listhp.Where(s => s.KhoiKienThuc.ChuongTrinhDaoTao.ID == CHUONGTRINHDAOTAO.ID).FirstOrDefault(s => s.MaHocPhan == HP);
                                    if (mahocphan == null)
                                    {
                                        var tenhocphan = listhp.Where(s => s.KhoiKienThuc.ChuongTrinhDaoTao.ID == CHUONGTRINHDAOTAO.ID).FirstOrDefault(s => s.TenHocPhan.Contains(HP));
                                        if (tenhocphan != null)
                                        {
                                            rangBuocHocPhan.HocPhanDaoTao = tenhocphan;
                                            rangBuocHocPhan.HocPhanDaoTao1 = listhp.Where(s => s.KhoiKienThuc.ChuongTrinhDaoTao.ID == CHUONGTRINHDAOTAO.ID).FirstOrDefault(s => s.TenHocPhan == HocPhan);
                                            rangBuocHocPhan.LoaiRangBuoc = "Song hành";
                                            listhprb.Add(rangBuocHocPhan);
                                        }
                                    }
                                    else
                                    {
                                        rangBuocHocPhan.HocPhanDaoTao = mahocphan;
                                        rangBuocHocPhan.HocPhanDaoTao1 = listhp.Where(s => s.KhoiKienThuc.ChuongTrinhDaoTao.ID == CHUONGTRINHDAOTAO.ID).FirstOrDefault(s => s.TenHocPhan == HocPhan);
                                        rangBuocHocPhan.LoaiRangBuoc = "Song hành";
                                        listhprb.Add(rangBuocHocPhan);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            ViewData["Khoa"] = Khoa;
            ViewData["Nganh"] = Nganh;
            ViewData["ctdtao"] = ctdtao;
            ViewData["listkkt"] = listkkt;
            ViewData["listhp"] = listhp;
            ViewData["listhprb"] = listhprb;
            return View("XemTruocCTDT");
        }

        public ActionResult ChiTietCTDaoTao(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var ChuongTrinhDaoTao = db.ChuongTrinhDaoTaos.Find(id);
            if (ChuongTrinhDaoTao == null)
            {
                return RedirectToAction("ListCTDaoTao");
            }
            ViewData["KhoiKienThuc"] = db.KhoiKienThucs.Where(s => s.ChuongTrinhDaoTao.ID == id).ToList();
            ViewData["RangBuocHocPhan"] = db.RangBuocHocPhans.Where(s => s.HocPhanDaoTao.KhoiKienThuc.ChuongTrinhDaoTao.ID == id).ToList();
            ViewData["HocPhan"] = db.HocPhanDaoTaos.ToList();
            return View(ChuongTrinhDaoTao);
        }

        public ActionResult XuatCTDaoTao(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var chuongTrinhDaoTao = db.ChuongTrinhDaoTaos.Find(id);
            var khoiKienThuc = db.KhoiKienThucs.Where(s => s.ChuongTrinhDaoTao.ID == chuongTrinhDaoTao.ID);
            ExcelPackage ep = new ExcelPackage();
            var sheet = ep.Workbook.Worksheets.Add("Ngành " + chuongTrinhDaoTao.NganhDaoTao.Nganh + " Khóa " + chuongTrinhDaoTao.KhoaDaoTao.Khoa);

            sheet.Cells["A1"].Value = "STT";
            sheet.Cells["B1"].Value = "Mã HP";
            sheet.Cells["C1"].Value = "TÊN HỌC PHẦN";
            sheet.Cells["D1"].Value = "SỐ TC";
            sheet.Cells["E1"].Value = "BB/TC";
            sheet.Cells["F1"].Value = "Tiên quyết";
            sheet.Cells["G1"].Value = "Học trước";
            sheet.Cells["H1"].Value = "Song hành";
            sheet.Cells["I1"].Value = "Học kỳ";
            sheet.Cells["A1:I1"].Style.Font.Bold = true;

            int row = 2;
            int STT = 0;
            foreach (var khoikt in khoiKienThuc)
            {
                sheet.Cells[string.Format("A{0}", row)].Value = khoikt.MaKhoiKienThuc;
                sheet.Cells[string.Format("B{0}", row)].Value = khoikt.TenKhoiKienThuc;
                sheet.Cells[string.Format("A{0}:B{0}", row)].Style.Font.Bold = true;
                row++;
                var hocPhan = db.HocPhanDaoTaos.Where(s => s.KhoiKienThuc.ID == khoikt.ID);
                var rangBuocHocPhan = db.RangBuocHocPhans.ToList();
                foreach (var hp in hocPhan)
                {
                    if (hp.ID_HocPhanTuChon == null)
                    {
                        STT++;
                        sheet.Cells[string.Format("A{0}", row)].Value = STT;
                        sheet.Cells[string.Format("E{0}", row)].Value = "BB";
                    }
                    else
                    {
                        sheet.Cells[string.Format("E{0}", row)].Value = "TC";
                    }
                    sheet.Cells[string.Format("B{0}", row)].Value = hp.MaHocPhan;
                    sheet.Cells[string.Format("C{0}", row)].Value = hp.TenHocPhan;
                    sheet.Cells[string.Format("D{0}", row)].Value = hp.SoTinChi;
                    sheet.Cells[string.Format("I{0}", row)].Value = hp.HocKy;

                    string HPTienQuyet = "";
                    string HPHocTruoc = "";
                    string HPSongHanh = "";
                    foreach (var rbHocPhan in rangBuocHocPhan)
                    {
                        if (rbHocPhan.LoaiRangBuoc == "Tiên quyết" && rbHocPhan.HocPhanDaoTao1.ID == hp.ID)
                        {
                            if (HPTienQuyet != "")
                            {
                                HPTienQuyet += ",";
                            }
                            if (rbHocPhan.HocPhanDaoTao.MaHocPhan != null)
                            {
                                HPTienQuyet += rbHocPhan.HocPhanDaoTao.MaHocPhan;
                            }
                            else
                            {
                                HPTienQuyet += rbHocPhan.HocPhanDaoTao.TenHocPhan;
                            }
                        }
                        if (rbHocPhan.LoaiRangBuoc == "Học trước" && rbHocPhan.HocPhanDaoTao1.ID == hp.ID)
                        {
                            if (HPHocTruoc != "")
                            {
                                HPHocTruoc += ",";
                            }
                            if (rbHocPhan.HocPhanDaoTao.MaHocPhan != null)
                            {
                                HPHocTruoc += rbHocPhan.HocPhanDaoTao.MaHocPhan;
                            }
                            else
                            {
                                HPHocTruoc += rbHocPhan.HocPhanDaoTao.TenHocPhan;
                            }
                        }
                        if (rbHocPhan.LoaiRangBuoc == "Song hành" && rbHocPhan.HocPhanDaoTao1.ID == hp.ID)
                        {
                            if (HPSongHanh != "")
                            {
                                HPSongHanh += ",";
                            }
                            if (rbHocPhan.HocPhanDaoTao.MaHocPhan != null)
                            {
                                HPSongHanh += rbHocPhan.HocPhanDaoTao.MaHocPhan;
                            }
                            else
                            {
                                HPSongHanh += rbHocPhan.HocPhanDaoTao.TenHocPhan;
                            }
                        }
                    }
                    sheet.Cells[string.Format("F{0}", row)].Value = HPTienQuyet;
                    sheet.Cells[string.Format("G{0}", row)].Value = HPHocTruoc;
                    sheet.Cells[string.Format("H{0}", row)].Value = HPSongHanh;
                    row++;
                }
            }
            sheet.Cells["A:A"].AutoFitColumns();
            sheet.Cells["C:E"].AutoFitColumns();
            sheet.Cells["I:AZ"].AutoFitColumns();

            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment; filename=" + "Xuất học phần.xlsx");
            Response.BinaryWrite(ep.GetAsByteArray());
            Response.End();

            return RedirectToAction("ChiTietCTDaoTao", new { id });
        }

        public ActionResult InCTDaoTao(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var ChuongTrinhDaoTao = db.ChuongTrinhDaoTaos.Find(id);
            if (ChuongTrinhDaoTao == null)
            {
                return RedirectToAction("ListCTDaoTao");
            }
            ViewData["KhoiKienThuc"] = db.KhoiKienThucs.Where(s => s.ChuongTrinhDaoTao.ID == id).ToList();
            ViewData["RangBuocHocPhan"] = db.RangBuocHocPhans.Where(s => s.HocPhanDaoTao.KhoiKienThuc.ChuongTrinhDaoTao.ID == id).ToList();
            ViewData["HocPhan"] = db.HocPhanDaoTaos.ToList();
            return View(ChuongTrinhDaoTao);
        }

        public ActionResult XoaCTDT(int id)
        {
            var ChuongTrinhDaoTao = db.ChuongTrinhDaoTaos.Find(id);
            if (ChuongTrinhDaoTao == null)
            {
                return RedirectToAction("ListCTDaoTao");
            }
            var listkkt = db.KhoiKienThucs.Where(s => s.ChuongTrinhDaoTao.ID == ChuongTrinhDaoTao.ID);
            if (listkkt != null)
                foreach (var khoikienthuc in listkkt.ToList())
                {
                    var listhocphan = db.HocPhanDaoTaos.Where(s => s.KhoiKienThuc.ID == khoikienthuc.ID);
                    if (listhocphan != null)
                    {
                        foreach (var hocphan in listhocphan.ToList())
                        {
                            var listRangBuocHP = db.RangBuocHocPhans.Where(s => s.ID_HocPhan == hocphan.ID);
                            if (listRangBuocHP != null)
                                foreach (var rangbuoc in listRangBuocHP.ToList())
                                {
                                    db.RangBuocHocPhans.Remove(rangbuoc);
                                    db.SaveChanges();
                                }
                        }
                        foreach(var hocphan in listhocphan.OrderByDescending(s => s.ID).ToList())
                        {
                            db.HocPhanDaoTaos.Remove(hocphan);
                            db.SaveChanges();
                        }
                    }
                    db.KhoiKienThucs.Remove(khoikienthuc);
                    db.SaveChanges();
                }
            db.ChuongTrinhDaoTaos.Remove(ChuongTrinhDaoTao);
            db.SaveChanges();
            return RedirectToAction("ChiTietCTDaoTao", new { id });
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
