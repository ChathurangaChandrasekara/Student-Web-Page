using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University.Models
{
    public class Batch
    {
        public int BatchId { get; set; }
        [Display(Name="Batch Name")]
        public string BatchName { get; set; }

        //public Faculty Faculty;
        //public int FacultyId { get; set; }

        //public Department department;
        //public int DepartmentId { get; set; }
    }
}