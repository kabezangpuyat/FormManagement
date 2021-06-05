using AutoMapper;
using QMS.Domain.Entities;
using QMS.Domain.Models.Audit;
using QMS.Domain.Models.Campaign;
using QMS.Domain.Models.Form;
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
    public class AuditMapper : Profile
    {
        public AuditMapper()
        {
            //CreateMap<CreateUserWithRoleRequest, User>()
            //  .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true))
            //  .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            //  .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            //  .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //  .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            //  .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName));
        }
    }

    /// <summary>
    /// Manual Mapping
    /// </summary>
    public static class AuditMappings
    {
        public static AuditViewModel ToSingleAuditViewModel(this IQueryable<Domain.Entities.Audit> val)
        {
            AuditViewModel model = new AuditViewModel();
            if (val.Count() == 0)
                model = null;
            else
                model = val.ToAuditViewModelQueryable().FirstOrDefault();

            return model;
        }

        public static IQueryable<AuditViewModel> ToAuditViewModelQueryable(this IQueryable<Domain.Entities.Audit> val)
        {
            IQueryable<AuditViewModel> model = null;
            if (val.Count() == 0)
                model = null;
            else
            {
                model = val.Select(x => new AuditViewModel
                {
                    ID = x.ID,
                    Name = x.Name,
                    Teammate = x.Teammate.ToSingleUserViewModel(),
                    AuditedBy = x.CreatedBy.ToSingleAuditViewModel(),
                    Active = x.Active,
                    Notes = x.FormNotes,
                    CreatedByID = x.CreatedByID,
                    DateCreated = x.DateCreated,
                    #region Form
                    Form = new FormViewModel
                    {
                        ID = x.FormID,
                        Key = x.Form.Key,
                        IsNoteVisible = x.Form.IsNoteVisible,
                        Name = x.Form.Name,
                        CreatedByID = x.Form.CreatedByID,
                        Active = x.Form.Active,
                        FormType = new FormTypeViewModel
                        {
                            ID = x.Form.FormTypeID,                            
                            Name = x.Form.FormType.Name,
                            CreatedByID = x.Form.FormType.CreatedByID,
                            Active = x.Form.FormType.Active
                        },
                        Category = new FormCategoryViewModel
                        {
                            ID = x.Form.FormCategoryID,
                            Name = x.Form.FormCategory.Name,
                            CreatedByID = x.Form.FormCategory.CreatedByID,
                            Active = x.Form.FormCategory.Active
                        }
                    }
                    #endregion
                    #region Details
                    ,
                    Details = x.AuditDetails.Select(ad => new AuditDetailViewModels
                    {
                        ID = ad.ID,
                        AuditID = ad.AuditID,
                        QuestionId = ad.QuestionID,
                        ChoiceId = ad.ChoiceID,
                        Notes = ad.QuestionNotes,
                        CreatedByID = ad.CreatedByID,
                        Active = ad.Active,
                        Question = ad.QuestionID == null ? null : new FormQuestionViewModel
                        {
                            ID = ad.FormQuestion.ID,
                            Name = ad.FormQuestion.Name,
                            Active = ad.FormQuestion.Active,
                            HtmlControl =  new HtmlControlViewModel
                            {
                                ID = ad.FormQuestion.HtmlControl.ID,
                                Name = ad.FormQuestion.HtmlControl.Name
                            },
                            SortOrder = ad.FormQuestion.SortOrder,
                            CreatedByID = ad.FormQuestion.CreatedByID
                        },
                        Choice = ad.ChoiceID == null ? null : new FormChoiceViewModel
                        {
                            ID = ad.FormChoice.ID,
                            Name = ad.FormChoice.Name,
                            Value = ad.FormChoice.Value,
                            Active = ad.FormChoice.Active,
                            CreatedByID = ad.FormChoice.CreatedByID,
                            SortOrder = ad.FormChoice.SortOrder
                        }
                    }).OrderBy(ad=>ad.ID)
                    .ToList()
                    #endregion
                });
            }
            return model;
        }

        public static UserViewModel ToSingleAuditViewModel(this Domain.Entities.User val)
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
