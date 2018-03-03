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
    public class DepartamentsController : Controller
    {
        private HRM_SystemEntities db = new HRM_SystemEntities();

        public ActionResult Index()
        {
            return View(db.Departaments.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departament departament = db.Departaments.Find(id);
            if (departament == null)
            {
                return HttpNotFound();
            }
            ViewBag.designations = db.Designations.Where(d => d.depart_id == id).ToList();
            return View(departament);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,depart_name")] Departament departament, FormCollection form)
        {
            List<string> designations = form["desig_name"].Split(',').ToList();
            if (ModelState.IsValid)
            {
                db.Departaments.Add(departament);
                db.SaveChanges();
                int id = db.Departaments.Where(d => d.depart_name == departament.depart_name).First().id;
                foreach (var item in designations)
                {
                    db.Designations.Add(new Designation
                    {
                        desig_name=item,
                        depart_id =id
                    });
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(departament);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departament departament = db.Departaments.Find(id);
            if (departament == null)
            {
                return HttpNotFound();
            }
            ViewBag.designations = db.Designations.Where(d => d.depart_id == id).ToList();
            return View(departament);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,depart_name")] Departament departament, FormCollection form)
        {
            List<string> designations = form["desig_name"].Split(',').ToList();
            if (ModelState.IsValid)
            {
                db.Entry(departament).State = EntityState.Modified;
                db.SaveChanges();
                List<Designation> desigs = db.Designations.Where(d => d.depart_id == departament.id).ToList();
                for (int i = 0; i < desigs.Count; i++) 
                {
                    desigs[i].desig_name = designations[i];
                    db.SaveChanges();
                }


                return RedirectToAction("Index");
            }
            return View(departament);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departament departament = db.Departaments.Find(id);
            if (departament == null)
            {
                return HttpNotFound();
            }
            return View(departament);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<Designation> desigs = db.Designations.Where(d => d.depart_id == id).ToList();
            foreach (var item in desigs)
            {
                db.Designations.Remove(item);
                db.SaveChanges();
            }
            Departament departament = db.Departaments.Find(id);
            db.Departaments.Remove(departament);
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
