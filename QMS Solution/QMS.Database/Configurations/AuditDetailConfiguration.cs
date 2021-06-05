using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QMS.Domain.Entities;
using System;

namespace QMS.Database.Configurations
{
    public class AuditDetailConfiguration : IEntityTypeConfiguration<AuditDetail>
    {
        public void Configure(EntityTypeBuilder<AuditDetail> builder)
        {
            builder.ToTable("AuditDetail", schema: "dbo").HasKey(x => x.ID);

            builder.Property(e => e.ID).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(e => e.AuditID).HasColumnName("AuditID").IsRequired(true);
            builder.Property(e => e.QuestionID).HasColumnName("QuestionID").IsRequired(false);
            builder.Property(e => e.ChoiceID).HasColumnName("ChoiceID").IsRequired(false);
            builder.Property(e => e.QuestionNotes).HasColumnName("QuestionNotes").IsRequired(false);            
            builder.Property(e => e.CreatedByID).HasColumnName("CreatedByID").IsRequired(false);
            builder.Property(e => e.ModifiedByID).HasColumnName("ModifiedByID").IsRequired(false);
            builder.Property(e => e.DateCreated).HasColumnName("DateCreated").HasDefaultValue(DateTimeOffset.Now);
            builder.Property(e => e.DateModified).HasColumnName("DateModified").IsRequired(false);
            builder.Property(e => e.Active).HasColumnName("Active").HasDefaultValue(true);

            builder.HasOne<Audit>(x => x.Audit)
               .WithMany(x => x.AuditDetails)
               .HasForeignKey(x => x.AuditID)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired(true);

            builder.HasOne<FormQuestion>(x => x.FormQuestion)
                .WithMany(x=>x.FormAnswers)
                .HasForeignKey(x => x.QuestionID)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.HasOne<FormChoice>(x => x.FormChoice)
                .WithMany(x=>x.FormAnswers)
                .HasForeignKey(x => x.ChoiceID)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
        }
    }
}
