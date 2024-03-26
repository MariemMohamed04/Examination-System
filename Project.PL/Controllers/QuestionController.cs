using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.PL.ViewModel;
using System.Collections.Generic;
using System.Security.Claims;

namespace Project.PL.Controllers
{
    [Authorize(Roles = "Instructor")]

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
            var allQuestions = _unitOfWork.QuestionRepo.getAllQuestionsWithCourses(); 
            List<Question> questionList = new List<Question>(); 
            var courses = getInstructorCourses();
            if (courses != null)
            {
                foreach(var course in courses)
                {
                   var questions =  allQuestions.Where(q => q.CourseId == course.CourseId);
                    if (questions != null)
                    {
                        foreach(var question in questions)
                        {
                            questionList.Add(question);
                        }
                    }
                }
            }
            
            return View(questionList);
        }

   

        public IActionResult AddQuestion()
        {
             //ViewBag.allcourses = _unitOfWork.CourseRepo.GetAll().ToList();
             ViewBag.Courses = getInstructorCourses();
             return View();
        }


        private List<Course> getInstructorCourses()
        {
            string name = User.Identity.Name;

            string id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var instructor = _unitOfWork.InstructorRepo.getInstructorByUserId(id);

            var insCourses = _unitOfWork.CourseRepo.getCoursesByInsId(instructor.InstructorId);

            return insCourses;

        }


        [HttpPost]
        public IActionResult AddQuestion(IFormCollection f)
        {

            ViewBag.allcourses = _unitOfWork.CourseRepo.GetAll().ToList();
            Choice first = new() { ChoiceTxt = f["firstChoice"]  , IsCorrect=0 };
            Choice second = new() { ChoiceTxt = f["secondChoice"], IsCorrect = 0 };
            Choice third = new() { ChoiceTxt = f["thirdChoice"], IsCorrect = 0 };
            Choice forth = new() { ChoiceTxt = f["forthChoice"], IsCorrect = 0 };
            Choice[] choices = [first, second, third, forth];


            _unitOfWork.ChoiceRepo.Add(first);
            _unitOfWork.ChoiceRepo.Add(second);
            _unitOfWork.ChoiceRepo.Add(third);
            _unitOfWork.ChoiceRepo.Add(forth);
            int c = int.Parse(f["ModelAnswer"]);
            var ch = choices[c].ChoiceTxt;
            choices[c].IsCorrect = 1; 
            Question newQuest = new() { Choices = choices.ToList(), QuestionText = f["qBody"], QuestionType = "MCQ", QuestionAnswer = ch , CourseId = int.Parse(f["CourseId"]) };

            _unitOfWork.QuestionRepo.Add(newQuest);

            foreach(var choice in choices)
            {
                choice.QuestionId = newQuest.QuestionId;
                _unitOfWork.ChoiceRepo.Update(choice);
            }

            return RedirectToAction("AddQuestion" );

        }



        public IActionResult AddTFQuestion()
        {
            ViewBag.allcourses = getInstructorCourses();
            return View();  
        }


        [HttpPost]
        public IActionResult AddTFQuestion(IFormCollection f)
        {
            ViewBag.allcourses = _unitOfWork.CourseRepo.GetAll().ToList();
            Choice first = null;
            Choice second = null;


           /* if (_unitOfWork.ChoiceRepo.getChoicesValue("True") > 0)
            {
                first = _unitOfWork.ChoiceRepo.getChoiceByValue("True");
            }
            else
            {
              // _unitOfWork.ChoiceRepo.Add(first);
           }
            if (_unitOfWork.ChoiceRepo.getChoicesValue("False") > 0)
            {
               // second = _unitOfWork.ChoiceRepo.getChoiceByValue("False");
            }
            else
            {
               // _unitOfWork.ChoiceRepo.Add(second);
           // } */

            first = new() { ChoiceTxt = "True" };
            second = new() { ChoiceTxt = "False" };
            Choice[] choices = [first, second];

            int c = int.Parse(f["ModelAnswer"]);
            var ch = choices[c].ChoiceTxt;
            Question newQuest = new() { Choices = null, QuestionText = f["qBody"], QuestionType = "TF", QuestionAnswer = ch , CourseId = int.Parse(f["CourseId"] ) };

            _unitOfWork.QuestionRepo.Add(newQuest);

          /*  foreach (var choice in choices)
            {
                choice.QuestionId = newQuest.QuestionId;
                _unitOfWork.ChoiceRepo.Update(choice);
            }*/

            return RedirectToAction("AddTFQuestion");
        }


        [HttpPost]
        public IActionResult UpdateTFQuestion(IFormCollection f)
        {
            ViewBag.allcourses = _unitOfWork.CourseRepo.GetAll().ToList();

            int c = int.Parse(f["ModelAnswer"]);
            var ch = c==0?"True":"False";
            Question newQuest = new() { Choices = null, QuestionText = f["qBody"], QuestionType = "TF", QuestionAnswer = ch, CourseId = int.Parse(f["CourseId"]) };

            _unitOfWork.QuestionRepo.Update(newQuest);


            return RedirectToAction("Index");
        }


        public IActionResult UpdateTFQuestion(int? id )
        {
            if (id is null)
                return NotFound();
            var question = _unitOfWork.QuestionRepo.GetById(id);
            if (question is null)
                return NotFound();

            ViewBag.allcourses = getInstructorCourses();


            return View(question);
        }



        public IActionResult UpdateMCQQuestion(int? id)
        {
            if (id is null)
                return NotFound();

            var question = _unitOfWork.QuestionRepo.GetById(id);

            if (question is null)
                return NotFound();

            var questionVM = _mapper.Map<QuestionViewModel>(question);
            ViewBag.Courses = getInstructorCourses();
            ViewBag.Choices = _unitOfWork.ChoiceRepo.GetAll().Where(ch => ch.QuestionId == id).ToList();

            return View(questionVM);
        }


        [HttpPost]
        public IActionResult UpdateMCQQuestion(int id , IFormCollection f)
        {


            if (ModelState.IsValid)
            {
                try
                {
                   var choices =  _unitOfWork.ChoiceRepo.GetAll().Where(ch => ch.QuestionId == id).ToList();
                    choices[0].ChoiceTxt = f["firstChoice"];
                    choices[1].ChoiceTxt = f["secondChoice"];
                    choices[2].ChoiceTxt = f["thirdChoice"];
                    choices[3].ChoiceTxt = f["forthChoice"];
                    foreach(var item in choices)
                    {     
                        _unitOfWork.ChoiceRepo.Update(item);
                    }
                    var question = _unitOfWork.QuestionRepo.GetById(id);
                    question.QuestionText = f["qBody"]; 
                    question.QuestionAnswer = choices[int.Parse(f["ModelAnswer"])].ChoiceTxt;
                    question.CourseId = int.Parse(f["CourseId"]) ; 
                    _unitOfWork.QuestionRepo.Update(question);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            
            return View();
        }



        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var question = _unitOfWork.QuestionRepo.GetById(id);

            if (question is null)
                return NotFound();

            _unitOfWork.ChoiceRepo.deleteQuestionChoices(question.QuestionId);
            _unitOfWork.ExamQuestionRepo.deleteQuestionFromExam(question.QuestionId);
            _unitOfWork.StudentExamQuestionRepo.deleteStudentAnswerOnQues(question.QuestionId);
            _unitOfWork.QuestionRepo.Delete(question);
            return RedirectToAction(nameof(Index));
        }



    }
}
