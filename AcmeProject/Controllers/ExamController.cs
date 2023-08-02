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
        private IUserQuestionValueService _userQuestionValueService;
        private IQuestionService _questionService;
        private IValueService _valueService;
        private IQuestionValueService _questionValueService;
        private IControllerLogService _logService;
        public ExamController(IExamService examService, IUserExamService userExamService, IQuestionExamService questionExamService,IUserQuestionValueService userQuestionValueService, IQuestionService questionService,IValueService valueService, IQuestionValueService questionValueService, IControllerLogService logService)
        {
           this._examService = examService;
            this._userExamService = userExamService;
            this._questionExamService = questionExamService;    
            this._userQuestionValueService = userQuestionValueService;  
            this._questionService = questionService;
            this._valueService = valueService;
            this._questionValueService = questionValueService;
            this._logService = logService;
        }
        public IActionResult Index()
        {           

            try
            {
                var Examvalues = _examService.GetList();

                return View(Examvalues);
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "Exam",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }
        [HttpGet]
        public IActionResult ExamInsert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ExamInsert(Exam exam)
        {           

            try
            {
                _examService.ExamAdd(exam);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "Exam",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }

        [HttpGet]
        public IActionResult ExamUpdate(int id) 
        {           

            try
            {
                var Examvalues = _examService.GetByID(id);
                return View(Examvalues);
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "Exam",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }

        [HttpPost]
        public IActionResult ExamUpdate(Exam exam) 
        {            
            try
            {
                _examService.ExamUpdate(exam);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "Exam",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }

        [HttpGet]
        public IActionResult ExamRemove(int id)
        {           

            try
            {
                var examvalues = _examService.GetByID(id);
                return View(examvalues);
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "Exam",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }

        [HttpPost]
        public IActionResult ExamRemove(Exam exam)
        {
            try
            {
                var questionExam = _questionService.GetOnAllQuestionExam(exam.ID, int.MaxValue, 1, out int totalCount);
                List<int> questionIDs = new List<int>();
                List<int> valueID = new List<int>();
                foreach (var item in questionExam)
                {
                    questionIDs.Add(item.ID);

                    var questionValue = _questionValueService.GetQuestionValue(item.ID);
                    foreach (var item2 in questionValue)
                    {
                        valueID.Add(item2.ValueID);
                    }
                }

                // int issuccessExam = _examService.ExamDelete(exam.ID);
                if (questionIDs.Count > 0)
                {
                    _userQuestionValueService.UserQuestionValueDelete(questionIDs);
                }
                if (valueID.Count > 0)
                {
                    _valueService.ValueDelete(valueID);
                }
                if (questionIDs.Count > 0)
                {
                    _questionValueService.QuestionValueDelete(questionIDs);
                }
                
                
                _userExamService.UserExamDelete(new List<int>() { exam.ID });

                if (questionIDs.Count > 0)
                {
                    _questionService.QuestionDelete(questionIDs);
                }
                if (questionIDs.Count > 0)
                {
                    _questionExamService.QuestionExamDelete(questionIDs);
                }                
                
                _examService.ExamDelete(new List<int>() { exam.ID });

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "Exam",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }

            
        }
    }
}
