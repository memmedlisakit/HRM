using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRM_Management_System.Models;
using HRM_Management_System.Areas.Admin.Filters;

namespace HRM_Management_System.Areas.Admin.Controllers
{
    [AdminFilter]
    public class AwardsController : Controller
    {
        private HRM_SystemEntities db = new HRM_SystemEntities();

        public ActionResult Index()
        {
            var awards = db.Awards.Include(a => a.Employee);
            return View(awards.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            return View(award);
        }

        public ActionResult Create()
        {
            ViewBag.award_emp_id = new SelectList(db.Employees, "id", "emp_fullname");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,award_emp_id,award_name,award_reason,award_cash_price,award_date")] Award award)
        {
            if (ModelState.IsValid)
            {
                db.Awards.Add(award);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.award_emp_id = new SelectList(db.Employees, "id", "emp_fullname", award.award_emp_id);
            return View(award);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            ViewBag.award_emp_id = new SelectList(db.Employees, "id", "emp_fullname", award.award_emp_id);
            return View(award);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,award_emp_id,award_name,award_reason,award_cash_price,award_date")] Award award)
        {
            if (ModelState.IsValid)
            {
                db.Entry(award).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.award_emp_id = new SelectList(db.Employees, "id", "emp_fullname", award.award_emp_id);
            return View(award);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            return View(award);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Award award = db.Awards.Find(id);
            db.Awards.Remove(award);
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
