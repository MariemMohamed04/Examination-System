using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.DAL.Entities
{
    public class Question
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestionId { get; set; }
        public string QuestionType {  get; set; }
        public string QuestionText { get; set; }
        public string QuestionAnswer { get; set; }
        public string QType { get; set; }
        public string QDegree { get; set; }

        public int CourseId { get; set; }
        public int ExamId { get; set; }

        public Exam Exam { get; set; }
        public List<Choice> Choices { get; set; }
        public List<Course> Courses { get; set; }


    }
}
