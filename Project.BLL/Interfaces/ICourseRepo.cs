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
        public List<Course> getCoursesByInsId(int? id);
        public Course getCourseWithTopics(int? id);
        public IEnumerable<Course> SearchByName(string Name);
        public List<Course> getCoursesByDeptId(int? id);
        //public IEnumerable<CourseStudent> getAllCourseStudents();
    }
}
