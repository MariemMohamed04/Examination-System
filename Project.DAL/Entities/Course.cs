using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.DAL.Entities
{

    public class Course: BaseEntity

    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        public string CrsName { get; set; }
        //public int ExamId { get; set; }


       /* public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public int InstructorId { get; set; }*/


        public List<CourseQuestion> CourseQuestions { get; set; }
        public List<CourseInstructor> CourseInstructors { get; set; }
        public List<CourseStudent> StudentCourses { get; set; }
        public List<CourseDepartment> CourseDepartments { get; set; }
        public List<Exam> Exams { get; set; }
        public List<Topic> Topics { get; set; }

    }
}
