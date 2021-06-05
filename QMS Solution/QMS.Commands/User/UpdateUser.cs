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
    public static class UpdateUser
    {
        #region Command
        public class Command : ICommand
        {
            public UpdateUserRequest UpdateUserRequest { get; set; }
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
                using(var transaction = _dataContext.Database.BeginTransaction())
                {
                    try
                    {
                        var currentuser = _currentUserProvider.GetCurrentUser();
                        //update userrole
                        this.UpdateUserRole(request.UpdateUserRequest, currentuser.ID);
                        //update usercampaign
                        this.UpdateUserCampaign(request.UpdateUserRequest, currentuser.ID);

                        #region Update User
                        var user = _dataContext.User.FirstOrDefault(x => x.ID == request.UpdateUserRequest.ID);
                        bool isUpdateUser = false;
                        if(user.Username.ToLower() != request.UpdateUserRequest.Username.ToLower())
                        {
                            user.Username = request.UpdateUserRequest.Username;
                            isUpdateUser = true;
                        }
                        if (user.Email.ToLower() != request.UpdateUserRequest.Email.ToLower())
                        {
                            user.Email = request.UpdateUserRequest.Email;
                            isUpdateUser = true;
                        }
                        if (user.FirstName.ToLower() != request.UpdateUserRequest.FirstName.ToLower())
                        {
                            user.FirstName = request.UpdateUserRequest.FirstName;
                            isUpdateUser = true;
                        }
                        if (user.LastName.ToLower() != request.UpdateUserRequest.LastName.ToLower())
                        {
                            user.LastName = request.UpdateUserRequest.LastName;
                            isUpdateUser = true;
                        }

                        if (isUpdateUser)
                        {
                            user.DateModified = DateTimeOffset.Now;
                            user.CreatedByID = currentuser.ID;
                            _dataContext.User.Update(user);
                        }
                        #endregion

                        await _dataContext.SaveChangesAsync();

                        transaction.Commit();
                    }
                    catch(Exception)
                    {
                        transaction.Rollback();
                    }
                }
                var result = _dataContext.User.Where(x => x.ID == request.UpdateUserRequest.ID).ToSingleUserViewModel();

                return new UpdateUserResponse(result);
            }


            #region Private Method(s)
            private void UpdateUserRole(UpdateUserRequest request, long currentUserId)
            {
                var userrole = _dataContext.UserRole.FirstOrDefault(x => x.Active && x.UserID == request.ID);
                if (userrole != null)
                {
                    if (userrole.RoleID != request.RoleId)
                    {
                        userrole.RoleID = request.RoleId;
                        userrole.ModifiedByID = currentUserId;
                        userrole.DateModified = DateTimeOffset.Now;

                        _dataContext.UserRole.Update(userrole);
                    }
                }
                else
                {
                    userrole = new UserRole
                    {
                        UserID = request.ID,
                        RoleID = request.RoleId,
                        CreatedByID = currentUserId,
                        Active = true,
                        DateCreated = DateTimeOffset.Now
                    };
                    _dataContext.UserRole.Add(userrole);
                }
            }
            private void UpdateUserCampaign(UpdateUserRequest request, long currentUserId)
            {
                if (request.CampaignIds.Length > 0)
                {
                    List<UserCampaign> ucs = new List<UserCampaign>();
                    List<UserCampaign> ucsupdate = new List<UserCampaign>();
                    //get uc count
                    var usercampaigns = _dataContext.UserCampaign.Where(x => x.UserID == request.ID);
                    foreach (var uc in usercampaigns)
                    {
                        uc.Active = false;
                        uc.DateModified = DateTimeOffset.Now;
                        uc.ModifiedByID = currentUserId;
                    }

                    if (usercampaigns.Count() > 0)
                        _dataContext.UserCampaign.UpdateRange(usercampaigns);

                    foreach (var campaignId in request.CampaignIds)
                    {
                        var usercampaign = _dataContext.UserCampaign.FirstOrDefault(x => x.UserID == request.ID && x.CampaignID == campaignId);
                        if (usercampaign == null)
                        {
                            var uc = new UserCampaign
                            {
                                UserID = request.ID,
                                CampaignID = campaignId,
                                DateCreated = DateTimeOffset.Now,
                                CreatedByID = currentUserId,
                                Active = true
                            };
                            ucs.Add(uc);
                        }
                        else
                        {
                            usercampaign.Active = true;
                            usercampaign.DateModified = DateTimeOffset.Now;
                            usercampaign.ModifiedByID = currentUserId;
                            ucsupdate.Add(usercampaign);
                        }

                    }
                    if (ucs.FirstOrDefault() != null)
                        _dataContext.UserCampaign.AddRange(ucs);
                    if (ucsupdate.FirstOrDefault() != null)
                        _dataContext.UserCampaign.UpdateRange(ucsupdate);
                }
            }
            #endregion
        }
        #endregion

    }
}
