using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Entities
{
    public class Form : _BaseEntity
    {
        public Guid Key { get; set; }
        public long FormTypeID { get; set; }
        public long FormCategoryID { get; set; }
        public string Name { get; set; }
        public bool IsNoteVisible { get; set; }

        public virtual FormType FormType { get; set; }
        public virtual FormCategory FormCategory { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual ICollection<FormQuestion> FormQuestions { get; set; }
        public virtual ICollection<Audit> Audits { get; set; }
    }
}
