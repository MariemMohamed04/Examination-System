using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface ICrsDeptRepo : IGenericRepo<CourseDepartment>
    {
        IEnumerable<CourseDepartment> AddCourseDepartment(int crsId, int deptId);
        CourseDepartment GetById(params object[] keyValues);

    }
}
