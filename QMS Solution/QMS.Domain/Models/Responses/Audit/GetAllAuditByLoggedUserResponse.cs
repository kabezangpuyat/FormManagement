using QMS.Domain.Models.Audit;
using QMS.Domain.Models.Form;
using QMS.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Models.Responses.Audit
{
    public class GetAllAuditByLoggedUserResponse : ICommandQueryResponse
    {
        public List<AuditViewModel> Audits { get; set; }
    }
}
