using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EmpManagement.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web.Mvc;

namespace EmpManagement.DAL
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
            : base("EmployeeDBContext")
        {
            // Database.SetInitializer<EmployeeDBContext>(new CreateDatabaseIfNotExists<EmployeeDBContext>());
            Database.SetInitializer<EmployeeDBContext>(new DropCreateDatabaseIfModelChanges<EmployeeDBContext>());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
