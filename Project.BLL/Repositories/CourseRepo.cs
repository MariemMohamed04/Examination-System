using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Interfaces;
using Project.DAL.Context;
using Project.DAL.Entities;

namespace Project.BLL.Repositories
{
    public class CourseRepo : GenericRepo<Course>, ICourseRepo
    {
        private readonly AppDbContext _context;
        public CourseRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public Course GetByIdIncld(int id)
        {
            return _context.Courses.Include(c => c.Topics).SingleOrDefault(c => c.CourseId == id);
        }

        public List<Course> getAllCourseStudent(int id)
        {
            var idParameter = new SqlParameter("Id", id); 
            return _context.Courses.FromSqlRaw("select c.* from Courses c , CourseStudents cs , Students s where c.CourseId =cs.CourseId and s.StudentId =cs.StudentId and s.StudentId = @Id " , idParameter).ToList();
        }


        public List<Course> getCoursesByInsId(int? id)
        {
            var idParameter = new SqlParameter("Id", id);
            return _context.Courses.FromSqlRaw("select crs.* from Courses crs , CourseInstructors crsIns , Instructors ins where crs.CourseId =crsIns.CourseId and ins.InstructorId =crsIns.InstructorId and ins.InstructorId = @Id ", idParameter).ToList();

        }

        public List<Course> getCoursesByDeptId(int? id)
        {
            var idParameter = new SqlParameter("Id", id);
            return _context.Courses.FromSqlRaw("select crs.* from Courses crs , CourseDepartments crsDept , Departments dept where crs.CourseId =crsDept.CourseId and dept.DepartmentId =crsDept.DepartmentId and dept.DepartmentId = @Id ", idParameter).ToList();

        }

        public Course getCourseWithTopics(int? id)
        {
            return _context.Courses.Include(c => c.Topics).FirstOrDefault(c => c.CourseId == id.Value); 
        }

        public IEnumerable<Course> SearchByName(string Name)
        {
            return _context.Courses.Where(crs => crs.CrsName.Trim().ToLower().Contains(Name.Trim().ToLower()));
        }
    }
}
