using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.DAL.Entities
{

    public class Topic: BaseEntity


    {
       // [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TopicId { get; set; }

        public string TopicName { get; set; }



        public int CourseId { get; set; }

        public Course Course { get; set; }

    }
}
