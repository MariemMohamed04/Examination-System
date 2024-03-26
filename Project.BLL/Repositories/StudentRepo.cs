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
    public class StudentRepo : GenericRepo<Student>, IStudentRepo
    {
        private readonly AppDbContext _context;

        public StudentRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Student getStudentByUserId(string userId)
        {
            return _context.Students.FirstOrDefault(u => u.UserId == userId); 
        }


        public void addStudentAnswers(StudentExamQuestion ans)
        {
            _context.StudentExamQuestions.Add(ans);
            _context.SaveChanges();
        }

        public bool getStudentAnswers(int examId , int studId )
        {
           return _context.StudentExamQuestions.Any(e=>e.ExamId == examId && e.StudentId ==studId);
        }
    }
}
