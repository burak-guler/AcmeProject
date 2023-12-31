﻿using Acme.Core.Entity;
using Acme.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer.Abstract
{
    public interface IQuestionValueService
    {
        List<QuestionValue> GetList();
        int QuestionValueAdd(QuestionValue questionValue);
        QuestionValue GetByID(int id);
        int QuestionValueDelete(List<int> questionID);
        int QuestionValueUpdate(QuestionValue questionValue);
        List<QuestionValue> GetQuestionValue(int id);

        public QuestionValue GetQuestionValue(int questionID, int valueID);
    }
}
