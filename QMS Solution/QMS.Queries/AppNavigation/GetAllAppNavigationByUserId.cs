using AutoMapper;
using MediatR;
using QMS.Core.Database;
using QMS.Core.Exceptions;
using QMS.Core.Providers;
using QMS.Domain.Constants;
using QMS.Domain.Models.AppNavigation;
using QMS.Domain.Models.Responses;
using QMS.Domain.Models.Responses.AppNavigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QMS.Queries.AppNavigation
{
    public static class GetAllAppNavigationByUserId
    {
        #region Query
        public class Query : IQuery
        {
            public List<long> RoleIds { get; set; }
        }
        #endregion

        #region Handler
        public class GetAllAppNavigationByUserIdHandler : QueryHandler, IRequestHandler<Query, ICommandQueryResponse>
        {
            public GetAllAppNavigationByUserIdHandler(IDataContext dataContext,
                IMapper mapper,
                ICurrentUserProvider currentUserProvider) : base(dataContext, mapper, currentUserProvider)
            {

            }

            public async Task<ICommandQueryResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var data = _dataContext.RoleAppNavigation.Where(x => x.Active && request.RoleIds.Contains(x.RoleID))
                    .Select(x => x.AppNavigation)
                    .AsQueryable();
                var count = data.Count();

                if (data is null || count == 0)
                    throw new DataNotFoundException(MessagesConstants.DataNotFound);

                var results = _mapper.Map<List<AppNavigationModel>>(data);

                return await Task.FromResult(new GetAllAppNavigationByUserIdResponse { AppNavigations = results });
            }
        }
        //public class GetAllAppNavigationByUserIdHandler : QueryHandler, IRequestHandler<Query, QueryCollectionResponse>
        //{
        //    public GetAllAppNavigationByUserIdHandler(IDataContext dataContext, 
        //        IMapper mapper, 
        //        ICurrentUserProvider currentUserProvider) : base(dataContext, mapper, currentUserProvider)
        //    {

        //    }

        //    public async Task<QueryCollectionResponse> Handle(Query request, CancellationToken cancellationToken)
        //    {
        //        var data = _dataContext.RoleAppNavigation.Where(x=>x.Active && x.RoleID==request.RoleId)
        //            .Select(x => x.AppNavigation )
        //            .AsQueryable();
        //        var count = data.Count();

        //        if (data is null || count==0)
        //            throw new DataNoFoundException(ExceptionMessageConstants.DataNotFound);

        //        var results = _mapper.Map<AppNavigationModel>(data);

        //        return await Task.FromResult(new QueryCollectionResponse { Results = results, Total = count });
        //    }
        //}
        #endregion
    }
}
