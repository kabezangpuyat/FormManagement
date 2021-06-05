using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Entities
{
    public class FormChoice : _BaseEntity
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int SortOrder { get; set; }
        public virtual ICollection<FormQuestionChoice> FormQuestionChoices { get; set; }
        public virtual ICollection<AuditDetail> FormAnswers { get; set; }
    }
}
