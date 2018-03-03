using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRM_Management_System.Models;

namespace HRM_Management_System.Controllers
{
    public class PartialsController : Controller
    {
        HRM_SystemEntities db = new HRM_SystemEntities();

        public PartialViewResult Index()
        {

            int a_count = db.Awards.Where(a => a.award_emp_id == ProfileController.logined.id).Count();
            int l_count = db.Leave_App.Where(l => l.leave_emp_id == ProfileController.logined.id).Count();
            ViewBag.leave_count = l_count;
            ViewBag.award_count = a_count;
            return PartialView(ProfileController.logined);
        }

        public PartialViewResult Apply_Leave()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Apply_Leave(Leave_App leave)
        {
            int status_id = db.Leave_status.Where(l => l.status_name == "Waiting").First().id;
            leave.leave_emp_id = ProfileController.logined.id;
            leave.leave_status_id = status_id;
            db.Leave_App.Add(leave);
            db.SaveChanges();
            return RedirectToAction("My_Leave", "Profile");
        }

        public PartialViewResult Change_Password()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Change_Password(FormCollection form)
        {
            string password = form["password"];
            string confirem_password = form["confirem_password"];
            if (password != confirem_password) 
            {
                TempData["error"] = "confirem password not same password";
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                Employee emp = db.Employees.Find(ProfileController.logined.id);
                emp.emp_password = password;
                db.SaveChanges();
                TempData["success"] = "Your password changed with success";
                return RedirectToAction("Index", "Profile");
            } 
        }

        public PartialViewResult Log_Out()
        {
            return PartialView();
        }


    }
}