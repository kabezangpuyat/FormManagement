using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace QMS.Domain.Models.Requests
{
    public class CreateMultiplechoiceRequest
    {
        public FormDetailRequest FormDetail { get; set; }
        public CreateMultiplechoiceDetail[] QuestionDetails { get; set; }
    }

    public class CreateMultiplechoiceDetail
    {
        public int Id { get; set; }
        public long Htmlcontrolid { get; set; }
        public string Formquestion { get; set; }
        public ChoiceRequestModel[] Choicedata { get; set; }
    }
    public class ChoiceRequestModel
    {
        public long Id { get; set; }
        public long Parentid { get; set; }
        public string Choice { get; set; }
        public int Value { get; set; }
        public int Sortorder { get; set; }
    }
}
