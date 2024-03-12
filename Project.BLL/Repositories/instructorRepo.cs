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
    public class instructorRepo : GenericRepo<Instructor>, IinstructorRepo
    {
        private readonly AppDbContext _context;

        public instructorRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}