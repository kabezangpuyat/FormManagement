using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QMS.Domain.Entities;
using System;

namespace QMS.Database.Configurations
{
    public class RoleAppNavigationConfiguration : IEntityTypeConfiguration<RoleAppNavigation>
    {
        public void Configure(EntityTypeBuilder<RoleAppNavigation> builder)
        {
            builder.ToTable("RoleAppNavigation", schema: "dbo").HasKey(x => x.ID);

            builder.Property(e => e.ID).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(e => e.AppNavigationID).HasColumnName("AppNavigationID").IsRequired(true);
            builder.Property(e => e.RoleID).HasColumnName("RoleID").IsRequired(true);
            builder.Property(e => e.CreatedByID).HasColumnName("CreatedByID").IsRequired(false);
            builder.Property(e => e.ModifiedByID).HasColumnName("ModifiedByID").IsRequired(false);
            builder.Property(e => e.DateCreated).HasColumnName("DateCreated").HasDefaultValue(DateTimeOffset.Now);
            builder.Property(e => e.DateModified).HasColumnName("DateModified").IsRequired(false);
            builder.Property(e => e.Active).HasColumnName("Active").HasDefaultValue(true);

            builder.HasOne<Role>(x => x.Role)
                .WithMany(x=>x.RoleAppNavigations)
                .HasForeignKey(x => x.RoleID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.HasOne<AppNavigation>(x => x.AppNavigation)
                .WithMany(x=>x.RoleAppNavigations)
                .HasForeignKey(x => x.AppNavigationID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
        }
    }
}
