using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL.Entities;

namespace Project.PL.Controllers
{
    public class TopicController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public TopicController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
            var topics = unitOfWork.TopicRepo.GetAll();

            return View(topics);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View(new Topic());
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

            return View(topic);
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
