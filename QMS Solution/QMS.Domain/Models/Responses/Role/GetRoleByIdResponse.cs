using QMS.Domain.Models.Role;

namespace QMS.Domain.Models.Responses.Role
{
    public class GetRoleByIdResponse : ICommandQueryResponse
    {
        public RoleViewModel Role { get; set; }
    }
}
