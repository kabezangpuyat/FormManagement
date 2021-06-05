using AutoMapper;
using MediatR;
using QMS.Core.Database;
using QMS.Core.Exceptions;
using QMS.Core.Services;
using QMS.Domain.Constants;
using QMS.Domain.Models.Requests;
using QMS.Domain.Models.Responses;
using QMS.Domain.Models.Responses.User;
using QMS.Mapper;
using QMS.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using QMS.Core.Providers;
using QMS.Domain.Entities;

namespace QMS.Commands.User
{
    /// <summary>
    /// It handles our Query, handler .Response is in Domain.
    /// We put those three in container for code discoverability purpose.
    /// 
    /// Benefits of using records is its immutable
    /// </summary>
    public static class CreateUserWithRoleCampaign
    {
        #region Command
        public class Command : ICommand
        {
            public CreateUserWithRoleRequest CreateUserRequest { get; set; }
        }
        #endregion

        #region Handler
        public class Handler : CommandHandler, IRequestHandler<Command, ICommandQueryResponse>
        {
            #region Private global variable(s)
            private readonly IEncryptionService _enryptionService;
            #endregion
            public Handler(IDataContext dataContext,
                IMapper mapper,
                ICurrentUserProvider currentUserProvider,
                IEncryptionService enctryptionService) : base(dataContext, mapper, currentUserProvider)
            {
                this._enryptionService = enctryptionService ?? throw new ArgumentNullException(nameof(enctryptionService));
            }
            public async Task<ICommandQueryResponse> Handle(Command request, CancellationToken cancellationToken)
            {   
                var currentuser = _currentUserProvider.GetCurrentUser();
                var role = _dataContext.Role.FirstOrDefault(x => x.ID == request.CreateUserRequest.RoleId);

                var user = _mapper.Map<Domain.Entities.User>(request.CreateUserRequest);
                user.CreatedByID = currentuser.ID;
                user.Password = _enryptionService.Encrypt("pasok12345");//hardcoded since this is not required by the app

                var userrole = new UserRole
                {
                    User = user,
                    Role = role,
                    CreatedByID = currentuser.ID,
                    DateCreated = DateTimeOffset.Now,
                    Active = true
                };

                #region Setup User Campaigns
                CreateUserCampaign(request.CreateUserRequest.CampaignIds, user, currentuser.ID);
                #endregion

                _dataContext.UserRole.Add(userrole);
                await _dataContext.SaveChangesAsync()
                    .ConfigureAwait(false);

                if (userrole == null)
                    throw new EntityNotCreatedException(MessagesConstants.ErrorCreatingUser);

                var result = _dataContext.User.Where(x=>x.ID==userrole.UserID).ToSingleUserViewModel();
                
                return new CreateUserResponse(result);
            }


            #region Private Method(s)
            private void CreateUserCampaign(long[] campaignIds, Domain.Entities.User user, long currentUserId)
            {
                if (campaignIds.Length > 0)
                {
                    List<UserCampaign> usercampaigns = new List<UserCampaign>();
                    foreach (var campaignId in campaignIds)
                    {
                        var campaign = _dataContext.Campaign.FirstOrDefault(x => x.ID == campaignId);
                        if (campaign != null)
                        {
                            UserCampaign uc = new UserCampaign
                            {
                                User = user,
                                Campaign = campaign,
                                CreatedByID = currentUserId,
                                DateCreated = DateTimeOffset.Now,
                                Active = true
                            };
                            usercampaigns.Add(uc);
                        }
                    }
                    if (usercampaigns.FirstOrDefault() != null)
                    {
                        _dataContext.UserCampaign.AddRange(usercampaigns);
                    }
                }
            }
            #endregion
        }
        #endregion

    }
}
