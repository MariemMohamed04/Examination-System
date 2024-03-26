using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.PL.ViewModel;

namespace Project.PL.Controllers
{
    [Authorize(Roles = "Admin")]

    public class CourseStudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CourseStudentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public IActionResult Index(int searchID=0)
        {
           
            List<String>coursesNames = new List<String>();
            List<String>studentNames = new List<String>();
            IEnumerable<CourseStudent> CrsStudents; 
            if (searchID == 0)
            {
                 CrsStudents = _unitOfWork.CrsStudentRepo.GetAll();
           
            }
            else
            {
                 CrsStudents = _unitOfWork.CrsStudentRepo.GetAll().Where(c=>c.StudentId == searchID);
            }
            var CrsStudentVM = _mapper.Map<IEnumerable<CrsStudentViewModel>>(CrsStudents);
            foreach (var crsStudent in CrsStudentVM)
            {
                var courseName = _unitOfWork.CourseRepo.GetById(crsStudent.CourseId).CrsName;
                var studentName = _unitOfWork.StudentRepo.GetById(crsStudent.StudentId).Name;
                coursesNames.Add(courseName);
                studentNames.Add(studentName);
            }
            ViewBag.studentNames = studentNames;
            ViewBag.coursesNames = coursesNames;
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

                    var exist = _unitOfWork.CrsStudentRepo.GetAll().Any(c => c.CourseId == CrsStudentVM.CourseId && c.StudentId == CrsStudentVM.StudentId);

                    if (!exist)
                    {
                        _unitOfWork.CrsStudentRepo.Add(CrsStudent);
                        TempData["Message"] = "CrsInst Created Successfully!!";
                    }

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
