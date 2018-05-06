using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University.Models
{
    public class Faculty
    {
        
        public int FacultyId { get; set; }

        [Display(Name="Faculty Name")]
        public string FacultyName { get; set; }

    }
}