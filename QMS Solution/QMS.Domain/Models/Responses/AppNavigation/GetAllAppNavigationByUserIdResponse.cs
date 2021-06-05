using QMS.Domain.Models.AppNavigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Models.Responses.AppNavigation
{
    public class GetAllAppNavigationByUserIdResponse : ICommandQueryResponse
    {
        public List<AppNavigationModel> AppNavigations { get; set; }
    }
}
