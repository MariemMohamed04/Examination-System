using Project.BLL.Interfaces;
using Project.DAL.Context;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repositories
{
    public class DepartmentRepo : GenericRepo<Department>, IDepartmentRepo
    {
        private readonly AppDbContext _context;

        public DepartmentRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetDepartmentsByBranchName(string Name)
        {
            return _context.Departments
                .Where(d => string.Equals(d.Branch.BranchName, Name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public IEnumerable<Department> SearchByName(string Name)
        {
            return _context.Departments.Where(dept => dept.DeptName.Trim().ToLower().Contains(Name.Trim().ToLower()));
        }
    }
}
