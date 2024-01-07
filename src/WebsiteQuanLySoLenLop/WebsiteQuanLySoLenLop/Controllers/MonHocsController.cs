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
    public class MonHocsController : Controller
    {
        private QuanLySoLenLopEntities db = new QuanLySoLenLopEntities();

        // GET: MonHocs
        public ActionResult Index(string searchString)
        {
            if (Session["admin"] != null)
            {
                var TenMH = from i in db.MonHocs select i;
                if (string.IsNullOrEmpty(searchString) == false)
                {
                    TenMH = TenMH.Where(i => i.TenMH.Contains(searchString));
                }
                return View(db.MonHocs.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: MonHocs/Details/5
        public ActionResult Details(string id)
        {
            if (Session["admin"] != null)
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
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: MonHocs/Create
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

        // POST: MonHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMH,TenMH,SoTietLT,SoTietTH")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                db.MonHocs.Add(monHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monHoc);
        }

        // GET: MonHocs/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["admin"] != null)
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
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: MonHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMH,TenMH,SoTietLT,SoTietTH")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monHoc);
        }

        // GET: MonHocs/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["admin"] != null)
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
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: MonHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MonHoc monHoc = db.MonHocs.Find(id);
            db.MonHocs.Remove(monHoc);
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
