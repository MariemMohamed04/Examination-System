using Microsoft.AspNetCore.Mvc;
using Project.DAL.Entities;
using Project.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Project.PL.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var student = _unitOfWork.StudentRepo.GetAll();
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Student());
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                var dublicatedId = _unitOfWork.StudentRepo.GetById(student.StudentId);
                if (dublicatedId != null)
                {
                    ModelState.AddModelError("StudentId", "student already exists.");
                    return View(student);
                }
                _unitOfWork.StudentRepo.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Details(int? id)
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
            return View(student);
        }

        [HttpGet]
        public IActionResult Update(int? id)
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
            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Student student, int id)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.StudentRepo.Update(student);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return View(student);
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
            _unitOfWork.StudentRepo.Delete(student);
            return RedirectToAction("Index");
        }
    }
}
