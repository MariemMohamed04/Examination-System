using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL.Entities;

namespace Project.PL.Controllers
{
    public class QuestionController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            return View();
        }

   

        public IActionResult AddQuestion()
        {
             ViewBag.allcourses = _unitOfWork.CourseRepo.GetAll().ToList();
             return View();
        }



        [HttpPost]
        public IActionResult AddQuestion(IFormCollection f)
        {

            ViewBag.allcourses = _unitOfWork.CourseRepo.GetAll().ToList();
            Choice first = new() { ChoiceTxt = f["firstChoice"] };
            Choice second = new() { ChoiceTxt = f["secondChoice"] };
            Choice third = new() { ChoiceTxt = f["thirdChoice"] };
            Choice forth = new() { ChoiceTxt = f["forthChoice"] };
            Choice[] choices = [first, second, third, forth];


            _unitOfWork.ChoiceRepo.Add(first);
            _unitOfWork.ChoiceRepo.Add(second);
            _unitOfWork.ChoiceRepo.Add(third);
            _unitOfWork.ChoiceRepo.Add(forth);
            int c = int.Parse(f["ModelAnswer"]);

            var ch = choices[c].ChoiceTxt;
            Question newQuest = new() { Choices = choices.ToList(), QuestionText = f["qBody"], QuestionType = "MCQ", QuestionAnswer = ch , CourseId = int.Parse(f["CourseId"]) };

            _unitOfWork.QuestionRepo.Add(newQuest);

            foreach(var choice in choices)
            {
                choice.QuestionId = newQuest.QuestionId;
                _unitOfWork.ChoiceRepo.Update(choice);
            }

            return View();

        }



        public IActionResult AddTFQuestion()
        {
            ViewBag.allcourses = _unitOfWork.CourseRepo.GetAll().ToList();
            return View();  
        }


        [HttpPost]
        public IActionResult AddTFQuestion(IFormCollection f)
        {
            ViewBag.allcourses = _unitOfWork.CourseRepo.GetAll().ToList();
            Choice first = null;
            Choice second = null;


            if (_unitOfWork.ChoiceRepo.getChoicesValue("True") > 0)
            {
                first = _unitOfWork.ChoiceRepo.getChoiceByValue("True");
            }
            else
            {
                first = new() { ChoiceTxt = "True" };
               _unitOfWork.ChoiceRepo.Add(first);
            }
            if (_unitOfWork.ChoiceRepo.getChoicesValue("False") > 0)
            {
                second = _unitOfWork.ChoiceRepo.getChoiceByValue("False");
            }
            else
            {
                second = new() { ChoiceTxt = "False" };
                _unitOfWork.ChoiceRepo.Add(second);
            }

            Choice[] choices = [first, second];

            int c = int.Parse(f["ModelAnswer"]);
            var ch = choices[c].ChoiceTxt;
            Question newQuest = new() { Choices = choices.ToList(), QuestionText = f["qBody"], QuestionType = "TF", QuestionAnswer = ch };

            _unitOfWork.QuestionRepo.Add(newQuest);

            foreach (var choice in choices)
            {
                choice.QuestionId = newQuest.QuestionId;
                _unitOfWork.ChoiceRepo.Update(choice);
            }

            return RedirectToAction("AddTFQuestion");
        }



    }
}
