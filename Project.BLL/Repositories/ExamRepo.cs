using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Interfaces;
using Project.DAL.Context;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repositories
{
    public class ExamRepo : GenericRepo<Exam>, IExamRepo
    {
        private readonly AppDbContext _context;

        public ExamRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void generateExam(int examNo , int numOfTFQuestion , int numOfMCQQuestion , int courseId)
        {   
            _context.Database.ExecuteSqlInterpolated($"GenerateAnExam  {examNo},{numOfTFQuestion},{numOfMCQQuestion},{courseId}");

        }

        public List<Question> getExamQuestions(int examId)
        {
            var examQuestions = _context.Questions
                .FromSqlRaw("EXEC GetExamQuestions @ExamNumber", new SqlParameter("@ExamNumber", examId))
                .ToList();
                

           // _context.Questions.Where(e=>e.CourseId == examId).ToList();

            return examQuestions; 
        }

        public List<Exam> getExamsCoursesByInstructor(List<Course> courses)
        {
            List<Exam> exams = new List<Exam>();
            foreach (var course in courses)
            {
                var examsCourses = _context.Exams.Where(e => e.CourseId == course.CourseId).ToList();
                if (examsCourses != null)
                {
                    foreach(var exam in examsCourses)
                    {
                        if(exam!=null)
                        exams.Add(exam);
                        
                    }
                }
            }
            return exams;
        }

        public Exam getFirstExam(int courseId , int StudentId)
        {
            var exam = _context.Exams.Include(c=>c.Course).FirstOrDefault(e=>e.CourseId == courseId 
            && !_context.StudentExamQuestions.Any(seq => seq.ExamId == e.ExamId && seq.StudentId == StudentId));
            return exam;
        }
    }
}
