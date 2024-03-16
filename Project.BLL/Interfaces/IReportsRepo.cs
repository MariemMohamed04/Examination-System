using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface IReportsRepo
    {
       public IEnumerable<Topic> GetTopicsByCourse(int courseId);
        public List<(string CourseName, int NumberOfStudents)> GetCoursesByInstructorId(int instructorId);

    }
}
