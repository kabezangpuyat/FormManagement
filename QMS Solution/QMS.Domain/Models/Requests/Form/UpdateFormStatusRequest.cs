using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace QMS.Domain.Models.Requests
{
    public class UpdateFormStatusRequest
    {
        public long Id { get; set; }
        public bool Active { get; set; }
    }

}
