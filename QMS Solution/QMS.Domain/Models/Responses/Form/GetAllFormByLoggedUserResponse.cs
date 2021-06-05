using QMS.Domain.Models.Form;
using QMS.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Models.Responses.Form
{
    public class GetAllFormByLoggedUserResponse : ICommandQueryResponse
    {
        public List<FormViewModel> Forms { get; set; }
    }
}
