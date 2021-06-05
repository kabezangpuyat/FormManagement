using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Models.Responses
{
    public class QueryCollectionResponse
    {
        public object Results { get; set; }
        public int Total { get; set; }
    }
}
