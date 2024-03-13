using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface IDepartmentRepo : IGenericRepo<Department>
    {
        IEnumerable<Department> GetDepartmentsByBranch(int branchId);
        IEnumerable<Department> SearchByName(string Name);
    }
}
