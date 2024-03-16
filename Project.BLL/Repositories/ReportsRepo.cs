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
    public class ReportsRepo : IReportsRepo
    {
        private readonly AppDbContext _context;

        public ReportsRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetStudentsByDepartment(int deptId)
        {
            return _context.Students.Where(s => s.DepartmentId == deptId).ToList();
        }

        public IEnumerable<int?> GetGradesByStudentId(int studentId)
        {
            return _context.CourseStudents
                .Where(sc => sc.StudentId == studentId && sc.CrsGrade != null)
                .Select(sc => sc.CrsGrade)
                .ToList();
        }
    }
}
