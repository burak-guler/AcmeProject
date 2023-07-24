using Acme.BusinessLayer.Abstract;
using Acme.Core.Entity;
using Acme.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AcmeProject.Controllers
{
    public class QuestionController : Controller
    {
        private IQuestionService _questionService;
        private IQuestionExamService _questionExamService;
        private IQuestionValueService _questionValueService;
        private IValueService _valueService;    

        public QuestionController(IQuestionService questionService, IQuestionExamService questionExamService,IQuestionValueService questionValueService,IValueService valueService)
        {
            this._questionService = questionService;
            this._questionExamService = questionExamService;
            this._questionValueService = questionValueService;
            this._valueService = valueService;
        }

        public IActionResult Index(int id)
        {
            TempData["ExamID"] = id;

           var question= _questionService.GetOnAllQuestionExam(id);
            return View(question);

            //var questionExamvalues = _questionExamService.GetByID(id);
            //if (questionExamvalues == null)
            //{

            //    return NotFound("Bu sınav herhangi bir soru ile eşleşemedi");
            //}
            //var question = _questionService.GetQuestion(questionExamvalues.QuestionID);

            //if (question == null)
            //{

            //    return NotFound("Bu sınava ait soru bulunamadı.");
            //}
            //return View(question);
        }

        [HttpGet]
        public IActionResult QuestionInsert() 
        {
            IndexModel model = new IndexModel();

            for (int i = 0; i < 4; i++)
            {
                model.ValueData.Add(new Value());
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult QuestionInsert(IndexModel Model) 
        {
           
            
                // Soru eklemek için
                _questionService.QuestionAdd(Model.Question);

                // Şık eklemek için
                //var values = Model.ValueData;

                for (int i = 0; i < Model.ValueData.Count; i++)
                {
                    _valueService.ValueAdd(Model.ValueData[i]);
                }

                //foreach (var value in Model.ValueData)
                //{
                //    _valueService.ValueAdd(value);
                //}            

                return RedirectToAction("Index");
            

             
        }
    

        public IActionResult Detail(int id)
        {

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

            //var questionvalue = _questionValueService.GetQuestionValue(id);
            //List<int> QuestionvalueID = new List<int>();
            //foreach (var value in questionvalue)
            //{
            //    QuestionvalueID.Add(value.ValueID);
            //}


            //foreach (var item in QuestionvalueID)
            //{
            //    var values = _valueService.GetValue(item);
            //    foreach (var val in values)
            //    {
            //            indexModel.ValueData.Add(val);
            //            if (question.TrueValueID==val.ID)
            //            {
            //            ViewBag.TrueID = val.Name.ToString();
            //            }
            //    }


            //}
            return View(indexModel);
        }



    }
}
