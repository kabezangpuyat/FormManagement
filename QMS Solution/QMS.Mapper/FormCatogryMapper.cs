using AutoMapper;
using QMS.Domain.Entities;
using QMS.Domain.Models.Form;
using QMS.Domain.Models.Requests;
using QMS.Domain.Models.Responses.User;
using QMS.Domain.Models.User;
using System.Linq;

namespace QMS.Mapper
{
    /// <summary>
    /// Using Auto Mapper
    /// </summary>
    public class FormCatogryMapper : Profile
    {
        public FormCatogryMapper()
        {

            CreateMap<FormCategory, FormCategoryViewModel>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
                .ForMember(dest => dest.CreatedByID, opt => opt.MapFrom(src => src.CreatedByID));
        }
    }

    ///// <summary>
    ///// Manual Mapping
    ///// </summary>
    //public static class FormMappings
    //{
    //    #region Map through Form
    //    public static FormViewModel ToSingleFormViewModel(this IQueryable<Domain.Entities.Form> val)
    //    {
    //        FormViewModel model = new FormViewModel();
    //        if (val.Count() == 0)
    //            model = null;
    //        else
    //            model = val.ToFormViewModelQueryable().FirstOrDefault();

    //        return model;
    //    }

    //    public static IQueryable<FormViewModel> ToFormViewModelQueryable(this IQueryable<Domain.Entities.Form> val)
    //    {
    //        IQueryable<FormViewModel> model = null;
    //        if (val.Count() == 0)
    //            model = null;
    //        else
    //        {
    //            model = val.Select(x => new FormViewModel
    //            {
    //                ID = x.ID,
    //                Key = x.Key,
    //                IsNoteVisible = x.IsNoteVisible,
    //                Name = x.Name,
    //                Category = new FormCategoryViewModel
    //                {
    //                    ID = x.FormCategoryID,
    //                    Name = x.FormCategory.Name,
    //                    Active = x.FormCategory.Active,
    //                    CreatedByID = x.FormCategory.CreatedByID
    //                },
    //                FormType = new FormTypeViewModel
    //                {
    //                    ID = x.FormTypeID,
    //                    Name = x.FormType.Name,
    //                    Active = x.FormType.Active,
    //                    CreatedByID = x.FormType.CreatedByID
    //                },
    //                Active = x.Active,
    //                CreatedByID = x.CreatedByID,
    //                Questions = x.FormQuestions.Where(q => q.FormID == x.ID && q.Active).Select(q => new FormQuestionViewModel
    //                {
    //                    ID = q.ID,
    //                    Name = q.Name,
    //                    Active = q.Active,
    //                    SortOrder = q.SortOrder,
    //                    CreatedByID = q.CreatedByID ?? 0,
    //                    HtmlControlID = q.HtmlControlID,
    //                    IsNoteVisible = q.IsNoteVisible,
    //                    HtmlControl = new HtmlControlViewModel
    //                    {
    //                        ID = q.HtmlControlID,
    //                        Name = q.HtmlControl.Name,
    //                        Active = q.HtmlControl.Active,
    //                        CreatedByID = q.HtmlControl.CreatedByID
    //                    },
    //                    Choices = q.FormQuestionChoices.Where(c => c.QuestionID == q.ID &&  c.Active).Select(c => new FormChoiceViewModel
    //                    {
    //                        ID = c.ChoiceID,
    //                        Name = c.FormChoice.Name,
    //                        Value = c.FormChoice.Value,
    //                        SortOrder = c.FormChoice.SortOrder,
    //                        Active = c.FormChoice.Active,
    //                        CreatedByID = c.FormChoice.CreatedByID
    //                    }).OrderBy(c=>c.SortOrder).ToList() ?? null
    //                }).OrderBy(q=>q.SortOrder).ToList() ?? null
    //            });
    //        }
    //        return model;
    //    }

    //    public static FormViewModel ToSingleFormViewModel(this Domain.Entities.Form val)
    //    {
    //        FormViewModel model = new FormViewModel();
    //        if (val == null)
    //            model = null;
    //        else
    //        {
    //            model = new FormViewModel
    //            {
    //                ID = val.ID,
    //                Key = val.Key,
    //                IsNoteVisible = val.IsNoteVisible,
    //                Name = val.Name,
    //                Category = new FormCategoryViewModel
    //                {
    //                    ID = val.FormCategoryID,
    //                    Name = val.FormCategory.Name,
    //                    Active = val.FormCategory.Active,
    //                    CreatedByID = val.FormCategory.CreatedByID
    //                },
    //                FormType = new FormTypeViewModel
    //                {
    //                    ID = val.FormTypeID,
    //                    Name = val.FormType.Name,
    //                    Active = val.FormType.Active,
    //                    CreatedByID = val.FormType.CreatedByID
    //                },
    //                Active = val.Active,
    //                CreatedByID = val.CreatedByID ?? 0,
    //                Questions = val.FormQuestions.Where(q => q.FormID == val.ID && q.Active).Count() == 0 ? null : val.FormQuestions.Where(q => q.FormID == val.ID && q.Active).Select(q => new FormQuestionViewModel
    //                {
    //                    ID = q.ID,
    //                    Name = q.Name,
    //                    Active = q.Active,
    //                    SortOrder = q.SortOrder,
    //                    CreatedByID = q.CreatedByID ?? 0,
    //                    HtmlControlID = q.HtmlControlID,
    //                    IsNoteVisible = q.IsNoteVisible,
    //                    HtmlControl = new HtmlControlViewModel
    //                    {
    //                        ID = q.HtmlControlID,
    //                        Name = q.HtmlControl.Name,
    //                        Active = q.HtmlControl.Active,
    //                        CreatedByID = q.HtmlControl.CreatedByID
    //                    },
    //                    Choices = q.FormQuestionChoices.Where(c => c.QuestionID == q.ID && c.Active).Count() == 0 ? null : q.FormQuestionChoices.Where(c => c.QuestionID == q.ID && c.Active).Select(c => new FormChoiceViewModel
    //                    {
    //                        ID = c.ChoiceID,
    //                        Name = c.FormChoice.Name,
    //                        Value = c.FormChoice.Value,
    //                        SortOrder = c.FormChoice.SortOrder,
    //                        Active = c.FormChoice.Active,
    //                        CreatedByID = c.FormChoice.CreatedByID
    //                    }).OrderBy(c=>c.SortOrder).ToList()
    //                }).OrderBy(q=>q.SortOrder).ToList()
    //            };
    //        }
    //        return model;
    //    }
    //    #endregion

    //    //#region Map Through QuestionChoice
    //    //public static IQueryable<FormViewModel> ToFormViewModelQueryable(this IQueryable<Domain.Entities.FormQuestionChoice> val)
    //    //{
    //    //    IQueryable<FormViewModel> model = null;
    //    //    if (val.Count() == 0)
    //    //        model = null;
    //    //    else
    //    //    {
    //    //        model = val.Select(x=>x.FormQuestion.Form())
                    
    //    //        val.Select(x => new FormViewModel
    //    //        {
    //    //            ID = x.ID,
    //    //            Key = x.Key,
    //    //            IsNoteVisible = x.IsNoteVisible,
    //    //            Name = x.Name,
    //    //            Category = x.FormCategoryID == null ? null : new FormCategoryViewModel
    //    //            {
    //    //                ID = x.FormCategoryID,
    //    //                Name = x.FormCategory.Name,
    //    //                Active = x.FormCategory.Active,
    //    //                CreatedByID = x.FormCategory.CreatedByID
    //    //            },
    //    //            FormType = x.FormTypeID == null ? null : new FormTypeViewModel
    //    //            {
    //    //                ID = x.FormTypeID,
    //    //                Name = x.FormType.Name,
    //    //                Active = x.FormType.Active,
    //    //                CreatedByID = x.FormType.CreatedByID
    //    //            },
    //    //            Active = x.Active,
    //    //            CreatedByID = x.CreatedByID,
    //    //            Questions = x.FormQuestions.Count() == 0 ? null : x.FormQuestions.Where(q => q.Active).Select(q => new FormQuestionViewModel
    //    //            {
    //    //                ID = q.ID,
    //    //                Name = q.Name,
    //    //                Active = q.Active,
    //    //                SortOrder = q.SortOrder,
    //    //                CreatedByID = q.CreatedByID ?? 0,
    //    //                HtmlControlID = q.HtmlControlID ?? 0,
    //    //                IsNoteVisible = q.IsNoteVisible,
    //    //                HtmlControl = q.HtmlControlID == null ? null : new HtmlControlViewModel
    //    //                {
    //    //                    ID = q.HtmlControlID,
    //    //                    Name = q.HtmlControl.Name,
    //    //                    Active = q.HtmlControl.Active,
    //    //                    CreatedByID = q.HtmlControl.CreatedByID
    //    //                },
    //    //                Choices = q.FormQuestionChoices.Count() == 0 ? null : q.FormQuestionChoices.Where(c => c.Active).Select(c => new FormChoiceViewModel
    //    //                {
    //    //                    ID = c.ChoiceID,
    //    //                    Name = c.FormChoice.Name,
    //    //                    Value = c.FormChoice.Value,
    //    //                    SortOrder = c.FormChoice.SortOrder,
    //    //                    Active = c.FormChoice.Active,
    //    //                    CreatedByID = c.FormChoice.CreatedByID
    //    //                }).ToList()
    //    //            }).ToList()
    //    //        });
    //    //    }
    //    //    return model;
    //    //}
    //    //#endregion
    //}
}
