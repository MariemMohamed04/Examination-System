namespace Project.PL.ViewModel
{
    public class ChoiceViewModel
    {

        public int ChoiceId { get; set; }

        public string ChoiceTxt { get; set; }

        public int? IsCorrect { get; set; }

        //Foreign Keys
        public int? QuestionId { get; set; }


    }
}
