using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.PL.ViewModel;

namespace Project.PL.Controllers
{
    [Authorize(Roles = "Admin")]

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

        public IActionResult Details(int crsId, int deptId)
        {
            var crsDept = _unitOfWork.CrsDeptRepo.GetByIds(crsId, deptId);
            if (crsDept == null)
            {
                return NotFound();
            }

            var crsDeptVM = _mapper.Map<CrsDeptViewModel>(crsDept);

            return View(crsDeptVM);
        }

        //[HttpGet]
        //public IActionResult Update(int crsId, int deptId)
        //{
        //    var crsDept = _unitOfWork.CrsDeptRepo.GetByIds(crsId, deptId);
        //    if (crsDept == null)
        //    {
        //        return NotFound();
        //    }

        //    var crsDeptVM = _mapper.Map<CrsDeptViewModel>(crsDept);
        //    ViewBag.Courses = _unitOfWork.CourseRepo.GetAll();
        //    ViewBag.Departments = _unitOfWork.DepartmentRepo.GetAll();

        //    return View(crsDeptVM);
        //}

        //[HttpPost]
        //public IActionResult Update(CrsDeptViewModel crsDeptVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var crsDept = _mapper.Map<CourseDepartment>(crsDeptVM);
        //            _unitOfWork.CrsDeptRepo.Update(crsDept);
        //            TempData["Message"] = "CourseDepartment Updated Successfully!!";
        //            return RedirectToAction("Index");
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }

        //    ViewBag.Courses = _unitOfWork.CourseRepo.GetAll();
        //    ViewBag.Departments = _unitOfWork.DepartmentRepo.GetAll();
        //    return View(crsDeptVM);
        //}

        public IActionResult Delete(int crsId, int deptId)
        {
            var crsDept = _unitOfWork.CrsDeptRepo.GetByIds(crsId, deptId);
            if (crsDept == null)
            {
                return NotFound();
            }

            var crsDeptVM = _mapper.Map<CrsDeptViewModel>(crsDept);
            _unitOfWork.CrsDeptRepo.Delete(crsDept);
            return RedirectToAction("Index");
        }

    }
}
