using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.PL.ViewModel;

namespace Project.PL.Controllers
{
    [Authorize (Roles = "Admin")]
    public class BranchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BranchController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var branches = _unitOfWork.BranchRepo.GetAll();
            var branchViewModels = _mapper.Map<IEnumerable<BranchViewModel>>(branches);
            return View(branchViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new BranchViewModel());
        }

        [HttpPost]
        public IActionResult Create(BranchViewModel branchVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var branch = _mapper.Map<Branch>(branchVM);
                    var dublicatedId = _unitOfWork.BranchRepo.GetById(branch.BranchId);
                    if (dublicatedId != null)
                    {
                        ModelState.AddModelError("BranchId", "BranchId already exists.");
                        return View(branch);
                    }

                    _unitOfWork.BranchRepo.Add(branch);
                    TempData["Message"] = "Branch Created Successfully!!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return View(branchVM);
        }

        public IActionResult Details(int? id)
        {
            try
            {
                if (id is null)
                {
                    return NotFound();
                }

                var branch = _unitOfWork.BranchRepo.GetById(id);

                if (branch is null)
                {
                    return NotFound();
                }

                var branchVM = _mapper.Map<BranchViewModel>(branch);
                return View(branchVM);
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

            var branch = _unitOfWork.BranchRepo.GetById(id);
            var branchViewModel = _mapper.Map<BranchViewModel>(branch);


            if (branch is null)
            {
                return NotFound();
            }

            return View(branchViewModel);
        }

        [HttpPost]
        public IActionResult Update(int id, BranchViewModel branchVM)
        {
            if (id != branchVM.BranchId)
            {
                return NotFound();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    var branch = _mapper.Map<Branch>(branchVM);
                    _unitOfWork.BranchRepo.Update(branch);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View(branchVM);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var branch = _unitOfWork.BranchRepo.GetById(id);

            if (branch is null)
            {
                return NotFound();
            }

            var departmentVM = _mapper.Map<BranchViewModel>(branch);
            _unitOfWork.BranchRepo.Delete(branch);
            return RedirectToAction("Index");
        }
    }
}
