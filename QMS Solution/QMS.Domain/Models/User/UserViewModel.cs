using QMS.Domain.Models.Campaign;
using QMS.Domain.Models.Role;
using System;
using System.Collections.Generic;

namespace QMS.Domain.Models.User
{
    public class UserViewModel : _BaseViewModel
    {
        public Guid Key { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public List<CampaignViewModel> Campaigns { get; set; }
    }
}
