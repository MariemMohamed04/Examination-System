using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface IExamQuestionRepo
    {
        public List<ExamQuestion> ExamQuestions(int examId);
        public int deleteQuestionFromExam(int quesId);
        public int deleteExamQuestions(int examId); 
    }
}
