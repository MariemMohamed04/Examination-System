using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface IQuestionRepo : IGenericRepo<Question>
    {
        public Question questionChoices(int qId);
        public List<Question> getAllQuestionsWithCourses();
        public List<Question> getAllQuestionsWithChoices();
    }
}
