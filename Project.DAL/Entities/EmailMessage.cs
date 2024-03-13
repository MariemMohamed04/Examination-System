using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class EmailMessage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
    }
}
