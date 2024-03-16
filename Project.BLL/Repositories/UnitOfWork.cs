using Microsoft.EntityFrameworkCore;
using Project.BLL.Interfaces;
using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        public ICrsDeptRepo CrsDeptRepo { get; set; }
        public IBranchRepo BranchRepo { get; set; }
        public IDepartmentRepo DepartmentRepo { get; set; }
        public IStudentRepo StudentRepo { get; set; }
        public IInstructorRepo InstructorRepo { get; set; }
        public ICourseRepo CourseRepo { get; set; }
        public ITopicRepo TopicRepo { get; set; }
        public IReportsRepo ReportsRepo { get; set; }

        public UnitOfWork(IBranchRepo branchRepo, IDepartmentRepo departmentRepo, IInstructorRepo instructorRepo, IStudentRepo studentRepo, ITopicRepo topicRepo, ICourseRepo courseRepo, IReportsRepo reportsRepo, ICrsDeptRepo crsDeptRepo)
        {
            CrsDeptRepo = crsDeptRepo;
            BranchRepo = branchRepo;
            DepartmentRepo = departmentRepo;
            InstructorRepo = instructorRepo;
            StudentRepo = studentRepo;
            CourseRepo = courseRepo;
            TopicRepo = topicRepo;
            ReportsRepo = reportsRepo;
        }

    }
}
