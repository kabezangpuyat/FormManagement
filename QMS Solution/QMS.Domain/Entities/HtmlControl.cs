using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Entities
{
    public class HtmlControl : _BaseEntity
    {
        public string Name { get; set; }

        public virtual FormType FormType { get; set; }
        public virtual FormCategory FormCategory { get; set; }
        public virtual ICollection<FormQuestion> FormQuestions { get; set; }
    }
}
