using Project.BLL.Interfaces;
using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repositories
{
    public class QuestionRepo : GenericRepo<QuestionRepo>, IQuestionRepo
    {
        public QuestionRepo(AppDbContext context) : base(context)
        {
        }
    }
}
