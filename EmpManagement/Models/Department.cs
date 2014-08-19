using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [StringLength(25,ErrorMessage="Department name cannot be more than 25 characters")]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}