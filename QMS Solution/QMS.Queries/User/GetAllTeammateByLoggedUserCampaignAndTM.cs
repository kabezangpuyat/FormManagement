using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QMS.Core.Database;
using QMS.Core.Exceptions;
using QMS.Core.Providers;
using QMS.Domain.Constants;
using QMS.Domain.Models.Queries;
using QMS.Domain.Models.Responses;
using QMS.Domain.Models.Responses.User;
using QMS.Domain.Models.User;
using QMS.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QMS.Queries.User
{
    /// <summary>
    /// It handles our Query, handler except for response.
    /// We put those three in container for code discoverability purpose.
    /// 
    /// Benefits of using records is its immutable
    /// </summary>
    public static class GetAllTeammateByLoggedUserCampaignAndTM
    {
        #region Query
        public class Query : CollectionQuery
        {
        }
        #endregion

        #region Handler
        public class Handler : QueryHandler, IRequestHandler<Query, QueryCollectionResponse>
        {
            public Handler(IDataContext dataContext,
                IMapper mapper,
                ICurrentUserProvider currentUserProvider) : base(dataContext, mapper, currentUserProvider)
            {
            }
            public async Task<QueryCollectionResponse> Handle(Query request, CancellationToken cancellationToken)
            {

                var campaignIds = _currentUserProvider.GetCurrentCampaigns().Select(x => x.ID).ToList();
                //var campaigns = _currentUserProvider.GetCurrentCampaigns();

                //var data = _dataContext.Form.Where(x => x.Active && x.CreatedBy.UserCampaigns.Any(uc => campaignIds.Contains((long)uc.CampaignID)))
                //    .AsQueryable();
                var tmRoleId = RoleConstants.TM;
                var currentuser = _currentUserProvider.GetCurrentUser();

                var data = _dataContext.User.Where(x=>x.Active &&
                                x.UserRoles.Any(us=>us.RoleID==tmRoleId && us.Active) &&
                                x.UserCampaigns.Any(uc=>campaignIds.Contains((long)uc.CampaignID) && uc.Active))
                    .OrderBy(x=>x.LastName)
                    .ThenBy(x=>x.FirstName)
                    .AsQueryable();
                var count = data.Count();
                if (data is null)
                    throw new DataNotFoundException(MessagesConstants.DataNotFound);

                var result = data.ToUserViewModelQueryable();

                return await Task.FromResult(new GetAllUserResponse() { Results = result, Total = count });
            }
        }
        #endregion
    }
}
