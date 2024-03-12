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
        public IStudentRepo StudentRepo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IInstructorRepo InstructorRepo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public UnitOfWork(IBranchRepo branchRepo, IDepartmentRepo departmentRepo, IInstructorRepo instructorRepo, IStudentRepo studentRepo)
        {
            BranchRepo = branchRepo;
            DepartmentRepo = departmentRepo;
            InstructorRepo = instructorRepo;
            StudentRepo = studentRepo;
        }
    }
}
