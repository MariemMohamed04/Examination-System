using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.BLL.Repositories;
using Project.DAL.Entities;
using Project.PL.ViewModel;

namespace Project.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index(string SearchValue = "")
        {
            IEnumerable<Department> departments;
            IEnumerable<DepartmentViewModel> mappedDepartments;
            if (string.IsNullOrEmpty(SearchValue))
            {
                departments = _unitOfWork.DepartmentRepo.GetAll();
                mappedDepartments = _mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
            }
            else
            {
                departments = _unitOfWork.DepartmentRepo.SearchByName(SearchValue);
                mappedDepartments = _mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
            }
            return View(mappedDepartments);
        }
    }
}
