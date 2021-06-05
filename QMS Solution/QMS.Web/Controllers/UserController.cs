using MediatR;
using Microsoft.AspNetCore.Mvc;
using QMS.Commands.User;
using QMS.Domain.Constants;
using QMS.Domain.Models.Queries;
using QMS.Domain.Models.Requests;
using QMS.Queries.User;
using System.Threading.Tasks;

namespace QMS.Web.Controllers
{
    public class UserController : _BaseController
    {
        #region Constructor(s)
        public UserController(IMediator mediator) : base(mediator)
        {
        }
        #endregion


        #region IActionResult(s)
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(int? page = null, int? pagesize = null)
        {
            var collection = new GetAllUser.Query() { Paging = new PagingModel { Page = page ?? 0, PageSize = pagesize ?? 0 } };
            return await ExecuteCollectionQuery(collection)
                .ConfigureAwait(false);
        }

        [HttpGet("get-all-tm-by-logged-user-campaign")]
        public async Task<IActionResult> GetAllTMByLoggedUserCampaign()
        {
            var collection = new GetAllTeammateByLoggedUserCampaignAndTM.Query();
            return await ExecuteCollectionQuery(collection)
                .ConfigureAwait(false);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return await ExecuteQuery(new GetUserById.Query(id))
                .ConfigureAwait(false);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var command = new DeleteUser.Command { Id = id };
            return await ExecuteCommand(command)
                .ConfigureAwait(false);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateUserRequest model)
        {
            var command = new UpdateUser.Command { UpdateUserRequest = model };
            return await ExecuteCommand(command)
                .ConfigureAwait(false);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateUserWithRoleRequest model)
        {
            var command = new CreateUserWithRoleCampaign.Command { CreateUserRequest = model };
            return await ExecuteCommand(command)
                .ConfigureAwait(false);
        }

        [HttpPost("create-admin-user")]
        public async Task<IActionResult> CreateAdminUser(CreateUserRequest model)
        {
            model.RoleId = RoleConstants.Administrator;
            var command = new CreateUser.Command { CreateUserRequest = model };
            return await ExecuteCommand(command)
                .ConfigureAwait(false);
        }

        [HttpPost("create-qa-user")]
        public async Task<IActionResult> CreateQAUser(CreateUserRequest model)
        {
            model.RoleId = RoleConstants.QA;
            var command = new CreateUser.Command { CreateUserRequest = model };
            return await ExecuteCommand(command)
                .ConfigureAwait(false);
        }

        [HttpPost("create-tl-user")]
        public async Task<IActionResult> CreateTLUser(CreateUserRequest model)
        {
            model.RoleId = RoleConstants.TL;
            var command = new CreateUser.Command { CreateUserRequest = model };
            return await ExecuteCommand(command)
                .ConfigureAwait(false);
        }
        [HttpPost("create-tm-user")]
        public async Task<IActionResult> CreateTMUser(CreateUserRequest model)
        {
            model.RoleId = RoleConstants.TM;
            var command = new CreateUser.Command { CreateUserRequest = model };
            return await ExecuteCommand(command)
                .ConfigureAwait(false);
        }
        #endregion
    }
}
