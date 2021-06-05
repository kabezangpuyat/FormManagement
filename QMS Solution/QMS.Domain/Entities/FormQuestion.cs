using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Entities
{
    public class FormQuestion : _BaseEntity
    {
        public long FormID { get; set; }
        public string Name { get; set; }
        public long HtmlControlID { get; set; }
        public bool IsNoteVisible { get; set; } // free text for comments or notes
        public int SortOrder { get; set; }

        public virtual Form Form { get; set; }
        public virtual HtmlControl HtmlControl { get; set; }
        public virtual ICollection<FormQuestionChoice> FormQuestionChoices { get; set; }
        public virtual ICollection<AuditDetail> FormAnswers { get; set; }
    }
}
