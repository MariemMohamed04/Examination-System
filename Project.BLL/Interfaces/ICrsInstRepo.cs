using Project.BLL.Repositories;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface ICrsInstRepo: IGenericRepo<CourseInstructor>
    {
        IEnumerable<CourseInstructor> AddCourseInstructor(int crsId, int InsId);
        CourseInstructor GetByIds(params object[] keyValues);


    }
}
