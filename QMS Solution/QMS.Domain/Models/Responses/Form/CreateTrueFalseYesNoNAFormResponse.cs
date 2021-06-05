using QMS.Domain.Models.Form;
using QMS.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Models.Responses.Form
{
    public class CreateTrueFalseYesNoNAFormResponse : ICommandQueryResponse
    {
        public FormViewModel Form { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
