using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QMS.Core.Database;
using QMS.Core.Exceptions;
using QMS.Core.Providers;
using QMS.Core.Services;
using QMS.Domain.Constants;
using QMS.Domain.Models.Authentication;
using QMS.Domain.Models.Responses;
using QMS.Mapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QMS.Commands.Authentication
{
    public static class CreateJWToken
    {
        #region Command
        public class Command : AuthenticationModel, ICommand
        {
            public Command( string username, string ipaddress)
            {
                this.Username = username;
                this.IpAddress = ipaddress;
            }
            public string IpAddress { get; set; }
        }
        #endregion

        #region Handler
        public class Handler : CommandHandler, IRequestHandler<Command, ICommandQueryResponse>
        {
            private readonly IAuthenticationService _authenticationService;
            private readonly IMediator _mediator;
            public Handler(IDataContext dataContext, 
                IMapper mapper,               
                IMediator mediator,
                ICurrentUserProvider currentUserProvider,
                IAuthenticationService authenticationService) : base(dataContext, mapper, currentUserProvider)
            {
                this._authenticationService = authenticationService ?? throw new ArgumentException(nameof(authenticationService));
                this._mediator = mediator ?? throw new ArgumentException(nameof(mediator));
            }

            public async Task<ICommandQueryResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var data = _dataContext.User.Where(x => x.Username == request.Username && x.Active);

                if(data.FirstOrDefault() == null)
                    throw new DataNotFoundException(MessagesConstants.DataNotFound);

                var user = data.ToSingleUserViewModel();

                var jwtResponse = _authenticationService.Authenticate(user, request.IpAddress);
                //Create RefreshToken
                await _mediator.Send(new CreateRefreshToken.Command { RefreshTokenModel = jwtResponse.RefreshTokenModel });

                return await Task.FromResult(jwtResponse);
            }

        }
        #endregion
    }
}
