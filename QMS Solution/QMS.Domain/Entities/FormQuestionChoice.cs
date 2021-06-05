using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Entities
{
    public class FormQuestionChoice : _BaseEntity
    {
        public long QuestionID { get; set; }
        public long ChoiceID { get; set; }

        public virtual FormQuestion FormQuestion { get; set; }
        public virtual FormChoice FormChoice { get; set; }
    }
}
