using QMS.Domain.Models.Responses.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using QMS.Domain.Models;
using QMS.Domain.Models.Authentication;
using QMS.Domain.Models.User;

namespace QMS.Core.Services
{
    public interface IAuthenticationService
    {
        JWTResponse Authenticate(UserViewModel model, string ipAddress);
        JWTResponse RefreshToken(string token, string ipAddress);
        bool RevokeToken(RevokeTokenModel model);
        bool ValidateToken(ValidateTokenModel model);
    }
}
