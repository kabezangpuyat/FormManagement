using QMS.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Models.Responses.User
{
    public class CreateUserResponse : ICommandQueryResponse
    {
        public CreateUserResponse(UserViewModel user)
        {
            User = user;
        }
        public UserViewModel User { get; set; }
    }
}
