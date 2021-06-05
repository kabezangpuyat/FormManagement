using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Entities
{
    public class RoleAppNavigation : _BaseEntity
    {
        public long AppNavigationID { get; set; }
        public long RoleID { get; set; }

        public virtual AppNavigation AppNavigation { get; set; }
        public virtual Role Role { get; set; }
    }
}
