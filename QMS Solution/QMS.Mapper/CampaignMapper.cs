using AutoMapper;
using QMS.Domain.Entities;
using QMS.Domain.Models.Campaign;
using QMS.Domain.Models.Requests;
using QMS.Domain.Models.Responses.Campaign;
using QMS.Domain.Models.Responses.User;
using QMS.Domain.Models.Role;
using QMS.Domain.Models.User;
using System;
using System.Linq;

namespace QMS.Mapper
{
    /// <summary>
    /// Using Auto Mapper
    /// </summary>
    public class CampaignMapper : Profile
    {
        public CampaignMapper()
        {
            //create mapping
            CreateMap<CreateCampaignRequest, Campaign>()
              .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.EpmsCampaignID, opt => opt.MapFrom(src => src.EpmsCampaignID))
              .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTimeOffset.Now));


            CreateMap<CampaignViewModel, Campaign>()
               .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true))
               .ForMember(dest => dest.EpmsCampaignID, opt => opt.MapFrom(src => src.EpmsID))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.CreatedByID, opt => opt.MapFrom(src => src.CreatedByID))
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID));

            CreateMap<Campaign, CampaignViewModel>()
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
               .ForMember(dest => dest.EpmsID, opt => opt.MapFrom(src => src.EpmsCampaignID))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.CreatedByID, opt => opt.MapFrom(src => src.CreatedByID))
               .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));

            CreateMap<GetCampaignByIdResponse, Campaign>()
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Campaign.ID))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Campaign.Name))
               .ForMember(dest => dest.EpmsCampaignID, opt => opt.MapFrom(src => src.Campaign.EpmsID))
               .ForMember(dest => dest.CreatedByID, opt => opt.MapFrom(src => src.Campaign.CreatedByID))
               .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Campaign.Active));
        }
    }

    /// <summary>
    /// Manual Mapping
    /// </summary>
    public static class CampaignMappings
    {
        public static CampaignViewModel ToSingleCampaignViewModel(this IQueryable<Domain.Entities.Campaign> val)
        {
            CampaignViewModel model = new CampaignViewModel();
            if (val.Count() == 0)
                model = null;
            else
                model = val.ToCampaignViewModelQueryable().FirstOrDefault();

            return model;
        }

        public static IQueryable<CampaignViewModel> ToCampaignViewModelQueryable(this IQueryable<Domain.Entities.Campaign> val)
        {
            IQueryable<CampaignViewModel> model = null;
            if (val.Count() == 0)
                model = null;
            else
            {
                model = val.Select(x => new CampaignViewModel
                {
                    ID = x.ID,
                    EpmsID = x.EpmsCampaignID,
                    Active = x.Active,
                    CreatedByID = x.CreatedByID,
                    Name = x.Name
                });                
            }
            return model;
        }

        public static CampaignViewModel ToSingleCampaignViewModel(this Domain.Entities.Campaign val)
        {
            CampaignViewModel model = new CampaignViewModel();
            if (val == null)
                model = null;
            else
            {
                model =  new CampaignViewModel
                {
                    ID = val.ID,
                    EpmsID = val.EpmsCampaignID,
                    Active = val.Active,
                    CreatedByID = val.CreatedByID,
                    Name = val.Name
                };
            }
            return model;
        }
    }
}
