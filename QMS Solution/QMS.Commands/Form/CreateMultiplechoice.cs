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
    public static class CreateMultiplechoice
    {
        #region Command
        public class Command : ICommand
        {
            public CreateMultiplechoiceRequest CreateMultiplechoiceRequest { get; set; }
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
                CreateMultiplechoiceResponse response = new CreateMultiplechoiceResponse { Success = false, Message = MessagesConstants.UnableToExecuteTransaction };
                long formId = 0;
                try
                {
                    var currentuser = _currentUserProvider.GetCurrentUser();
                    var currentUserId = currentuser.ID;
                    var dateCreated = DateTimeOffset.Now;

                    var formDetail = request.CreateMultiplechoiceRequest.FormDetail;
                    var questiondetails = request.CreateMultiplechoiceRequest.QuestionDetails;

                    #region Create Form and Form Questions
                    formId = this.CreateForm(currentUserId,dateCreated,formDetail);
                    var success = this.CreateQuestionChoices(currentUserId, dateCreated, formId, questiondetails);
                    #endregion
                    FormViewModel formModel = new FormViewModel();
                    if (success && formId > 0)
                        formModel = _dataContext.Form.Where(x => x.ID == formId).ToSingleFormViewModel();

                    if (formModel != null)
                        response = new CreateMultiplechoiceResponse { Form = formModel, Message = $"Form [{formModel.Name}] created.", Success = success };
                }
                catch (Exception ex)
                {
                    if (formId > 0)
                    {
                        await _mediator.Send(new DeleteForm.Command { Id = formId });
                    }
                    response = new CreateMultiplechoiceResponse { Success = false, Message = ex.Message };
                }


                return await Task.FromResult(response);
            }

            #region Private Method(s)
            private long CreateForm(long createdById, DateTimeOffset dateCreated, FormDetailRequest formdetail)
            {
                long id = 0;

                var data = new Domain.Entities.Form
                {
                    Key = Guid.NewGuid(),
                    Name = formdetail.FormName,
                    FormCategoryID = formdetail.CategoryId,
                    FormTypeID = FormTypeConstants.QAForm,
                    IsNoteVisible = true,
                    CreatedByID = createdById,
                    DateCreated = dateCreated,
                    Active = true
                };

                _dataContext.Form.Add(data);
                _dataContext.SaveChanges();

                if (data != null)
                    id = data.ID;

                return id;
            }
            private bool CreateQuestionChoices(long createdById, DateTimeOffset dateCreated, long formId, 
                CreateMultiplechoiceDetail[] multiplechoicedetails)
            {
                bool success = false;
                try
                {
                    if (multiplechoicedetails.Length > 0)
                    {
                        //create question
                        foreach (var qadetail in multiplechoicedetails)
                        {
                            var question = new Domain.Entities.FormQuestion
                            {
                                Name = qadetail.Formquestion,
                                IsNoteVisible = false,
                                CreatedByID = createdById,
                                DateCreated = dateCreated,
                                Active = false,
                                HtmlControlID = qadetail.Htmlcontrolid,
                                FormID = formId
                            };
                            if (qadetail.Htmlcontrolid == HtmlControlIdConstants.Textbox)
                                question.IsNoteVisible = true;

                            _dataContext.FormQuestion.Add(question);
                            _dataContext.SaveChanges();

                            if (question != null && question?.ID > 0)
                            {
                                long questionId = question.ID;
                                //create choices
                                if (qadetail.Choicedata.Length > 0)
                                    foreach (var choice in qadetail.Choicedata)
                                    {
                                        var choicedata = new Domain.Entities.FormChoice
                                        {
                                            Name = choice.Choice,
                                            Value = choice.Value,
                                            CreatedByID = createdById,
                                            DateCreated = dateCreated,
                                            Active = true
                                        };
                                        _dataContext.FormChoice.Add(choicedata);
                                        _dataContext.SaveChanges();
                                        if (choicedata != null && choicedata?.ID > 0)
                                        {
                                            //create questionchoice
                                            long choiceId = choicedata.ID;
                                            var questionchoice = new Domain.Entities.FormQuestionChoice
                                            {
                                                QuestionID = questionId,
                                                ChoiceID = choiceId,
                                                CreatedByID = createdById,
                                                DateCreated = dateCreated,
                                                Active = true
                                            };
                                            _dataContext.FormQuestionChoice.Add(questionchoice);
                                            _dataContext.SaveChanges();

                                            if (questionchoice != null && questionchoice?.ID > 0)
                                                success = true;
                                        }
                                    }
                            }

                        }
                    }
                }
                catch(Exception ex)
                {
                    //TODO: log
                    success = false;
                }

                return success;
            }
            #endregion
        }

        #endregion
    }
}
