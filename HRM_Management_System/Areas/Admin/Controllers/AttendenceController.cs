using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRM_Management_System.Models;
using HRM_Management_System.Areas.Admin.Filters;

namespace HRM_Management_System.Areas.Admin.Controllers
{
    [AdminFilter]
    public class AttendenceController : Controller
    {
        HRM_SystemEntities db = new HRM_SystemEntities();

        public ActionResult Index()
        {
            ViewBag.leave_types = db.Leave_type.ToList();
            return View(db.Employees.ToList());
        }

        [HttpPost]
        public ActionResult Save(FormCollection form)
        {
            if (form["employee_id"] != null) 
            {
                List<int> ids = new List<int>();
                string[] employee_id = form["employee_id"].Split(',');
                string[] leave_type_id = form["leave_type_id"].Split(',');
                string[] reasons = form["reason"].Split(',');
                int i = 0;
                foreach (var item in employee_id)
                {
                    db.Attendences.Add(new Attendence
                    {
                        atten_emp_id = Convert.ToInt32(item),
                        atten_leave_type_id = Convert.ToInt32(leave_type_id[i]),
                        atten_reason = reasons[i],
                        atten_status = false,
                        atten_date = DateTime.Now.Date
                    });
                    db.SaveChanges();
                    i++;
                    ids.Add(Convert.ToInt32(item));
                }


                List<Employee> employes = new List<Employee>();
                foreach (var item in db.Employees.ToList())
                {
                    if (!ids.Contains(item.id))
                    {
                        employes.Add(item);
                    } 
                }

                foreach (var item in employes)
                {
                    db.Attendences.Add(new Attendence {
                        atten_emp_id =item.id,
                        atten_leave_type_id=null,
                        atten_reason =null,
                        atten_status =true,
                        atten_date =DateTime.Now.Date
                    });
                    db.SaveChanges();
                }

                return Redirect("/Admin/Attendence/Index");
            }
            else
            {
                foreach (var item in db.Employees.ToList())
                {
                    db.Attendences.Add(new Attendence
                    {
                        atten_emp_id = item.id,
                        atten_status = true,
                        atten_reason = null,
                        atten_leave_type_id = null,
                        atten_date = DateTime.Now.Date
                    });
                    db.SaveChanges();
                }
                return Redirect("/Admin/Attendence/Index");
            }
        }


        public ActionResult View_Attendence()
        {
            return View(db.Attendences.ToList());
        }


        public ActionResult Delete(int? id)
        {
            Attendence atten = db.Attendences.Find(id);
            db.Attendences.Remove(atten);
            db.SaveChanges();
            return RedirectToAction("View_Attendence");
        }
        
    }
}