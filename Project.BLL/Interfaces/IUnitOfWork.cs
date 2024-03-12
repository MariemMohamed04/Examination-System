using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        public IBranchRepo BranchRepo { get; set; }
        public IDepartmentRepo DepartmentRepo { get; set; }

        public IStudentRepo StudentRepo { get; set; }
        public IInstructorRepo InstructorRepo { get; set; }

        public ICourseRepo CourseRepo { get; set; }
        public ITopicRepo TopicRepo { get; set; }
    }
}
