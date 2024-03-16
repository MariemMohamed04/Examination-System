using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface IStudentRepo : IGenericRepo<Student>
    {
        public Student getStudentByUserId(string userId);   
    }
}
