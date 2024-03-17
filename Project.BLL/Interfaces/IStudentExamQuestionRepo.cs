using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface IStudentExamQuestionRepo
    {
        public StudentExamQuestion getByIds(int ExamId, int studentId, int QusId);
    }
}
