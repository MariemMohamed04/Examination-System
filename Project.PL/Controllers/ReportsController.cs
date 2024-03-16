using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.BLL.Repositories;
using Project.DAL.Entities;
using Project.PL.ViewModel;

namespace Project.PL.Controllers
{
    
    public class ReportsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReportsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public IActionResult GetTopicsByCourse(int courseId)
        {
            var Topics = _unitOfWork.ReportsRepo.GetTopicsByCourse(courseId);
             var reportFourViewModel = _mapper.Map<IEnumerable<ReportFourViewModel>>(Topics);

            return View(reportFourViewModel);
        }
        public IActionResult GetCoursesByID(int id)
        {
            var courses=_unitOfWork.ReportsRepo.GetCoursesByInstructorId(id);
            var reportThreeViewModel = _mapper.Map<IEnumerable<ReportFourViewModel>>(courses);
            return View(reportThreeViewModel);

        }
    }
}
