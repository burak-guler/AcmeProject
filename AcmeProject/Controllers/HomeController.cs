using Acme.BusinessLayer.Abstract;
using Acme.BusinessLayer.Concrete;
using Acme.Core.Entity;
using AcmeProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AcmeProject.Controllers
{
    public class HomeController : Controller
    {
        
        
        private readonly ILogger<HomeController> _logger;

        private IExamService _examService;

        public HomeController(ILogger<HomeController> logger,IExamService examService)
        {
            this._examService = examService;   
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Exam exam = new Exam();
            //exam.Name = "Matematik";
            //_examService.ExamAdd(exam);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}