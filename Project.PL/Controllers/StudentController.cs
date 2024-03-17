using Microsoft.AspNetCore.Mvc;
using Project.DAL.Entities;
using Project.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AutoMapper;
using Project.PL.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace Project.PL.Controllers
{
    [Authorize(Roles = "Admin")]

    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var students = _unitOfWork.StudentRepo.GetAll();
            var studentVM = _mapper.Map<IEnumerable<StudentViewModel>>(students);
            return View(studentVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new StudentViewModel());
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel studentVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var student = _mapper.Map<Student>(studentVM);
                    var dublicatedId = _unitOfWork.StudentRepo.GetById(student.StudentId);
                    if (dublicatedId != null)
                    {
                        ModelState.AddModelError("StudentId", "student already exists.");
                        return View(student);
                    }
                    _unitOfWork.StudentRepo.Add(student);
                    TempData["Message"] = "student Created Successfully!!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return View(studentVM);
        }

        public IActionResult Details(int? id)
        {
            try
            {
                if (id is null)
                {
                    return NotFound();
                }

                var student = _unitOfWork.StudentRepo.GetById(id);
                if (student is null)
                {
                    return NotFound();
                }
                var studentVM = _mapper.Map<StudentViewModel>(student);
                return View(studentVM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var student = _unitOfWork.StudentRepo.GetById(id);
            var studentVM = _mapper.Map<StudentViewModel>(student);
            if (student is null)
            {
                return NotFound();
            }
            return View(studentVM);
        }

        [HttpPost]
        public IActionResult Update( int id, StudentViewModel studentVM)
        {
            if (id != studentVM.StudentId)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var student = _mapper.Map<Student>(studentVM);
                    _unitOfWork.StudentRepo.Update(student);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return View(studentVM);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var student = _unitOfWork.StudentRepo.GetById(id);
            if (student is null)
            {
                return NotFound();
            }
            var studentVM = _mapper.Map<StudentViewModel>(student);
            _unitOfWork.StudentRepo.Delete(student);
            return RedirectToAction("Index");
        }
    }
}
