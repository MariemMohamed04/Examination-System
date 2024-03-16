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

        public List<Course> getAllCourseStudent(int id )
        {
           return  _context.Courses.FromSqlRaw("select c.* from Courses c , CourseStudent cs , Student s" +
               " where c.CourseId =cs.CourseId and s.StudentId =cs.StudentId" +
               " and s.StudentId = {Id} ").ToList();
        }
    }
}
