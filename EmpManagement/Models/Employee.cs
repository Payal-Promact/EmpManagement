using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpManagement.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string EmpName { get; set; }
        public DateTime EmpDOJ { get; set; }
        public long EmpContactNo { get; set; }
        public decimal EmpSalary { get; set; }
        public int DeptID { get; set; }

        public virtual Department Department { get; set; }
    }

}