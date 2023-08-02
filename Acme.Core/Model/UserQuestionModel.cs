using Acme.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.Model
{
    public class UserQuestionModel
    {
        public UserQuestionModel()
        {
            Questions = new Dictionary<Question, List<Value>>();
        }

        public int ExamID { get; set; }
        public Dictionary<Question, List<Value>> Questions { get; set; }

        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
