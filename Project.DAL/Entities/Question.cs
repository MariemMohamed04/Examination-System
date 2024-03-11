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
        public int QDegree { get; set; }

        public int CourseId { get; set; }
        public int ExamId { get; set; }

        public List<ExamQuestion> ExamQuestions { get; set; }
        public List<Choice> Choices { get; set; }
        public List<CourseQuestion> CourseQuestions { get; set; }


    }
}
