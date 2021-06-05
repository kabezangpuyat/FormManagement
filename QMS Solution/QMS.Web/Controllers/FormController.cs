using MediatR;
using Microsoft.AspNetCore.Mvc;
using QMS.Commands.Form;
using QMS.Domain.Models.Requests;
using QMS.Queries.Form;
using System.Threading.Tasks;

namespace QMS.Web.Controllers
{
    public class FormController : _BaseController
    {
        #region Constructor(s)
        public FormController(IMediator mediator) : base(mediator)
        {
        }
        #endregion

        #region IActionResult(s)
        [HttpGet("get-all-active")]
        public async Task<IActionResult> GetAllActive()
        {
            return await ExecuteQuery(new GetAllActiveForm.Query())
                .ConfigureAwait(false);
        }

        [HttpGet("get-all-by-logged-user")]
        public async Task<IActionResult> GetAllByLoggedUser()
        {
            return await ExecuteQuery(new GetAllFormByLoggedUser.Query())
                .ConfigureAwait(false);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return await ExecuteQuery(new GetFormById.Query(id))
                .ConfigureAwait(false);
        }

        [HttpPost("create-form")]
        public async Task<IActionResult> CreateForm(CreateTrueFalseYesNoNAFormRequest model)
        {
            var command = new CreateTrueFalseYesNoNA.Command { CreateTrueFalseYesNoNAFormRequest = model };
            return await ExecuteCommand(command)
                .ConfigureAwait(false);
        }

        [HttpPost("create-multiplechoice-form")]
        public async Task<IActionResult> CreateMultiplechoiceForm(CreateMultiplechoiceRequest model)
        {
            var command = new CreateMultiplechoice.Command { CreateMultiplechoiceRequest = model };
            return await ExecuteCommand(command)
                .ConfigureAwait(false);
        }

        [HttpDelete("delete-form/{id}")]
        public async Task<IActionResult> DeleteForm(long id)
        {
            var command = new DeleteForm.Command { Id = id };
            return await ExecuteCommand(command)
                .ConfigureAwait(false);
        }
        [HttpPut("update-form-status")]
        public async Task<IActionResult> UpdateStatus(UpdateFormStatusRequest model)
        {
            var command = new DeactivateOrActivateForm.Command { Id = model.Id, Active = model.Active };
            return await ExecuteCommand(command)
                .ConfigureAwait(false);
        }

        [HttpPut("update-basic-form")]
        public async Task<IActionResult> UpdateYNTFNA(UpdateTrueFalseYesNoNAFormRequest model)
        {
            var command = new UpdateTrueFalseYesNoNAForm.Command { Payload = model };
            return await ExecuteCommand(command)
                .ConfigureAwait(false);
        }
        [HttpPut("update-multiplechoice-form")]
        public async Task<IActionResult> UpdateMultipleChoiceForm(UpdateMultiplechoiceRequest model)
        {
            var command = new UpdateMultiplechoice.Command { Payload = model };
            return await ExecuteCommand(command)
                .ConfigureAwait(false);
        }
        #endregion
    }
}
