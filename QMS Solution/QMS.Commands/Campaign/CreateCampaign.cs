using AutoMapper;
using MediatR;
using QMS.Core.Database;
using QMS.Core.Exceptions;
using QMS.Core.Providers;
using QMS.Domain.Constants;
using QMS.Domain.Models.Campaign;
using QMS.Domain.Models.Requests;
using QMS.Domain.Models.Responses;
using QMS.Domain.Models.Responses.Campaign;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QMS.Commands.Campaign
{
    /// <summary>
    /// It handles our Query, handler .Response is in Domain.
    /// We put those three in container for code discoverability purpose.
    /// 
    /// Benefits of using records is its immutable
    /// </summary>
    public static class CreateCampaign
    {
        #region Command
        public class Command : ICommand
        {
            public CreateCampaignRequest CreateCampaignRequest { get; set; }
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
                bool success = false;
                string message = MessagesConstants.ErrorCreatingUser;
                CampaignViewModel result = new CampaignViewModel();

                using(var transaction = _dataContext.Database.BeginTransaction())
                {
                    try
                    {
                        var currentuser = _currentUserProvider.GetCurrentUser();
                        var data = _mapper.Map<Domain.Entities.Campaign>(request.CreateCampaignRequest);
                        data.CreatedByID = currentuser.ID;

                        _dataContext.Campaign.Add(data);
                        await _dataContext.SaveChangesAsync()
                            .ConfigureAwait(false);

                        transaction.Commit();
                        if (data == null)
                            result = null;
                        else
                        {
                            success = true;
                            message = MessagesConstants.DataCreated;
                            result = _mapper.Map<CampaignViewModel>(data);// _dataContext.User.Where(x=>x.ID==data.ID).ToSingleUserViewModel();
                        }
                     
                    }
                    catch( Exception ex)
                    {
                        //TODO: LOg
                        transaction.Rollback();
                    }      
                }
                
                
                return new CreateCampaignResponse(result, message,success);
            }
        }
        #endregion
    }
}
