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
using QMS.Domain.Entities;

namespace QMS.Commands.User
{
    /// <summary>
    /// It handles our Query, handler .Response is in Domain.
    /// We put those three in container for code discoverability purpose.
    /// 
    /// Benefits of using records is its immutable
    /// </summary>
    public static class DeleteUser
    {
        #region Command
        public class Command : ICommand
        {
            public long Id { get; set; }
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
                string message = MessagesConstants.FailedToDeleteData;
                bool success = false;
                using(var transaction = _dataContext.Database.BeginTransaction())
                {
                    try
                    {
                        var currentuser = _currentUserProvider.GetCurrentUser();
                        var user = _dataContext.User.FirstOrDefault(x => x.ID == request.Id);
                        if(user!=null)
                        {
                            user.Active = false;
                            user.ModifiedByID = currentuser.ID;
                            user.DateModified = DateTimeOffset.Now;
                            _dataContext.User.Update(user);
                            await _dataContext.SaveChangesAsync();

                            message = MessagesConstants.DataDeleted;
                            success = true;
                        }                      

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
