using MediatR;
using QMS.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMS.Commands
{
    public interface ICommand : IRequest<ICommandQueryResponse>
    {
    }
}
