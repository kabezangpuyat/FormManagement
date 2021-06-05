using MediatR;
using Microsoft.AspNetCore.Mvc;
using QMS.Domain.Models.Queries;
using QMS.Queries.Role;
using System.Threading.Tasks;

namespace QMS.Web.Controllers
{
    public class RoleController : _BaseController
    {
        #region Constructor(s)
        public RoleController(IMediator mediator) : base(mediator)
        {
        }
        #endregion


        #region IActionResult(s)
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(int? page = null, int? pagesize = null)
        {
            var collection = new GetAllRole.Query() { Paging = new PagingModel { Page = page ?? 0, PageSize = pagesize ?? 0 } };
            return await ExecuteCollectionQuery(collection)
                .ConfigureAwait(false);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return await ExecuteQuery(new GetRoleById.Query(id))
                .ConfigureAwait(false);
        }

        #endregion
    }
}
