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
    public class StudentExamQuestionRepo : GenericRepo<StudentExamQuestion>, IStudentExamQuestionRepo
    {
        AppDbContext _context;
        public StudentExamQuestionRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public int deleteExamAnswers(int examId)
        {
            var answers = _context.StudentExamQuestions.Where(e=>e.ExamId == examId);
            foreach(var item in answers)
            {
                _context.StudentExamQuestions.Remove(item);
            }
            return _context.SaveChanges();
        }

        public int deleteStudentAnswerOnQues(int questionId)
        {
            var answer = _context.StudentExamQuestions.FirstOrDefault(e => e.QuestionId == questionId);
            if(answer != null)
            {
                _context.StudentExamQuestions.Remove(answer);
                return _context.SaveChanges();
            }
            return _context.SaveChanges();
        }

        public StudentExamQuestion getByIds(int ExamId, int studentId, int QusId)
        {
            return _context.StudentExamQuestions.SingleOrDefault(s => s.ExamId == ExamId && s.StudentId == studentId && s.QuestionId == QusId);
        }

        public bool isStudentDoExam(int examId, int studentId)
        {
            return _context.StudentExamQuestions.Any(e => e.ExamId == examId && e.StudentId==studentId);
        }
    }
}
