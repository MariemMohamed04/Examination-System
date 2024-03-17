using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL.Entities
{
    public class StudentExamQuestion : BaseEntity
    {
        public string StudentAnswer { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        [ForeignKey("Question")]
        public int? QuestionId { get; set; }


        public Student Student { get; set; }
        public Exam Exam { get; set; }
        public Question Question { get; set; }


    }
}
