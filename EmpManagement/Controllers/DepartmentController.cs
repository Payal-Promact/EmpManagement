using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EmpManagement.Models;
using EmpManagement.DAL;
using System.Net;

namespace EmpManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        //
        // GET: /Department/
        public ViewResult Index()
        {
            return View(db.Departments.ToList());
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
        [HttpPost,ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,DeptName")] Department dp)
        {
            if(ModelState.IsValid)
            {
                db.Departments.Add(dp);
                db.SaveChanges();
                return RedirectToAction("Index");
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
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DeptName")] Department dp)
        {
            if(ModelState.IsValid)
            {
                db.Entry(dp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Department dp = db.Departments.Find(id);
            db.Departments.Remove(dp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
