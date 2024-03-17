using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Interfaces;
using Project.DAL.Context;
using Project.DAL.Entities;

namespace Project.BLL.Repositories
{
    public class CourseRepo : GenericRepo<Course>, ICourseRepo
    {
        AppDbContext _context;
        public CourseRepo(AppDbContext context) : base(context)
        {
            _context=context;

        }

        public List<Course> getAllCourseStudent(int Id )
        {
            var idParameter = new SqlParameter("Id", Id);
            var courses = _context.Courses
                .FromSqlRaw("SELECT c.* FROM Courses c, CourseStudents cs, Students s WHERE c.CourseId = cs.CourseId AND s.StudentId = cs.StudentId AND s.StudentId = @Id", idParameter)
                .ToList();
            return courses;
        }
    }
}
