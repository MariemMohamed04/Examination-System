using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using System.Security.Claims;

namespace Project.PL.Controllers
{

    [Authorize(Roles = "Student")]
    public class StartExamController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public List<Exam> exams; 

        public StartExamController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public IActionResult Main()
        {

            string name = User.Identity.Name;

            string id =  User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value; 

            var student = _unitOfWork.StudentRepo.getStudentByUserId(id);

            var courses = _unitOfWork.CourseRepo.getAllCourseStudent(student.StudentId);

            ViewBag.Courses = courses;

            foreach (var course in courses)
            {
                var exam = _unitOfWork.ExamRepo.getAllExams(course.CourseId);
                exams.Add(exam);
            }


            return View(courses);
        }


        [HttpPost]
        public IActionResult Main(int courseId)
        {

            return View();
        }



    }
}
