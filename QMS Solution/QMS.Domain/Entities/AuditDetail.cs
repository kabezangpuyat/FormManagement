using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Entities
{
    public class AuditDetail : _BaseEntity
    {
        public long AuditID { get; set; }
        public long? QuestionID { get; set; }
        public long? ChoiceID { get; set; }
        public string QuestionNotes { get; set; }

        public virtual FormQuestion FormQuestion { get; set; }
        public virtual FormChoice FormChoice { get; set; }
        public virtual Audit Audit { get; set; }
    }
}
