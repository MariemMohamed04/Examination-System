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
    internal class QuestionRepo : GenericRepo<Question> , IQuestionRepo
    {
        private readonly AppDbContext _context;

        public QuestionRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
