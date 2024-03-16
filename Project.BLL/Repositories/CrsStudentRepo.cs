using Microsoft.EntityFrameworkCore;
using Project.BLL.Interfaces;
using Project.DAL.Context;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repositories
{
    public class CrsStudentRepo : GenericRepo<CourseStudent>, ICrsStudentRepo
    {
        private readonly AppDbContext _context;
        public CrsStudentRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<CourseStudent> AddCoursetudent(int crsId, int StdId)
        {
            var courseStudent = new CourseStudent { CourseId = crsId, StudentId=StdId };

            _context.Set<CourseStudent>().Add(courseStudent);
            _context.SaveChanges();

            return _context.Set<CourseStudent>().ToList();
        }

        public IEnumerable<CourseStudent> GetAllInclud()
        {
            return _context.Set<CourseStudent>().Include(cs => cs.Student).Include(cs => cs.Course).ToList();
        }

        public CourseStudent GetByIds(params object[] keyValues)
        {
            return _context.CourseStudents.Find(keyValues);
        }
    }
}
