using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.Entity
{
    public class Report
    {
        public int ReportID { get; set; }
        public int UserID { get; set; }
        public int ExamID { get; set; }
        public decimal Duration { get; set; }
        public int TrueCount { get; set; }
        public int WrongCount { get; set; }
        public DateTime StartDate { get; set; }
        
        

    }
}
