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
    public class InstructorRepo : GenericRepo<Instructor>, IInstructorRepo
    {
        private readonly AppDbContext _context;

        public InstructorRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Instructor getInstructorByUserId(string userId)
        {
            return _context.Instructors.FirstOrDefault(u => u.UserId == userId);
        }
    }
}
