using QMS.Domain.Models.Authentication;
using QMS.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace QMS.Domain.Models.Responses.Authentication
{
    public class CreateRefreshTokenResponse : ICommandQueryResponse
    {
        public RefreshTokenModel RefreshToken { get; set; }
        public CreateRefreshTokenResponse(RefreshTokenModel refreshToken)
        {
            this.RefreshToken = refreshToken;
        }
    }
}
