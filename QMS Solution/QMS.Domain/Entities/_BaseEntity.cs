using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Entities
{
    public class _BaseEntity
    {
		public long ID { get; set; }
		public long? CreatedByID { get; set; }
		public long? ModifiedByID { get; set; }
		public DateTimeOffset DateCreated { get; set; }
		public DateTimeOffset? DateModified { get; set; }
		public bool Active { get; set; }
	}
}
