using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Models.Requests.Audit
{
    public class CreateAuditRequest
    {
        public long FormID { get; set; }
        public string AuditName { get; set; }
        public string FormNotes { get; set; }
        public long UserID { get; set; }
        public List<AuditDetailRequest> AuditDetails { get; set; }
    }
    public class AuditDetailRequest
    {
        public long? QuestionID { get; set; }
        public long? ChoiceID { get; set; }
        public string QuestionNotes { get; set; }
    }
}
