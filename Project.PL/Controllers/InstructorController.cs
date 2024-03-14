using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.PL.ViewModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Project.PL.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InstructorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var instructors = _unitOfWork.InstructorRepo.GetAll();
            var instructorViewModels = _mapper.Map<IEnumerable<InstructorViewModel>>(instructors);
            return View(instructorViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new InstructorViewModel());
        }

        [HttpPost]
        public IActionResult Create(InstructorViewModel instructorVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                
                    var instructor = _mapper.Map<Instructor>(instructorVM);
                    var dublicatedId = _unitOfWork.InstructorRepo.GetById(instructor.InstructorId);
                    if (dublicatedId != null)
                    {
                        ModelState.AddModelError("InstructorId", "instructor already exists.");
                        return View(instructor);
                    }
                    _unitOfWork.InstructorRepo.Add(instructor);
                    TempData["Message"] = "instructor Created Successfully!!";
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    var innerException = ex.InnerException;
                    Debug.WriteLine(innerException); 
                }
            }
            return View(instructorVM);
        }

             public IActionResult Details(int? id)
             {
            try
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
                var InstructorVM = _mapper.Map<InstructorViewModel>(instructor);
                return View(InstructorVM);
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

            var instructor = _unitOfWork.InstructorRepo.GetById(id);
            var instructorViewModel = _mapper.Map<InstructorViewModel>(instructor);
            if (instructor is null)
            {
                return NotFound();
            }
            return View(instructorViewModel);
        }

        [HttpPost]
        public IActionResult Update( int id, InstructorViewModel instructorVM)
        {
            if (id != instructorVM.InstructorId)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var instructor = _mapper.Map<Instructor>(instructorVM);
                    _unitOfWork.InstructorRepo.Update(instructor);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return View(instructorVM);
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
            var instructorVM = _mapper.Map<InstructorViewModel>(instructor);
            _unitOfWork.InstructorRepo.Delete(instructor);
            return RedirectToAction("Index");
        }
    }
}
