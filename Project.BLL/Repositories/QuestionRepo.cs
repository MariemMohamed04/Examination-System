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
    public class QuestionRepo : GenericRepo<Question> , IQuestionRepo
    {
        private readonly AppDbContext _context;

        public QuestionRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Question questionChoices(int qId)
        {
            return _context.Questions.Include(q => q.Choices).SingleOrDefault(q => q.QuestionId == qId);
        }
    }
}
