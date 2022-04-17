using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Viewmodel
{
    public class ShowfaqViewmodel
    {
        public string usernameq { get; set; }
        public string descriptionq { get; set; }
        public DateTime CreateDateq { get; set; }
        public int questionid { get; set; }

        public ShowAnswerViewmodel showAnswerVm { get; set; }

    }

    public class ShowAnswerViewmodel
    {
        public string usernamea { get; set; }
        public string descriptiona { get; set; }
        public DateTime? CreateDatea { get; set; }
        public int? answerid { get; set; }
    }
}
