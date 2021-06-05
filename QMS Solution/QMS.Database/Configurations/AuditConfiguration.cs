using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QMS.Domain.Entities;
using System;

namespace QMS.Database.Configurations
{
    public class AuditConfiguration : IEntityTypeConfiguration<Audit>
    {
        public void Configure(EntityTypeBuilder<Audit> builder)
        {
            builder.ToTable("Audit", schema: "dbo").HasKey(x => x.ID);

            builder.Property(e => e.ID).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(e => e.FormID).HasColumnName("FormID").IsRequired(true);
            builder.Property(e => e.TeammateID).HasColumnName("TeammateID").IsRequired(true);
            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(300);
            builder.Property(e => e.FormNotes).HasColumnName("FormNotes").IsRequired(false);
            builder.Property(e => e.CreatedByID).HasColumnName("CreatedByID").IsRequired(false);
            builder.Property(e => e.ModifiedByID).HasColumnName("ModifiedByID").IsRequired(false);
            builder.Property(e => e.DateCreated).HasColumnName("DateCreated").HasDefaultValue(DateTimeOffset.Now);
            builder.Property(e => e.DateModified).HasColumnName("DateModified").IsRequired(false);
            builder.Property(e => e.Active).HasColumnName("Active").HasDefaultValue(true);

            //form 
            builder.HasOne<Form>(x => x.Form)
                .WithMany(x => x.Audits)
                .HasForeignKey(x => x.FormID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.HasOne<User>(x => x.CreatedBy)
               .WithMany(x => x.Audits)
               .HasForeignKey(x => x.CreatedByID)
               .OnDelete(DeleteBehavior.SetNull)
               .IsRequired(false);

            builder.HasOne<User>(x => x.Teammate)
               .WithMany(x => x.AuditTeammates)
               .HasForeignKey(x => x.TeammateID)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired(true);
        }
    }
}
