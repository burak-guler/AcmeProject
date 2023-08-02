using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.Entity
{
    public class Question
    {
        [Key]
        public int ID { get; set; }
        public int Number { get; set; }
        public string QuestionContent { get; set; }
        public int? TrueValueID { get; set; }
    }
}
