using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.PL.ViewModel;

namespace Project.PL.Controllers
{
    [Authorize(Roles = "Admin")]

    public class TopicController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public TopicController(IUnitOfWork _unitOfWork, IMapper mapper)
        {
            unitOfWork = _unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var topics = unitOfWork.TopicRepo.GetAll();
            var mappedTopics = _mapper.Map<IEnumerable<TopicViewModel>>(topics);
            return View(mappedTopics);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Courses = unitOfWork.CourseRepo.GetAll();
            return View(new TopicViewModel());
        }

        [HttpPost]
        public IActionResult Create(Topic topic)
        {
            if (ModelState.IsValid)
            {

                unitOfWork.TopicRepo.Add(topic);
                return RedirectToAction("Index");
            }
            else
                return View(topic);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var topic = unitOfWork.TopicRepo.GetById(id.Value);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);

        }

        [HttpGet]
        public IActionResult Update(int? id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            var topic = unitOfWork.TopicRepo.GetById(id.Value);
            if (topic == null)
            {
                return NotFound();
            }
            ViewBag.Courses = unitOfWork.CourseRepo.GetAll();
            var mappedTopic = _mapper.Map<TopicViewModel>(topic);

            return View(mappedTopic);
        }

        [HttpPost]
        public IActionResult Update(Topic topic, int? id)
        {
            topic.CourseId = id.Value;
            unitOfWork.TopicRepo.Update(topic);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var topic = unitOfWork.TopicRepo.GetById(id.Value);
            if (topic == null)
            {
                return NotFound();
            }
            unitOfWork.TopicRepo.Delete(topic);

            return RedirectToAction("Index");
        }
    }
}
