using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface IExamRepo : IGenericRepo<Exam>
    {

        public void generateExam(int examNo, int numOfTFQuestion, int numOfMCQQuestion, int courseId);

        public Exam getFirstExam(int courseId);

        public List<Question> getExamQuestions(int examId);


    }
}
