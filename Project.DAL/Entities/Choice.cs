using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL.Entities
{
    public class Choice
    {

        [Key , DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ChoiceId { get; set; }

        public string ChoiceTxt { get; set; }

        public int IsCorrect { get; set; }

        //Foreign Keys
        public int QuestionId { get; set; }

        //Navigation Prop
        public Question Question { get; set; }
    
       
    
    }
}
