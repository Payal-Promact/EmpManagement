using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpManagement.Models
{
    public class Employee
    {
        //auto-increment
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage="Please enter Employee Name")]
        [MaxLength(30, ErrorMessage="Employee name cannot be more than 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage="Please enter Date field")]
        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",ApplyFormatInEditMode = true)]
        public DateTime DOJ { get; set; }

        [Required(ErrorMessage="Please enter Contact Number")]
        [MinLength(10,ErrorMessage="Contact number cannot be less than 10 digits")]
        [MaxLength(20,ErrorMessage="Contact number cannot be more than 20 characters")]
        [Column("ContactNum")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage="Please enter Salary")]
        public decimal Salary { get; set; }

        [ForeignKey("Department")]
        [Required(ErrorMessage="Please select Department from the list")]
        public int DepartmentID { get; set; }
   
        //Navigation property
        //Keeping track of the Department the employee belongs to
        public virtual Department Department { get; set; }

   
    }

}