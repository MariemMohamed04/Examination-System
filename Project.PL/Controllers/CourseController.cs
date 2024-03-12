using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL.Entities;

namespace Project.PL.Controllers
{
    public class CourseController : Controller
    {
        
            private readonly IUnitOfWork unitOfWork;

            public CourseController(IUnitOfWork _unitOfWork)
            {
                unitOfWork = _unitOfWork;
            }

            public IActionResult Index()
            {
                var courses=unitOfWork.CourseRepo.GetAll();

                return View(courses);
            }

        [HttpGet]
        public IActionResult Create()
        {

            return View(new Course());
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {

                unitOfWork.CourseRepo.Add(course);
                return RedirectToAction("Index");
            }
            else
                return View(course);
        }


        public IActionResult Details(int? id) 
        {
            if (id == null)
            {
                return BadRequest();
            }
            var course = unitOfWork.CourseRepo.GetById(id.Value);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);

        }

        [HttpGet]
        public IActionResult Update(int? id) 
        {

            if (id == null)
            {
                return BadRequest();
            }
            var course = unitOfWork.CourseRepo.GetById(id.Value);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        public IActionResult Update(Course course, int? id)
        {
            course.CourseId = id.Value;
            unitOfWork.CourseRepo.Update(course);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var course = unitOfWork.CourseRepo.GetById(id.Value);
            if (course == null)
            {
                return NotFound();
            }
            unitOfWork.CourseRepo.Delete(course);

            return RedirectToAction("Index");
        }
    }

}

