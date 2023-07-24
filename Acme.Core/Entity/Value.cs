using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.Entity
{
    public class Value
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string QuestionValueContent { get; set; }
    }
}
