using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using QMS.Commands.Authentication;
using QMS.Domain.ConfigSections;
using QMS.Domain.Models.AppNavigation;
using QMS.Domain.Models.Authentication;
using QMS.Domain.Models.Responses.AppNavigation;
using QMS.Domain.Models.Responses.Authentication;
using QMS.Queries.AppNavigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using QMS.Core.Services;

namespace QMS.Web.Controllers
{
    public class AccountController : _BaseController
    {
        private readonly PingAuthentication _pingAuthentication;

        private readonly IPingService _pingService;
        #region Constructor(s)
        public AccountController(IMediator mediator,
            IOptions<PingAuthentication> pingAuthentication,
            IPingService pingService) : base(mediator)
        {
            this._pingAuthentication = pingAuthentication?.Value ?? throw new ArgumentException(nameof(pingAuthentication));
            this._pingService = pingService;
        }
        #endregion


        #region IActionResult(s)
        [HttpGet("values/{email}"),AllowAnonymous]
        public async Task<IActionResult> Values(string email)
        {
            var result = await Task.FromResult(email);

            return Ok(result);
        }

        [HttpGet("authenticate-ping/{code}"),AllowAnonymous]
        public async Task<IActionResult> AuthenticateUsingPing( string code )
        {
            string employeeNumber = await _pingService.GetEmployeeNumberFromPing(new PingAuthenticationModel { Code = code });
            return await this.GetAll(employeeNumber);
        }

        [HttpGet("authenticate/{employeeNumber}"), AllowAnonymous]
        public async Task<IActionResult> GetAll(string employeeNumber)
        {
            var command = new CreateJWToken.Command(employeeNumber, this.IpAddress());
            var response = await _mediator.Send(command) as JWTResponse;

            if (response == null)
                return BadRequest(new { message = "Fail to authenticate user. Please contact your system administrator." });

            this.SetTokenCookie(response.RefreshToken, response.JwtToken, response.ExpiryDate);

            var roleIds = response.Roles.Select(x => x.ID).ToList();
            var query = new GetAllAppNavigationByUserId.Query { RoleIds = roleIds };
            var navigationsResponse = await _mediator.Send(query) as GetAllAppNavigationByUserIdResponse;
            response.AppNavigations = navigationsResponse.AppNavigations;
            response.InitialPage = navigationsResponse.AppNavigations.FirstOrDefault(x => x.IsInitialPage).Name;

            return await ExecuteResult(response).ConfigureAwait(false);
        }

        [AllowAnonymous,
        HttpPost("validatetoken")]
        public IActionResult Validate([FromBody] ValidateTokenModel model)
        {
            bool valid = false;

            var refreshtoken = Request.Cookies["refreshtoken"];
            var expirytoken = Request.Cookies["tokenexpiry"];


            if (!string.IsNullOrEmpty(refreshtoken) || !string.IsNullOrEmpty(expirytoken))
            {
                if (refreshtoken.Trim().ToLower() == model.Token.Trim().ToLower())
                {
                    //if token is 1 minute to expire then tagged is invalid
                    DateTime currentDate = DateTime.Now;
                    var expiry = Convert.ToDateTime(expirytoken);
                    double diffInSeconds = (expiry - currentDate).TotalSeconds;
                    if (diffInSeconds >= 120)
                        valid = true;
                }

            }

            return Ok(new { valid = valid });
        }

        [AllowAnonymous,
        HttpGet("validateexpiry/{expirydate}")]
        public IActionResult ValidateExpiry(DateTimeOffset expirydate)
        {
            bool valid = false;

            //if token is 1 minute to expire then tagged is invalid
            DateTimeOffset currentDate = DateTime.Now;
            double diffInSeconds = (expirydate - currentDate).TotalSeconds;
            if (diffInSeconds >= 120)
                valid = true;

            return Ok(new { valid = valid });
        }
        #endregion

        #region Helper Method(s)
        private void SetTokenCookie(string token, string jwttoken, DateTime expiryDate)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expiryDate 
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
            Response.Cookies.Append("jwttoken", jwttoken, cookieOptions);
            Response.Cookies.Append("tokenexpiry", expiryDate.ToString(), cookieOptions);
        }
        private void RemoveSession()
        {
            Response.Cookies.Delete("refreshToken", new CookieOptions() { Secure = true });
            Response.Cookies.Delete("jwttoken", new CookieOptions() { Secure = true });
            Response.Cookies.Delete("tokenexpiry", new CookieOptions() { Secure = true });
        }

        private string IpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
        #endregion
    }
}
