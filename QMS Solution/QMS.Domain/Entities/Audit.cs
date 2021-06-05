using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Entities
{
    public class Audit : _BaseEntity
    {
        public long FormID { get; set; }
        public long TeammateID { get; set; }
        public string Name { get; set; }
        public string FormNotes { get; set; }

        public virtual Form Form { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual User Teammate { get; set; }
        //public virtual User Teammate { get; set; }
        public virtual ICollection<AuditDetail> AuditDetails { get; set; }
    }
}
