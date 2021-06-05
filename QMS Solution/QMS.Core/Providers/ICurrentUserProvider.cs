using QMS.Domain.Models.Campaign;
using QMS.Domain.Models.Role;
using QMS.Domain.Models.User;
using System.Collections.Generic;

namespace QMS.Core.Providers
{
    public interface ICurrentUserProvider
    {
        UserViewModel GetCurrentUser();
        List<RoleViewModel> GetCurrentRoles();
        List<CampaignViewModel> GetCurrentCampaigns();
    }
}
