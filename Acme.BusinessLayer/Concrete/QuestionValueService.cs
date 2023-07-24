using Acme.BusinessLayer.Abstract;
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

        public void QuestionValueAdd(QuestionValue questionValue)
        {
            _questionValueRepository.Insert(questionValue); 
        }

        public void QuestionValueDelete(QuestionValue questionValue)
        {
            _questionValueRepository.Delete(questionValue);
        }

        public void QuestionValueUpdate(QuestionValue questionValue)
        {
            _questionValueRepository.Update(questionValue);
        }
    }
}
