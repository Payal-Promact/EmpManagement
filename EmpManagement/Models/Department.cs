using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpManagement.Models
{
    public class Department
    {
        //auto-increment
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string DeptName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}