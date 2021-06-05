using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QMS.Domain.Entities;
using System;

namespace QMS.Database.Configurations
{
    public class FormQuestionChoiceConfiguration : IEntityTypeConfiguration<FormQuestionChoice>
    {
        public void Configure(EntityTypeBuilder<FormQuestionChoice> builder)
        {
            builder.ToTable("FormQuestionChoice", schema: "dbo").HasKey(x => x.ID);

            builder.Property(e => e.ID).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(e => e.QuestionID).HasColumnName("QuestionID").IsRequired(true);
            builder.Property(e => e.ChoiceID).HasColumnName("ChoiceID").IsRequired(true);
            builder.Property(e => e.CreatedByID).HasColumnName("CreatedByID").IsRequired(false);
            builder.Property(e => e.ModifiedByID).HasColumnName("ModifiedByID").IsRequired(false);
            builder.Property(e => e.DateCreated).HasColumnName("DateCreated").HasDefaultValue(DateTimeOffset.Now);
            builder.Property(e => e.DateModified).HasColumnName("DateModified").IsRequired(false);
            builder.Property(e => e.Active).HasColumnName("Active").HasDefaultValue(true);

            builder.HasOne<FormQuestion>(x => x.FormQuestion)
                .WithMany(x=>x.FormQuestionChoices)
                .HasForeignKey(x => x.QuestionID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.HasOne<FormChoice>(x => x.FormChoice)
                .WithMany(x=>x.FormQuestionChoices)
                .HasForeignKey(x => x.ChoiceID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
        }
    }
}
