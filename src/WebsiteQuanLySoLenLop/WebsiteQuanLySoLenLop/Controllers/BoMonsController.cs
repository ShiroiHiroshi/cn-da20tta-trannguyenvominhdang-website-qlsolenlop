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
    public class BoMonsController : Controller
    {
        private QuanLySoLenLopEntities db = new QuanLySoLenLopEntities();

        // GET: BoMons
        public ActionResult Index(string searchString)
        {
            if (Session["admin"] != null)
            {
                var TenBoMon = from i in db.BoMons select i;
                if (string.IsNullOrEmpty(searchString) == false)
                {
                    TenBoMon = TenBoMon.Where(i => i.TenBoMon.Contains(searchString));
                }
                return View(db.BoMons.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: BoMons/Details/5
        public ActionResult Details(string id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                BoMon boMon = db.BoMons.Find(id);
                if (boMon == null)
                {
                    return HttpNotFound();
                }
                return View(boMon);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: BoMons/Create
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

        // POST: BoMons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBoMon,TenBoMon")] BoMon boMon)
        {
            if (ModelState.IsValid)
            {
                db.BoMons.Add(boMon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boMon);
        }

        // GET: BoMons/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                BoMon boMon = db.BoMons.Find(id);
                if (boMon == null)
                {
                    return HttpNotFound();
                }
                return View(boMon);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: BoMons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBoMon,TenBoMon")] BoMon boMon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boMon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boMon);
        }

        // GET: BoMons/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                BoMon boMon = db.BoMons.Find(id);
                if (boMon == null)
                {
                    return HttpNotFound();
                }
                return View(boMon);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: BoMons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BoMon boMon = db.BoMons.Find(id);
            db.BoMons.Remove(boMon);
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
