using Microsoft.EntityFrameworkCore;
using QMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Database
{
    public static class CreateUserCampaign
    { 
        #region public Method(s)
        public static void SeedUserCampaign(ModelBuilder builder)
        {
            //NOTE: Password == pasok12345
            builder.Entity<UserCampaign>()
                .HasData(
                    new UserCampaign { ID = 1, UserID = 1, CampaignID = 1, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now},
                    new UserCampaign { ID = 2, UserID = 1, CampaignID = 2, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },

                    new UserCampaign { ID = 3, UserID = 2, CampaignID = 2, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new UserCampaign { ID = 4, UserID = 3, CampaignID = 4, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new UserCampaign { ID = 5, UserID = 4, CampaignID = 3, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new UserCampaign { ID = 6, UserID = 5, CampaignID = 1, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new UserCampaign { ID = 7, UserID = 6, CampaignID = 2, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new UserCampaign { ID = 8, UserID = 7, CampaignID = 2, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new UserCampaign { ID = 9, UserID = 8, CampaignID = 4, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new UserCampaign { ID = 10, UserID = 9, CampaignID = 2, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new UserCampaign { ID = 11, UserID = 10, CampaignID = 4, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },

                    new UserCampaign { ID = 12, UserID = 11, CampaignID = 4, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new UserCampaign { ID = 13, UserID = 12, CampaignID = 4, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new UserCampaign { ID = 14, UserID = 13, CampaignID = 3, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new UserCampaign { ID = 15, UserID = 14, CampaignID = 3, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new UserCampaign { ID = 16, UserID = 15, CampaignID = 2, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new UserCampaign { ID = 17, UserID = 15, CampaignID = 4, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now }
                );
        }

        #endregion
    }
}
