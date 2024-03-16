using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
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
        public IActionResult GetStudentByDepartment(int deptId)
        {
            var students = _unitOfWork.ReportsRepo.GetStudentsByDepartment(deptId);
            var reportOneViewModel = _mapper.Map<IEnumerable<ReportOneViewModel>>(students);
            //ViewBag.Departments = _unitOfWork.DepartmentRepo.GetAll();
            return View(reportOneViewModel);
        }
    }
}

