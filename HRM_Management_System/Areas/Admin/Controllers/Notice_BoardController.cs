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
    public class Notice_BoardController : Controller
    {
        private HRM_SystemEntities db = new HRM_SystemEntities();

        public ActionResult Index()
        {
            return View(db.Notice_Board.ToList());
        }


        public ActionResult Create()
        {
            ViewBag.depatrtaments = db.Departaments.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,notice_title,notice_content,notice_status")] Notice_Board notice_Board, FormCollection form)
        { 
            int depart_id = Convert.ToInt32(form["department"]);

            if (ModelState.IsValid)
            {
                if (depart_id==0)
                {
                    notice_Board.notice_depart_id = null;
                }
                else
                {
                    notice_Board.notice_depart_id = depart_id;
                }
                db.Notice_Board.Add(notice_Board);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notice_Board);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice_Board notice_Board = db.Notice_Board.Find(id);
            if (notice_Board == null)
            {
                return HttpNotFound();
            }
            ViewBag.depatrtaments = db.Departaments.ToList();
            return View(notice_Board);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,notice_title,notice_content,notice_status")] Notice_Board notice_Board, FormCollection form)
        {
            int depart_id = Convert.ToInt32(form["department"]);

            if (ModelState.IsValid)
            {
                if (depart_id == 0)
                {
                    notice_Board.notice_depart_id = null;
                }
                else
                {
                    notice_Board.notice_depart_id = depart_id;
                }
                db.Entry(notice_Board).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notice_Board);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice_Board notice_Board = db.Notice_Board.Find(id);
            if (notice_Board == null)
            {
                return HttpNotFound();
            }
            return View(notice_Board);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notice_Board notice_Board = db.Notice_Board.Find(id);
            db.Notice_Board.Remove(notice_Board);
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
