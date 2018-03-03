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
    public class Leave_AppController : Controller
    {
        private HRM_SystemEntities db = new HRM_SystemEntities();

        public ActionResult Index()
        {
            
            var leave_App = db.Leave_App.Include(l => l.Employee).Include(l => l.Leave_status);
            return View(leave_App.ToList());
        } 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leave_App leave_App = db.Leave_App.Find(id);
            if (leave_App == null)
            {
                return HttpNotFound();
            }
            ViewBag.leave_emp_id = new SelectList(db.Employees, "id", "emp_fullname", leave_App.leave_emp_id);
            ViewBag.leave_status_id = new SelectList(db.Leave_status, "id", "status_name", leave_App.leave_status_id);
            return View(leave_App);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,leave_emp_id,leave_date,leave_reason,leave_status_id")] Leave_App leave_App)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leave_App).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.leave_emp_id = new SelectList(db.Employees, "id", "emp_fullname", leave_App.leave_emp_id);
            ViewBag.leave_status_id = new SelectList(db.Leave_status, "id", "status_name", leave_App.leave_status_id);
            return View(leave_App);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leave_App leave_App = db.Leave_App.Find(id);
            if (leave_App == null)
            {
                return HttpNotFound();
            }
            return View(leave_App);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Leave_App leave_App = db.Leave_App.Find(id);
            db.Leave_App.Remove(leave_App);
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
