using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL.Entities
{
    public class ExamStudent:BaseEntity
    {

        public int ExamResult { get; set; }


        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }

        public Student Student { get; set; }
        public Exam Exam { get; set; }

    }
}
