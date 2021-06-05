using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QMS.Domain.Entities;
using System;

namespace QMS.Database.Configurations
{
    public class FormQuestionConfiguration : IEntityTypeConfiguration<FormQuestion>
    {
        public void Configure(EntityTypeBuilder<FormQuestion> builder)
        {
            builder.ToTable("FormQuestion", schema: "dbo").HasKey(x => x.ID);

            builder.Property(e => e.ID).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(e => e.FormID).HasColumnName("FormID").IsRequired(true);
            builder.Property(e => e.Name).HasColumnName("Name").IsRequired(true);
            builder.Property(e => e.HtmlControlID).HasColumnName("HtmlControlID").IsRequired(true);
            builder.Property(e => e.IsNoteVisible).HasColumnName("IsNoteVisible").HasDefaultValue(false);
            builder.Property(e => e.SortOrder).HasColumnName("SortOrder").HasDefaultValueSql("NEXT VALUE FOR shared.OrderNumbers");
            builder.Property(e => e.CreatedByID).HasColumnName("CreatedByID").IsRequired(false);
            builder.Property(e => e.ModifiedByID).HasColumnName("ModifiedByID").IsRequired(false);
            builder.Property(e => e.DateCreated).HasColumnName("DateCreated").HasDefaultValue(DateTimeOffset.Now);
            builder.Property(e => e.DateModified).HasColumnName("DateModified").IsRequired(false);
            builder.Property(e => e.Active).HasColumnName("Active").HasDefaultValue(true);

            builder.HasOne<HtmlControl>(x => x.HtmlControl)
                .WithMany(x=>x.FormQuestions)
                .HasForeignKey(x => x.HtmlControlID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.HasOne<Form>(x => x.Form)
                .WithMany(x => x.FormQuestions)
                .HasForeignKey(x => x.FormID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
        }
    }
}
