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
    public class CrsDeptRepo : GenericRepo<CourseDepartment>, ICrsDeptRepo
    {
        private readonly AppDbContext _context;

        public CrsDeptRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
