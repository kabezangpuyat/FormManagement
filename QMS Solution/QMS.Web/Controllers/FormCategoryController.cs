using MediatR;
using Microsoft.AspNetCore.Mvc;
using QMS.Queries.Form;
using System.Threading.Tasks;

namespace QMS.Web.Controllers
{
    public class FormCategoryController : _BaseController
    {
        #region Constructor(s)
        public FormCategoryController(IMediator mediator) : base(mediator)
        {
        }
        #endregion

        #region IActionResult(s)
        [HttpGet("get-all-by-status")]
        public async Task<IActionResult> GetAllByStatus(bool? active)
        {
            return await ExecuteQuery(new GetFormBGetAllFormCategoryByStatusyId.Query(active))
                .ConfigureAwait(false);
        }

        #endregion
    }
}
