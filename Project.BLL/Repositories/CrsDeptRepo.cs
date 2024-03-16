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
    public class CrsDeptRepo : GenericRepo<CourseDepartment>, ICrsDeptRepo
    {
        private readonly AppDbContext _context;

        public CrsDeptRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        //public IEnumerable<CourseDepartment> AddCourseDepartment(int crsId, int deptId)
        //{
        //    var courseDepartment = new CourseDepartment
        //    {
        //        CourseId = crsId,
        //        DepartmentId = deptId
        //    };

        //    _context.Set<CourseDepartment>().Add(courseDepartment);
        //    _context.SaveChanges();

        //    return _context.Set<CourseDepartment>().ToList();
        //}

        public CourseDepartment GetByIds(params object[] keyValues)
        {
            return _context.Set<CourseDepartment>().Find(keyValues);
        }
    }
}
