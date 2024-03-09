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
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=. ;Database=ExaminationSystemDB ; Integrated Security =true ; TrustServerCertificate=True ;");
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudent>().HasKey(c => new { c.StudentId, c.CourseId });
            modelBuilder.Entity<ExamStudent>().HasKey(c => new { c.StudentId, c.ExamId });
            modelBuilder.Entity<StudentExamQuestion>().HasKey(c => new { c.StudentId, c.ExamId, c.QuestionId });


            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Choice> Choices { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamStudent> ExamStudents { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<StudentExamQuestion> StudentExamQuestions { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Topic> Topics { get; set; }


    }
}
