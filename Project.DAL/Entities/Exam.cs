using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project.DAL.Entities
{
    public class Exam
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExamId { get; set; }
        public int Duration { get; set;}
        public int NumOfQuestions {  get; set; }
        public string Date { get; set; }
        public int ExamGrade { get; set; }


        public int CourseId { get; set; }
/*        public int QuestionId { get; set; }
*/
        //Navigation Props
        public Course Course { get; set; }
        public List<ExamStudent> ExamStudents { get; set; }
        public List<ExamQuestion> ExamQuestions { get;}

    }
}
