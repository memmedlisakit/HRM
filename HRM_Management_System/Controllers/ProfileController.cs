using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRM_Management_System.Models;
using HRM_Management_System.ViewModels;

namespace HRM_Management_System.Controllers
{
    public class ProfileController : Controller
    {
        HRM_SystemEntities db = new HRM_SystemEntities();
        public static Employee logined = null;

        [UserFilter]
        [HttpGet]
        public ActionResult Index()
        {
            ProfileViewModel vm = new ProfileViewModel();
            vm._employe = logined;
            vm._awards = db.Awards.ToList();
            vm._holidays = db.Holidays.OrderByDescending(h=>h.holiday_date).ToList();
            vm._notices = db.Notice_Board.Where(n => n.notice_depart_id == null || n.notice_depart_id == logined.emp_dep_id).ToList();
            return View(vm);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string email = form["email"];
            string password = form["password"];
            int count = db.Employees.Where(e => e.emp_email == email && e.emp_password == password).Count();
            if (count > 0) 
            {
                logined = db.Employees.FirstOrDefault(e => e.emp_email == email && e.emp_password == password);
                Session["user_email"] = logined.emp_email;
                Session["user_password"] = logined.emp_password;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "Email or password incorrect";
                return View();
            }
        }

        [UserFilter]
        public ActionResult My_Leave()
        { 
            return View(db.Leave_App.Where(l=>l.leave_emp_id==ProfileController.logined.id).ToList());
        }

        [UserFilter]
        public ActionResult Logout()
        {
            logined = null;
            Session["user_email"] = null;
            Session["user_password"] = null;
            return View("Login");
        }
    }
}