using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM_Management_System.Controllers
{
    public class UserFilter : ActionFilterAttribute
    {
        private string rootUrl = "/Profile/Login";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        { 
            if (HttpContext.Current.Session["user_email"] == null || HttpContext.Current.Session["user_password"] == null) 
            {
                filterContext.Result = new RedirectResult(rootUrl);
                return;
            }

            if (HttpContext.Current.Session["user_email"].ToString() != ProfileController.logined.emp_email||HttpContext.Current.Session["user_password"].ToString()!=ProfileController.logined.emp_password)
            {
                filterContext.Result = new RedirectResult(rootUrl);
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}