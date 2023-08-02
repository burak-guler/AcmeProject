using Acme.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Acme.Core.Model
{
    public class UserExamModel
    {
        public int SelectedUserID { get; set; }
        public int SelectedExamID { get; set; }
        public List<User> Users { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
