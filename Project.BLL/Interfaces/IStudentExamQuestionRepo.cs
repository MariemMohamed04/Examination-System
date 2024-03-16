using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Entities;

namespace Project.BLL.Interfaces
{
    public interface IStudentExamQuestionRepo:IGenericRepo<StudentExamQuestion>
    {
        public StudentExamQuestion getByIds(int ExamId, int  studentId, int QusId);
    }
}
