using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL.Entities;

namespace Project.PL.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public InstructorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var instructor = _unitOfWork.InstructorRepo.GetAll();
            return View(instructor);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Instructor());
        }

        [HttpPost]
        public IActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                var dublicatedId = _unitOfWork.InstructorRepo.GetById(instructor.InstructorId);
                if (dublicatedId != null)
                {
                    ModelState.AddModelError("InstructorId", "instructor already exists.");
                    return View(instructor);
                }
                _unitOfWork.InstructorRepo.Add(instructor);
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var instructor = _unitOfWork.InstructorRepo.GetById(id);
            if (instructor is null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var instructor = _unitOfWork.InstructorRepo.GetById(id);
            if (instructor is null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        [HttpPost]
        public IActionResult Update(Instructor instructor, int id)
        {
            if (id != instructor.InstructorId)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.InstructorRepo.Update(instructor);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return View(instructor);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var instructor = _unitOfWork.InstructorRepo.GetById(id);
            if (instructor is null)
            {
                return NotFound();
            }
            _unitOfWork.InstructorRepo.Delete(instructor);
            return RedirectToAction("Index");
        }
    }
}
