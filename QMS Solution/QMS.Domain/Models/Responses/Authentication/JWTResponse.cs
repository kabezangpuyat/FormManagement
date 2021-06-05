using QMS.Domain.Models.AppNavigation;
using QMS.Domain.Models.Authentication;
using QMS.Domain.Models.Campaign;
using QMS.Domain.Models.Role;
using QMS.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QMS.Domain.Models.Responses.Authentication
{
    public class JWTResponse : ICommandQueryResponse
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string JwtToken { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public List<AppNavigationModel> AppNavigations { get; set; }
        public List<CampaignViewModel> Campaigns { get; set; }
        public string InitialPage { get; set; }

        //[JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }
        [JsonIgnore]
        public RefreshTokenModel RefreshTokenModel { get; set; }

        public JWTResponse(UserViewModel user, string jwtToken, string refreshToken, DateTime expiryDate, 
            RefreshTokenModel refreshModelToken, List<RoleViewModel> roles, List<CampaignViewModel> campaigns)
        {
            Id = user.ID;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
            ExpiryDate = expiryDate;
            RefreshTokenModel = refreshModelToken;
            Roles = roles;
            Campaigns = campaigns;
        }
    }
}
