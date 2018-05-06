using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Display(Name="Department Name")]
        public string DepartmentName { get; set; }

      

        public Faculty Faculty;
        public int FacultyId { get; set; }
        [Display(Name = "Faculty Name")]
        public string FacultyName { get; set; }
    }
}