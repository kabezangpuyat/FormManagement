using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QMS.Domain.Entities;
using System;

namespace QMS.Database.Configurations
{
    public class LobConfiguration : IEntityTypeConfiguration<Lob>
    {
        public void Configure(EntityTypeBuilder<Lob> builder)
        {
            builder.ToTable("Lob", schema: "dbo").HasKey(x => x.ID);

            builder.Property(e => e.ID).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(e => e.CampaignID).HasColumnName("CampaignID").IsRequired(false);
            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(100);
            builder.Property(e => e.CreatedByID).HasColumnName("CreatedByID").IsRequired(false);
            builder.Property(e => e.ModifiedByID).HasColumnName("ModifiedByID").IsRequired(false);
            builder.Property(e => e.DateCreated).HasColumnName("DateCreated").HasDefaultValue(DateTimeOffset.Now);
            builder.Property(e => e.DateModified).HasColumnName("DateModified").IsRequired(false);
            builder.Property(e => e.Active).HasColumnName("Active").HasDefaultValue(true);

            //campaign mapping
            builder.HasOne<Campaign>(x => x.Campaign)
                .WithMany(x => x.Lobs)
                .HasForeignKey(x=>x.CampaignID)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
        }
    }
}
