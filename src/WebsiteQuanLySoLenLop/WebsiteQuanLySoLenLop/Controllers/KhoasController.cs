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
    public class KhoasController : Controller
    {
        private QuanLySoLenLopEntities db = new QuanLySoLenLopEntities();

        // GET: Khoas
        public ActionResult Index(string searchString)
        {
            if (Session["admin"] != null)
            {
                var TenKhoa = from i in db.Khoas select i;
                if (string.IsNullOrEmpty(searchString) == false)
                {
                    TenKhoa = TenKhoa.Where(i => i.TenKhoa.Contains(searchString));
                }
                return View(db.Khoas.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Khoas/Details/5
        public ActionResult Details(string id)
        {
            if (Session["admin"] != null)
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
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Khoas/Create
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

        // POST: Khoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhoa,TenKhoa")] Khoa khoa)
        {
            if (ModelState.IsValid)
            {
                db.Khoas.Add(khoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khoa);
        }

        // GET: Khoas/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["admin"] != null)
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
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Khoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhoa,TenKhoa")] Khoa khoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khoa);
        }

        // GET: Khoas/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["admin"] != null)
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
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Khoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Khoa khoa = db.Khoas.Find(id);
            db.Khoas.Remove(khoa);
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
