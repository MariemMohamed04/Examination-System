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

        public IEnumerable<Topic> GetTopicsByCourse(int courseId)
        {
            return _context.Topics.Where(s => s.CourseId == courseId).ToList();
        }
        public List<(string CourseName, int NumberOfStudents)> GetCoursesByInstructorId(int instructorId)
        {
            var courses = _context.CourseInstructors
                .Where(ci => ci.InstructorId == instructorId)
                .Select(ci => ci.CourseId)
            .ToList();

            var courseStudentCounts = _context.CourseStudents
                .Where(cs => courses.Contains(cs.CourseId))
                .GroupBy(cs => cs.CourseId)
                .Select(g => new { CourseId = g.Key, StudentCount = g.Count() })
                .ToList();

            var result = (from courseStudentCount in courseStudentCounts
                          join course in _context.Courses on courseStudentCount.CourseId equals course.CourseId
                          select (course.CrsName, courseStudentCount.StudentCount)).ToList();

            return result;
        }
    }
}
