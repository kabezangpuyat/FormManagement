using Microsoft.EntityFrameworkCore;
using QMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Database
{
    public static class Seed
    {      
        public static void Initialiaze(ModelBuilder builder)
        {
            #region Campaign Lob data
            CreateCampaignLobData.SeedCampaign(builder);
            //CreateCampaignLobData.SeedLob(builder);
            #endregion

            #region User role campaign data
            CreateUserRoleData.SeedRole(builder);
            CreateUserRoleData.SeedUser(builder);
            CreateUserRoleData.SeedUserRole(builder);
            CreateUserCampaign.SeedUserCampaign(builder);
            #endregion

            #region App Navigation Data
            CreateAppNavigationRoleData.SeedAppNavigation(builder);
            CreateAppNavigationRoleData.SeedRoleAppNavigation(builder);
            #endregion       

            #region Form data
            CreateInitialFormData.SeedHtmlType(builder);
            CreateInitialFormData.SeedFormType(builder);
            CreateInitialFormData.SeedFormCategory(builder);
            CreateInitialFormData.SeedForm(builder);
            CreateInitialFormData.SeedChoice(builder);
            CreateInitialFormData.SeedFormQuestion(builder);            
            CreateInitialFormData.SeedFormQuestionChoice(builder);
            #endregion
        }
    }
}
