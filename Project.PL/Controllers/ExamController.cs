using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.PL.ViewModel;

namespace Project.PL.Controllers
{
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

            return View();
        }


        public IActionResult Create() {

            ViewBag.Courses = _unitOfWork.CourseRepo.GetAll();


            return View();
        }



        [HttpPost]
        public IActionResult Create(ExamViewModel examViewModel)
        {
            var exam = _mapper.Map<Exam>(examViewModel);
            _unitOfWork.ExamRepo.Add(exam);

            _unitOfWork.ExamRepo.generateExam(exam.ExamId , exam.Num_TF_Questions , exam.Num_MCQ_Questions , exam.CourseId);

            return RedirectToAction("Index");
        }


    }
}
