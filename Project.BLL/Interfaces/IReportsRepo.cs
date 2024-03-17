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
        List<Student> GetStudentsByDepartment(int deptId);
        IEnumerable<CourseStudent> GetGradesByStudentId(int stdId);
        IEnumerable<CourseInstructor> GetCourseByInstructorId(int instId);
        List<CourseStudent> GetStudentByCourse(int crsId);
        List<Topic> GetTopicsByCourseId(int crsId);
    }
}
