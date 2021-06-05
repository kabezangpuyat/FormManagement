using AutoMapper;
using QMS.Core.Database;
using QMS.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMS.Commands
{
    public abstract class CommandHandler
    {
        protected readonly IDataContext _dataContext;
        protected readonly IMapper _mapper;
        protected readonly ICurrentUserProvider _currentUserProvider;
        public CommandHandler(IDataContext dataContext, IMapper mapper, ICurrentUserProvider currentUserProvider)
        {
            _dataContext = dataContext ?? throw new ArgumentException(nameof(dataContext));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
            _currentUserProvider = currentUserProvider ?? throw new ArgumentException(nameof(currentUserProvider));
        }
    }
}
