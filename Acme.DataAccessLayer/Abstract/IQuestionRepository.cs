﻿using Acme.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataAccessLayer.Abstract
{
    public interface IQuestionRepository: IRepository<Question>
    {
        List<Question> GetQuestionList(int id);
        List<Question> GetOnAllQuestionExam(int id, int pageSize, int pageNumber, out int totalCount);
    }
}
