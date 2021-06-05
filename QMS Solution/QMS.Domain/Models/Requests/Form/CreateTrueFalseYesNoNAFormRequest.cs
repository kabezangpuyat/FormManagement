using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace QMS.Domain.Models.Requests
{
    public class CreateTrueFalseYesNoNAFormRequest
    {
        public FormDetailRequest FormDetail { get; set; }
        public CreateTFYNNARequestModel[] QuestionDetails { get; set; }
    }

   public class CreateTFYNNARequestModel
   {
        public int Id { get; set; }
        public long Htmlcontrolid { get; set; }
        public string Formquestion { get; set; }
    }
    public class FormDetailRequest
    {
        public string FormName { get; set; }
        public long CategoryId { get; set; }
    }

}
