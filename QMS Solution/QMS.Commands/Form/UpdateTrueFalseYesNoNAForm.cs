using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QMS.Core.Database;
using QMS.Core.Providers;
using QMS.Domain.Constants;
using QMS.Domain.Models.Requests;
using QMS.Domain.Models.Responses;
using QMS.Domain.Models.Responses.Form;
using QMS.Mapper;
using QMS.Queries.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QMS.Commands.Form
{
    /// <summary>
    /// It handles our Query, handler .Response is in Domain.
    /// We put those three in container for code discoverability purpose.
    /// 
    /// Benefits of using records is its immutable
    /// </summary>
    public static class UpdateTrueFalseYesNoNAForm
    {
        #region Command
        public class Command : ICommand
        {
            public UpdateTrueFalseYesNoNAFormRequest Payload { get; set; }
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
                this._mediator = mediator ?? throw new ArgumentException(nameof(mediator));
            }
            public async Task<ICommandQueryResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                string message = MessagesConstants.FailedToModifyData;
                bool success = false;
                using(var transaction = _dataContext.Database.BeginTransaction())
                {
                    try
                    {
                        var currentuser = _currentUserProvider.GetCurrentUser();
                        var currentUserId = currentuser?.ID;
                        var dateModified = DateTimeOffset.Now;

                        var form = request.Payload.FormDetail;
                        var questionsToUpdate = request.Payload.QuestionDetails
                            .Where(x => !x.Isnew.HasValue);

                        var questionsToAdd = request.Payload.QuestionDetails
                            .Where(x => x.Isnew.HasValue == true);

                        #region Update Form
                        var formtoupdate = new Domain.Entities.Form { ID = form.FormId };
                        _dataContext.Form.Attach(formtoupdate);
                        formtoupdate.Name = form.FormName;
                        formtoupdate.ModifiedByID = currentUserId;
                        formtoupdate.DateModified = dateModified;
                        #endregion

                        #region Update question
                        if (questionsToUpdate.Count() > 0)
                        {
                            List<Domain.Entities.FormQuestion> questions =
                                questionsToUpdate.Select(x => new Domain.Entities.FormQuestion {
                                    ID = x.Id
                                }).ToList();
                            _dataContext.FormQuestion.AttachRange(questions);
                            questions.ForEach(x =>
                            {
                                var data = questionsToUpdate.FirstOrDefault(y => y.Id == x.ID);
                                if (x.ID == data?.Id)
                                {
                                    x.Name = data.Name;
                                    x.DateModified = dateModified;
                                    x.ModifiedByID = currentUserId;
                                }
                            });
                        }
                        #endregion


                        message = MessagesConstants.DataModified;
                        success = true;

                        await _dataContext.SaveChangesAsync();
                        transaction.Commit();
                        if (questionsToAdd.Count() > 0)
                            this.CreateQuestionAndChoice(questionsToAdd, currentUserId, dateModified, form.FormId, form.CategoryId, questionsToUpdate.Select(x => x.Id).ToList());
                    }
                    catch (Exception ex)
                    {
                        message += $"<br /> {ex.Message}";
                        transaction.Rollback();
                    }
                }

                return await Task.FromResult(new CommandQueryResponse(message, success));
            }

            #region Private Method(s)
            private void CreateQuestionAndChoice(IEnumerable<UpdateQuestionDetail> questionsToAdd,
                long? currentUserId, DateTimeOffset dateModified, long formId, long categoryId, 
                List<long> questionToUpdateIds)
            {
                #region Create New Questions
                if (questionsToAdd.Count() > 0)
                {
                    FormMappings._currentUserId = currentUserId ?? 0;
                    FormMappings._currentDate = dateModified;
                    FormMappings._formId = formId;

                    var choiceIds = this.ChoiceIds(categoryId);
                    var questions = questionsToAdd.ToUpdateFormQuestionsQueryable();
                    _dataContext.FormQuestion.AddRange(questions);
                    _dataContext.SaveChanges();

                    //var result = await _mediator.Send(new GetFormById.Query(formId)) as GetFormByFormIDResponse;
                    var formQuestions = _dataContext.FormQuestion.Where(x => !questionToUpdateIds.Contains(x.ID) && x.FormID == formId)
                        .ToList();
                        //result.Form.Questions;

                    #region create question choice
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
                        _dataContext.SaveChanges();
                    }
                    #endregion
                }
                #endregion
            }
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
