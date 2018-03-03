using HRM_Management_System.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM_Management_System.Areas.Admin.Filters
{
    public class AdminFilter : ActionFilterAttribute
    { 
        private string rootUrl = "/Admin/AdminLogin/Login";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Email"] == null || HttpContext.Current.Session["Password"] == null || HttpContext.Current.Session["Name"] == null)  
            {
                filterContext.Result = new RedirectResult(rootUrl);
                return;
            }

            if (HttpContext.Current.Session["Email"].ToString() != AdminLoginController.LoginedAdmin.admin_email || HttpContext.Current.Session["Password"].ToString() != AdminLoginController.LoginedAdmin.admin_password || HttpContext.Current.Session["Name"].ToString() != AdminLoginController.LoginedAdmin.admin_name ) 
            {
                filterContext.Result = new RedirectResult(rootUrl);
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}