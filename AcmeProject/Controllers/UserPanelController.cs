using Acme.BusinessLayer.Abstract;
using Acme.Core.Entity;
using Acme.Core.Model;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Diagnostics;
using System.Drawing.Printing;

namespace AcmeProject.Controllers
{
    public class UserPanelController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;
        private IUserService _userService;
        private IUserExamService _userExamService;
        private IUserQuestionValueService _userQuestionValueService;
        private IExamService _examService;
        private IQuestionService _questionService;
        private IValueService _valueService;
        private IQuestionValueService _questionValueService;
        private IReportService _reportService;
        private IControllerLogService _logService;

        public UserPanelController(IHttpContextAccessor httpContextAccessor, IUserService userService, IUserExamService userExamService,IUserQuestionValueService userQuestionValueService, IExamService examService, IQuestionService questionService, IValueService valueService,IQuestionValueService questionValueService, IReportService reportService, IControllerLogService logService) 
        {
            this._userService = userService;
            this._httpContextAccessor = httpContextAccessor;
            this._userExamService = userExamService;
            this._userQuestionValueService = userQuestionValueService;
            this._examService = examService;
            this._questionService = questionService;   
            this._valueService = valueService;  
            this._questionValueService = questionValueService;
            this._reportService = reportService;
            this._logService = logService;

        }
        public IActionResult Index()
        {           

            try
            {
                int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
                var user = _userService.GetByID((int)userID);
                ViewBag.userNameSurname = user.UserName + " " + user.UserSurname;
                var userExam = _examService.GetAllUserExam((int)userID);
                return View(userExam);
            }
            catch (Exception ex)
            {
                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "UserPanel",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }

        [HttpGet]
        public IActionResult UserProfile()
        {            
            try
            {
                int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
                var user = _userService.GetByID((int)userID);
                return View(user);
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "UserPanel",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }
        [HttpPost]
        public IActionResult UserProfile(User user)
        {
            
            try
            {
                _userService.UserUpdate(user);
                return View();
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "UserPanel",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }

        public IActionResult UserQuestion(int id, int pageNumber = 1, int pageSize = 2)
        {           
            try
            {
                string dateTimeNow = DateTime.Now.ToString();
                _httpContextAccessor.HttpContext.Session.SetString("DateTime", dateTimeNow);

                var exam = _examService.GetByID(id);
                ViewBag.ExamName = exam.Name;

                UserQuestionModel userQuestionModel = new UserQuestionModel();
                userQuestionModel.ExamID = id;

                int totalCount = 0;
                userQuestionModel.ExamID = id;
                userQuestionModel.CurrentPage = pageNumber;
                userQuestionModel.PageSize = pageSize;
                
                var questions = _questionService.GetOnAllQuestionExam(id, pageSize, pageNumber, out totalCount);

                userQuestionModel.TotalCount = totalCount;

                foreach (var question in questions)
                    userQuestionModel.Questions.Add(question, _valueService.GetOnAllQuestionExam(question.ID));

                return View(userQuestionModel);
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "UserPanel",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }

        [HttpPost]
        public IActionResult UserAnswer(int id, int elapsedTime)
        {          

            try
            {
                double examTimeDk = elapsedTime / (1000.0 * 60.0);
                int trueCount = 0;
                int wrongCount = 0;

                var questions = _questionService.GetOnAllQuestionExam(id, int.MaxValue, 1, out int totalCount);
                int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");

                foreach (var question in questions)
                {
                    var selectedQuestionValueID = int.Parse(Request.Form[$"questionValueBox_{question.ID}"].ToString());

                    if (question.TrueValueID == selectedQuestionValueID)
                        trueCount++;
                    else
                        wrongCount++;

                    //ID = Notlardaki 1. maddede oluşturulan metod çağırılacak (question.ID, selectedQuestionValueID)
                    var questionValue = _questionValueService.GetQuestionValue(question.ID, selectedQuestionValueID);
                    int ID = questionValue.ID;

                    UserQuestionValue userQuestionValue = new UserQuestionValue()
                    {
                        QuestionValueID = ID,
                        UserID = userID.Value
                    };

                    _userQuestionValueService.UserQuestionValueAdd(userQuestionValue);
                }
                string datetime = _httpContextAccessor.HttpContext.Session.GetString("DateTime");
                Report report = new Report()
                {
                    UserID = userID.Value,
                    ExamID = id,
                    Duration = Convert.ToDecimal(examTimeDk),
                    TrueCount = trueCount,
                    WrongCount = wrongCount,
                    StartDate = Convert.ToDateTime(datetime)
                };
                _reportService.ReportAdd(report);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "UserPanel",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }
    }
}
