using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QMS.Core.Database;
using QMS.Core.Exceptions;
using QMS.Core.Providers;
using QMS.Domain.Constants;
using QMS.Domain.Models.Responses;
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
    public static class GetAllFormByLoggedUser
    {
        #region Query
        public class Query : IQuery 
        {
           
        }

        #endregion

        #region Handler
        public class GetAllFormByLoggedUserHandler : QueryHandler, IRequestHandler<Query, ICommandQueryResponse>
        {
            public GetAllFormByLoggedUserHandler(IDataContext dataContext,
                IMapper mapper,
                ICurrentUserProvider currentUserProvider) : base(dataContext, mapper, currentUserProvider)
            {
            }
            public async Task<ICommandQueryResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var campaignIds = _currentUserProvider.GetCurrentCampaigns().Select(x=>x.ID).ToList();
                var campaigns = _currentUserProvider.GetCurrentCampaigns();

                var data = _dataContext.Form.Where(x => x.Active && x.CreatedBy.UserCampaigns.Any(uc => campaignIds.Contains((long)uc.CampaignID)))
                    .AsQueryable();

                if (data == null)
                    throw new DataNotFoundException(MessagesConstants.DataNotFound);

                var model = await data.ToFormViewModelQueryable().OrderBy(x => x.Name).ToListAsync();

                var result = new GetAllFormByLoggedUserResponse { Forms = model };
                return result;
            }
        }
        #endregion
    }
}
