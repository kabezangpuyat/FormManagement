using Microsoft.EntityFrameworkCore;
using QMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Database
{
    public static class CreateCampaignLobData
    { 
        #region public Method(s)
        public static void SeedCampaign(ModelBuilder builder)
        {
            builder.Entity<Campaign>()
                .HasData(
                    new Campaign { ID = 1, Name = "IT", EpmsCampaignID = 420, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new Campaign { ID = 2, Name = "Operations", EpmsCampaignID = 22, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new Campaign { ID = 3, Name = "Data Science", EpmsCampaignID = 373, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new Campaign { ID = 4, Name = "Finance", EpmsCampaignID = 1389, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 }
                );
        }

        public static void SeedLob(ModelBuilder builder)
        {
            //NOTE: Password == pasok12345
            builder.Entity<Lob>()
                .HasData(
                    new Lob { ID = 1, CampaignID = 1, Name = "Lob 1", Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now},
                    new Lob { ID = 2, CampaignID = 1, Name = "Lob 2", Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new Lob { ID = 3, CampaignID = 1, Name = "Lob 3", Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new Lob { ID = 4, CampaignID = 2, Name = "Lob 4", Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new Lob { ID = 5, CampaignID = 2, Name = "Lob 5", Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new Lob { ID = 6, CampaignID = 2, Name = "Lob 6", Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now }
                );
        }

        #endregion
    }
}
