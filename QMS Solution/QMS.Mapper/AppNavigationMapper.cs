using AutoMapper;
using QMS.Domain.Entities;
using QMS.Domain.Models.AppNavigation;
using QMS.Domain.Models.Requests;
using QMS.Domain.Models.Responses.User;
using QMS.Domain.Models.User;
using System.Linq;

namespace QMS.Mapper
{
    #region Automapper

    /// <summary>
    /// Using Auto Mapper
    /// </summary>
    public class AppNavigationMapper : Profile
    {
        public AppNavigationMapper()
        {
            //create mapping
            CreateMap<AppNavigation, AppNavigationModel>()
              .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
              .ForMember(dest => dest.IsInitialPage, opt => opt.MapFrom(src => src.IsInitialPage))
              .ForMember(dest => dest.IsMainModule, opt => opt.MapFrom(src => src.IsMainModule));
        }
    } 
    #endregion

    #region Manual Mapping
    /// <summary>
    /// Manual Mapping
    /// </summary>
    //public static class UserMappings
    //{
    //    public static UserViewModel ToSingleUserViewModel(this IQueryable<Domain.Entities.User> val)
    //    {
    //        UserViewModel model = new UserViewModel();
    //        if (val.Count() == 0)
    //            model = null;
    //        else
    //            model = val.ToUserViewModelQueryable().FirstOrDefault();

    //        return model;
    //    }

    //    public static IQueryable<UserViewModel> ToUserViewModelQueryable(this IQueryable<Domain.Entities.User> val)
    //    {
    //        IQueryable<UserViewModel> model = null;
    //        if (val.Count() == 0)
    //            model = null;
    //        else
    //        {
    //            model = val.Select(x => new UserViewModel
    //            {
    //                ID = x.ID,
    //                Key = x.Key,
    //                Username = x.Username,
    //                Password = x.Password,
    //                Email = x.Email,
    //                FirstName = x.FirstName,
    //                LastName = x.LastName,
    //                MiddleName = x.MiddleName,
    //                Active = x.Active,
    //                Roles = x.UserRoles.Select(ur => new RoleViewModel
    //                {
    //                    ID = ur.RoleID,
    //                    Key = ur.Role.Key,
    //                    Name = ur.Role.Name,
    //                    Active = ur.Role.Active
    //                }).ToList()
    //            });
    //        }
    //        return model;
    //    }

    //    public static UserViewModel ToSingleUserViewModel(this Domain.Entities.User val)
    //    {
    //        UserViewModel model = new UserViewModel();
    //        if (val == null)
    //            model = null;
    //        else
    //        {
    //            model = new UserViewModel
    //            {
    //                ID = val.ID,
    //                Key = val.Key,
    //                Username = val.Username,
    //                Password = val.Password,
    //                Email = val.Email,
    //                FirstName = val.FirstName,
    //                LastName = val.LastName,
    //                MiddleName = val.MiddleName,
    //                Active = val.Active,
    //                Roles = val.UserRoles?.Select(ur => new RoleViewModel
    //                {
    //                    ID = ur.RoleID,
    //                    Key = ur.Role.Key,
    //                    Name = ur.Role.Name,
    //                    Active = ur.Role.Active
    //                }).ToList() ?? null
    //            };
    //        }
    //        return model;
    //    } 


    //}
    #endregion
}
