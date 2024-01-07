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
    public class PhongsController : Controller
    {
        private QuanLySoLenLopEntities db = new QuanLySoLenLopEntities();

        // GET: Phongs
        public ActionResult Index(string searchString)
        {
            if (Session["admin"] != null)
            {
                var TenMH = from i in db.MonHocs select i;
                if (string.IsNullOrEmpty(searchString) == false)
                {
                    TenMH = TenMH.Where(i => i.TenMH.Contains(searchString));
                }
                return View(db.Phongs.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Phongs/Details/5
        public ActionResult Details(string id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Phong phong = db.Phongs.Find(id);
                if (phong == null)
                {
                    return HttpNotFound();
                }
                return View(phong);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Phongs/Create
        public ActionResult Create()
        {
            if (Session["admin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Phongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhong,TenPhong")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                db.Phongs.Add(phong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phong);
        }

        // GET: Phongs/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Phong phong = db.Phongs.Find(id);
                if (phong == null)
                {
                    return HttpNotFound();
                }
                return View(phong);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Phongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhong,TenPhong")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phong);
        }

        // GET: Phongs/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Phong phong = db.Phongs.Find(id);
                if (phong == null)
                {
                    return HttpNotFound();
                }
                return View(phong);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Phongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Phong phong = db.Phongs.Find(id);
            db.Phongs.Remove(phong);
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
