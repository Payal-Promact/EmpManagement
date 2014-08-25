using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EmpManagement.Models;
using EmpManagement.DAL;
using System.Net;
using System.Data;

namespace EmpManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        //
        // GET: /Department/    
        public ViewResult Index()
        {
            List<Department> depts = db.Departments.ToList();
            return View(depts);
        }
      

        // GET:/Department/Details/2
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department dpt = db.Departments.Find(id);
            if(dpt == null)
            {
                return HttpNotFound();
            }
            return View(dpt);
        }

        // GET: /Department/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: /Department/Create/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department dp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Departments.Add(dp);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException de)
            {
                string msg = de.Message;
                ModelState.AddModelError("", "Unable to save changes");
                //  return msg;
            }
            return View(dp);

        }

        // GET:/Department/Edit/2
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department dp=db.Departments.Find(id);
            if(dp == null)
            {
                return HttpNotFound();
            }
            return View(dp);
        }

        // POST: /Department/Edit/2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department dp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(dp).State = EntityState.Modified;
                    int sv=db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException de)
            {
                //string msg = de.Message;
                ModelState.AddModelError("", "Unable to save changes");
                //  return msg;
            }
            return View(dp);

        }


        // GET: /Department/Delete/4
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department dp = db.Departments.Find(id);
            if(dp == null)
            {
                return HttpNotFound();
            }
            return View(dp);
        }


        // POST: /Department/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
           
                Department dp = db.Departments.Find(id);
                db.Departments.Remove(dp);
                db.SaveChanges();
               // return RedirectToAction("Delete", new { id = id, saveChangesError = true });
               
            return RedirectToAction("Index");
        }
    }
}
