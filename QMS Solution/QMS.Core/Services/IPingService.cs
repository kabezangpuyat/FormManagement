using QMS.Domain.Entities;
using QMS.Domain.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QMS.Core.Services
{
    public interface IPingService
    {
        Task<PingTokenModel> GetAccessToken(PingAuthenticationModel model);
        Task<string> GetEmployeeNumberFromPing(PingTokenModel model);
        Task<string> GetEmployeeNumberFromPing(PingAuthenticationModel model);
    }
}
