using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.BLL.Repositories;
using Project.DAL.Entities;
using Project.PL.ViewModel;

namespace Project.PL.Controllers
{
    [Authorize(Roles = "Admin")]

    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DepartmentController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult Index(string SearchValue = "")
        {
            IEnumerable<Department> departments;
            IEnumerable<DepartmentViewModel> mappedDepartments;
            if (string.IsNullOrEmpty(SearchValue))
            {
                departments = _unitOfWork.DepartmentRepo.GetAll();
                mappedDepartments = _mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
            }
            else
            {
                departments = _unitOfWork.DepartmentRepo.SearchByName(SearchValue);
                mappedDepartments = _mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
            }
            return View(mappedDepartments);
        }

        public IActionResult Create()
        {
            ViewBag.Branches = _unitOfWork.BranchRepo.GetAll();
            ViewBag.Instructors = _unitOfWork.InstructorRepo.GetAll();
            return View(new DepartmentViewModel());
        }

        [HttpPost]
        public IActionResult Create(DepartmentViewModel departmentVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var department = _mapper.Map<Department>(departmentVM);

                    var dublicatedId = _unitOfWork.DepartmentRepo.GetById(department.DepartmentId);
                    if (dublicatedId != null)
                    {
                        ModelState.AddModelError("DepartmentId", "DepartmentId already exists.");
                        return View(department);
                    }

                    _unitOfWork.DepartmentRepo.Add(department);
                    TempData["Message"] = "Department Created Successfully!!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the exception and inner exception
                    _logger.LogError(ex, "An error occurred while creating a department.");
                    if (ex.InnerException != null)
                    {
                        _logger.LogError(ex.InnerException, "Inner Exception");
                    }

                    // Redirect to an error page or display a user-friendly error message
                    return RedirectToAction("Error", "Home");
                }

            }
            ViewBag.Branches = _unitOfWork.BranchRepo.GetAll();
            ViewBag.Instructors = _unitOfWork.InstructorRepo.GetAll();
            return View(departmentVM);
        }
        public IActionResult Details(int? id)
        {
            try
            {
                if (id is null)
                    return NotFound();
                var department = _unitOfWork.DepartmentRepo.GetById(id);
                if (department is null)
                    return NotFound();

                var departmentVM = _mapper.Map<DepartmentViewModel>(department);
                return View(departmentVM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IActionResult Update(int? id)
        {
            if (id is null)
                return NotFound();

            var department = _unitOfWork.DepartmentRepo.GetById(id);

            if (department is null)
                return NotFound();

            var departmentVM = _mapper.Map<DepartmentViewModel>(department);
            ViewBag.Branches = _unitOfWork.BranchRepo.GetAll();
            ViewBag.Instructors = _unitOfWork.InstructorRepo.GetAll();

            return View(departmentVM);
        }

        [HttpPost]
        public IActionResult Update(int id, DepartmentViewModel departmentVM)
        {
            if (id != departmentVM.DepartmentId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var department = _mapper.Map<Department>(departmentVM);
                    _unitOfWork.DepartmentRepo.Update(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            ViewBag.Branches = _unitOfWork.BranchRepo.GetAll();
            ViewBag.Instructors = _unitOfWork.InstructorRepo.GetAll();

            return View(departmentVM);
        }


        public IActionResult Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var department = _unitOfWork.DepartmentRepo.GetById(id);

            if (department is null)
                return NotFound();

            var departmentVM = _mapper.Map<DepartmentViewModel>(department);

            _unitOfWork.DepartmentRepo.Delete(department);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetDepartmentsByBranch(int branchId)
        {
            var departments = _unitOfWork.DepartmentRepo.GetDepartmentsByBranch(branchId);
            var mappedDepartments = _mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
            return View("Index", mappedDepartments);
        }
    }
}
