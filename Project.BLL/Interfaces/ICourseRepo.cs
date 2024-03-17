using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface ICourseRepo : IGenericRepo<Course>
    {
        public Course GetByIdIncld(int id);
        public List<Course> getAllCourseStudent(int id);
        //public IEnumerable<CourseStudent> getAllCourseStudents();
    }
}
