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
        [Display(Name = "Faculty Name")]
        public int FacultyId { get; set; }
        public int FacultyName { get; set; }

        [Required]
        public Department Department;
        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }
        public int DepartmentName { get; set; }

        [Required]
        public Batch Batch;
        [Display(Name = "Batch Name")]
        public int BatchId { get; set; }
        public int BatchName { get; set; }

        public string Type { get; set; }
    }
}