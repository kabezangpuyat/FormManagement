using AutoMapper;
using QMS.Domain.Entities;
using QMS.Domain.Models.Role;
using QMS.Domain.Models.User;
using System.Linq;

namespace QMS.Mapper
{
    /// <summary>
    /// Using Auto Mapper
    /// </summary>
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<Role, RoleViewModel>()
              .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.CreatedByID, opt => opt.MapFrom(src => src.CreatedByID))
              .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));
        }
    }

    /// <summary>
    /// Manual Mapping
    /// </summary>
    public static class RoleMappings
    {
        public static RoleViewModel ToSingleUserViewModel(this IQueryable<Domain.Entities.Role> val)
        {
            RoleViewModel model = new RoleViewModel();
            if (val.Count() == 0)
                model = null;
            else
                model = val.ToRoleViewModelQueryable().FirstOrDefault();

            return model;
        }

        public static IQueryable<RoleViewModel> ToRoleViewModelQueryable(this IQueryable<Domain.Entities.Role> val)
        {
            IQueryable<RoleViewModel> model = null;
            if (val.Count() == 0)
                model = null;
            else
            {
                model = val.Select(x => new RoleViewModel
                {
                    ID = x.ID,
                    Name = x.Name,
                    CreatedByID = x.CreatedByID,
                    Active = x.Active
                });                
            }
            return model;
        }

        public static RoleViewModel ToSingleRoleViewModel(this Domain.Entities.Role val)
        {
            RoleViewModel model = new RoleViewModel();
            if (val == null)
                model = null;
            else
            {
                model =  new RoleViewModel
                {
                    ID = val.ID,
                    Name = val.Name,
                    CreatedByID = val.CreatedByID,
                    Active = val.Active
                };
            }
            return model;
        }
    }
}
