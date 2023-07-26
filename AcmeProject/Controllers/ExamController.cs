using Acme.BusinessLayer.Abstract;
using Acme.BusinessLayer.Concrete;
using Acme.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AcmeProject.Controllers
{
    public class ExamController : Controller
    {
        private IExamService _examService;
        private IUserExamService _userExamService;
        private IQuestionExamService _questionExamService;
        public ExamController(IExamService examService, IUserExamService userExamService, IQuestionExamService questionExamService)
        {
           this._examService = examService;
            this._userExamService = userExamService;
            this._questionExamService = questionExamService;    
        }
        public IActionResult Index()
        {
            var Examvalues = _examService.GetList();

            return View(Examvalues);
        }
        [HttpGet]
        public IActionResult ExamInsert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ExamInsert(Exam exam)
        {
            _examService.ExamAdd(exam);
            return RedirectToAction("Index");  
        }

        [HttpGet]
        public IActionResult ExamUpdate(int id) 
        {
            var Examvalues = _examService.GetByID(id);
            return View(Examvalues);
        }
        [HttpPost]
        public IActionResult ExamUpdate(Exam exam) 
        {
            _examService.ExamUpdate(exam);
           return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ExamRemove(int id)
        {
            var examvalues = _examService.GetByID(id);
            return View(examvalues);
        }

        [HttpPost]
        public IActionResult ExamRemove(Exam exam)
        {
            try
            {
                 
                int issuccessExam = _examService.ExamDelete(exam.ID);
                
            }
            catch (Exception ex)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
    }
}
