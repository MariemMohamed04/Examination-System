using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL.Entities
{
    public class Branch : BaseEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BranchId { get; set; }

        public string BranchName { get; set; }

        public string BranchLoc {  get; set; }


/*        public int InstructorId { get; set; }
        public int StudentId { get; set; }
        public int DepartmentId { get; set; }
*/

        public List<Instructor> Instructors { get; set;}
        public List<Student> Students { get;set;}
        public List<Department> Departments { get; set;}



    }
}
