using Microsoft.EntityFrameworkCore;
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
    public class ExamRepo : GenericRepo<Exam>, IExamRepo
    {
        private readonly AppDbContext _context;

        public ExamRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void generateExam(int examNo , int numOfTFQuestion , int numOfMCQQuestion)
        {
            _context.Database.ExecuteSqlInterpolated($"GenerateAnExam  {examNo},{numOfTFQuestion},{numOfMCQQuestion}");

        }
    }
}
