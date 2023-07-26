using Acme.BusinessLayer.Abstract;
using Acme.Core.Entity;
using Acme.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;

namespace AcmeProject.Controllers
{
    public class QuestionController : Controller
    {
        private IQuestionService _questionService;
        private IQuestionExamService _questionExamService;
        private IQuestionValueService _questionValueService;
        private IValueService _valueService;  
        private IHttpContextAccessor _httpContextAccessor;
        private IUserExamService _userExamService;

        public QuestionController(IQuestionService questionService, IQuestionExamService questionExamService,IQuestionValueService questionValueService,IValueService valueService, IHttpContextAccessor httpContextAccessor,IUserExamService userExamService)
        {
            this._questionService = questionService;
            this._questionExamService = questionExamService;
            this._questionValueService = questionValueService;
            this._valueService = valueService;
            this._httpContextAccessor = httpContextAccessor;
            this._userExamService = userExamService;
        }

        public IActionResult Index(int id)
        {
            _httpContextAccessor.HttpContext.Session.SetInt32("ExamID", id);

            var question = _questionService.GetOnAllQuestionExam(id);
            return View(question);
        }

        [HttpGet]
        public IActionResult QuestionInsert(int id) 
        {
            
            IndexModel model = new IndexModel();
            
            if (id > 0)
            {
                var question= _questionService.GetByID(id);
                model.Question = question;

                var value = _valueService.GetOnAllQuestionExam(id);
                foreach (var item in value)
                {
                    model.ValueData.Add(item);
                    if (item.ID==question.TrueValueID)
                    {
                        model.SelectedTrueValue = item.Name;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    model.ValueData.Add(new Value());
                }
            }
            

            return View(model);
        }
        [HttpPost]
        public IActionResult QuestionInsert(IndexModel model, int id) 
        {
            int? examID = _httpContextAccessor.HttpContext.Session.GetInt32("ExamID");

            List<int> valueIdList = new List<int>();

            try
            {

                int questionId = 0;
                if (id > 0) 
                {

                    var values = _valueService.GetOnAllQuestionExam(id);

                    //Value tablosuna insert ve update işlemi
                    for (int i = 0; i < model.ValueData.Count; i++)
                    {                                       
                            int valueId = _valueService.ValueUpdate(model.ValueData[i]);
                            if (valueId <= 0)
                                return View();
                            

                            if (model.ValueData[i].Name.Equals(model.SelectedTrueValue))
                            {
                                model.Question.TrueValueID = values.Where(w => w.Name.Equals(model.ValueData[i].Name)).FirstOrDefault().ID;
                            }                        
                    }
                    model.Question.ID = id;
                    questionId = _questionService.QuestionUpdate(model.Question);
                    if (questionId <= 0)
                        return View();
                }            
                else
                {
                   


                    for (int i = 0; i < model.ValueData.Count; i++)
                    {                       
                            int valueId = _valueService.ValueAdd(model.ValueData[i]);
                            if (valueId <= 0)
                                return View();
                            valueIdList.Add(valueId);

                            if (model.ValueData[i].Name.Equals(model.SelectedTrueValue))
                            {
                                model.Question.TrueValueID = valueId;
                            }                       
                       
                    }

                    questionId = _questionService.QuestionAdd(model.Question);
                    if (questionId <= 0)
                        return View();

                    //QuestionValue tablosuna insert  işlemi
                    foreach (var valueId in valueIdList)
                    {
                        var isSuccess = _questionValueService.QuestionValueAdd(new QuestionValue()
                        {
                            QuestionID = questionId,
                            ValueID = valueId
                        });

                        if (isSuccess <= 0)
                            return View();
                    }

                    //QuestionExam tablosuna insert işlemi
                    var isSuccessQuestionExam = _questionExamService.QuestionExamAdd(new QuestionExam()
                    {
                        QuestionID = questionId,
                        ExamID = examID ?? 0
                    });

                    if (isSuccessQuestionExam <= 0)
                        return View();

                }               

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return RedirectToAction("Index", new { id = examID });
        }
    

        public IActionResult Detail(int id)
        {
            _httpContextAccessor.HttpContext.Session.SetInt32("QuestionID", id);

            IndexModel indexModel = new IndexModel();

            var question = _questionService.GetByID(id);
            
            if (question != null)
                indexModel.QuestionData.Add(question);

            var Value = _valueService.GetOnAllQuestionExam(id);
            if (Value!=null)
            {
                foreach (var item in Value)
                {
                    indexModel.ValueData.Add(item);
                    if (question.TrueValueID==item.ID)
                    {
                        ViewBag.TrueID = item.Name.ToString();
                    }
                }
            }
            return View(indexModel);
        }

        [HttpGet]
        public IActionResult QuestionDelete()
        {
            int? questionID = _httpContextAccessor.HttpContext.Session.GetInt32("QuestionID");
            int? examID = _httpContextAccessor.HttpContext.Session.GetInt32("ExamID");
            _questionService.QuestionDelete((int)questionID);
            
            return RedirectToAction("Index", new {id= examID });
        }

        //[HttpPost]
        //public IActionResult QuestionDelete(int id)
        //{
        //    int? examID = _httpContextAccessor.HttpContext.Session.GetInt32("ExamID");

        //    try
        //    {
        //        _questionService.QuestionDelete(id);
                      
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    return RedirectToAction("Index", new { id = examID });
        //}



    }
}
