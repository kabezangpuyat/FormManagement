using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.ConfigSections
{
    public class PingAuthentication
    {
        public string Api { get; set; }
        public string ClientId { get; set; }
        public string Secret { get; set; }
    }
}
