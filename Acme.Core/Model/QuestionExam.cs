using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.Model
{
    public class QuestionExam
    {
        [Key]
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public int ExamID { get; set; }
    }
}
