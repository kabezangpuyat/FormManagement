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
    public static class GetAllUser
    {
        #region Query
        public class Query : CollectionQuery
        {
            public PagingModel Paging { get; set; }
        }
        #endregion

        #region Handler
        public class GetAllUserHandler : QueryHandler, IRequestHandler<Query, QueryCollectionResponse>
        {
            public GetAllUserHandler(IDataContext dataContext,
                IMapper mapper,
                ICurrentUserProvider currentUserProvider) : base(dataContext, mapper, currentUserProvider)
            {
            }
            public async Task<QueryCollectionResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var currentuser = _currentUserProvider.GetCurrentUser();
                var data = _dataContext.User.Where(x=>x.Active).AsQueryable();
                var count = data.Count();
                if (data is null)
                    throw new DataNotFoundException(MessagesConstants.DataNotFound);

                if (request.Paging.Page > 0 && request.Paging.PageSize > 0)
                    data = GetPaginated<Domain.Entities.User>(data, request.Paging);

                var result = data.ToUserViewModelQueryable();

                return await Task.FromResult(new GetAllUserResponse() { Results = result, Total = count });
            }
        }
        #endregion
    }
}
