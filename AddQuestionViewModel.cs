using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyApplication.Models
{
    public class AddQuestionViewModel
    {
        public int Question_ID { get; set; }
        public string Question { get; set; }
        public int Survey_ID { get; set; }
        public string Survey_Type { get; set; }

        public IEnumerable<SelectListItem> listItems { get; set; }
    }
}