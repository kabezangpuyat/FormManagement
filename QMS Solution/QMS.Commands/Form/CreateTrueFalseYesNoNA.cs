using AutoMapper;
using MediatR;
using QMS.Core.Database;
using QMS.Core.Exceptions;
using QMS.Core.Services;
using QMS.Domain.Constants;
using QMS.Domain.Models.Requests;
using QMS.Domain.Models.Responses;
using QMS.Domain.Models.Responses.User;
using QMS.Mapper;
using QMS.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using QMS.Core.Providers;
using QMS.Domain.Models.Responses.Form;
using QMS.Domain.Models.Form;
using QMS.Queries.Form;

namespace QMS.Commands.Form
{
    /// <summary>
    /// It handles our Query, handler .Response is in Domain.
    /// We put those three in container for code discoverability purpose.
    /// 
    /// Benefits of using records is its immutable
    /// </summary>
    public static class CreateTrueFalseYesNoNA
    {
        #region Command
        public class Command : ICommand
        {
            public CreateTrueFalseYesNoNAFormRequest CreateTrueFalseYesNoNAFormRequest { get; set; }
        }
        #endregion

        #region Handler
        public class Handler : CommandHandler, IRequestHandler<Command, ICommandQueryResponse>
        {
            private readonly IMediator _mediator;
            public Handler(IDataContext dataContext,
                IMapper mapper,
                ICurrentUserProvider currentUserProvider,
                IMediator mediator) : base(dataContext, mapper, currentUserProvider)
            {
                this._mediator = mediator;
            }

            public async Task<ICommandQueryResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                CreateTrueFalseYesNoNAFormResponse response = new CreateTrueFalseYesNoNAFormResponse { Success = false, Message = MessagesConstants.UnableToExecuteTransaction };
                long formId = 0;
                try
                {
                    var currentuser = _currentUserProvider.GetCurrentUser();
                    var currentUserId = currentuser.ID;

                    var formDetail = request.CreateTrueFalseYesNoNAFormRequest.FormDetail;
                    var choiceIds = this.ChoiceIds(formDetail.CategoryId);
                    var questions = request.CreateTrueFalseYesNoNAFormRequest.QuestionDetails;

                    #region Create Form and Form Questions
                    FormMapper.CreatedById = currentUserId;
                    FormMapper.FormTypeId = FormTypeConstants.QAForm;

                    var form = _mapper.Map<Domain.Entities.Form>(formDetail);
                    FormMappings._currentUserId = currentUserId;
                    FormMappings._formData = form;
                    var questionsToCreate = questions.ToFormQuestionsQueryable();
                    _dataContext.FormQuestion.AddRange(questionsToCreate);
                    await _dataContext.SaveChangesAsync();

                    formId = form.ID;
                    var result = await _mediator.Send(new GetFormById.Query(formId)) as GetFormByFormIDResponse;
                    var formQuestions = result.Form.Questions;
                    #endregion

                    #region Question Choice insert
                    var choices = _dataContext.FormChoice.Where(x => choiceIds.Contains(x.ID));
                    List<Domain.Entities.FormQuestionChoice> questionChoices = new List<Domain.Entities.FormQuestionChoice>();
                    foreach (var choice in choices)
                    {
                        foreach (var question in formQuestions)
                        {
                            if (question.HtmlControlID == HtmlControlIdConstants.Option && question.ID > 0)
                            {
                                Domain.Entities.FormQuestionChoice formQuestionChoice = new Domain.Entities.FormQuestionChoice
                                {
                                    ChoiceID = choice.ID,
                                    QuestionID = question.ID,
                                    CreatedByID = currentUserId
                                };

                                questionChoices.Add(formQuestionChoice);
                            }
                        }
                    }
                    if (questionChoices.FirstOrDefault() != null)
                    {
                        _dataContext.FormQuestionChoice.AddRange(questionChoices);
                        await _dataContext.SaveChangesAsync()
                          .ConfigureAwait(false);

                    }
                    #endregion

                    FormViewModel formModel = new FormViewModel();
                    if (form.ID > 0)
                        formModel = _dataContext.Form.Where(x => x.ID == form.ID).ToSingleFormViewModel();

                    if (formModel != null)
                        response = new CreateTrueFalseYesNoNAFormResponse { Form = formModel, Message = $"Form [{form.Name}] created.", Success = true };
                }
                catch (Exception ex)
                {
                    if (formId > 0)
                    {
                        await _mediator.Send(new DeleteForm.Command { Id = formId });
                    }
                    response = new CreateTrueFalseYesNoNAFormResponse { Success = false, Message = ex.Message };
                }


                return response;
            }

            #region Private Method(s)
            private long[] ChoiceIds(long catId)
            {
                long[] returnValue = FormChoiceIdsConstants.YesNoChoiceIds;

                if (catId == FormCategoryConstants.YesNoNaForm)
                    return FormChoiceIdsConstants.YesNoNAChoiceIds;

                if (catId == FormCategoryConstants.TrueFalseForm)
                    return FormChoiceIdsConstants.TrueFalseChoiceIds;

                return returnValue;
            }
            #endregion
        }

        #endregion
    }
}
