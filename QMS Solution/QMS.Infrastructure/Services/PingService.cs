using Microsoft.Extensions.Options;
using QMS.Core.Services;
using QMS.Domain.ConfigSections;
using QMS.Domain.Entities;
using QMS.Domain.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using System.IdentityModel.Tokens.Jwt;

namespace QMS.Infrastructure.Services
{
    public class PingService : IPingService
    {
        private readonly PingAuthentication _pingAuthentication;

        #region Constructor(s)
        public PingService(IOptions<PingAuthentication> pingAuthentication)
        {
            this._pingAuthentication = pingAuthentication?.Value ?? throw new ArgumentException(nameof(pingAuthentication));
        }
        #endregion

        #region PingService
        public async Task<PingTokenModel> GetAccessToken(PingAuthenticationModel model)
        {
            var response = _pingAuthentication.Api.WithHeader("Content-Type", "application/x-www-form-urlencoded")
                   .PostUrlEncodedAsync(new
                   {
                       client_id = _pingAuthentication.ClientId,
                       client_secret = _pingAuthentication.Secret,
                       grant_type = "authorization_code",
                       code = model.Code
                   })
                   .ReceiveJson<PingTokenModel>()
                   .Result;

            return await Task.FromResult(response);
        }

        public async Task<string> GetEmployeeNumberFromPing(PingTokenModel model)
        {
            var handler = new JwtSecurityTokenHandler();
            var accessTokenDecoded = handler.ReadJwtToken(model.AccessToken);

            string employeeNumber = accessTokenDecoded.Subject.Substring(2, accessTokenDecoded.Subject.IndexOf("@") - 2);
            return await Task.FromResult(employeeNumber);
        }
        public async Task<string> GetEmployeeNumberFromPing(PingAuthenticationModel model)
        {
            var pingToken = await this.GetAccessToken(model);

            return await this.GetEmployeeNumberFromPing(pingToken);
        }
        #endregion
    }
}
