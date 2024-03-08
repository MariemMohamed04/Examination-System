using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
        }

        //public DbSet<Admin> Admins { get; set; }
        //public DbSet<Branch> Branches { get; set; }
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<Exam> Exams { get; set; }
        //public DbSet<Instructor> Instructors { get; set; }
        //public DbSet<Question> Questions { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Topic> Topics { get; set; }
    }
}
