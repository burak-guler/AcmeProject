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
        private IUserQuestionValueService _userQuestionValueService;
        private IControllerLogService _logService;

        public QuestionController(IQuestionService questionService, IQuestionExamService questionExamService,IQuestionValueService questionValueService,IValueService valueService, IHttpContextAccessor httpContextAccessor,IUserExamService userExamService, IUserQuestionValueService userQuestionValueService, IControllerLogService logService)
        {
            this._questionService = questionService;
            this._questionExamService = questionExamService;
            this._questionValueService = questionValueService;
            this._valueService = valueService;
            this._httpContextAccessor = httpContextAccessor;
            this._userExamService = userExamService;
            this._userQuestionValueService= userQuestionValueService;
            this._logService = logService;
        }

        public IActionResult Index(int id, int pageNumber = 1, int pageSize = 2)
        {
            _httpContextAccessor.HttpContext.Session.SetInt32("ExamID", id);

            try
            {
                UserQuestionModel userQuestionModel = new UserQuestionModel();
                userQuestionModel.ExamID = id;

                int totalCount = 0;
                ViewBag.ExamID = id;
                ViewBag.CurrentPage = pageNumber;
                ViewBag.PageSize = pageSize;

                var question = _questionService.GetOnAllQuestionExam(id, pageSize, pageNumber, out totalCount);
                ViewBag.TotalCount = totalCount;
                return View(question);
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "Question",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }

        [HttpGet]
        public IActionResult QuestionInsert(int id) 
        {          
          
            try
            {
                IndexModel model = new IndexModel();

                if (id > 0)
                {
                    var question = _questionService.GetByID(id);
                    model.Question = question;

                    var value = _valueService.GetOnAllQuestionExam(id);
                    foreach (var item in value)
                    {
                        model.ValueData.Add(item);
                        if (item.ID == question.TrueValueID)
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
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "Question",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
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
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "Question",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }

            return RedirectToAction("Index", new { id = examID });
        }
    

        public IActionResult Detail(int id)
        {          
            try
            {
                _httpContextAccessor.HttpContext.Session.SetInt32("QuestionID", id);

                int? questionExamID = _httpContextAccessor.HttpContext.Session.GetInt32("ExamID");
                ViewBag.questionExamID = questionExamID;

                IndexModel indexModel = new IndexModel();

                var question = _questionService.GetByID(id);

                if (question != null)
                    indexModel.QuestionData.Add(question);

                var Value = _valueService.GetOnAllQuestionExam(id);
                if (Value != null)
                {
                    foreach (var item in Value)
                    {
                        indexModel.ValueData.Add(item);
                        if (question.TrueValueID == item.ID)
                        {
                            ViewBag.TrueID = item.Name.ToString();
                        }
                    }
                }
                return View(indexModel);
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "Question",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }

        [HttpGet]
        public IActionResult QuestionDelete()
        {            
            try
            {
                int? questionID = _httpContextAccessor.HttpContext.Session.GetInt32("QuestionID");
                int? examID = _httpContextAccessor.HttpContext.Session.GetInt32("ExamID");

                var question = _questionService.GetByID((int)questionID);
                question.TrueValueID = null;
                _questionService.QuestionUpdate(question);
                var questionValue = _questionValueService.GetQuestionValue((int)questionID);
                List<int> valueID = new List<int>();
                foreach (var item in questionValue)
                {
                    valueID.Add(item.ValueID);
                }
                _questionValueService.QuestionValueDelete(new List<int>() { questionID.Value });
                _valueService.ValueDelete(valueID);
                _userQuestionValueService.UserQuestionValueDelete(new List<int>() { questionID.Value });
                _questionExamService.QuestionExamDelete(new List<int>() { questionID.Value });
                _questionService.QuestionDelete(new List<int>() { questionID.Value });


                return RedirectToAction("Index", new { id = examID });
            }
            catch (Exception ex)
            {

                ControllerLog log = new ControllerLog()
                {
                    ControllerName = "Question",
                    Message = ex.Message,
                    MessageDate = DateTime.Now
                };
                _logService.ControllerLogAdd(log);

                throw;
            }
        }
    }
}
