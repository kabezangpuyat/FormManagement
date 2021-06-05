using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Models.AppNavigation
{
    public class AppNavigationModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool IsInitialPage { get; set; }
        public bool IsMainModule { get; set; }
    }
}
