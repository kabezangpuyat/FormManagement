using AutoMapper;
using QMS.Domain.Constants;
using QMS.Domain.Entities;
using QMS.Domain.Models.Form;
using QMS.Domain.Models.Requests;
using QMS.Domain.Models.Responses.User;
using QMS.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QMS.Mapper
{
    /// <summary>
    /// Using Auto Mapper
    /// </summary>
    public class FormMapper : Profile
    {
        public static long CreatedById { get; set; }
        public static long FormTypeId { get; set; }
        //public static Form FormData { get; set; }
        public FormMapper()
        {
            //form question mapper
            CreateMap<CreateTFYNNARequestModel, FormQuestion>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Formquestion))
                .ForMember(dest => dest.HtmlControlID, opt => opt.MapFrom(src => src.Htmlcontrolid))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.IsNoteVisible, opt => opt.MapFrom(src => src.Htmlcontrolid == 3 ? true : false))//3 is textbox
                .ForMember(dest => dest.CreatedByID, opt => opt.MapFrom(src => CreatedById))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTimeOffset.Now));

            //Forms
            CreateMap<FormDetailRequest, Form>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FormName))
                 .ForMember(dest => dest.FormCategoryID, opt => opt.MapFrom(src => src.CategoryId))
                 //.ForMember(dest => dest.FormQuestions, opt => opt.MapFrom(src => Questions))
                 .ForMember(dest => dest.FormTypeID, opt => opt.MapFrom(src => FormTypeId))
                 .ForMember(dest => dest.IsNoteVisible, opt => opt.MapFrom(src => true))
                 .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTimeOffset.Now))
                 .ForMember(dest => dest.CreatedByID, opt => opt.MapFrom(src => CreatedById))
                 .ForMember(dest => dest.Key, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<Form, FormViewModel>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.IsNoteVisible, opt => opt.MapFrom(src => src.IsNoteVisible))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
                .ForMember(dest => dest.CreatedByID, opt => opt.MapFrom(src => src.CreatedByID))
                .ForMember(dest => dest.Category, opt => opt.Condition(src => src.FormCategory.Active))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new FormCategoryViewModel
                {
                    ID = src.FormCategoryID,
                    Name = src.FormCategory.Name,
                    Active = src.FormCategory.Active,
                    CreatedByID = src.FormCategory.CreatedByID
                }))
                .ForMember(dest => dest.FormType, opt => opt.Condition(src => src.FormType.Active))
                .ForMember(dest => dest.FormType, opt => opt.MapFrom(src => new FormTypeViewModel
                {
                    ID = src.FormTypeID,
                    Name = src.FormType.Name,
                    Active = src.FormType.Active,
                    CreatedByID = src.FormType.CreatedByID
                }))
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.FormQuestions.Where(q => q.FormID == src.ID && q.Active).Count()==0 ? null : src.FormQuestions.Where(q=> q.FormID == src.ID && q.Active).Select(q=> new FormQuestionViewModel { 
                    ID = q.ID,
                    Name = q.Name,
                    HtmlControlID = q.HtmlControlID,
                    IsNoteVisible = q.IsNoteVisible,
                    SortOrder = q.SortOrder,
                    Active = q.Active,
                    CreatedByID = q.CreatedByID ?? 0,
                    HtmlControl = new HtmlControlViewModel
                    {
                        ID = q.HtmlControlID,
                        Name = q.HtmlControl.Name,
                        Active = q.HtmlControl.Active,
                        CreatedByID = q.HtmlControl.CreatedByID ?? 0
                    },
                    Choices = q.FormQuestionChoices.Where(c => c.QuestionID == q.ID && c.Active).Count() == 0 ? null : q.FormQuestionChoices.Where(c => c.QuestionID == q.ID && c.Active).Select(c => new FormChoiceViewModel
                    {
                        ID = c.ChoiceID,
                        Name = c.FormChoice.Name,
                        Value = c.FormChoice.Value,
                        SortOrder = c.FormChoice.SortOrder,
                        Active = c.FormChoice.Active,
                        CreatedByID = c.FormChoice.CreatedByID
                    }).ToList()
                }).ToList()));
        }
    }

    /// <summary>
    /// Manual Mapping
    /// </summary>
    public static class FormMappings
    {
        #region Map through Form
        public static FormViewModel ToSingleFormViewModel(this IQueryable<Domain.Entities.Form> val)
        {
            FormViewModel model = new FormViewModel();
            if (val.Count() == 0)
                model = null;
            else
                model = val.ToFormViewModelQueryable().FirstOrDefault();

            return model;
        }

        public static IQueryable<FormViewModel> ToFormViewModelQueryable(this IQueryable<Domain.Entities.Form> val)
        {
            IQueryable<FormViewModel> model = null;
            if (val.Count() == 0)
                model = null;
            else
            {
                model = val.Select(x => new FormViewModel
                {
                    ID = x.ID,
                    Key = x.Key,
                    IsNoteVisible = x.IsNoteVisible,
                    Name = x.Name,
                    Category = new FormCategoryViewModel
                    {
                        ID = x.FormCategoryID,
                        Name = x.FormCategory.Name,
                        Active = x.FormCategory.Active,
                        CreatedByID = x.FormCategory.CreatedByID
                    },
                    FormType = new FormTypeViewModel
                    {
                        ID = x.FormTypeID,
                        Name = x.FormType.Name,
                        Active = x.FormType.Active,
                        CreatedByID = x.FormType.CreatedByID
                    },
                    Active = x.Active,
                    CreatedByID = x.CreatedByID,
                    Questions = x.FormQuestions.Where(q => q.FormID == x.ID && q.Active).Select(q => new FormQuestionViewModel
                    {
                        ID = q.ID,
                        Name = q.Name,
                        Active = q.Active,
                        SortOrder = q.SortOrder,
                        CreatedByID = q.CreatedByID ?? 0,
                        HtmlControlID = q.HtmlControlID,
                        IsNoteVisible = q.IsNoteVisible,
                        HtmlControl = new HtmlControlViewModel
                        {
                            ID = q.HtmlControlID,
                            Name = q.HtmlControl.Name,
                            Active = q.HtmlControl.Active,
                            CreatedByID = q.HtmlControl.CreatedByID
                        },
                        Choices = q.FormQuestionChoices.Where(c => c.QuestionID == q.ID &&  c.Active).Select(c => new FormChoiceViewModel
                        {
                            ID = c.ChoiceID,
                            Name = c.FormChoice.Name,
                            Value = c.FormChoice.Value,
                            SortOrder = c.FormChoice.SortOrder,
                            Active = c.FormChoice.Active,
                            CreatedByID = c.FormChoice.CreatedByID
                        }).OrderBy(c=>c.SortOrder).ToList() ?? null
                    }).OrderBy(q=>q.SortOrder).ToList() ?? null
                });
            }
            return model;
        }

        public static FormViewModel ToSingleFormViewModel(this Domain.Entities.Form val)
        {
            FormViewModel model = new FormViewModel();
            if (val == null)
                model = null;
            else
            {
                model = new FormViewModel
                {
                    ID = val.ID,
                    Key = val.Key,
                    IsNoteVisible = val.IsNoteVisible,
                    Name = val.Name,
                    Category = new FormCategoryViewModel
                    {
                        ID = val.FormCategoryID,
                        Name = val.FormCategory.Name,
                        Active = val.FormCategory.Active,
                        CreatedByID = val.FormCategory.CreatedByID
                    },
                    FormType = new FormTypeViewModel
                    {
                        ID = val.FormTypeID,
                        Name = val.FormType.Name,
                        Active = val.FormType.Active,
                        CreatedByID = val.FormType.CreatedByID
                    },
                    Active = val.Active,
                    CreatedByID = val.CreatedByID ?? 0,
                    Questions = val.FormQuestions.Where(q => q.FormID == val.ID && q.Active).Count() == 0 ? null : val.FormQuestions.Where(q => q.FormID == val.ID && q.Active).Select(q => new FormQuestionViewModel
                    {
                        ID = q.ID,
                        Name = q.Name,
                        Active = q.Active,
                        SortOrder = q.SortOrder,
                        CreatedByID = q.CreatedByID ?? 0,
                        HtmlControlID = q.HtmlControlID,
                        IsNoteVisible = q.IsNoteVisible,
                        HtmlControl = new HtmlControlViewModel
                        {
                            ID = q.HtmlControlID,
                            Name = q.HtmlControl.Name,
                            Active = q.HtmlControl.Active,
                            CreatedByID = q.HtmlControl.CreatedByID
                        },
                        Choices = q.FormQuestionChoices.Where(c => c.QuestionID == q.ID && c.Active).Count() == 0 ? null : q.FormQuestionChoices.Where(c => c.QuestionID == q.ID && c.Active).Select(c => new FormChoiceViewModel
                        {
                            ID = c.ChoiceID,
                            Name = c.FormChoice.Name,
                            Value = c.FormChoice.Value,
                            SortOrder = c.FormChoice.SortOrder,
                            Active = c.FormChoice.Active,
                            CreatedByID = c.FormChoice.CreatedByID
                        }).OrderBy(c=>c.SortOrder).ToList()
                    }).OrderBy(q=>q.SortOrder).ToList()
                };
            }
            return model;
        }
        #endregion

        #region Map FormQuestions
        public static long _formId { get; set; }
        public static long _currentUserId { get; set; }
        public static Form _formData { get; set; }
        public static DateTimeOffset _currentDate { get; set; }
        public static IQueryable<Domain.Entities.FormQuestion> ToFormQuestionsQueryable(this CreateTFYNNARequestModel[] val)
        {
            IQueryable<Domain.Entities.FormQuestion> data = null;
            if (val.Count() > 0)
                data = val.Select(x => new FormQuestion
                {
                    Form = _formData,
                    HtmlControlID = x.Htmlcontrolid,
                    Name = x.Formquestion,
                    IsNoteVisible = x.Htmlcontrolid == HtmlControlIdConstants.Textbox ? true : false,
                    Active = true,
                    CreatedByID = _currentUserId,
                    DateCreated = DateTimeOffset.Now
                }).AsQueryable();

            return data;
        }

        public static IQueryable<Domain.Entities.FormQuestion> ToUpdateFormQuestionsQueryable(this IEnumerable<UpdateQuestionDetail> val)
        {
            IQueryable<Domain.Entities.FormQuestion> data = null;
            if (val.Count() > 0)
                data = val.Select(x => new FormQuestion
                {
                    FormID = _formId,
                    HtmlControlID = x.HtmlControlID,
                    Name = x.Name,
                    IsNoteVisible = x.HtmlControlID == HtmlControlIdConstants.Textbox ? true : false,
                    Active = true,
                    CreatedByID = _currentUserId,
                    DateCreated = _currentDate
                }).AsQueryable();

            return data;
        }

        #endregion

        //#region Map Through QuestionChoice
        //public static IQueryable<FormViewModel> ToFormViewModelQueryable(this IQueryable<Domain.Entities.FormQuestionChoice> val)
        //{
        //    IQueryable<FormViewModel> model = null;
        //    if (val.Count() == 0)
        //        model = null;
        //    else
        //    {
        //        model = val.Select(x=>x.FormQuestion.Form())

        //        val.Select(x => new FormViewModel
        //        {
        //            ID = x.ID,
        //            Key = x.Key,
        //            IsNoteVisible = x.IsNoteVisible,
        //            Name = x.Name,
        //            Category = x.FormCategoryID == null ? null : new FormCategoryViewModel
        //            {
        //                ID = x.FormCategoryID,
        //                Name = x.FormCategory.Name,
        //                Active = x.FormCategory.Active,
        //                CreatedByID = x.FormCategory.CreatedByID
        //            },
        //            FormType = x.FormTypeID == null ? null : new FormTypeViewModel
        //            {
        //                ID = x.FormTypeID,
        //                Name = x.FormType.Name,
        //                Active = x.FormType.Active,
        //                CreatedByID = x.FormType.CreatedByID
        //            },
        //            Active = x.Active,
        //            CreatedByID = x.CreatedByID,
        //            Questions = x.FormQuestions.Count() == 0 ? null : x.FormQuestions.Where(q => q.Active).Select(q => new FormQuestionViewModel
        //            {
        //                ID = q.ID,
        //                Name = q.Name,
        //                Active = q.Active,
        //                SortOrder = q.SortOrder,
        //                CreatedByID = q.CreatedByID ?? 0,
        //                HtmlControlID = q.HtmlControlID ?? 0,
        //                IsNoteVisible = q.IsNoteVisible,
        //                HtmlControl = q.HtmlControlID == null ? null : new HtmlControlViewModel
        //                {
        //                    ID = q.HtmlControlID,
        //                    Name = q.HtmlControl.Name,
        //                    Active = q.HtmlControl.Active,
        //                    CreatedByID = q.HtmlControl.CreatedByID
        //                },
        //                Choices = q.FormQuestionChoices.Count() == 0 ? null : q.FormQuestionChoices.Where(c => c.Active).Select(c => new FormChoiceViewModel
        //                {
        //                    ID = c.ChoiceID,
        //                    Name = c.FormChoice.Name,
        //                    Value = c.FormChoice.Value,
        //                    SortOrder = c.FormChoice.SortOrder,
        //                    Active = c.FormChoice.Active,
        //                    CreatedByID = c.FormChoice.CreatedByID
        //                }).ToList()
        //            }).ToList()
        //        });
        //    }
        //    return model;
        //}
        //#endregion
    }
}
