using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class CourseDepartment : BaseEntity
    {
        public int CourseId { get; set; }
        public int DepartmentId { get; set; }
    }
}
