using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace QMS.Domain.Entities
{
    public class User : _BaseEntity
    {
        public Guid Key { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserCampaign> UserCampaigns { get; set; }
        public virtual ICollection<AuditDetail> FormAnswers { get; set; }
        public virtual ICollection<Form> Forms { get; set; }
        public virtual ICollection<Audit> Audits { get; set; }
        public virtual ICollection<Audit> AuditTeammates { get; set; }
        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
