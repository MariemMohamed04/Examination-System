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
    public class StudentExamQuestionRepo : GenericRepo<StudentExamQuestion>,IStudentExamQuestionRepo
    {
        AppDbContext _context;
        public StudentExamQuestionRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public StudentExamQuestion getByIds(int ExamId, int studentId, int QusId)
        {
            return _context.StudentExamQuestions.SingleOrDefault(s => s.ExamId == ExamId && s.StudentId == studentId && s.QuestionId == QusId);
        }
    }
}
