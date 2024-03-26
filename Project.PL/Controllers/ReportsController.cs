using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.PL.ViewModel;

namespace Project.PL.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ReportsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReportsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Report 01
        public IActionResult GetStudentByDepartment()
        {
            ViewBag.Departments = _unitOfWork.DepartmentRepo.GetAll().ToList();
            return View("IndexGetStudentByDepartment");
        }

        [HttpPost]
        public IActionResult GetStudentByDepartment(int Id)
        {
            var students = _unitOfWork.ReportsRepo.GetStudentsByDepartment(Id);
            return View(students);
        } 
        #endregion

        #region Report 02
        public IActionResult GetGradesByStudent()
        {
            ViewBag.Students = _unitOfWork.StudentRepo.GetAll().ToList();
            return View("IndexGetGradesByStudent");
        }

        [HttpPost]
        public IActionResult GetGradesByStudent(int Id)
        {
            var stdCrs = _unitOfWork.ReportsRepo.GetGradesByStudentId(Id);
            List<ReportTwoViewModel> rtVM = new List<ReportTwoViewModel>();
            foreach (var item in stdCrs)
            {
                var rt = new ReportTwoViewModel();
                rt.Course = _unitOfWork.CourseRepo.GetById(item.CourseId);
                rt.CrsGrade = item.CrsGrade;
                rtVM.Add(rt);
            }
            return View(rtVM);
        } 
        #endregion

        #region Report 03
        public IActionResult GetCourseByInstructor()
        {
            ViewBag.Instructors = _unitOfWork.InstructorRepo.GetAll().ToList();
            return View("IndexGetCourseByInstructor");
        }

        [HttpPost]
        public IActionResult GetCourseByInstructor(int Id)
        {
            var insCrs = _unitOfWork.ReportsRepo.GetCourseByInstructorId(Id);
            List<ReportThreeViewModel> rtVM = new List<ReportThreeViewModel>();
            foreach (var item in insCrs)
            {
                var rt = new ReportThreeViewModel();
                rt.Course = _unitOfWork.CourseRepo.GetById(item.CourseId);
                rt.StdCount = _unitOfWork.ReportsRepo.GetStudentByCourse(item.CourseId).Count();
                rtVM.Add(rt);
            }
            return View(rtVM);
        } 
        #endregion

        #region Report 04
        public IActionResult GetTopicsByCourse()
        {
            ViewBag.Courses = _unitOfWork.CourseRepo.GetAll().ToList();
            return View("IndexGetTopicsByCourse");
        }

        [HttpPost]
        public IActionResult GetTopicsByCourse(int Id)
        {
            var topics = _unitOfWork.ReportsRepo.GetTopicsByCourseId(Id);
            if ( topics.Count>0 && topics != null )
            {
             ViewBag.Course = topics[0].Course;

            }
            return View(topics);
        }
        #endregion

        #region Report 05
        public IActionResult IndexQuestions()
        {
            ViewBag.Exams = _unitOfWork.ExamRepo.GetAll().ToList(); 
            return View("IndexQuestions");
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
                if(question != null)
                    questions.Add(question);
            }
            return View(questions);
        }
        #endregion

        #region Report 06
        public IActionResult IndexAnswers()
        {
            ViewBag.Students = _unitOfWork.StudentRepo.GetAll().ToList();
            ViewBag.Exams = _unitOfWork.ExamRepo.GetAll().ToList();
            return View("IndexAnswers");
        }

        [HttpPost]
        public IActionResult GetExamByStudent(int ExamId, int StudentId)
        {
            var examQues = _unitOfWork.ExamQuestionRepo.ExamQuestions(ExamId);
            var questionsAnswers = new List<AnswerQuestionsViewModel>();
            if (_unitOfWork.StudentExamQuestionRepo.isStudentDoExam(ExamId , StudentId) )
            {
                foreach (var q in examQues)
                {
                    var questionsAnswer = new AnswerQuestionsViewModel();
                    var ques = _unitOfWork.QuestionRepo.GetById(q.QuestionId);
                    if (ques != null)
                    {
                        questionsAnswer.Question = ques;
                        questionsAnswer.Answer = _unitOfWork.StudentExamQuestionRepo.getByIds(ExamId, StudentId, q.QuestionId).StudentAnswer;
                        questionsAnswers.Add(questionsAnswer);
                    }
                }

            }
            return View(questionsAnswers);
        } 
        #endregion
    }
}

