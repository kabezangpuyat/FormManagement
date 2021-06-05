using Microsoft.EntityFrameworkCore;
using QMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Database
{
    public static class CreateInitialFormData
    {
        #region public Method(s)
        public static void SeedHtmlType(ModelBuilder builder)
        {
            builder.Entity<HtmlControl>()
                .HasData(
                    new HtmlControl { ID = 1, Name = "Option", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new HtmlControl { ID = 2, Name = "Dropdown", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new HtmlControl { ID = 3, Name = "Textbox", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new HtmlControl { ID = 4, Name = "Checkbox", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 }
                );
        }
        public static void SeedFormType(ModelBuilder builder)
        {
            builder.Entity<FormType>()
                .HasData(
                    new FormType { ID = 1, Name = "QA Form", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new FormType { ID = 2, Name = "Survey Form", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 }
                );
        }
        public static void SeedFormCategory(ModelBuilder builder)
        {
            builder.Entity<FormCategory>()
                .HasData(
                    new FormCategory { ID = 1, Name = "Yes | No Form", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new FormCategory { ID = 2, Name = "True | False Form", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new FormCategory { ID = 3, Name = "Yes/No/NA Form", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new FormCategory { ID = 4, Name = "Multiple Choices Form", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 }
                );
        }

        public static void SeedForm(ModelBuilder builder)
        {
            Guid key1 = Guid.Parse("A891CEC8-0808-4CDE-A42E-495634B0AF03");
            Guid key2 = Guid.Parse("72B5A528-6838-4DC2-A889-30A47DB1CE07");
            Guid key3 = Guid.Parse("73D4794B-76DB-4DDD-816C-E8E25F89E756");
            Guid key4 = Guid.Parse("480DD49E-7BB8-4DF1-BD16-C9592F3BE5BE");
            builder.Entity<Form>()
                .HasData(
                    new Form { ID = 1, Name = "QA Form 1", FormTypeID = 1, FormCategoryID = 4, Key = key1, Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 }, //yes or no
                    new Form { ID = 2, Name = "QA Form 2", FormTypeID = 1, FormCategoryID = 1, Key = key2, Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new Form { ID = 3, Name = "QA Form 3", FormTypeID = 1, FormCategoryID = 3, Key = key3, Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 }
                );
        }

        public static void SeedChoice(ModelBuilder builder)
        {
            //NOTE: Password == pasok12345
            builder.Entity<FormChoice>()
                .HasData(
                    new FormChoice { ID = 1, SortOrder = 1, Name = "Yes", Value = 1, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new FormChoice { ID = 2, SortOrder = 2, Name = "No", Value = 0, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new FormChoice { ID = 3, SortOrder = 3, Name = "NA", Value = 2, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new FormChoice { ID = 4, SortOrder = 4, Name = "True", Value = 1, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new FormChoice { ID = 5, SortOrder = 5, Name = "False", Value = 0, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },

                    new FormChoice { ID = 6, SortOrder = 6, Name = "[CRITICAL ERROR] Agent shared private information", Value = -25, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//Process Adherence
                    new FormChoice { ID = 7, SortOrder = 7, Name = "[CRITICAL ERROR] Did not take ownership of the case", Value = -25, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//Process Adherence
                    new FormChoice { ID = 8, SortOrder = 8, Name = "[CRITICAL ERROR] Did not use/complete WFT", Value = -25, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//Process Adherence
                    new FormChoice { ID = 9, SortOrder = 9, Name = "Process was not followed", Value = 7, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//Process Adherence
                    new FormChoice { ID = 10, SortOrder = 10, Name = "Provided inaccurate information", Value = 10, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//Process Adherence
                    new FormChoice { ID = 11, SortOrder = 11, Name = "Did not attach KB as appropriate", Value = 7, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//Process Adherence
                    new FormChoice { ID = 12, SortOrder = 12, Name = "Did not follow CSAT positioning", Value = 1, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//Process Adherence
                    new FormChoice { ID = 13, SortOrder = 13, Name = "Meets Expectations", Value = 25, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//Process Adherence

                    new FormChoice { ID = 14, SortOrder = 14, Name = "[CRITICAL ERROR] Failure to properly follow-up/escalate", Value = -25, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//Transfers and Followups
                    new FormChoice { ID = 15, SortOrder = 15, Name = "[CRITICAL ERROR] - Agent failed to OB on dropped contact", Value = -25, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//Transfers and Followups
                    new FormChoice { ID = 16, SortOrder = 16, Name = "[CRITICAL ERROR] Did not correctly escalate Covid-19 case", Value = -25, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//Transfers and Followups
                    new FormChoice { ID = 17, SortOrder = 17, Name = "[CRITICAL ERROR] Failed to escalate a HSL case", Value = -25, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//Transfers and Followups
                    new FormChoice { ID = 18, SortOrder = 18, Name = "Transferred without a justified reason", Value = 10, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//Transfers and Followups
                    new FormChoice { ID = 19, SortOrder = 19, Name = "Escalated without appropriate case notes", Value = 10, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//Transfers and Followups
                    new FormChoice { ID = 20, SortOrder = 20, Name = "Failed to follow through with request", Value = 15, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//Transfers and Followups
                    new FormChoice { ID = 21, SortOrder = 21, Name = "Meets Expectations", Value = 35, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//Transfers and Followups

                    new FormChoice { ID = 22, SortOrder = 22, Name = "Agent was not easy to understand", Value = 3, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//language grammar formatting
                    new FormChoice { ID = 23, SortOrder = 23, Name = "Agent used unfamiliar language", Value = 4, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//language grammar formatting
                    new FormChoice { ID = 24, SortOrder = 24, Name = "Poor Communication (voice/format/text)", Value = 3, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//language grammar formatting
                    new FormChoice { ID = 25, SortOrder = 25, Name = "Meets Expecations", Value = 10, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//language grammar formatting

                    new FormChoice { ID = 26, SortOrder = 26, Name = "[CRITICAL ERROR] Agent used inapproriate language", Value = -25, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//professional conduct
                    new FormChoice { ID = 27, SortOrder = 27, Name = "[CRITICAL ERROR] Agent cursed, yelled, was rude", Value = -25, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//professional conduct
                    new FormChoice { ID = 28, SortOrder = 28, Name = "Excessive hold time", Value = 10, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//professional conduct
                    new FormChoice { ID = 29, SortOrder = 29, Name = "Meets Expectations", Value = 10, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//professional conduct
                    new FormChoice { ID = 30, SortOrder = 30, Name = "[CRITICAL ERROR] Did not link with correct delivery/email", Value = -25, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//documentation

                    new FormChoice { ID = 31, SortOrder = 31, Name = "[CRITICAL ERROR] Did not link with correct delivery/email", Value = -25, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//documentation
                    new FormChoice { ID = 32, SortOrder = 32, Name = "Did not duplicate/merge cases", Value = 5, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//documentation
                    new FormChoice { ID = 33, SortOrder = 33, Name = "Did not include sufficient case notes", Value = 5, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//documentation
                    new FormChoice { ID = 34, SortOrder = 34, Name = "Did not set case status appropriately", Value = 5, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//documentation
                    new FormChoice { ID = 35, SortOrder = 35, Name = "Did not select correct Issue/Issue Cat", Value = 1, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//documentation
                    new FormChoice { ID = 36, SortOrder = 36, Name = "Incorrect Resolution/Category", Value = 1, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//documentation
                    new FormChoice { ID = 37, SortOrder = 37, Name = "Did not associate correct account name", Value = 1, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//documentation
                    new FormChoice { ID = 38, SortOrder = 38, Name = "Did not log call to the case", Value = 1, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//documentation
                    new FormChoice { ID = 39, SortOrder = 39, Name = "Did not update to correct case origin", Value = 1, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },//documentation
                    new FormChoice { ID = 40, SortOrder = 40, Name = "Meets Expectations", Value = 20, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now }//documentation

                );
        }

        public static void SeedFormQuestion(ModelBuilder builder)
        {
            builder.Entity<FormQuestion>()
                .HasData(
                    new FormQuestion { ID = 1, FormID = 2, HtmlControlID = 3, Name = "Date", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 1 },
                    new FormQuestion { ID = 2, FormID = 2, HtmlControlID = 3, Name = "Teammate", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 2 },
                    new FormQuestion { ID = 3, FormID = 2, HtmlControlID = 3, Name = "Case ID", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 3 },
                    new FormQuestion { ID = 4, FormID = 2, HtmlControlID = 3, Name = "Issue", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 4 },
                    new FormQuestion { ID = 5, FormID = 2, HtmlControlID = 3, Name = "Resolution", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 5 },
                    new FormQuestion { ID = 6, FormID = 2, HtmlControlID = 3, Name = "Delivery ID", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 6 },
                    new FormQuestion { ID = 7, FormID = 2, HtmlControlID = 3, Name = "What is the issue of the Cx?", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 7 },
                    new FormQuestion { ID = 8, FormID = 2, HtmlControlID = 3, Name = "What is the resolution provided by the TM?", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 8 },
                    new FormQuestion { ID = 9, FormID = 2, HtmlControlID = 1, Name = "Documentation", Active = true, IsNoteVisible = false, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 9 },//Y or N
                    new FormQuestion { ID = 10, FormID = 2, HtmlControlID = 1, Name = "Process Adherance", Active = true, IsNoteVisible = false, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 10 },//Y or N
                    new FormQuestion { ID = 11, FormID = 2, HtmlControlID = 1, Name = "Transfers and Follow-ups", Active = true, IsNoteVisible = false, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 11 },//Y or N
                    new FormQuestion { ID = 12, FormID = 2, HtmlControlID = 1, Name = "Language, Grammar & Formatting", Active = true, IsNoteVisible = false, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 12 },//Y or N
                    new FormQuestion { ID = 13, FormID = 2, HtmlControlID = 1, Name = "Professional Conduct", Active = true, IsNoteVisible = false, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 13 },//Y or N


                    new FormQuestion { ID = 14, FormID = 3, HtmlControlID = 3, Name = "Date", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 14 },
                    new FormQuestion { ID = 15, FormID = 3, HtmlControlID = 3, Name = "Teammate", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 15 },
                    new FormQuestion { ID = 16, FormID = 3, HtmlControlID = 3, Name = "Case ID", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 16 },
                    new FormQuestion { ID = 17, FormID = 3, HtmlControlID = 3, Name = "Issue", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 17 },
                    new FormQuestion { ID = 18, FormID = 3, HtmlControlID = 3, Name = "Resolution", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 18 },
                    new FormQuestion { ID = 19, FormID = 3, HtmlControlID = 3, Name = "Delivery ID", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 19 },
                    new FormQuestion { ID = 20, FormID = 3, HtmlControlID = 3, Name = "What is the issue of the Cx?", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 20 },
                    new FormQuestion { ID = 21, FormID = 3, HtmlControlID = 3, Name = "What is the resolution provided by the TM?", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 21 },
                    new FormQuestion { ID = 22, FormID = 3, HtmlControlID = 1, Name = "Documentation", Active = true, IsNoteVisible = false, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 22 },//Y or N or NA
                    new FormQuestion { ID = 23, FormID = 3, HtmlControlID = 1, Name = "Process Adherance", Active = true, IsNoteVisible = false, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 23 },//Y or N or NA
                    new FormQuestion { ID = 24, FormID = 3, HtmlControlID = 1, Name = "Transfers and Follow-ups", Active = true, IsNoteVisible = false, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 24 },//Y or N or NA
                    new FormQuestion { ID = 25, FormID = 3, HtmlControlID = 1, Name = "Language, Grammar & Formatting", Active = true, IsNoteVisible = false, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 25 },//Y or N or NA
                    new FormQuestion { ID = 26, FormID = 3, HtmlControlID = 1, Name = "Professional Conduct", Active = true, IsNoteVisible = false, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 26 },//Y or N or NA

                    new FormQuestion { ID = 27, FormID = 1, HtmlControlID = 3, Name = "Date", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 27 },
                    new FormQuestion { ID = 28, FormID = 1, HtmlControlID = 3, Name = "Teammate", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 28 },
                    new FormQuestion { ID = 29, FormID = 1, HtmlControlID = 3, Name = "Case ID", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 29 },
                    new FormQuestion { ID = 30, FormID = 1, HtmlControlID = 3, Name = "Issue", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 30 },
                    new FormQuestion { ID = 31, FormID = 1, HtmlControlID = 3, Name = "Resolution", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 31 },
                    new FormQuestion { ID = 32, FormID = 1, HtmlControlID = 3, Name = "Delivery ID", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 32 },
                    new FormQuestion { ID = 33, FormID = 1, HtmlControlID = 3, Name = "What is the issue of the Cx?", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 33 },
                    new FormQuestion { ID = 34, FormID = 1, HtmlControlID = 3, Name = "What is the resolution provided by the TM?", Active = true, IsNoteVisible = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 34 },
                    new FormQuestion { ID = 35, FormID = 1, HtmlControlID = 4, Name = "Documentation", Active = true, IsNoteVisible = false, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 35 },
                    new FormQuestion { ID = 36, FormID = 1, HtmlControlID = 4, Name = "Process Adherance", Active = true, IsNoteVisible = false, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 36 },
                    new FormQuestion { ID = 37, FormID = 1, HtmlControlID = 4, Name = "Transfers and Follow-ups", Active = true, IsNoteVisible = false, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 37 },
                    new FormQuestion { ID = 38, FormID = 1, HtmlControlID = 4, Name = "Language, Grammar & Formatting", Active = true, IsNoteVisible = false, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 38 },
                    new FormQuestion { ID = 39, FormID = 1, HtmlControlID = 4, Name = "Professional Conduct", Active = true, IsNoteVisible = false, DateCreated = DateTimeOffset.Now, CreatedByID = 1, SortOrder = 39 }
                );
        }     

        public static void SeedFormQuestionChoice(ModelBuilder builder)
        {
            builder.Entity<FormQuestionChoice>()
                  .HasData(
            #region Form 2

                      new FormQuestionChoice { ID = 1, QuestionID = 9, ChoiceID = 1, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N Question 1
                      new FormQuestionChoice { ID = 2, QuestionID = 9, ChoiceID = 2, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N Question 1
                      new FormQuestionChoice { ID = 3, QuestionID = 10, ChoiceID = 1, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N Question 2
                      new FormQuestionChoice { ID = 4, QuestionID = 10, ChoiceID = 2, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N Question 2
                      new FormQuestionChoice { ID = 5, QuestionID = 11, ChoiceID = 1, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N Question 3
                      new FormQuestionChoice { ID = 6, QuestionID = 11, ChoiceID = 2, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N Question 3
                      new FormQuestionChoice { ID = 7, QuestionID = 12, ChoiceID = 1, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N Question 4
                      new FormQuestionChoice { ID = 8, QuestionID = 12, ChoiceID = 2, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N Question 4
                      new FormQuestionChoice { ID = 9, QuestionID = 13, ChoiceID = 1, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N Question 5
                      new FormQuestionChoice { ID = 10, QuestionID = 13, ChoiceID = 2, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N Question 5

            #endregion

            #region Form 3

                      new FormQuestionChoice { ID = 11, QuestionID = 22, ChoiceID = 1, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N | NA  Question 1
                      new FormQuestionChoice { ID = 12, QuestionID = 22, ChoiceID = 2, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N | NA  Question 1
                      new FormQuestionChoice { ID = 13, QuestionID = 22, ChoiceID = 3, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N | NA  Question 1
                      new FormQuestionChoice { ID = 14, QuestionID = 23, ChoiceID = 1, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N | NA  Question 2
                      new FormQuestionChoice { ID = 15, QuestionID = 23, ChoiceID = 2, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N | NA  Question 2
                      new FormQuestionChoice { ID = 16, QuestionID = 23, ChoiceID = 3, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N | NA  Question 2
                      new FormQuestionChoice { ID = 17, QuestionID = 24, ChoiceID = 1, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N | NA  Question 3
                      new FormQuestionChoice { ID = 18, QuestionID = 24, ChoiceID = 2, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N | NA  Question 3
                      new FormQuestionChoice { ID = 19, QuestionID = 24, ChoiceID = 3, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N | NA  Question 3
                      new FormQuestionChoice { ID = 20, QuestionID = 25, ChoiceID = 1, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N | NA  Question 4
                      new FormQuestionChoice { ID = 21, QuestionID = 25, ChoiceID = 2, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N | NA  Question 4
                      new FormQuestionChoice { ID = 22, QuestionID = 25, ChoiceID = 3, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N | NA  Question 4
                      new FormQuestionChoice { ID = 23, QuestionID = 26, ChoiceID = 1, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N | NA  Question 5
                      new FormQuestionChoice { ID = 24, QuestionID = 26, ChoiceID = 2, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N | NA  Question 5
                      new FormQuestionChoice { ID = 25, QuestionID = 26, ChoiceID = 3, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form 2 Y | N | NA  Question 5

            #endregion

            #region Form 1

            #region documentation 

                      new FormQuestionChoice { ID = 26, QuestionID = 35, ChoiceID = 31, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//documentation
                      new FormQuestionChoice { ID = 27, QuestionID = 35, ChoiceID = 32, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//documentation
                      new FormQuestionChoice { ID = 28, QuestionID = 35, ChoiceID = 33, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//documentation
                      new FormQuestionChoice { ID = 29, QuestionID = 35, ChoiceID = 34, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//documentation
                      new FormQuestionChoice { ID = 30, QuestionID = 35, ChoiceID = 35, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//documentation
                      new FormQuestionChoice { ID = 31, QuestionID = 35, ChoiceID = 36, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//documentation
                      new FormQuestionChoice { ID = 32, QuestionID = 35, ChoiceID = 37, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//documentation
                      new FormQuestionChoice { ID = 33, QuestionID = 35, ChoiceID = 38, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//documentation
                      new FormQuestionChoice { ID = 34, QuestionID = 35, ChoiceID = 39, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//documentation
                      new FormQuestionChoice { ID = 35, QuestionID = 35, ChoiceID = 40, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//documentation

            #endregion

            #region Process Adherence

                      new FormQuestionChoice { ID = 36, QuestionID = 36, ChoiceID = 6, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//Process Adherence
                      new FormQuestionChoice { ID = 37, QuestionID = 36, ChoiceID = 7, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//Process Adherence
                      new FormQuestionChoice { ID = 38, QuestionID = 36, ChoiceID = 8, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//Process Adherence
                      new FormQuestionChoice { ID = 39, QuestionID = 36, ChoiceID = 9, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//Process Adherence
                      new FormQuestionChoice { ID = 40, QuestionID = 36, ChoiceID = 10, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//Process Adherence
                      new FormQuestionChoice { ID = 41, QuestionID = 36, ChoiceID = 11, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//Process Adherence
                      new FormQuestionChoice { ID = 42, QuestionID = 36, ChoiceID = 12, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//Process Adherence
                      new FormQuestionChoice { ID = 43, QuestionID = 36, ChoiceID = 13, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//Process Adherence

            #endregion

            #region Transfers and Follow-ups

                    new FormQuestionChoice { ID = 44, QuestionID = 37, ChoiceID = 14, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//Transfers and Followups
                    new FormQuestionChoice { ID = 45, QuestionID = 37, ChoiceID = 15, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//Transfers and Followups
                    new FormQuestionChoice { ID = 46, QuestionID = 37, ChoiceID = 16, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//Transfers and Followups
                    new FormQuestionChoice { ID = 47, QuestionID = 37, ChoiceID = 17, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//Transfers and Followups
                    new FormQuestionChoice { ID = 48, QuestionID = 37, ChoiceID = 18, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//Transfers and Followups
                    new FormQuestionChoice { ID = 49, QuestionID = 37, ChoiceID = 19, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//Transfers and Followups
                    new FormQuestionChoice { ID = 50, QuestionID = 37, ChoiceID = 20, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//Transfers and Followups
                    new FormQuestionChoice { ID = 51, QuestionID = 37, ChoiceID = 21, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//Transfers and Followups

            #endregion

            #region Language, Grammar & Formatting

                      new FormQuestionChoice { ID = 52, QuestionID = 38, ChoiceID = 22, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//language grammar formatting
                      new FormQuestionChoice { ID = 53, QuestionID = 38, ChoiceID = 23, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//language grammar formatting
                      new FormQuestionChoice { ID = 54, QuestionID = 38, ChoiceID = 24, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//language grammar formatting
                      new FormQuestionChoice { ID = 55, QuestionID = 38, ChoiceID = 25, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//language grammar formatting

            #endregion

            #region Professional Conduct

                      new FormQuestionChoice { ID = 56, QuestionID = 39, ChoiceID = 26, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//professional conduct
                      new FormQuestionChoice { ID = 57, QuestionID = 39, ChoiceID = 27, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//professional conduct
                      new FormQuestionChoice { ID = 58, QuestionID = 39, ChoiceID = 28, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//professional conduct
                      new FormQuestionChoice { ID = 59, QuestionID = 39, ChoiceID = 29, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//professional conduct
                      new FormQuestionChoice { ID = 60, QuestionID = 39, ChoiceID = 30, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 }//professional conduct
            #endregion

            #endregion
                  );

        }
        #endregion
    }
}
