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
            throw new NotImplementedException();
        }

        public IEnumerable<CourseStudent> GetAllInclud()
        {
            throw new NotImplementedException();
        }

        public CourseStudent GetByIds(params object[] keyValues)
        {
            throw new NotImplementedException();
        }
    }
}
