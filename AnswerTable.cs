//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SurveyApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class AnswerTable
    {
        public int Answer_ID { get; set; }
        public string SelectedAnswer { get; set; }
        public Nullable<int> User_ID { get; set; }
        public Nullable<int> Survey_ID { get; set; }
        public Nullable<int> Question_ID { get; set; }
    
        public virtual QuestionTable QuestionTable { get; set; }
        public virtual SurveyTable SurveyTable { get; set; }
        public virtual Registration Registration { get; set; }
    }
}
