using Acme.BusinessLayer.Abstract;
using Acme.BusinessLayer.Concrete;
using Acme.Core.Entity;
using Acme.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcmeProject.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        private IUserExamService _userExamService;
        private IExamService _examService;
        private IUserQuestionValueService _userQuestionValueService;
        private IHttpContextAccessor _httpContextAccessor;
        private IControllerLogService _logService;
        public UserController(IUserService userService, IUserExamService userExamService,IExamService examService, IUserQuestionValueService userQuestionValueService, IHttpContextAccessor httpContextAccessor, IControllerLogService logService) 
        {
            this._userService = userService;
            this._userExamService = userExamService;
            this._examService = examService;
            this._userQuestionValueService = userQuestionValueService;
            this._httpContextAccessor = httpContextAccessor;
            this._logService = logService;
        }
        public IActionResult Index()
        {            
            try
            {
                var userList = _userService.GetList();
                return View(userList);
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "User",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }

        [HttpGet]
        public IActionResult UserInsert() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserInsert(User user) 
        {            
            try
            {
                _userService.UserAdd(user);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "User",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }

        public IActionResult UserUpdate(int id)
        {
            
            try
            {
                var userValue = _userService.GetByID(id);
                return View(userValue);
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "User",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }
        [HttpPost]
        public IActionResult UserUpdate(User user)
        {
            
            try
            {
                _userService.UserUpdate(user);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "User",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }

        public IActionResult UserRemove(int id)
        {
           
            try
            {
                if (id > 0)
                {
                    _userExamService.DeleteUserID(id);
                    _userQuestionValueService.DeleteUserID(id);
                    _userService.UserDelete(new List<int>() { id });
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "User",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }

        [HttpGet]
        public IActionResult UserExamInsert(int id)
        {
           
            try
            {
                //_httpContextAccessor.HttpContext.Session.SetInt32("Userid", id);            

                var model = new UserExamModel();
                model.Users = _userService.GetList().Select(u => new User
                {
                    ID = u.ID,
                    UserName = u.UserName
                }).ToList();

                model.Exams = _examService.GetList().Select(e => new Exam
                {
                    ID = e.ID,
                    Name = e.Name
                }).ToList();

                return View(model);
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "User",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }
        [HttpPost]
        public IActionResult UserExamInsert(UserExamModel model)
        {           

            try
            {
                int selectedUserID = model.SelectedUserID;
                int selectedExamID = model.SelectedExamID;

                UserExam userexam = new UserExam();
                userexam.UserID = selectedUserID;
                userexam.ExamID = selectedExamID;
                _userExamService.UserExamAdd(userexam);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "User",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }

        public PartialViewResult UserExamsListPartial()
        {
            
            try
            {
                int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("Userid");
                var userExam = _examService.GetAllUserExam((int)userID);
                return PartialView(userExam);
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "User",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }


    }
}
