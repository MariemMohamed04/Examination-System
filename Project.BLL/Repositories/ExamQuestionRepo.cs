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
    public class ExamQuestionRepo : GenericRepo<ExamQuestion>, IExamQuestionRepo
    {
        AppDbContext _Context;
        public ExamQuestionRepo(AppDbContext context) : base(context)
        {
            _Context = context;
        }

        public List<ExamQuestion> ExamQuestions(int examId)
        {
            return _Context.ExamQuestions.Where(eq => eq.ExamId == examId).ToList();
        }
    }
}
