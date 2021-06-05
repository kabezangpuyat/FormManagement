using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Models
{
    public class _BaseViewModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long? CreatedByID { get; set; }
        public bool Active { get; set; }
    }
}
