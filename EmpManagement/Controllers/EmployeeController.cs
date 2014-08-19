using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpManagement.Models;
using EmpManagement.DAL;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Configuration;

namespace EmpManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();
        //
        // GET: /Employee/

      /*
        public ViewResult Index()
        {
            return View(db.Employees.ToList());
        }

      */


        public ActionResult Index()
        {
            IEnumerable<SelectListItem> items = db.Departments.Select(c => new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.Name

                });
            ViewBag.Departments = items;
            return View();
        }


        // GET: /Employee/Details/4
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee emp = db.Employees.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        //GET: /Employee/Create
        public ActionResult Create()
        {
           // ViewBag.DeptName = new SelectList(db.departments,"DeptName","DeptName");
            return View();
        }

        // POST: /Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpName,EmpDOJ,EmpContactNo,EmpSalary")] Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Employees.Add(emp);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException de)
            {
               // string msg = de.Message;
                ModelState.AddModelError("", "Unable to save changes");
               // return msg;

            }

            return View(emp);
        }


        // GET: /Employees/Edit/3
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee emp = db.Employees.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        // POST: /Employees/Edit/3
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmpName,EmpDOJ,EmpContactNo,EmpSalary")] Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException de)
            {               
                string msg=de.Message;
                ModelState.AddModelError("", "Unable to save changes");
               // return msg;
            }
            return View(emp);
        }


        // GET: /Employees/Delete/3
        public ActionResult Delete(int? id,bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if(saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed";
            }

            Employee emp = db.Employees.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        //POST: /Employees/Delete/3
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Employee emp = db.Employees.Find(id);
                db.Employees.Remove(emp);
                db.SaveChanges();
            }
            catch(DataException de)
            {
              //  string msg=de.Message;
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
               // return msg;
            }
            return RedirectToAction("Index");
        }

        
         /* Ensuring that database connections are not left open
         * and the resources they hold are freed up
         */

       /* protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }*/


    }
}
