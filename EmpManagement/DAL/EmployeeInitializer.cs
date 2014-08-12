using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EmpManagement.Models;

namespace EmpManagement.DAL
{
    public class EmployeeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EmployeeDBContext>
    {
        protected override void Seed(EmployeeDBContext context)
        {
            var departments = new List<Department>
            {
                new Department{ID=101,DeptName="IT",},
                new Department{ID=103,DeptName="Computer",},
                new Department{ID=105,DeptName="Electrical",},
            };

            departments.ForEach(e => context.Departments.Add(e));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee{ID=1201,EmpName="Hillary Johnson",EmpDOJ=DateTime.Parse("2002-07-02"),EmpContactNo=9875864253,EmpSalary=30000,DeptID=101,},
                new Employee{ID=1403,EmpName="Kiera Williams",EmpDOJ=DateTime.Parse("2004-08-03"),EmpContactNo=8745961653,EmpSalary=45000,DeptID=105,},
            };

            employees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();



        }

    }
}
