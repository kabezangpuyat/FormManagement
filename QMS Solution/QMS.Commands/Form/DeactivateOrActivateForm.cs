using AutoMapper;
using MediatR;
using QMS.Core.Database;
using QMS.Core.Providers;
using QMS.Domain.Constants;
using QMS.Domain.Models.Responses;
using QMS.Domain.Models.Responses.Form;
using System;
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
    public static class DeactivateOrActivateForm
    {
        #region Command
        public class Command : ICommand
        {
            public long Id { get; set; }
            public bool Active { get; set; }
        }
        #endregion

        #region Handler
        public class Handler : CommandHandler, IRequestHandler<Command, ICommandQueryResponse>
        {
            public Handler(IDataContext dataContext,
                IMapper mapper,
                ICurrentUserProvider currentUserProvider) : base(dataContext, mapper, currentUserProvider)
            {
              
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
                        var form = _dataContext.Form.FirstOrDefault(x => x.ID == request.Id);
                        form.Active = request.Active;
                        form.DateModified = DateTimeOffset.Now;
                        form.ModifiedByID = currentuser?.ID;

                        _dataContext.Form.Update(form);
                        await _dataContext.SaveChangesAsync();
                        message = MessagesConstants.DataModified;
                        success = true;

                        transaction.Commit();
                    }
                    catch(Exception)
                    {
                        transaction.Rollback();
                    }
                }

                return new CommandQueryResponse(message, success);
            }
        }
        #endregion

    }
}
