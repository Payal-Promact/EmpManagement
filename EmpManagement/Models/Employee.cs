using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpManagement.Models
{
    public class Employee
    {
        //auto-increment
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage="Employee name cannot be more than 30 characters")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime DOJ { get; set; }

        [Required]
        [StringLength(20,ErrorMessage="Contact number cannot be more than 20 characters")]
        [Column("ContactNum")]
        public string ContactNo { get; set; }

        [Required]
        public decimal Salary { get; set; }

        //Foreign key
        public int DeptID { get; set; }
   
        //Navigation property
        public virtual Department Department { get; set; }
    }

}