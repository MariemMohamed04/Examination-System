using Project.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IinstructorRepo InstructorRepo { get; set; }
        public IstudentRepo StudentRepo { get; set; }



        public UnitOfWork(IinstructorRepo instructorRepo, IstudentRepo studentRepo)
        {
            InstructorRepo = instructorRepo;
            StudentRepo = studentRepo;
        }

    }
}
