﻿using Project.BLL.Interfaces;
using Project.DAL.Context;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repositories
{
    public class QuestionRepo : GenericRepo<Question>, IQuestionRepo
    {
        public QuestionRepo(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Question> SearchByName(string Name)
        {
            throw new NotImplementedException();
        }
    }
}
