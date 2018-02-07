using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string UniversityCard { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int EPNumber { get; set; }

        public Faculty Faculty;
        public int FacultyId { get; set; }

        public Department Department;
        public int DepartmentId { get; set; }

        public Batch Batch;
        public int BatchId { get; set; }

        public string Type { get; set; }
    }
}