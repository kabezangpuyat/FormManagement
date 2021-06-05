using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QMS.Core.Database;
using QMS.Core.Exceptions;
using QMS.Core.Providers;
using QMS.Domain.Constants;
using QMS.Domain.Models.Responses;
using QMS.Domain.Models.Responses.Audit;
using QMS.Domain.Models.Responses.Form;
using QMS.Mapper;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QMS.Queries.Form
{
    /// <summary>
    /// It handles our Query, handler and response.
    /// We put those three in container for code discoverability purpose.
    /// 
    /// Benefits of using records is its immutable
    /// </summary>
    public static class GetAllByTeammateCampaign
    {
        #region Query
        public class Query : IQuery 
        {
           
        }

        #endregion

        #region Handler
        public class Handler : QueryHandler, IRequestHandler<Query, ICommandQueryResponse>
        {
            public Handler(IDataContext dataContext,
                IMapper mapper,
                ICurrentUserProvider currentUserProvider) : base(dataContext, mapper, currentUserProvider)
            {
            }
            public async Task<ICommandQueryResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var campaignIds = _currentUserProvider.GetCurrentCampaigns().Select(x=>x.ID).ToList();
                var campaigns = _currentUserProvider.GetCurrentCampaigns();

                var data = _dataContext.Audit
                    .Where(x => x.Active 
                        && x.Teammate.UserCampaigns.Any(uc => uc.Active && campaignIds.Contains((long)uc.CampaignID)))
                    .AsQueryable();

                if (data.FirstOrDefault() == null)
                    throw new DataNotFoundException(MessagesConstants.DataNotFound);

                var model = await data.ToAuditViewModelQueryable().OrderBy(x => x.Name).ToListAsync();

                var result = new GetAllAuditByLoggedUserResponse { Audits = model };
                return result;
            }
        }
        #endregion
    }
}
