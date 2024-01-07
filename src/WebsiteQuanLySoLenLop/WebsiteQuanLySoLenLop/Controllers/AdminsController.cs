using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteQuanLySoLenLop.common;
using WebsiteQuanLySoLenLop.Models;

namespace WebsiteQuanLySoLenLop.Controllers
{
    public class AdminsController : Controller
    {
        private QuanLySoLenLopEntities db = new QuanLySoLenLopEntities();

        public ActionResult Index(string searchString)
        {
            if (Session["admin"] != null)
            {
                var TenGV = from i in db.GiangViens select i;
                if (string.IsNullOrEmpty(searchString) == false)
                {
                    TenGV = TenGV.Where(i => i.HoTenGVGD.Contains(searchString));
                }
                return View(TenGV.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        // GET: Admins/GiangVienDetail/5
        public ActionResult GiangVienDetail(string id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                GiangVien giangVien = db.GiangViens.Find(id);
                if (giangVien == null)
                {
                    return HttpNotFound();
                }
                return View(giangVien);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult GiangVienAdd()
        {
            if (Session["admin"] != null)
            {
                ViewBag.MaBoMon = new SelectList(db.BoMons, "MaBoMon", "TenBoMon");
                ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: GiangViens/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GiangVienAdd([Bind(Include = "MaGVGD,HoTenGVGD,Matkhau,MaKhoa,MaBoMon")] GiangVien giangVien)
        {
            if (ModelState.IsValid)
            {
                var encryptedMd5Pas = Encryptor.EncryptMD5(giangVien.Matkhau);
                giangVien.Matkhau = encryptedMd5Pas;
                db.GiangViens.Add(giangVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBoMon = new SelectList(db.BoMons, "MaBoMon", "TenBoMon", giangVien.MaBoMon);
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", giangVien.MaKhoa);
            return View(giangVien);
        }


        // GET: GiangViens/Delete/5
        public ActionResult GiangVienDelete(string id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                GiangVien giangVien = db.GiangViens.Find(id);
                if (giangVien == null)
                {
                    return HttpNotFound();
                }
                return View(giangVien);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost, ActionName("GiangVienDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GiangVien giangVien = db.GiangViens.Find(id);
            db.GiangViens.Remove(giangVien);
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
