using System.ComponentModel.DataAnnotations.Schema;

namespace Project.PL.Mapper
{
    public class CrsStudentViewModel
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int? CrsGrade { get; set; }
    }
}