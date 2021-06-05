using AutoMapper;
using QMS.Domain.Entities;
using QMS.Domain.Models.Campaign;
using QMS.Domain.Models.Requests;
using QMS.Domain.Models.Responses.User;
using QMS.Domain.Models.Role;
using QMS.Domain.Models.User;
using System.Linq;

namespace QMS.Mapper
{
    /// <summary>
    /// Using Auto Mapper
    /// </summary>
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            //create mapping
            //CreateUserRequest
            CreateMap<CreateUserRequest, User>()
              //.ForMember(dest => dest.Key, opt => opt.MapFrom(src => Guid.NewGuid()))
              .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true))
              //.ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTimeOffset.Now))
              .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
              .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
              .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
              .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName));

            CreateMap<CreateUserWithRoleRequest, User>()
              .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true))
              .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
              .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
              .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName));

            CreateMap<UserViewModel, User>()
               //.ForMember(dest => dest.Key, opt => opt.MapFrom(src => Guid.NewGuid()))
               .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true))
               //.ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTimeOffset.Now))
               .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName));

            CreateMap<User, UserViewModel>()
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
               .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

            CreateMap<GetUserByIdResponse, User>()
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.User.ID))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.User.Password))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
               .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.User.MiddleName))
               .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.User.Username));
        }
    }

    /// <summary>
    /// Manual Mapping
    /// </summary>
    public static class UserMappings
    {
        public static UserViewModel ToSingleUserViewModel(this IQueryable<Domain.Entities.User> val)
        {
            UserViewModel model = new UserViewModel();
            if (val.Count() == 0)
                model = null;
            else
                model = val.ToUserViewModelQueryable().FirstOrDefault();

            return model;
        }

        public static IQueryable<UserViewModel> ToUserViewModelQueryable(this IQueryable<Domain.Entities.User> val)
        {
            IQueryable<UserViewModel> model = null;
            if (val.Count() == 0)
                model = null;
            else
            {
                model = val.Select(x => new UserViewModel
                {
                    ID = x.ID,
                    Key = x.Key,
                    Username = x.Username,
                    Password = x.Password,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    MiddleName = x.MiddleName,
                    Active = x.Active,
                    CreatedByID = x.CreatedByID,
                    Name = $"{x.LastName}, {x.FirstName}",
                    Roles = x.UserRoles.Where(ur=>ur.Active && ur.UserID == x.ID).Select(ur => new RoleViewModel
                    {
                        ID = ur.RoleID,
                        Name = ur.Role.Name,
                        Active = ur.Role.Active,
                        CreatedByID = ur.Role.CreatedByID
                    }).ToList(),
                    Campaigns = x.UserCampaigns.Count() == 0 ? null : x.UserCampaigns.Where(uc=> uc.Active ).Select(uc=> new CampaignViewModel
                    {
                        ID = (long)uc.CampaignID,
                        Active = uc.Campaign.Active,
                        Name = uc.Campaign.Name,
                        CreatedByID = uc.Campaign.CreatedByID ?? 0,
                        EpmsID = uc.Campaign.EpmsCampaignID
                    }).ToList()
                });                
            }
            return model;
        }

        public static UserViewModel ToSingleUserViewModel(this Domain.Entities.User val)
        {
            UserViewModel model = new UserViewModel();
            if (val == null)
                model = null;
            else
            {
                model =  new UserViewModel
                {
                    ID = val.ID,
                    Key = val.Key,
                    Username = val.Username,
                    Password = val.Password,
                    Email = val.Email,
                    FirstName = val.FirstName,
                    LastName = val.LastName,
                    MiddleName = val.MiddleName,
                    Active = val.Active,
                    CreatedByID = val.CreatedByID,
                    Name = $"{val.LastName}, {val.FirstName}",
                    Roles = val.UserRoles?.Where(ur=>ur.UserID==val.ID && ur.Active).Select(ur => new RoleViewModel
                    {
                        ID = ur.RoleID,
                        Name = ur.Role.Name,
                        Active = ur.Role.Active,
                        CreatedByID = ur.Role.CreatedByID
                    }).ToList() ?? null,
                    Campaigns = val.UserCampaigns?.Where(uc=>uc.Active).Select(uc=> new CampaignViewModel { 
                        ID = (long)uc.CampaignID,
                        Name = uc.Campaign.Name,
                        Active = uc.Campaign.Active,
                        CreatedByID = uc.Campaign.CreatedByID ?? 0,
                        EpmsID = uc.Campaign.EpmsCampaignID
                    }).ToList() ?? null
                };
            }
            return model;
        }
    }
}
