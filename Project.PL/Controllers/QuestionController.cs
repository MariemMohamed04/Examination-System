using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.PL.ViewModel;
using System;
using System.Collections.Generic;

namespace Project.PL.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<QuestionController> _logger;

        public QuestionController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<QuestionController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult Index(string searchValue = "")
        {
            IEnumerable<Question> questions;
            IEnumerable<QuestionViewModel> mappedQuestions;
            if (string.IsNullOrEmpty(searchValue))
            {
                questions = _unitOfWork.QuestionRepo.GetAll();
                mappedQuestions = _mapper.Map<IEnumerable<QuestionViewModel>>(questions);
            }
            else
            {
                questions = _unitOfWork.QuestionRepo.SearchByText(searchValue);
                mappedQuestions = _mapper.Map<IEnumerable<QuestionViewModel>>(questions);
            }
            return View(mappedQuestions);
        }

        public IActionResult Create()
        {
            return View(new QuestionViewModel());
        }

        [HttpPost]
        public IActionResult Create(QuestionViewModel questionVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var question = _mapper.Map<Question>(questionVM);

                    // Check for duplicate question ID
                    var duplicateId = _unitOfWork.QuestionRepo.GetById(question.QuestionId);
                    if (duplicateId != null)
                    {
                        ModelState.AddModelError("QuestionId", "Question ID already exists.");
                        return View(question);
                    }

                    _unitOfWork.QuestionRepo.Add(question);
                    TempData["Message"] = "Question Created Successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the exception and inner exception
                    _logger.LogError(ex, "An error occurred while creating a question.");
                    if (ex.InnerException != null)
                    {
                        _logger.LogError(ex.InnerException, "Inner Exception");
                    }

                    // Redirect to an error page or display a user-friendly error message
                    return RedirectToAction("Error", "Home");
                }
            }

            return View(questionVM);
        }

        public IActionResult Update(int? id)
        {
            if (id is null)
                return NotFound();

            var question = _unitOfWork.QuestionRepo.GetById(id);

            if (question is null)
                return NotFound();

            var questionVM = _mapper.Map<QuestionViewModel>(question);

            return View(questionVM);
        }

        [HttpPost]
        public IActionResult Update(int id, QuestionViewModel questionVM)
        {
            if (id != questionVM.QuestionId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var question = _mapper.Map<Question>(questionVM);
                    _unitOfWork.QuestionRepo.Update(question);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return View(questionVM);
        }

        public IActionResult Details(int? id)
        {
            try
            {
                if (id is null)
                    return NotFound();

                var question = _unitOfWork.QuestionRepo.GetById(id);

                if (question is null)
                    return NotFound();

                var questionVM = _mapper.Map<QuestionViewModel>(question);

                return View(questionVM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var question = _unitOfWork.QuestionRepo.GetById(id);

            if (question is null)
                return NotFound();

            _unitOfWork.QuestionRepo.Delete(question);

            return RedirectToAction(nameof(Index));
        }
    }
}