using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Entities
{
    public class Campaign : _BaseEntity
    {

        public string Name { get; set; }
        public long EpmsCampaignID { get; set; }
        public virtual ICollection<Lob> Lobs { get; set; }
        public virtual ICollection<UserCampaign> UserCampaigns { get; set; }
    }
}
