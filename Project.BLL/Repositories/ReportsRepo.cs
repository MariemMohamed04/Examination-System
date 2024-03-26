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
    public class ReportsRepo : IReportsRepo
    {
        private readonly AppDbContext _context;

        public ReportsRepo(AppDbContext context)
        {
            _context = context;
        }
        public List<Student> GetStudentsByDepartment(int deptId)
        {
            return _context.Students.Include(s=>s.Department).Where(d => d.DepartmentId == deptId).ToList();
        }
        public IEnumerable<CourseStudent> GetGradesByStudentId(int stdId)
        {
            return _context.CourseStudents.Where(sc => sc.StudentId == stdId).ToList();
        }

        public IEnumerable<CourseInstructor> GetCourseByInstructorId(int instId)
        {
            return _context.CourseInstructors.Where(i => i.InstructorId == instId).ToList();
        }

        public List<CourseStudent> GetStudentByCourse(int crsId)
        {
            return _context.CourseStudents.Where(sc => sc.CourseId == crsId).ToList();
        }

        public List<Topic> GetTopicsByCourseId(int crsId)
        {
            return _context.Topics.Include(c=>c.Course).Where(t => t.CourseId == crsId).ToList();
        }
    }
}
