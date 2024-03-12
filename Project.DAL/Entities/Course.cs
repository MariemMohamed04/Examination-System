using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.DAL.Entities
{
    public class Course: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        public string CrsName { get; set; }

        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public int InstructorId { get; set; }

        public List<Question> Questions { get; set; }
        public List<Instructor> Instructor{ get; set; }
        public List<CourseStudent> StudentCourses { get; set; }
        public List<Department> Departments { get; set; }
        public List<Exam> Exams { get; set; }

    }
}
