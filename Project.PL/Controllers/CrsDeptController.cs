using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.PL.ViewModel;

namespace Project.PL.Controllers
{
    public class CrsDeptController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CrsDeptController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var CrsDepts = _unitOfWork.CrsDeptRepo.GetAll();
            var crsDeptViewModels = _mapper.Map<IEnumerable<CrsDeptViewModel>>(CrsDepts);
            return View(crsDeptViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Courses = _unitOfWork.CourseRepo.GetAll();
            ViewBag.Departments = _unitOfWork.DepartmentRepo.GetAll();
            return View(new CrsDeptViewModel());
        }

        [HttpPost]
        public IActionResult Create(CrsDeptViewModel crsDeptVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var crsDept = _mapper.Map<CourseDepartment>(crsDeptVM);
                    _unitOfWork.CrsDeptRepo.Add(crsDept);
                    TempData["Message"] = "CourseDepartment Created Successfully!!";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            ViewBag.Courses = _unitOfWork.CourseRepo.GetAll();
            ViewBag.Departments = _unitOfWork.DepartmentRepo.GetAll();
            return View(crsDeptVM);
        }

        [HttpGet]
        public IActionResult Update(int crsId, int deptId)
        {
            var crsDept = _unitOfWork.CrsDeptRepo.GetByIds(crsId, deptId);
            if (crsDept == null)
            {
                return NotFound();
            }

            var crsDeptVM = _mapper.Map<CrsDeptViewModel>(crsDept);
            ViewBag.Courses = _unitOfWork.CourseRepo.GetAll();
            ViewBag.Departments = _unitOfWork.DepartmentRepo.GetAll();

            return View(crsDeptVM);
        }

        [HttpPost]
        public IActionResult Update(int crsId, int deptId, CrsDeptViewModel crsDeptVM)
        {
            if (crsId != crsDeptVM.CourseId || deptId != crsDeptVM.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var crsDept = _unitOfWork.CrsDeptRepo.GetByIds(crsId, deptId); // Use the composite key
                    if (crsDept == null)
                    {
                        return NotFound();
                    }

                    // Update the properties of crsDept
                    crsDept.CourseId = crsDeptVM.CourseId;
                    crsDept.DepartmentId = crsDeptVM.DepartmentId;

                    _unitOfWork.CrsDeptRepo.Update(crsDept);
                    TempData["Message"] = "CourseDepartment Updated Successfully!!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            ViewBag.Courses = _unitOfWork.CourseRepo.GetAll();
            ViewBag.Departments = _unitOfWork.DepartmentRepo.GetAll();

            return View(crsDeptVM);
        }



    }
}
