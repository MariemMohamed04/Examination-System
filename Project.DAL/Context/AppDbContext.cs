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
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {


        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudent>().HasKey(c => new { c.StudentId, c.CourseId });
            modelBuilder.Entity<ExamStudent>().HasKey(c => new { c.StudentId, c.ExamId });
            modelBuilder.Entity<StudentExamQuestion>().HasKey(c => new { c.StudentId, c.ExamId, c.QuestionId });
            modelBuilder.Entity<CourseDepartment>().HasKey(c => new { c.CourseId, c.DepartmentId });
            modelBuilder.Entity<ExamQuestion>().HasKey(c => new { c.ExamId, c.QuestionId });
            modelBuilder.Entity<CourseInstructor>().HasKey(c => new { c.CourseId, c.InstructorId });
           // modelBuilder.Entity<CourseQuestion>().HasKey(c => new { c.CourseId, c.QuestionId });

            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Choice> Choices { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamStudent> ExamStudents { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<StudentExamQuestion> StudentExamQuestions { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<CourseDepartment> CourseDepartments { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }
       // public DbSet<CourseQuestion> CourseQuestions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Topic> Topics { get; set; }


    }
}
