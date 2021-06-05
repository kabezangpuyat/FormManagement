using Microsoft.EntityFrameworkCore;
using QMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Database
{
    public static class CreateAppNavigationRoleData
    {
        #region public Method(s)
        public static void SeedAppNavigation(ModelBuilder builder)
        {

            builder.Entity<AppNavigation>()
                .HasData(
                    //admin
                    new AppNavigation { ID = 1, Name = "user", Description = "User management navigation", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, IsInitialPage = false, IsMainModule = true },
                    new AppNavigation { ID = 2, Name = "form-admin", Description = "Admin - Form Management", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, IsInitialPage = false, IsMainModule = true },
                    new AppNavigation { ID = 3, Name = "form-create", Description = "Admin - Form Create Update", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, IsInitialPage = false, IsMainModule = false },
                    new AppNavigation { ID = 4, Name = "report-admin", Description = "Admin - Audit Summary", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, IsInitialPage = true, IsMainModule = true },
                    //QA
                    new AppNavigation { ID = 5, Name = "form-qa", Description = "QA - Form Management", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, IsInitialPage = false, IsMainModule = true },
                    new AppNavigation { ID = 6, Name = "form-createupdate-qa", Description = "QA - Form Create Update", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, IsInitialPage = false, IsMainModule = false },
                    new AppNavigation { ID = 7, Name = "audit-qa", Description = "QA - Audit Record List", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, IsInitialPage = true, IsMainModule = true },
                    new AppNavigation { ID = 8, Name = "audit-create", Description = "QA - Audit Record Create", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, IsInitialPage = false, IsMainModule = false },
                    new AppNavigation { ID = 9, Name = "report-qa", Description = "QA - Report", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, IsInitialPage = false, IsMainModule = false },
                    //TL
                    new AppNavigation { ID = 10, Name = "report-tl", Description = "TL - Audit Summary", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, IsInitialPage = true, IsMainModule = true },
                    //TM
                    new AppNavigation { ID = 11, Name = "report-TM", Description = "TM - Audit Summary", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, IsInitialPage = true, IsMainModule = true },

                    //admin
                    new AppNavigation { ID = 12, Name = "form-update", Description = "Admin - Form Create Update", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, IsInitialPage = false, IsMainModule = false },
                    new AppNavigation { ID = 13, Name = "audit-details-view", Description = "Audit/report details view", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1, IsInitialPage = false, IsMainModule = false }
                );
        }
        public static void SeedRoleAppNavigation(ModelBuilder builder)
        {
            long adminid = 1, qid = 2, tlid = 3, tmid = 4;

            builder.Entity<RoleAppNavigation>()
                .HasData(
                    new RoleAppNavigation { ID = 1, RoleID = adminid, AppNavigationID = 1, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//user form [ADMIN]
                    new RoleAppNavigation { ID = 2, RoleID = adminid, AppNavigationID = 2, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form-admin [ADMIN]
                    new RoleAppNavigation { ID = 3, RoleID = adminid, AppNavigationID = 3, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form-create [ADMIN]
                    new RoleAppNavigation { ID = 4, RoleID = adminid, AppNavigationID = 4, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//report-admin [ADMIN]

                    new RoleAppNavigation { ID = 5, RoleID = qid, AppNavigationID = 2, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form-admin [ADMIN]
                    new RoleAppNavigation { ID = 6, RoleID = qid, AppNavigationID = 3, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form-create [ADMIN]
                    new RoleAppNavigation { ID = 7, RoleID = qid, AppNavigationID = 7, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//audit-qa [QA]
                    new RoleAppNavigation { ID = 8, RoleID = qid, AppNavigationID = 8, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//audit-create [QA]
                    new RoleAppNavigation { ID = 9, RoleID = qid, AppNavigationID = 9, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//report-qa [QA]

                    new RoleAppNavigation { ID = 10, RoleID = tlid, AppNavigationID = 10, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },

                    new RoleAppNavigation { ID = 11, RoleID = tmid, AppNavigationID = 11, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },

                    new RoleAppNavigation { ID = 12, RoleID = adminid, AppNavigationID = 12, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form-update [ADMIN]
                    new RoleAppNavigation { ID = 13, RoleID = qid, AppNavigationID = 12, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form-update [ADMIN]-[QA]
                    new RoleAppNavigation { ID = 14, RoleID = adminid, AppNavigationID = 13, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//audit-details-view [ADMIN]
                    new RoleAppNavigation { ID = 15, RoleID = qid, AppNavigationID = 13, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//audit-details-view [ADMIN]-[QA]
                    //TL - tl-audit-details-view
                    new RoleAppNavigation { ID = 16, RoleID = tlid, AppNavigationID = 13, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    //TM - tm-audit-details-view
                    new RoleAppNavigation { ID = 17, RoleID = tmid, AppNavigationID = 13, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 }
                );
        }
        public static void SeedRoleAppNavigation_originalsetup(ModelBuilder builder)
        {
            long adminid = 1, qid = 2, tlid = 3, tmid = 4;

            builder.Entity<RoleAppNavigation>()
                .HasData(
                    new RoleAppNavigation { ID = 1, RoleID = adminid, AppNavigationID = 1, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//user form [ADMIN]
                    new RoleAppNavigation { ID = 2, RoleID = adminid, AppNavigationID = 2, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form-admin [ADMIN]
                    new RoleAppNavigation { ID = 3, RoleID = adminid, AppNavigationID = 3, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form-create [ADMIN]
                    new RoleAppNavigation { ID = 4, RoleID = adminid, AppNavigationID = 4, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//report-admin [ADMIN]

                    new RoleAppNavigation { ID = 5, RoleID = qid, AppNavigationID = 5, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form-qa [QA]
                    new RoleAppNavigation { ID = 6, RoleID = qid, AppNavigationID = 6, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//form-createupdate-qa [QA]
                    new RoleAppNavigation { ID = 7, RoleID = qid, AppNavigationID = 7, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//audit-qa [QA]
                    new RoleAppNavigation { ID = 8, RoleID = qid, AppNavigationID = 8, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//audit-create [QA]
                    new RoleAppNavigation { ID = 9, RoleID = qid, AppNavigationID = 9, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },//report-qa [QA]

                    new RoleAppNavigation { ID = 10, RoleID = tlid, AppNavigationID = 10, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },

                    new RoleAppNavigation { ID = 11, RoleID = tmid, AppNavigationID = 11, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },

                    new RoleAppNavigation { ID = 12, RoleID = adminid, AppNavigationID = 12, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 }//form-update [ADMIN]
                );
        }

        #endregion
    }
}
