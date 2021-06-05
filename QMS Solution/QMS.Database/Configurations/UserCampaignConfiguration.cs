using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QMS.Domain.Entities;
using System;

namespace QMS.Database.Configurations
{
    public class UserCampaignConfiguration : IEntityTypeConfiguration<UserCampaign>
    {
        public void Configure(EntityTypeBuilder<UserCampaign> builder)
        {
            builder.ToTable("UserCampaign", schema: "dbo").HasKey(x => x.ID);

            builder.Property(e => e.ID).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(e => e.UserID).HasColumnName("UserID").IsRequired(false);
            builder.Property(e => e.CampaignID).HasColumnName("CampaignID").IsRequired(false);
            builder.Property(e => e.CreatedByID).HasColumnName("CreatedByID").IsRequired(false);
            builder.Property(e => e.ModifiedByID).HasColumnName("ModifiedByID").IsRequired(false);
            builder.Property(e => e.DateCreated).HasColumnName("DateCreated").HasDefaultValue(DateTimeOffset.Now);
            builder.Property(e => e.DateModified).HasColumnName("DateModified").IsRequired(false);
            builder.Property(e => e.Active).HasColumnName("Active").HasDefaultValue(true);

            builder.HasOne<Campaign>(x => x.Campaign)
                .WithMany(x=>x.UserCampaigns)
                .HasForeignKey(x => x.CampaignID)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.HasOne<User>(x => x.User)
                .WithMany(x=>x.UserCampaigns)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
        }
    }
}
