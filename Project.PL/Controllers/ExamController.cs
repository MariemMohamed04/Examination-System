using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
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

        //public IActionResult Index()
        //{
        //    var  exams = _unitOfWork.ExamRepo.GetAll();
        //    var examVM = _mapper.Map<IEnumerable<StudentViewModel>>(students);
        //    return View(studentVM);
        //    return View();
        //}
    }
}
