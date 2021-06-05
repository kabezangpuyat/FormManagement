using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QMS.Domain.Entities;
using System;

namespace QMS.Database.Configurations
{
    public class AppNavigationConfiguration : IEntityTypeConfiguration<AppNavigation>
    {
        public void Configure(EntityTypeBuilder<AppNavigation> builder)
        {
            builder.ToTable("AppNavigation", schema: "dbo").HasKey(x => x.ID);

            builder.Property(e => e.ID).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.Description).HasColumnName("Description").HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.IsInitialPage).HasColumnName("IsInitialPage").IsRequired(true).HasDefaultValue(false);
            builder.Property(e => e.IsMainModule).HasColumnName("IsMainModule").IsRequired(true).HasDefaultValue(false);
            builder.Property(e => e.CreatedByID).HasColumnName("CreatedByID").IsRequired(false);
            builder.Property(e => e.ModifiedByID).HasColumnName("ModifiedByID").IsRequired(false);
            builder.Property(e => e.DateCreated).HasColumnName("DateCreated").HasDefaultValue(DateTimeOffset.Now);
            builder.Property(e => e.DateModified).HasColumnName("DateModified").IsRequired(false);
            builder.Property(e => e.Active).HasColumnName("Active").HasDefaultValue(true);

            builder.HasIndex(x => x.Name).IsUnique(true);
        }
    }
}
