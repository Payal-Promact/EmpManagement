namespace EmpManagement.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EmpManagement.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<EmpManagement.DAL.EmployeeDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmpManagement.DAL.EmployeeDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

                context.Employees.AddOrUpdate(i => i.EmpName,
                new Employee
                {
                    
                    EmpName = "Robert Johnson",
                    EmpDOJ = DateTime.Parse("2007-06-18"),
                    EmpContactNo = 8953421576,
                    EmpSalary = 35000,
                    
                },

                new Employee
                {
                    
                    EmpName = "Katherine Louis",
                    EmpDOJ = DateTime.Parse("2003-05-17"),
                    EmpContactNo = 7946132586,
                    EmpSalary = 60000,
                    
                }

              );

            context.Departments.AddOrUpdate(i => i.DeptName,
                new Department
                {
                    
                    DeptName = "Aeronautical",
                },
                new Department
                {
                    
                    DeptName = "MCA",
                }


                );

        }
    }
}

  