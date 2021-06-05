using MediatR;
using Microsoft.AspNetCore.Mvc;
using QMS.Commands.Audit;
using QMS.Domain.Models.Requests.Audit;
using QMS.Queries.Form;
using System.Threading.Tasks;

namespace QMS.Web.Controllers
{
    public class AuditController : _BaseController
    {
        #region Constructor(s)
        public AuditController(IMediator mediator) : base(mediator)
        {
        }
        #endregion

        #region IActionResult(s)
        [HttpGet("get-all-by-status")]
        public async Task<IActionResult> GetAllByStatus(bool? active)
        {
            return await ExecuteQuery(new GetAllAuditByStatus.Query { Active = active })
                .ConfigureAwait(false);
        }
        [HttpGet("get-all-by-logged-user")]
        public async Task<IActionResult> GetAllByLoggedUser()
        {
            return await ExecuteQuery(new GetAllAuditByLoggedUser.Query())
                .ConfigureAwait(false);
        }

        [HttpGet("get-all-by-logged-user-assignment")]
        public async Task<IActionResult> GetAllAuditByLoggedUserAssignment()
        {
            return await ExecuteQuery(new GetAllAuditByLoggedUserAssignment.Query())
                .ConfigureAwait(false);
        }
        //GetAllAuditByCampaignOfTeammate
        [HttpGet("get-all-by-teammate-campaign")]
        public async Task<IActionResult> GetAllByTeammateCampaign()
        {
            return await ExecuteQuery(new GetAllByTeammateCampaign.Query())
                .ConfigureAwait(false);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateAuditRequest model)
        {
            var command = new CreateAudit.Command { Payload = model };
            return await ExecuteCommand(command)
                .ConfigureAwait(false);
        }
        #endregion
    }
}
