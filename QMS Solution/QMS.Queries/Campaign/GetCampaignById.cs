using AutoMapper;
using MediatR;
using QMS.Core.Database;
using QMS.Core.Exceptions;
using QMS.Core.Providers;
using QMS.Domain.Constants;
using QMS.Domain.Models.Campaign;
using QMS.Domain.Models.Responses;
using QMS.Domain.Models.Responses.Campaign;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QMS.Queries.Campaign
{
    /// <summary>
    /// It handles our Query, handler and response.
    /// We put those three in container for code discoverability purpose.
    /// 
    /// Benefits of using records is its immutable
    /// </summary>
    public static class GetCampaignById
    {
        #region Query
        public class Query : IQuery 
        {
            public Query(long ID)
            {
                this.ID = ID;
            }
            public long ID { get; set; }
        }

        #endregion

        #region Handler
        public class GetCampaignByIdHandler : QueryHandler, IRequestHandler<Query, ICommandQueryResponse>
        {
            public GetCampaignByIdHandler(IDataContext dataContext,
                IMapper mapper,
                ICurrentUserProvider currentUserProvider) : base(dataContext, mapper, currentUserProvider)
            {
            }
            public async Task<ICommandQueryResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var currentuser = _currentUserProvider.GetCurrentUser();
                var data = _dataContext.Campaign.FirstOrDefault(x => x.ID == request.ID);
                if (data is null)
                    throw new DataNotFoundException(MessagesConstants.DataNotFound);

                var model = _mapper.Map<CampaignViewModel>(data);  //user.ToSingleUserViewModel();
                   
                var result = new GetCampaignByIdResponse { Campaign = model };
                return await Task.FromResult(result);
            }
        }
        #endregion
    }
}
