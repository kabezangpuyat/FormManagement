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
    public static class UpdateMultiplechoice
    {
        #region Command
        public class Command : ICommand
        {
            public UpdateMultiplechoiceRequest Payload { get; set; }
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
                CommandQueryResponse response = new CommandQueryResponse(MessagesConstants.UnableToExecuteTransaction, false);
                long formId = 0;

                using (var transaction = _dataContext.Database.BeginTransaction())
                {
                    try
                    {
                        var currentuser = _currentUserProvider.GetCurrentUser();
                        var currentUserId = currentuser.ID;
                        var dateCreated = DateTimeOffset.Now;

                        var formDetail = request.Payload.FormDetail;
                        var questiondetails = request.Payload.QuestionDetails;

                        #region Update Form and Form Questions
                        formId = formDetail.FormId;
                        #region UpdateForm
                        var formtoupdate = new Domain.Entities.Form { ID = formId };
                        _dataContext.Form.Attach(formtoupdate);
                        formtoupdate.Name = formDetail.FormName;
                        formtoupdate.ModifiedByID = currentUserId;
                        formtoupdate.DateModified = dateCreated;
                        #endregion

                        var questionsToUpdate = questiondetails.Where(x => !x.Isnew.HasValue);
                        #region Update question
                        if (questionsToUpdate.Count() > 0)
                        {
                            List<Domain.Entities.FormQuestion> questions = new List<Domain.Entities.FormQuestion>();
                            foreach(var questiondetail in questionsToUpdate)
                            {
                                var question = new Domain.Entities.FormQuestion { ID = questiondetail.Id };
                                _dataContext.FormQuestion.Attach(question);
                                question.Name = questiondetail.Name;
                                question.ModifiedByID = currentUserId;
                                question.DateModified = dateCreated;
                                #region update choice
                                foreach(var choicedetail in questiondetail.Choices)
                                {
                                    var choice = new Domain.Entities.FormChoice { ID = choicedetail.Id };
                                    _dataContext.FormChoice.Attach(choice);
                                    choice.Name = choicedetail.Name;
                                    choice.Value = choicedetail.Value;
                                    choice.DateModified = dateCreated;
                                    choice.ModifiedByID = currentUserId;
                                }
                                #endregion
                            }
                        }
                        #endregion
                        var questionsToAdd = questiondetails.Where(x => x.Isnew.HasValue == true)
                            .ToArray();

                        var success = true;
                        #endregion
                        _dataContext.SaveChanges();
                        transaction.Commit();

                        //create new details
                        success = this.CreateQuestionChoices(currentUserId, dateCreated, formId, questionsToAdd);


                        if (success)
                            response = new CommandQueryResponse(MessagesConstants.DataModified, success);

                    }
                    catch (Exception ex)
                    {
                        response = new CommandQueryResponse(ex.Message, false);
                        transaction.Rollback();
                    }
                }

                return await Task.FromResult(response);
            }

            #region Private Method(s)
            private bool CreateQuestionChoices(long createdById, DateTimeOffset dateCreated, long formId,
                UpdateMultipleChoiceQuestionDetail[] multiplechoicedetails)
            {
                bool success = true;
                try
                {
                    if (multiplechoicedetails.Length > 0)
                    {
                        //create question
                        foreach (var qadetail in multiplechoicedetails)
                        {
                            var question = new Domain.Entities.FormQuestion
                            {
                                Name = qadetail.Name,
                                IsNoteVisible = false,
                                CreatedByID = createdById,
                                DateCreated = dateCreated,
                                Active = false,
                                HtmlControlID = qadetail.HtmlControlID,
                                FormID = formId
                            };
                            if (qadetail.HtmlControlID == HtmlControlIdConstants.Textbox)
                                question.IsNoteVisible = true;

                            _dataContext.FormQuestion.Add(question);
                            _dataContext.SaveChanges();

                            if (question != null && question?.ID > 0)
                            {
                                long questionId = question.ID;
                                //create choices
                                if (qadetail.Choices.Length > 0)
                                    foreach (var choice in qadetail.Choices)
                                    {
                                        var choicedata = new Domain.Entities.FormChoice
                                        {
                                            Name = choice.Name,
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
