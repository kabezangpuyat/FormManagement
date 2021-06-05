using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace QMS.Domain.Models.Requests
{
    public class UpdateMultiplechoiceRequest
    {
        public UpdateFormDetail FormDetail { get; set; }
        public UpdateMultipleChoiceQuestionDetail[] QuestionDetails { get; set; }
    }

    public class UpdateMultipleChoiceQuestionDetail
    {
        public int Id { get; set; }
        public long HtmlControlID { get; set; }
        public string Name { get; set; }
        public UpdateMultipleChoiceData[] Choices { get; set; }
        public bool? Isnew { get; set; }
    }
    public class UpdateMultipleChoiceData
    {
        public long Id { get; set; }
        public long Parentid { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int Sortorder { get; set; }
    }
}
