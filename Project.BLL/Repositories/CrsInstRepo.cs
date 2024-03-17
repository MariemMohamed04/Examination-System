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
    public class CrsInstRepo : GenericRepo<CourseInstructor>, ICrsInstRepo
    {
        private readonly AppDbContext _context;

        public CrsInstRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<CourseInstructor> AddCourseInstructor(int crsId, int InsId)
        {
            var courseInstructor = new CourseInstructor
            {
                CourseId = crsId,
                InstructorId = InsId
            };

            _context.Set<CourseInstructor>().Add(courseInstructor);
            _context.SaveChanges();

            return _context.Set<CourseInstructor>().ToList();
        }

        public CourseInstructor GetByIds(params object[] keyValues)
        {
            return _context.Set<CourseInstructor>().Find(keyValues);
        }
    }
}
