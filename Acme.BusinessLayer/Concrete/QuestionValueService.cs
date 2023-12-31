﻿using Acme.BusinessLayer.Abstract;
using Acme.Core.Model;
using Acme.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer.Concrete
{
    public class QuestionValueService : IQuestionValueService
    {
        private IQuestionValueRepository _questionValueRepository;

        public QuestionValueService(IQuestionValueRepository questionValueRepository)
        {
            _questionValueRepository = questionValueRepository;
        }

        public QuestionValue GetByID(int id)
        {
            return _questionValueRepository.Get(id);
        }

        public List<QuestionValue> GetList()
        {
            return _questionValueRepository.List();
        }

        public List<QuestionValue> GetQuestionValue(int id)
        {
            return _questionValueRepository.GetQuestionValueList(id);
        }

        public QuestionValue GetQuestionValue(int questionID, int valueID)
        {
            return _questionValueRepository.GetQuestionValue(questionID, valueID); 
        }

        public int QuestionValueAdd(QuestionValue questionValue)
        {
            return _questionValueRepository.Insert(questionValue); 
        }

        public int QuestionValueDelete(List<int> questionID)
        {
            return _questionValueRepository.Delete(questionID);
        }

        public int QuestionValueUpdate(QuestionValue questionValue)
        {
            return _questionValueRepository.Update(questionValue);
        }
    }
}
