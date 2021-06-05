using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QMS.Core.Database;
using QMS.Core.Exceptions;
using QMS.Core.Providers;
using QMS.Domain.Constants;
using QMS.Domain.Models.Form;
using QMS.Domain.Models.Responses;
using QMS.Domain.Models.Responses.Form;
using QMS.Domain.Models.Responses.FormCategory;
using QMS.Mapper;
using System.Collections.Generic;
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
    public static class GetFormBGetAllFormCategoryByStatusyId
    {
        #region Query
        public class Query : IQuery 
        {
            public Query(bool? active)
            {
                this.Active = active;
            }
            public bool? Active { get; set; }
        }

        #endregion

        #region Handler
        public class GetAllFormCategoryByStatusHandler : QueryHandler, IRequestHandler<Query, ICommandQueryResponse>
        {
            public GetAllFormCategoryByStatusHandler(IDataContext dataContext,
                IMapper mapper,
                ICurrentUserProvider currentUserProvider) : base(dataContext, mapper, currentUserProvider)
            {
            }
            public async Task<ICommandQueryResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var data = _dataContext.FormCategory.Where(x => (x.Active==request.Active) || (request.Active == null))
                    .AsQueryable();

                if (data == null)
                    throw new DataNotFoundException(MessagesConstants.DataNotFound);

                var model = _mapper.Map<List<FormCategoryViewModel>>(data);

                var result = new GetAllFormCategoryResponse { FormCategories = model };
                return await Task.FromResult(result);
            }
        }
        #endregion
    }
}
