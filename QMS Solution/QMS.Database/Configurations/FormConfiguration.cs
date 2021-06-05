using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QMS.Domain.Entities;
using System;

namespace QMS.Database.Configurations
{
    public class FormConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.ToTable("Form", schema: "dbo").HasKey(x => x.ID);

            builder.Property(e => e.ID).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(e => e.Key).HasColumnName("Key").HasDefaultValue(Guid.NewGuid());
            builder.Property(e => e.FormCategoryID).HasColumnName("FormCategoryID").IsRequired(true);
            builder.Property(e => e.FormTypeID).HasColumnName("FormTypeID").IsRequired(true);
            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(100);
            builder.Property(e => e.IsNoteVisible).HasColumnName("IsNoteVisible").HasDefaultValue(true);
            builder.Property(e => e.CreatedByID).HasColumnName("CreatedByID").IsRequired(false);
            builder.Property(e => e.ModifiedByID).HasColumnName("ModifiedByID").IsRequired(false);
            builder.Property(e => e.DateCreated).HasColumnName("DateCreated").HasDefaultValue(DateTimeOffset.Now);
            builder.Property(e => e.DateModified).HasColumnName("DateModified").IsRequired(false);
            builder.Property(e => e.Active).HasColumnName("Active").HasDefaultValue(true);

            //form category mapping
            builder.HasOne<FormCategory>(x => x.FormCategory)
                .WithMany(x => x.Forms)
                .HasForeignKey(x => x.FormCategoryID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            //formtype mapping
            builder.HasOne<FormType>(x => x.FormType)
                .WithMany(x => x.Forms)
                .HasForeignKey(x => x.FormTypeID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.HasOne<User>(x => x.CreatedBy)
               .WithMany(x => x.Forms)
               .HasForeignKey(x => x.CreatedByID)
               .OnDelete(DeleteBehavior.SetNull)
               .IsRequired(false);
        }
    }
}
