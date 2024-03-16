using Project.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        public IBranchRepo BranchRepo { get; set; }
        public IDepartmentRepo DepartmentRepo { get; set; }
        public IStudentRepo StudentRepo { get; set; }
        public IInstructorRepo InstructorRepo { get; set; }
        public ICourseRepo CourseRepo { get; set; }
        public ITopicRepo TopicRepo { get; set; }
        public ICrsStudentRepo CrsStudentRepo { get; set; }
        public IExamQuestionRepo ExamQuestionRepo { get; set; }
        public IQuestionRepo QuestionRepo { get; set; }
        public IExamRepo ExamRepo { get; set; }
        public IStudentExamQuestionRepo StudentExamQuestionRepo { get; set; }





        public UnitOfWork(IBranchRepo branchRepo, IDepartmentRepo departmentRepo, IInstructorRepo instructorRepo, IStudentRepo studentRepo, ITopicRepo topicRepo, ICourseRepo courseRepo, ICrsStudentRepo crsStudentRepo, IExamQuestionRepo examQuestionRepo, IQuestionRepo questionRepo, IExamRepo examRepo, IStudentExamQuestionRepo studentExamQuestionRepo)
        {
            BranchRepo = branchRepo;
            DepartmentRepo = departmentRepo;
            InstructorRepo = instructorRepo;
            StudentRepo = studentRepo;
            CourseRepo = courseRepo;
            TopicRepo = topicRepo;
            CrsStudentRepo = crsStudentRepo;
            ExamQuestionRepo = examQuestionRepo;
            QuestionRepo = questionRepo;
            ExamRepo = examRepo;
            StudentExamQuestionRepo = studentExamQuestionRepo;
        }
    }
}
