namespace Project.PL.ViewModel
{
    public class QuestionViewModel
    {

        public int QuestionId { get; set; }
        public string QuestionType { get; set; }
        public string QuestionText { get; set; }
        public string QuestionAnswer { get; set; }
        public int? QuestionDegree { get; set; }

        /* public int CourseId { get; set; }
         public int ExamId { get; set; }*/


        public int CourseId { get; set; }


    }
}
