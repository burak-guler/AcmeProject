using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.Entity
{
    public class ControllerLog
    {
        public int LogID { get; set; }
        public string ControllerName { get; set; }
        public string Message { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
