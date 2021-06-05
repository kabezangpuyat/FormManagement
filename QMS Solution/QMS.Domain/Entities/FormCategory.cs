using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Entities
{
    public class FormCategory : _BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Form> Forms { get; set; }
    }
}
