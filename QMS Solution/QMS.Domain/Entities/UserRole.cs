using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Entities
{
    public class UserRole : _BaseEntity
    {
        public long UserID { get; set; }
        public long RoleID { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
