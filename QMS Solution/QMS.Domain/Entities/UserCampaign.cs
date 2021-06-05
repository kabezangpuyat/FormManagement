using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Entities
{
    public class UserCampaign : _BaseEntity
    {
        public long? UserID { get; set; }
        public long? CampaignID { get; set; }

        public virtual User User { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}
