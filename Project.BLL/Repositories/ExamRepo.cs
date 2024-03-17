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





        public Exam getFirstExam(int courseId)
        {
            return _context.Exams.Include(c=>c.Course).FirstOrDefault(e=>e.CourseId == courseId);
        }
    }
}
