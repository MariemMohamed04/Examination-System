using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.BLL.Repositories;
using Project.DAL.Entities;
using Project.PL.ViewModel;

namespace Project.PL.Controllers
{
    [Authorize(Roles = "Admin")]

    public class CourseController : Controller
    {
        
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;


        public CourseController(IUnitOfWork _unitOfWork , IMapper mapper)
        {
            unitOfWork = _unitOfWork;
            _mapper = mapper;
        }


/*        public IActionResult Index()
        {
            var courses=unitOfWork.CourseRepo.GetAll();
            var mappedCourses = _mapper.Map<IEnumerable<CourseViewModel>>(courses);
            return View(mappedCourses);
        }
*/

        public IActionResult Index(string SearchValue = "")
        {
            IEnumerable<Course> courses;
            IEnumerable<CourseViewModel> mappedCourses;
            if (string.IsNullOrEmpty(SearchValue))
            {
                courses = unitOfWork.CourseRepo.GetAll();
                mappedCourses = _mapper.Map<IEnumerable<CourseViewModel>>(courses);
            }
            else
            {
                courses = unitOfWork.CourseRepo.SearchByName(SearchValue);
                mappedCourses = _mapper.Map<IEnumerable<CourseViewModel>>(courses);
            }
            return View(mappedCourses);
        }


        [HttpGet]
        public IActionResult Create()
        {

            return View(new CourseViewModel());
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {

                unitOfWork.CourseRepo.Add(course);
                return RedirectToAction("Create", "Topice");
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
            var course = unitOfWork.CourseRepo.getCourseWithTopics(id);
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
            var mappedCourse = _mapper.Map<CourseViewModel>(course);
            return View(mappedCourse);
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

