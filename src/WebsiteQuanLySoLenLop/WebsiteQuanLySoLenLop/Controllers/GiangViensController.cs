using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteQuanLySoLenLop.Models;

namespace WebsiteQuanLySoLenLop.Controllers
{
    public class GiangViensController : Controller
    {
        private QuanLySoLenLopEntities db = new QuanLySoLenLopEntities();

        // GET: GiangViens
        public ActionResult Index(string searchString)
        {
            if (Session["User"] != null)
            {
                var soLenLops = db.SoLenLops.Include(s => s.GiangVien).Include(s => s.Lop).Include(s => s.MonHoc).Include(s => s.Phong);
                var User = Session["User"] as WebsiteQuanLySoLenLop.Models.GiangVien;
                var MaGV = from i in db.SoLenLops select i;
                var MaLop = from i in db.SoLenLops select i;
                MaGV = MaGV.Where(i => i.MaGVGD.Contains(User.MaGVGD));
                if (string.IsNullOrEmpty(searchString) == false)
                {
                    MaLop = MaLop.Where(i => i.MaLop.Contains(searchString) && i.MaGVGD.Contains(User.MaGVGD));
                    return View(MaLop.ToList());
                }
                return View(MaGV.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: GiangViens/Details/5
        public ActionResult SoLenLopDetail(int? id)
        {
            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                SoLenLop soLenLop = db.SoLenLops.Find(id);
                if (soLenLop == null)
                {
                    return HttpNotFound();
                }
                return View(soLenLop);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: GiangViens/Create
        public ActionResult SoLenLopCreate()
        {
            if (Session["User"] != null)
            {
                ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "MaLop");
                ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "MaMH");
                ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "MaPhong");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: GiangViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SoLenLopCreate([Bind(Include = "ID,HocKy,NamHoc,Nhom,NgayLenLop,Buoi,SoTietDayLT,SoTietDayTH,SinhVienVang,Tomtatnoidung,MaMH,MaLop,MaPhong,MaGVGD")] SoLenLop soLenLop)
        {
            if (ModelState.IsValid)
            {
                var user = Session["User"] as WebsiteQuanLySoLenLop.Models.GiangVien;
                soLenLop.MaGVGD = user.MaGVGD;
                db.SoLenLops.Add(soLenLop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "MaLop", soLenLop.MaLop);
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "MaMH", soLenLop.MaMH);
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "MaPhong", soLenLop.MaPhong);
            return View(soLenLop);
        }

        // GET: GiangViens/Edit/5
        public ActionResult SoLenLopUpdate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoLenLop soLenLop = db.SoLenLops.Find(id);
            if (soLenLop == null)
            {
                return HttpNotFound();
            }

            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "MaLop", soLenLop.MaLop);
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "MaMH", soLenLop.MaMH);
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "MaPhong", soLenLop.MaPhong);
            return View(soLenLop);
        }

        // POST: SoLenLops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SoLenLopUpdate([Bind(Include = "ID,HocKy,NamHoc,Nhom,NgayLenLop,Buoi,SoTietDayLT,SoTietDayTH,SinhVienVang,Tomtatnoidung,MaMH,MaLop,MaPhong,MaGVGD")] SoLenLop soLenLop)
        {
            if (ModelState.IsValid)
            {
                var user = Session["User"] as WebsiteQuanLySoLenLop.Models.GiangVien;
                soLenLop.MaGVGD = user.MaGVGD;
                db.Entry(soLenLop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "MaLop", soLenLop.MaLop);
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "MaMH", soLenLop.MaMH);
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "MaPhong", soLenLop.MaPhong);
            return View(soLenLop);
        }

        // GET: GiangViens/Delete/5
        public ActionResult SoLenLopDelete(int? id)
        {
            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                SoLenLop soLenLop = db.SoLenLops.Find(id);
                if (soLenLop == null)
                {
                    return HttpNotFound();
                }
                return View(soLenLop);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: GiangViens/Delete/5
        [HttpPost, ActionName("SoLenLopDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SoLenLop soLenLop = db.SoLenLops.Find(id);
            db.SoLenLops.Remove(soLenLop);
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
