using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.PL.ViewModel;
using System.Diagnostics;

namespace Project.PL.Controllers
{
    public class TopicController : Controller
    {
        

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TopicController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
           var topics = _unitOfWork.TopicRepo.GetAll();
           
           var topicViewModels = _mapper.Map<IEnumerable<TopicViewModel>>(topics);
            return View(topicViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Courses = _unitOfWork.CourseRepo.GetAll();
            return View(new TopicViewModel());
        }

        [HttpPost]
        public IActionResult Create(TopicViewModel topicVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var topic = _mapper.Map<Topic>(topicVM);
                    var dublicatedId = _unitOfWork.TopicRepo.GetById(topic.TopicId);

                    if (dublicatedId != null)
                    {
                        ModelState.AddModelError("topicId", "topic already exists.");
                        return View(topic);
                    }
                    _unitOfWork.TopicRepo.Add(topic);
                    TempData["Message"] = "topic Created Successfully!!";
                    return RedirectToAction("index");

                }
                catch (DbUpdateException ex)
                {
                    var innerException = ex.InnerException;
                    Debug.WriteLine(innerException);
                }
            }
            return View(topicVM);
        }

        public IActionResult Details(int? id)
        {
            try
            {
                if (id is null)
                {
                    return NotFound();
                }

                var topic = _unitOfWork.TopicRepo.GetByIdIncld(id.Value);
                if (topic is null)
                {
                    return NotFound();
                }
               // var topicVM = _mapper.Map<TopicViewModel>(topic);
                return View(topic/*VM*/);
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

            
            var topic = _unitOfWork.TopicRepo.GetById(id);
            var topicVM = _mapper.Map<TopicViewModel>(topic);
            if (topic is null)
            {
                return NotFound();
            }

            ViewBag.Courses = _unitOfWork.CourseRepo.GetAll();
            return View(topicVM);
        }

        [HttpPost]
        public IActionResult Update(int id, TopicViewModel topicVM)
        {
            if (id != topicVM.TopicId)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var topic = _mapper.Map<Topic>(topicVM);
                    _unitOfWork.TopicRepo.Update(topic);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return View(topicVM);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var topic = _unitOfWork.TopicRepo.GetById(id.Value);

            if (topic is null)
            {
                return NotFound();
            }
            var topicVM = _mapper.Map<TopicViewModel>(topic);
            _unitOfWork.TopicRepo.Delete(topic);
            return RedirectToAction("Index");
        }
    }

}

