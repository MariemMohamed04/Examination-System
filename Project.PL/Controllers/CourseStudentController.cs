using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.PL.ViewModel;

namespace Project.PL.Controllers
{
    public class CourseStudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CourseStudentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var CrsStudent = _unitOfWork.CrsStudentRepo.GetAll();
            var CrsStudentVM = _mapper.Map<IEnumerable<CrsStudentViewModel>>(CrsStudent);
            return View(CrsStudentVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Courses = _unitOfWork.CourseRepo.GetAll();
            ViewBag.Student = _unitOfWork.StudentRepo.GetAll();
            return View(new CrsStudentViewModel());
        }

        [HttpPost]
        public IActionResult Create(CrsStudentViewModel CrsStudentVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var CrsStudent = _mapper.Map<CourseStudent>(CrsStudentVM);


                    _unitOfWork.CrsStudentRepo.Add(CrsStudent);
                    TempData["Message"] = "CrsInst Created Successfully!!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            ViewBag.Courses = _unitOfWork.CourseRepo.GetAll();
            ViewBag.Instructors = _unitOfWork.InstructorRepo.GetAll();
            return View(CrsStudentVM);
        }


        public IActionResult Delete(int crsId, int stdId)
        {
            var CrsStudent = _unitOfWork.CrsStudentRepo.GetByIds(crsId, stdId);
            if (CrsStudent == null)
            {
                return NotFound();
            }

            var crsInsVM = _mapper.Map<CrsStudentViewModel>(CrsStudent);
            _unitOfWork.CrsStudentRepo.Delete(CrsStudent);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int crsId, int StdId)
        {
            var CrsStudent = _unitOfWork.CrsStudentRepo.GetByIds(crsId, StdId);
            if (CrsStudent == null)
            {
                return NotFound();
            }

            var CrsStudentVM = _mapper.Map<CrsStudentViewModel>(CrsStudent);

            return View(CrsStudentVM);
        }
    }
}
