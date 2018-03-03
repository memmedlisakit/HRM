using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRM_Management_System.Models;
using HRM_Management_System.Areas.Admin.Filters;

namespace HRM_Management_System.Areas.Admin.Controllers
{

    public class AdminLoginController : Controller
    {
        HRM_SystemEntities db = new HRM_SystemEntities();
        public static Models.Admin LoginedAdmin = null;


        public ActionResult Login()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string email = form["admin_email"];
            string password = form["admin_password"];
            int count = db.Admins.Where(a => a.admin_email == email && a.admin_password == password).Count();
            if (count > 0) 
            {
                LoginedAdmin = db.Admins.FirstOrDefault(a => a.admin_email == email && a.admin_password == password);
                Session["Email"] = LoginedAdmin.admin_email;
                Session["Password"] = LoginedAdmin.admin_password;
                Session["Name"]= LoginedAdmin.admin_name;
                return RedirectToAction("Index", "AdminLogin");
            }
            ViewBag.error = "Email or Password incorrect";
            return View();
        }

        [AdminFilter]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            LoginedAdmin = null;
            Session["Email"] = null;
            Session["Password"] = null;
            Session["Name"] = null;
            return View("Login");
        }
    }
}