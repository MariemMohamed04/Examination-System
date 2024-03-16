using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface IUnitOfWork
    {

        public ICourseRepo CourseRepo { get; }
        public ITopicRepo TopicRepo { get; }    

        public IBranchRepo BranchRepo { get; set; }
        public IDepartmentRepo DepartmentRepo { get; set; }

        public IStudentRepo StudentRepo { get; set; }
        public IInstructorRepo InstructorRepo { get; set; }
        public ICrsStudentRepo CrsStudentRepo { get; set; }
        public IExamQuestionRepo ExamQuestionRepo { get; set; }
        public IQuestionRepo QuestionRepo { get; set; }
        public IExamRepo ExamRepo { get; set; }
        public IStudentExamQuestionRepo StudentExamQuestionRepo { get; set; }



    }
}
