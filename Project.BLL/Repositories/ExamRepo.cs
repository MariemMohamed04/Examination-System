using Project.BLL.Interfaces;
using Project.DAL.Context;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repositories
{
    public class ExamRepo : GenericRepo<Exam>,IExamRepo
    {
        public ExamRepo(AppDbContext context) : base(context)
        {
        }
    }
}
