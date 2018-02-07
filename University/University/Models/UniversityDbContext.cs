using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace University.Models
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<Faculty> Facultys { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Batch> Batchs { get; set; }
        public DbSet<User> Users { get; set; }

    }
}