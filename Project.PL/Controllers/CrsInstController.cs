using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.BLL.Repositories;
using Project.DAL.Entities;
using Project.PL.ViewModel;

namespace Project.PL.Controllers
{
    public class CrsInstController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CrsInstController(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var CrsInsts = _unitOfWork.CrsInstRepo.GetAll();
            var CrsInstViewModels = _mapper.Map<IEnumerable<CrsInstViewModel>>(CrsInsts);
            return View(CrsInstViewModels);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Courses = _unitOfWork.CourseRepo.GetAll();
            ViewBag.Instructors = _unitOfWork.InstructorRepo.GetAll();
            return View(new CrsInstViewModel());
        }

        [HttpPost]
        public IActionResult Create(CrsInstViewModel CrsInstVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var CrsInst = _mapper.Map<CourseInstructor>(CrsInstVM);
                    

                    _unitOfWork.CrsInstRepo.Add(CrsInst);
                    TempData["Message"] = "CrsInst Created Successfully!!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            ViewBag.Courses = _unitOfWork.CourseRepo.GetAll();
            ViewBag.Instructors = _unitOfWork.InstructorRepo.GetAll();
            return View(CrsInstVM);
        }
        public IActionResult Delete(int crsId, int InsId)
        {
            var crsIns = _unitOfWork.CrsInstRepo.GetByIds(crsId, InsId);
            if (crsIns == null)
            {
                return NotFound();
            }

            var crsInsVM = _mapper.Map<CrsInstViewModel>(crsIns);
            _unitOfWork.CrsInstRepo.Delete(crsIns);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int crsId, int InsId)
        {
            var crsIns = _unitOfWork.CrsInstRepo.GetByIds(crsId, InsId);
            if (crsIns == null)
            {
                return NotFound();
            }

            var crsInsVM = _mapper.Map<CrsInstViewModel>(crsIns);

            return View(crsInsVM);
        }



    }
}
