using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.PL.ViewModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Project.PL.Controllers
{
    public class CourseController : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
           var  courses = _unitOfWork.CourseRepo.GetAll();
           var CourseViewModels = _mapper.Map<IEnumerable<CourseViewModel>>(courses);
            return View(CourseViewModels);
        }
       


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Topics = _unitOfWork.TopicRepo.GetAll();
            return View(new CourseViewModel());
        }

        [HttpPost]
        public IActionResult Create(CourseViewModel courseVM )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var course = _mapper.Map<Course>(courseVM);
                    var dublicatedId = _unitOfWork.CourseRepo.GetById(course.CourseId);
                    if (dublicatedId != null)
                    {
                        ModelState.AddModelError("CourseId", "Course already exists.");
                        return View(course);
                    }
                    _unitOfWork.CourseRepo.Add(course);


             


                    TempData["Message"] = "course Created Successfully!!";

                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    var innerException = ex.InnerException;
                    Debug.WriteLine(innerException);
                }
            }
            return View(courseVM);
        }

        public IActionResult Details(int? id)
        {
            try
            {
                if (id is null)
                {
                    return NotFound();
                }

                var course = _unitOfWork.CourseRepo.GetByIdIncld(id.Value);
                if (course is null)
                {
                    return NotFound();
                }
                //var courseVM = _mapper.Map<CourseViewModel>(course);
                return View(course/*VM*/);
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

            var course = _unitOfWork.CourseRepo.GetById(id);
            var courseVM = _mapper.Map<CourseViewModel>(course);
            if (course is null)
            {
                return NotFound();
            }
            return View(courseVM);
        }

        [HttpPost]
        public IActionResult Update(int id, CourseViewModel courseVM)
        {
            if (id != courseVM.CourseId)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var course = _mapper.Map<Course>(courseVM);
                    _unitOfWork.CourseRepo.Update(course);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return View(courseVM);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var course = _unitOfWork.CourseRepo.GetById(id);
            if (course is null)
            {
                return NotFound();
            }
            var courseVM = _mapper.Map<CourseViewModel>(course);
            _unitOfWork.CourseRepo.Delete(course);
            return RedirectToAction("Index");
        }
    }

}

