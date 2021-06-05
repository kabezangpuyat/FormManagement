using QMS.Domain.Models.Form;
using QMS.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Models.Responses.Form
{
    public class GetFormByFormIDResponse : ICommandQueryResponse
    {
        public FormViewModel Form { get; set; }
    }
}
