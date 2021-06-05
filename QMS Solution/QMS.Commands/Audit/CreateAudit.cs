using AutoMapper;
using MediatR;
using QMS.Core.Database;
using QMS.Core.Providers;
using QMS.Domain.Constants;
using QMS.Domain.Models.Requests.Audit;
using QMS.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QMS.Commands.Audit
{
    /// <summary>
    /// It handles our Query, handler .Response is in Domain.
    /// We put those three in container for code discoverability purpose.
    /// 
    /// Benefits of using records is its immutable
    /// </summary>
    public static class CreateAudit
    {
        #region Command
        public class Command : ICommand
        {
            public CreateAuditRequest Payload { get; set; }
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
                var payload = request.Payload;
                var formId = payload.FormID;
                var auditName = payload.AuditName;
                var formNotes = payload.FormNotes;
                var teammateID = payload.UserID;
             
                using (var transaction = _dataContext.Database.BeginTransaction())
                {
                    try
                    {
                        var currentuser = _currentUserProvider.GetCurrentUser();
                        var currentUserId = currentuser.ID;
                        var dateCreated = DateTimeOffset.Now;
                        
                        if(payload.AuditDetails.Count() > 0)
                        {
                            var audit = new Domain.Entities.Audit
                            {
                                FormID = formId,
                                Name = auditName,
                                TeammateID = teammateID,
                                FormNotes = formNotes,
                                DateCreated = dateCreated,
                                CreatedByID = currentUserId
                            };
                            List<Domain.Entities.AuditDetail> auditdetails = new List<Domain.Entities.AuditDetail>();
                            foreach(var detail in payload.AuditDetails)
                            {
                                long? choiceId = detail.ChoiceID;
                                if (choiceId == 0)
                                    choiceId = null;

                                auditdetails.Add(new Domain.Entities.AuditDetail
                                {
                                    Audit = audit,
                                    QuestionID = detail.QuestionID,
                                    ChoiceID = choiceId,
                                    QuestionNotes = detail.QuestionNotes,
                                    DateCreated = dateCreated,
                                    CreatedByID = currentUserId,
                                    Active = true
                                });
                            }
                            if(auditdetails.FirstOrDefault() != null)
                            {
                                _dataContext.AuditDetail.AddRange(auditdetails);
                                await _dataContext.SaveChangesAsync();
                            }
                        }

                        response = new CommandQueryResponse(MessagesConstants.DataCreated, true);

                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        response = new CommandQueryResponse(ex.Message, false);
                        transaction.Rollback();
                    }
                }

                return response;
            }
        }

        #endregion
    }
}
