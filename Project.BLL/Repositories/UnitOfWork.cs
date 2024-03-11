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

        public UnitOfWork(IBranchRepo branchRepo, IDepartmentRepo departmentRepo)
        {
            BranchRepo = branchRepo;
            DepartmentRepo = departmentRepo;
        }
    }
}
