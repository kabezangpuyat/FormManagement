using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QMS.Domain.Entities;
using System;

namespace QMS.Database.Configurations
{
    public class FormChoiceConfiguration : IEntityTypeConfiguration<FormChoice>
    {
        public void Configure(EntityTypeBuilder<FormChoice> builder)
        {
            builder.ToTable("FormChoice", schema: "dbo").HasKey(x => x.ID);

            builder.Property(e => e.ID).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasColumnName("Name").IsRequired(true);
            builder.Property(e => e.SortOrder).HasColumnName("SortOrder").HasDefaultValueSql("NEXT VALUE FOR shared.OrderNumbers"); 
            builder.Property(e => e.CreatedByID).HasColumnName("CreatedByID").IsRequired(false);
            builder.Property(e => e.ModifiedByID).HasColumnName("ModifiedByID").IsRequired(false);
            builder.Property(e => e.DateCreated).HasColumnName("DateCreated").HasDefaultValue(DateTimeOffset.Now);
            builder.Property(e => e.DateModified).HasColumnName("DateModified").IsRequired(false);
            builder.Property(e => e.Active).HasColumnName("Active").HasDefaultValue(true);

        }
    }
}
