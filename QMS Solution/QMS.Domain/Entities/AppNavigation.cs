using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Entities
{
    public class AppNavigation : _BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsInitialPage { get; set; }
        public bool IsMainModule { get; set; }
        public virtual ICollection<RoleAppNavigation> RoleAppNavigations { get; set; }
    }
}
