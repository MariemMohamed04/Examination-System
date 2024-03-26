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

        public int deleteQuestionFromExam(int quesId)
        {
            var ques = _Context.ExamQuestions.FirstOrDefault(e => e.QuestionId == quesId); 
            if(ques != null)
                _Context.ExamQuestions.Remove(ques);
            return _Context.SaveChanges();
        }

        public int deleteExamQuestions(int examId)
        {
            var questions = _Context.ExamQuestions.Where(e => e.ExamId == examId);
            foreach (var item in questions)
            {
                _Context.ExamQuestions.Remove(item);
            }
            return _Context.SaveChanges();
        }

    }
}
