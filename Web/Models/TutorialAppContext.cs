using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class TutorialAppContext : DbContext
    {
        public TutorialAppContext() : base("default")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}