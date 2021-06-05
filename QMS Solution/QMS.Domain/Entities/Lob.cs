using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Entities
{
    public class Lob : _BaseEntity
    {
        public long? CampaignID { get; set; }
        public string Name { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
