using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.BLL.Interfaces;
using Project.BLL.Repositories;
using Project.DAL.Entities;
using Project.PL.ViewModel;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace Project.PL.Controllers
{

    [Authorize(Roles = "Student")]
    public class StartExamController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public List<Exam> exams; 

        public StartExamController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public IActionResult StudentMain()
        {
            List<Course> examCourses  = new List<Course>();  
            string name = User.Identity.Name;

            string id =  User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value; 

            var student = _unitOfWork.StudentRepo.getStudentByUserId(id);

            var courses = _unitOfWork.CourseRepo.getAllCourseStudent(student.StudentId);
            var exams = _unitOfWork.ExamRepo.GetAll();

         
            foreach(var course in courses)
            {
                var exam = exams.FirstOrDefault(e => e.CourseId == course.CourseId) ;
                
                if ( exam!=null)
                {
                    if(!_unitOfWork.StudentRepo.getStudentAnswers(exam.ExamId))
                         examCourses.Add(course);
                }
            }  

            //ViewBag.Courses = courses;
            ViewBag.StudentId = student.StudentId;


            return View(examCourses);
        }


        [HttpPost]
        public IActionResult StudentMain(int CourseId , int StudentId)
        {
             
            var exam = _unitOfWork.ExamRepo.getFirstExam(CourseId);
            
            var questions = _unitOfWork.ExamRepo.getExamQuestions(exam.ExamId);
            var  mappedQuestions = _mapper.Map<List<QuestionViewModel>>(questions);

            var choices = _unitOfWork.ChoiceRepo.GetAll();
            List<Choice> allChoices = new List<Choice>(); 
            foreach (var question in questions)
            {
              var allQChoices =   choices.Where(ch => ch.QuestionId == question.QuestionId && question.QuestionType == "MCQ");

                foreach(var choice in allQChoices)
                {
                   
                    allChoices.Add(choice);
                    
                }     

            }

            var mappedChoices= _mapper.Map<List<ChoiceViewModel>>(allChoices);

            string json = JsonConvert.SerializeObject(mappedQuestions);
            string json2 = JsonConvert.SerializeObject(mappedChoices);
            TempData["QuestionList"] = json;
            TempData["allChoices"] = json2;

            //ViewBag.AllChoices = allChoices;
            return RedirectToAction("ShowExam" , "StartExam", new {  studentId = StudentId , examId = exam.ExamId });
        }


        public IActionResult ShowExam( int studentId , int examId )
        {

            string questions = TempData["QuestionList"] as string;
            string choices = TempData["allChoices"] as string;

            List<Question> Questions = JsonConvert.DeserializeObject<List<Question>>(questions); 
            List<Choice> Choices = JsonConvert.DeserializeObject<List<Choice>>(choices); 

            ViewBag.choices = Choices;
            ViewBag.studentId = studentId;
            ViewBag.examId = examId;


            return View(Questions);  
        }



        [HttpPost]
        public IActionResult ShowExam(List<StudentExamQuestion> Answers)
        {

           foreach(var ans in Answers)
            {
                _unitOfWork.StudentRepo.addStudentAnswers(ans);
            }

          /*  var StudentExam = Answers[0].ExamId;
            var StudentId = Answers[0].StudentId;
            var allExams = _unitOfWork.ExamRepo.GetAll();
            var studentExamCourseId = allExams.FirstOrDefault(c => c.ExamId == StudentExam).CourseId; */

           /* var course = _unitOfWork.CourseRepo.GetAll().FirstOrDefault(c=>c.CourseId == studentExamCourseId);*/
            
          //  var courseStudentGrade = _unitOfWork.CourseRepo.getAllCourseStudents().FirstOrDefault(cs=>cs.CourseId == studentExamCourseId && cs.StudentId ==StudentId);
             
            
            

            int correctAns = 0;
            for(int i= 0 ; i < Answers.Count; i++ )
            {
                var ans = Answers[i]; 
               var question = _unitOfWork.QuestionRepo.GetById(ans.QuestionId);

                if(question.QuestionAnswer == ans.StudentAnswer)
                {
                    correctAns += 1;
                }

            }

            double grade = (correctAns*100.0)/Answers.Count;

            int wrongAns = Answers.Count - correctAns;

            //courseStudentGrade.CrsGrade = (int)grade;
            

            return RedirectToAction("ShowResult" , "StartExam" , new {Studentgrade = grade , CorrectAns = correctAns , WrongAns = wrongAns } );
        }



        public IActionResult ShowResult(double Studentgrade, int CorrectAns , int WrongAns) { 
        
            ViewBag.Studentgrade = Studentgrade;    
            ViewBag.CorrectAns = CorrectAns;    
            ViewBag.WrongAns = WrongAns;   
       
            return View(); 
        }



    }
}
