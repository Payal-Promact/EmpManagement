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
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage="Please enter Department name")]
        [MaxLength(25,ErrorMessage="Department name cannot be more than 25 characters")]
        public string Name { get; set; }

        //This is to maintain the many Employees associated with a Department entity
        public virtual ICollection<Employee> Employees { get; set; }
      
    }
}