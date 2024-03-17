using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.DAL.Entities
{
    public class CourseStudent : BaseEntity
    {

        public int? CrsGrade {  get; set; }


        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }



        public Student Student { get; set; }
        public Course Course { get; set; }


    }
}
