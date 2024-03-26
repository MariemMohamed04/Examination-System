using Project.BLL.Interfaces;
using Project.DAL.Context;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repositories
{
    public class ChoicesRepo : GenericRepo<Choice> , IChoicesRepo
    {

        private readonly AppDbContext _context;

        public ChoicesRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public int getChoicesValue(string value)
        {
            return _context.Choices.Where(c => c.ChoiceTxt == value).ToList().Count; 
        }

        public Choice getChoiceByValue(string value)
        {
            return _context.Choices.FirstOrDefault(c => c.ChoiceTxt == value);
        }

        public int deleteQuestionChoices(int id )
        {
            var choices =  _context.Choices.Where(ch => ch.QuestionId == id);
            foreach (var item in choices)
            {
                _context.Choices.Remove(item);
            }
            return _context.SaveChanges(); ;
        }
    }
}
