using Acme.BusinessLayer.Abstract;
using Acme.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AcmeProject.Controllers
{
    public class LoginController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;
        private IUserService _userService;
        private IControllerLogService _logService;
        public LoginController(IHttpContextAccessor httpContextAccessor, IUserService userService, IControllerLogService logService) 
        {
            this._userService = userService;
            this._httpContextAccessor = httpContextAccessor;
            this._logService = logService;
        }    
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();   
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            try
            {
                var users = _userService.GetUser(user);

                _httpContextAccessor.HttpContext.Session.SetInt32("UserID", users.ID);

                if (users.AdminLogin == true)
                {
                    return RedirectToAction("Index", "Exam");
                }
                else
                {
                    return RedirectToAction("Index", "UserPanel");
                }
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "Login",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }            
			
        }

        [HttpGet]
        public IActionResult Register() { return View(); }
        [HttpPost]
        public IActionResult Register(User user)
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
                    ControllerName = "Login-Register",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }

    }
}
