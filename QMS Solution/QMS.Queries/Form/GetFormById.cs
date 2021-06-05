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
    public static class GetFormById
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
        public class GetFormByIdHandler : QueryHandler, IRequestHandler<Query, ICommandQueryResponse>
        {
            public GetFormByIdHandler(IDataContext dataContext,
                IMapper mapper,
                ICurrentUserProvider currentUserProvider) : base(dataContext, mapper, currentUserProvider)
            {
            }
            public async Task<ICommandQueryResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var data = _dataContext.Form.Where(x => x.ID == request.ID)
                    .AsQueryable();

                if (data == null)
                    throw new DataNotFoundException(MessagesConstants.DataNotFound);

                var model = data.ToSingleFormViewModel();
                //_mapper.Map<FormViewModel>(data);

                var result = new GetFormByFormIDResponse { Form = model };
                return await Task.FromResult(result);
            }
        }
        #endregion
    }
}
