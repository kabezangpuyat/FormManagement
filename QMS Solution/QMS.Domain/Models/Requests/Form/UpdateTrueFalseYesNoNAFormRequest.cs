using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace QMS.Domain.Models.Requests
{
    public class UpdateTrueFalseYesNoNAFormRequest
    {
        public UpdateFormDetail FormDetail { get; set; }
        public UpdateQuestionDetail[] QuestionDetails { get; set; }
    }

   public class UpdateFormDetail
   {
        public long FormId { get; set; }
        public long CategoryId { get; set; }
        public string FormName { get; set; }
    }
    public class UpdateQuestionDetail
    {
        public long Id { get; set; }
        public long HtmlControlID { get; set; }
        public string Name { get; set; }
        public bool? Isnew { get; set; }
    }
}
