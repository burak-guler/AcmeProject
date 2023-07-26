using Acme.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.Model
{
    public class IndexModel
    {
        
        public IndexModel()
        {
            QuestionData = new List<Question>();    
            ValueData = new List<Value>();  
        }

        public List<Question> QuestionData { get; set; }
        public List<Value> ValueData { get; set; }

        public Question Question { get; set; }
        public Value Value { get; set; }
        public string SelectedTrueValue { get; set; }
    }
}
