using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        public ICrsDeptRepo CrsDeptRepo { get; set; }
        public ICourseRepo CourseRepo { get; set; }
        public ITopicRepo TopicRepo { get; set; }

        public IBranchRepo BranchRepo { get; set; }
        public IDepartmentRepo DepartmentRepo { get; set; }

        public IStudentRepo StudentRepo { get; set; }
        public IInstructorRepo InstructorRepo { get; set; }
        public IChoicesRepo ChoiceRepo { get; set; }
        public IQuestionRepo QuestionRepo { get; set; }
        public IExamRepo ExamRepo { get; set; } 

        public ICrsStudentRepo CrsStudentRepo { get; set; }
        public IExamQuestionRepo ExamQuestionRepo { get; set; }
        public IStudentExamQuestionRepo StudentExamQuestionRepo { get; set; }

        public ICrsInstRepo CrsInstRepo { get; set; }
       
        public IReportsRepo ReportsRepo { get; set; }
    }
}
