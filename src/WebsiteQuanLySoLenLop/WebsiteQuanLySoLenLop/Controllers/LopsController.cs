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
    public class LopsController : Controller
    {
        private QuanLySoLenLopEntities db = new QuanLySoLenLopEntities();

        // GET: Lops
        public ActionResult Index(string searchString)
        {
            if (Session["admin"] != null)
            {
                var TenLop = from i in db.Lops select i;
                if (string.IsNullOrEmpty(searchString) == false)
                {
                    TenLop = TenLop.Where(i => i.TenLop.Contains(searchString));
                }
                return View(db.Lops.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Lops/Details/5
        public ActionResult Details(string id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Lop lop = db.Lops.Find(id);
                if (lop == null)
                {
                    return HttpNotFound();
                }
                return View(lop);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Lops/Create
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

        // POST: Lops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLop,TenLop")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                db.Lops.Add(lop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lop);
        }

        // GET: Lops/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Lop lop = db.Lops.Find(id);
                if (lop == null)
                {
                    return HttpNotFound();
                }
                return View(lop);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Lops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLop,TenLop")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lop);
        }

        // GET: Lops/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Lop lop = db.Lops.Find(id);
                if (lop == null)
                {
                    return HttpNotFound();
                }
                return View(lop);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Lops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Lop lop = db.Lops.Find(id);
            db.Lops.Remove(lop);
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
