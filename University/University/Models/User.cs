using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University.Models
{
    public class User
    {
        
        public int UserId { get; set; }

        [Display(Name= "First Name")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Display(Name ="University Card")]
        public string UniversityCard { get; set; }


        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        [Display(Name = "EP Number")]
        public int EPNumber { get; set; }

        public Faculty Faculty;
        [Required]
        
        public int FacultyId { get; set; }
        [Display(Name = "Faculty Name")]
        public string FacultyName { get; set; }

        [Required]
        public Department Department;
        
        public int DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Required]
        public Batch Batch;
        
        public int BatchId { get; set; }
        [Display(Name = "Batch Name")]
        public string BatchName { get; set; }

        public string Type { get; set; }
    }
}