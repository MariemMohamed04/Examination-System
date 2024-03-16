using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.DAL.Entities
{
    public class Instructor : BaseEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InstructorId { get; set; }
        public string Name { get; set;}
        public int Age { get; set;}
        public string City { get; set;}
        public string Street { get; set;}
        public string Gender { get; set;}
        public int Salary { get; set;}
        public string UserId { get; set; }


        public int BranchId { get; set; }
       // public int CourseId { get; set; }

        public List<CourseInstructor> CourseInstructor { get; set; }
        public Branch Branch { get; set; }


    }
}
