using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface ICrsStudentRepo : IGenericRepo<CourseStudent>
    {
        IEnumerable<CourseStudent> AddCoursetudent(int crsId, int StdId);
        IEnumerable<CourseStudent> GetAllInclud();
        CourseStudent GetByIds(params object[] keyValues);
    }
}
