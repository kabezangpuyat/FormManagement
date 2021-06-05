using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using QMS.Core.Providers;
using QMS.Domain.Constants;
using QMS.Domain.Models.Campaign;
using QMS.Domain.Models.Role;
using QMS.Domain.Models.User;
using System;
using System.Collections.Generic;

namespace QMS.Infrastructure.Providers
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        #region Constructor(s)
        public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor ?? throw new ArgumentException(nameof(httpContextAccessor));
        }
        #endregion

        #region ICurrentUserProvider
        public List<RoleViewModel> GetCurrentRoles()
        {
            List<RoleViewModel> curretnRoles = new List<RoleViewModel>();
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var roleClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimsContants.CurrentRoles);
                if (roleClaim != null)
                    curretnRoles = JsonConvert.DeserializeObject<List<RoleViewModel>>(roleClaim.Value);
            }
            else
                curretnRoles = null;

            return curretnRoles;
        }

        public UserViewModel GetCurrentUser()
        {
            UserViewModel currentUser = new UserViewModel();
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var userClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimsContants.CurrentUser);
                if (userClaim != null)
                    currentUser = JsonConvert.DeserializeObject<UserViewModel>(userClaim.Value);
            }
            else
                currentUser = null;

            return currentUser;
        }
        public List<CampaignViewModel> GetCurrentCampaigns()
        {
            List<CampaignViewModel> curretnRoles = new List<CampaignViewModel>();
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var campaignClaims = _httpContextAccessor.HttpContext.User.FindFirst(ClaimsContants.CurrentCampaigns);
                if (campaignClaims != null)
                    curretnRoles = JsonConvert.DeserializeObject<List<CampaignViewModel>>(campaignClaims.Value);
            }
            else
                curretnRoles = null;

            return curretnRoles;
        }
        #endregion
    }
}
