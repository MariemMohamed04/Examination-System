using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface IUnitOfWork
    {//comment
        public IstudentRepo StudentRepo { get; set; }
        public IinstructorRepo InstructorRepo { get; set; }
    }
}
