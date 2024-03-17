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


    public class TopicRepo : GenericRepo<Topic>, ITopicRepo
    {

        private readonly AppDbContext _context;
        public TopicRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Topic GetByIdIncld(int id)
        {
            return _context.Topics.Include(t => t.Course).SingleOrDefault(t => t.TopicId == id);
        }
    }

}
