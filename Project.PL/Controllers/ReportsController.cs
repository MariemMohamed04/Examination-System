using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.PL.ViewModel;

namespace Project.PL.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult IndexQuestions()
        {



            return View();
        }

        [HttpPost]
        public IActionResult GetExamByQuestion(int Id)
        {
            var exam = _unitOfWork.ExamRepo.GetById(Id);
            ViewBag.Exam = exam;

            var examQues = _unitOfWork.ExamQuestionRepo.ExamQuestions(Id);
            var questions = new List<Question>();

            foreach (var q in examQues)
            {
                var question = _unitOfWork.QuestionRepo.questionChoices(q.QuestionId);

                questions.Add(question);
            }
            return View(questions);
        }



        public IActionResult IndexAnswers()
        {

            return View();
        }

        [HttpPost]
        public IActionResult GetExamByStudent(int ExamId, int StudentId)
        {
            var examQues = _unitOfWork.ExamQuestionRepo.ExamQuestions(ExamId);
            var questionsAnswers = new List<AnswerQuestionsViewModel>();

            

            foreach (var q in examQues)
            {
                var questionsAnswer = new AnswerQuestionsViewModel();
                questionsAnswer.Question = _unitOfWork.QuestionRepo.GetById(q.QuestionId);
                questionsAnswer.Answer = _unitOfWork.StudentExamQuestionRepo.getByIds(ExamId, StudentId, q.QuestionId).StudentAnswer;

                questionsAnswers.Add(questionsAnswer);

            }

            return View(questionsAnswers);

        }

    }
}
