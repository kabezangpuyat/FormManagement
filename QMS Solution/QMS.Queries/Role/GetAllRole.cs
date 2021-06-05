using AutoMapper;
using MediatR;
using QMS.Core.Database;
using QMS.Core.Exceptions;
using QMS.Core.Providers;
using QMS.Domain.Constants;
using QMS.Domain.Models.Queries;
using QMS.Domain.Models.Responses;
using QMS.Domain.Models.Responses.Role;
using QMS.Domain.Models.Role;
using QMS.Domain.Models.User;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QMS.Queries.Role
{
    /// <summary>
    /// It handles our Query, handler except for response.
    /// We put those three in container for code discoverability purpose.
    /// 
    /// Benefits of using records is its immutable
    /// </summary>
    public static class GetAllRole
    {
        #region Query
        public class Query : CollectionQuery
        {
            public PagingModel Paging { get; set; }
        }
        #endregion

        #region Handler
        public class GetAllRoleHandler : QueryHandler, IRequestHandler<Query, QueryCollectionResponse>
        {
            public GetAllRoleHandler(IDataContext dataContext,
                IMapper mapper,
                ICurrentUserProvider currentUserProvider) : base(dataContext, mapper, currentUserProvider)
            {
            }
            public async Task<QueryCollectionResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var currentuser = _currentUserProvider.GetCurrentUser();
                var data = _dataContext.Role.AsQueryable();
                var count = data.Count();
                if (data is null)
                    throw new DataNotFoundException(MessagesConstants.DataNotFound);

                if (request.Paging.Page > 0 && request.Paging.PageSize > 0)
                    data = GetPaginated<Domain.Entities.Role>(data, request.Paging);

                var result = _mapper.Map<List<RoleViewModel>>(data);

                return await Task.FromResult(new GetAllRoleResponse() { Results = result, Total = count });
            }
        }
        #endregion
    }
}
