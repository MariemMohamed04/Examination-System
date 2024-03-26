using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.PL.ViewModel;
using System.Security.Claims;

namespace Project.PL.Controllers
{
    [Authorize(Roles = "Instructor")]

    public class ExamController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExamController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }




        public IActionResult Index()
        {
            var insCourses = getInstructorCourses();

            var exams = _unitOfWork.ExamRepo.getExamsCoursesByInstructor(insCourses); 

           // var exams = _unitOfWork.ExamRepo.GetAll();

            List<Course> courses = new List<Course>(); 
            foreach (var exam in exams)
            {
               var course = _unitOfWork.CourseRepo.GetAll().FirstOrDefault(c => c.CourseId == exam.CourseId);
                courses.Add(course);
            }
            ViewBag.Courses = courses;
            return View(exams);
        }
            

        public IActionResult Create() {

            var insCourses = getInstructorCourses(); 
            
            ViewBag.Courses = insCourses;

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
        public IActionResult Create(ExamViewModel examViewModel)
        {
            var exam = _mapper.Map<Exam>(examViewModel);
            _unitOfWork.ExamRepo.Add(exam);

            _unitOfWork.ExamRepo.generateExam(exam.ExamId , exam.Num_TF_Questions , exam.Num_MCQ_Questions , exam.CourseId);

            return RedirectToAction("Index");
        }




        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var exam = _unitOfWork.ExamRepo.GetById(id);

            if (exam is null)
                return NotFound();

            _unitOfWork.StudentExamQuestionRepo.deleteExamAnswers(exam.ExamId);
            _unitOfWork.ExamQuestionRepo.deleteQuestionFromExam(exam.ExamId);
            _unitOfWork.ExamRepo.Delete(exam);
            return RedirectToAction(nameof(Index));
        }


    }
}
