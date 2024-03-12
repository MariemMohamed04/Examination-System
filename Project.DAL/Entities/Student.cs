using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.DAL.Entities
{
    public class Student : BaseEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }

        public string City {  get; set; }
        public string Street { get; set; }
        public string Gender { get; set; }
        public int UserId { get; set; }



        //Forkes
        public int BrandId { get; set; }
        public int DepartmentId { get; set; }

        //Navigation Prop
        public List<CourseStudent> StudentCourses { get; set; }
        public List<ExamStudent> ExamStudents { get; set; }

        public  Department Department { get; set; }
        public Branch Branch { get; set; }

    }
}
