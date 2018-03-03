using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRM_Management_System.Models;
using System.IO;
using HRM_Management_System.Areas.Admin.Filters;

namespace HRM_Management_System.Areas.Admin.Controllers
{ 
    [AdminFilter]
    public class EmployeesController : Controller
    {
        private HRM_SystemEntities db = new HRM_SystemEntities();

        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Departament).Include(e => e.Designation).Include(e => e.Gender);
            return View(employees.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        public ActionResult Create()
        {
            ViewBag.emp_dep_id = new SelectList(db.Departaments, "id", "depart_name");
            ViewBag.emp_desig_id = new SelectList(db.Designations, "id", "desig_name");
            ViewBag.emp_gender_id = new SelectList(db.Genders, "id", "gender_name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,emp_fullname,emp_fathername,emp_dateof_birth,emp_gender_id,emp_phone,emp_address,emp_email,emp_password,emp_dep_id,emp_desig_id,emp_date_of_joining,emp_exit_date,emp_work_status,emp_salary")] Employee employee,
            HttpPostedFileBase emp_photo, HttpPostedFileBase emp_resume, HttpPostedFileBase emp_offer_letter, HttpPostedFileBase emp_joining_letter, HttpPostedFileBase emp_contact_and_argue, HttpPostedFileBase emp_ID_proof)
        {
            ViewBag.emp_dep_id = new SelectList(db.Departaments, "id", "depart_name", employee.emp_dep_id);
            ViewBag.emp_desig_id = new SelectList(db.Designations, "id", "desig_name", employee.emp_desig_id);
            ViewBag.emp_gender_id = new SelectList(db.Genders, "id", "gender_name", employee.emp_gender_id);

            if (emp_photo!=null)
            {
                if (emp_photo.ContentType != "image/jpeg")
                {
                    ViewBag.photo_error = "File type jpg";
                    return View();
                }
                else
                {
                    string photo_name = DateTime.Now.ToString("MMddyyyyHHssmmffftt") + Path.GetFileName(emp_photo.FileName);
                    string p_path = Path.Combine(Server.MapPath("~/Uploads/"), photo_name);
                    emp_photo.SaveAs(p_path);
                    employee.emp_photo = photo_name;
                }

            }
            if (emp_resume!=null)
            {
                if (emp_resume.ContentType != "application/pdf")
                {
                    ViewBag.resume_error = "File type pdf";
                    return View();
                }
                else
                {
                    string resume_name = DateTime.Now.ToString("MMddyyyyHHssmmffftt") + Path.GetFileName(emp_resume.FileName);
                    string r_path = Path.Combine(Server.MapPath("~/Files/"), resume_name);
                    emp_resume.SaveAs(r_path);
                    employee.emp_resume = resume_name;
                }

            }
            if (emp_offer_letter!=null)
            {
                if (emp_offer_letter.ContentType != "application/pdf")
                {
                    ViewBag.letter_error = "File type pdf";
                    return View();
                }
                else
                {
                    string offer_name = DateTime.Now.ToString("MMddyyyyHHssmmffftt") + Path.GetFileName(emp_offer_letter.FileName);
                    string o_path = Path.Combine(Server.MapPath("~/Files/"), offer_name);
                    emp_offer_letter.SaveAs(o_path);
                    employee.emp_offer_letter = offer_name;
                }

            }
            if (emp_joining_letter!=null)
            {
                if (emp_joining_letter.ContentType != "application/pdf")
                {
                    ViewBag.joining_error = "File type pdf";
                    return View();
                }
                else
                {
                    string joining_name = DateTime.Now.ToString("MMddyyyyHHssmmffftt") + Path.GetFileName(emp_joining_letter.FileName);
                    string j_path = Path.Combine(Server.MapPath("~/Files/"), joining_name);
                    emp_joining_letter.SaveAs(j_path);
                    employee.emp_joining_letter = joining_name;
                }

            }
            if (emp_contact_and_argue!=null)
            {
                if (emp_contact_and_argue.ContentType != "application/pdf")
                {
                    ViewBag.argue_error = "File type pdf";
                    return View();
                }
                else
                {

                    string contact_name = DateTime.Now.ToString("MMddyyyyHHssmmffftt") + Path.GetFileName(emp_contact_and_argue.FileName);
                    string c_path = Path.Combine(Server.MapPath("~/Files/"), contact_name);
                    emp_contact_and_argue.SaveAs(c_path);
                    employee.emp_contact_and_argue = contact_name;
                }

            }
            if (emp_ID_proof!=null)
            {
                if (emp_ID_proof.ContentType != "application/pdf")
                {
                    ViewBag.proof_error = "File type pdf";
                    return View();
                }
                else
                { 
                    string proof_name = DateTime.Now.ToString("MMddyyyyHHssmmffftt") + Path.GetFileName(emp_ID_proof.FileName);
                    string pr_path = Path.Combine(Server.MapPath("~/Files/"), proof_name);
                    emp_ID_proof.SaveAs(pr_path);
                    employee.emp_ID_proof = proof_name;
                }
            } 

            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(employee);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.emp_dep_id = new SelectList(db.Departaments, "id", "depart_name", employee.emp_dep_id);
            ViewBag.emp_desig_id = new SelectList(db.Designations, "id", "desig_name", employee.emp_desig_id);
            ViewBag.emp_gender_id = new SelectList(db.Genders, "id", "gender_name", employee.emp_gender_id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,emp_fullname,emp_fathername,emp_dateof_birth,emp_gender_id,emp_phone,emp_address,emp_email,emp_password,emp_dep_id,emp_desig_id,emp_date_of_joining,emp_exit_date,emp_work_status,emp_salary")] Employee employee,
            HttpPostedFileBase emp_photo, HttpPostedFileBase emp_resume, HttpPostedFileBase emp_offer_letter, HttpPostedFileBase emp_joining_letter, HttpPostedFileBase emp_contact_and_argue, HttpPostedFileBase emp_ID_proof)
        {
            Employee selected = db.Employees.Find(employee.id);

            ViewBag.emp_dep_id = new SelectList(db.Departaments, "id", "depart_name", employee.emp_dep_id);
            ViewBag.emp_desig_id = new SelectList(db.Designations, "id", "desig_name", employee.emp_desig_id);
            ViewBag.emp_gender_id = new SelectList(db.Genders, "id", "gender_name", employee.emp_gender_id);

            if (emp_photo!=null)
            {
                if (emp_photo.ContentType != "image/jpeg")
                {
                    ViewBag.photo_error = "File type jpg";
                    return View();
                }
                else
                {
                    string photo_name = DateTime.Now.ToString("MMddyyyyHHssmmffftt") + Path.GetFileName(emp_photo.FileName);

                    string file_path = Path.Combine(Server.MapPath("~/Uploads/"), photo_name);
                    emp_photo.SaveAs(file_path);
                    selected.emp_photo = photo_name;
                }
            }
            if (emp_resume!=null)
            {
                if (emp_resume.ContentType != "application/pdf")
                {
                    ViewBag.resume_error = "File type pdf";
                    return View();
                }
                else
                {
                    string resume_name = DateTime.Now.ToString("MMddyyyyHHssmmffftt") + Path.GetFileName(emp_resume.FileName);

                    string file_path = Path.Combine(Server.MapPath("~/Files/"), resume_name);
                    emp_resume.SaveAs(file_path);
                    selected.emp_resume = resume_name;
                }
            }
            if (emp_offer_letter!=null)
            {
                if (emp_offer_letter.ContentType != "application/pdf")
                {
                    ViewBag.letter_error = "File type pdf";
                    return View();
                }
                else
                {
                    string offer_name = DateTime.Now.ToString("MMddyyyyHHssmmffftt") + Path.GetFileName(emp_offer_letter.FileName);

                    string file_path = Path.Combine(Server.MapPath("~/Files/"), offer_name);
                    emp_offer_letter.SaveAs(file_path);
                    selected.emp_offer_letter = offer_name;
                }
            }
            if (emp_joining_letter!=null)
            {
                if (emp_joining_letter.ContentType != "application/pdf")
                {
                    ViewBag.joining_error = "File type pdf";
                    return View();
                }
                else
                {
                    string joining_name = DateTime.Now.ToString("MMddyyyyHHssmmffftt") + Path.GetFileName(emp_joining_letter.FileName);

                    string file_path = Path.Combine(Server.MapPath("~/Files/"), joining_name);
                    emp_joining_letter.SaveAs(file_path);
                    selected.emp_joining_letter = joining_name;
                }
            }
            if (emp_contact_and_argue!=null)
            {
                if (emp_contact_and_argue.ContentType != "application/pdf")
                {
                    ViewBag.argue_error = "File type pdf";
                    return View();
                }
                else
                {
                    string contact_name = DateTime.Now.ToString("MMddyyyyHHssmmffftt") + Path.GetFileName(emp_contact_and_argue.FileName);

                    string file_path = Path.Combine(Server.MapPath("~/Files/"), contact_name);
                    emp_contact_and_argue.SaveAs(file_path);
                    selected.emp_contact_and_argue = contact_name;
                }
            }
            if (emp_ID_proof!=null)
            {
                if (emp_ID_proof.ContentType != "application/pdf")
                {
                    ViewBag.proof_error = "File type pdf";
                    return View();
                }
                else
                {
                    string proof_name = DateTime.Now.ToString("MMddyyyyHHssmmffftt") + Path.GetFileName(emp_ID_proof.FileName);

                    string file_path = Path.Combine(Server.MapPath("~/Files/"), proof_name);
                    emp_ID_proof.SaveAs(file_path);
                    selected.emp_ID_proof = proof_name;
                }
            }

            selected.emp_fullname = employee.emp_fullname;
            selected.emp_fathername = employee.emp_fathername;
            selected.emp_dateof_birth = employee.emp_dateof_birth;
            selected.emp_gender_id = employee.emp_gender_id;
            selected.emp_phone = employee.emp_phone;
            selected.emp_address = employee.emp_address;
            selected.emp_email = employee.emp_email;
            selected.emp_password = employee.emp_password;
            selected.emp_dep_id = employee.emp_dep_id;
            selected.emp_desig_id = employee.emp_desig_id;
            selected.emp_date_of_joining = employee.emp_date_of_joining;
            selected.emp_exit_date = employee.emp_exit_date;
            selected.emp_work_status = employee.emp_work_status;
            selected.emp_salary = employee.emp_salary;
             
            if (ModelState.IsValid)
            { 
                db.SaveChanges();
                return RedirectToAction("Index");
            }   
            return View(employee);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            db.Employees.Remove(employee);
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
