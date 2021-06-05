using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace QMS.Domain.Models.Requests
{
    public class CreateCampaignRequest
    {
        public string Name { get; set; }
        public long EpmsCampaignID { get; set; }
    }
}
