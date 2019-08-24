using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyApplication.Models
{
    public class QuestionViewModel
    {
        public int Question_ID { get; set; }
        public string Question { get; set; }
        public string SelectedAnswer { get; set; }
        public int Survey_ID { get; set; }

        public int User_ID { get; set; }
    }
    public class QuestionItem
    {
        public List<QuestionViewModel> ListQuestionModel { get; set; }
    }
    
}