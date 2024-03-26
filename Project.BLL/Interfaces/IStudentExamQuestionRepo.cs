using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface IStudentExamQuestionRepo :IGenericRepo<StudentExamQuestion>
    {
        public StudentExamQuestion getByIds(int ExamId, int studentId, int QusId);
        public int deleteExamAnswers(int examId);
        public int deleteStudentAnswerOnQues(int questionId);
        public bool isStudentDoExam(int examId ,  int studentId);
    }
}
