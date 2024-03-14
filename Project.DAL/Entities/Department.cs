using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.DAL.Entities
{
    public class Department : BaseEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentId { get; set; }

        public string DeptName { get; set; }

        public string DeptLoc {  get; set; }
        public int BranchId { get; set; }
        public int InstructorId { get; set; }
       // public int CourseId { get; set; }

        public List<CourseDepartment> CourseDepartments { get; set; }
        public List<Student> Students { get; set; }

        public Instructor Instructor { get; set; }
        public Branch Branch { get; set; }

    }
}
