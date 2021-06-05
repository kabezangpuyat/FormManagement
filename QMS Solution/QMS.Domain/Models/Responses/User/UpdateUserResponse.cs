using QMS.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Models.Responses.User
{
    public class UpdateUserResponse : ICommandQueryResponse
    {
        public UpdateUserResponse(UserViewModel user)
        {
            User = user;
        }
        public UpdateUserResponse(UserViewModel user, bool? success)
        {
            User = user;
            Success = success;
        }
        public UserViewModel User { get; set; }
        public bool? Success { get; set; }
    }
}
