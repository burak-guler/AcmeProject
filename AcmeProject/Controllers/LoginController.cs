using Acme.BusinessLayer.Abstract;
using Acme.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AcmeProject.Controllers
{
    public class LoginController : Controller
    {
        private IUserService _userService;
        public LoginController(IUserService userService) 
        {
            this._userService = userService;    
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
            var users = _userService.GetUser(user);
            if (users!=null)
            {
                return RedirectToAction("Index", "Exam");
            }
            else
            {
                return View();
            }

			
        }

        [HttpGet]
        public IActionResult Register() { return View(); }
        [HttpPost]
        public IActionResult Register(User user)
        {
            _userService.UserAdd(user);
            return RedirectToAction("Index");
        }

    }
}
