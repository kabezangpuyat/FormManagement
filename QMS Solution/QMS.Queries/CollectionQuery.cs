using MediatR;
using QMS.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Queries
{
    public class CollectionQuery : IRequest<QueryCollectionResponse>
    {
    }
}
