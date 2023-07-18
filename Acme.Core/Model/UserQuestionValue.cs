using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.Model
{
    public class UserQuestionValue
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int QuestionValueID { get; set; }
    }
}
