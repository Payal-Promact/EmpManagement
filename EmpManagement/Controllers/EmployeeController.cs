﻿using System;
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
        

        // GET: /Employee/Index
        public ViewResult Index()
        {
            var emp = db.Employees.ToList();
            var dp = db.Departments.ToList();
            if (dp.Count == 0)
            {
               
                return View(emp);
            }
            else
            {
                return View(emp);
            }
         }

        //filling the dropdown list from database
        public List<Department> getDepartmentList()
        {
            var dp = db.Departments.ToList();
            using(db)
            {
                if (dp.Count == 0)
                {
                   return null;
                }
                else
                {
                    return
                        (from dpt in db.Departments select dpt).ToList();
                }
            }
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
            var departments = db.Departments.ToList();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View();
        }

        // POST: /Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            var departments = db.Departments.ToList();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");

            if (ModelState.IsValid)
            {
               // alert('Yes ModelState is valid');
                if (db.Employees.Any(model => model.DepartmentID.Equals(emp.DepartmentID)))
                {
                   return View(emp);
                }
                else
                {
                    db.Employees.Add(emp);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(emp);

        }


        // GET: /Employees/Edit/3
        public ActionResult Edit(int? id)
        {
            var departments = db.Departments.ToList();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
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

        public ActionResult Edit(Employee emp)
        {
            var departments = db.Departments.ToList();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            //  var errors = ModelState.Values.SelectMany(v => v.Errors);
            try
            {
                /*The ModelState.IsValid internally checks the Values.All(modelState => 
                 * modelState.Errors.Count == 0) expression..
                 * Because there was no input,the values collection will be empty
                 * so modelState.isvalid will return true..
                 */

                if (ModelState.IsValid)
                {
                    db.Entry(emp).State = EntityState.Modified;
                    int sv = db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(emp);
                }
                
            }
            catch (DataException /* de */)
            {
                ModelState.AddModelError("", "Unable to save changes .. Try again");
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
                ViewBag.ErrorMessage = "Delete failed or try again";
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
            catch (DataException /*de*/)
            {
                return RedirectToAction("Delete", new { id = id, errorinsavechanges = true });
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
