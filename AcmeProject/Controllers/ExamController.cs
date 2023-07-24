using Acme.BusinessLayer.Abstract;
using Acme.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AcmeProject.Controllers
{
    public class ExamController : Controller
    {
        private IExamService _examService;
        public ExamController(IExamService examService)
        {
           this._examService = examService;
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

        public IActionResult ExamRemove(int id)
        {
            _examService.ExamDelete(_examService.GetByID(id));  
            return RedirectToAction("Index");
        }
    }
}
