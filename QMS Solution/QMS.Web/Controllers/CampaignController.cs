using MediatR;
using Microsoft.AspNetCore.Mvc;
using QMS.Commands.Campaign;
using QMS.Commands.User;
using QMS.Domain.Constants;
using QMS.Domain.Models.Queries;
using QMS.Domain.Models.Requests;
using QMS.Queries.Campaign;
using QMS.Queries.User;
using System.Threading.Tasks;

namespace QMS.Web.Controllers
{
    public class CampaignController : _BaseController
    {
        #region Constructor(s)
        public CampaignController(IMediator mediator) : base(mediator)
        {
        }
        #endregion


        #region IActionResult(s)
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(int? page = null, int? pagesize = null)
        {
            var collection = new GetAllCampaign.Query() { Paging = new PagingModel { Page = page ?? 0, PageSize = pagesize ?? 0 } };
            return await ExecuteCollectionQuery(collection)
                .ConfigureAwait(false);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return await ExecuteQuery(new GetCampaignById.Query(id))
                .ConfigureAwait(false);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCampaignRequest model)
        {
            var command = new CreateCampaign.Command { CreateCampaignRequest = model };
            return await ExecuteCommand(command)
                .ConfigureAwait(false);
        }

        #endregion
    }
}
