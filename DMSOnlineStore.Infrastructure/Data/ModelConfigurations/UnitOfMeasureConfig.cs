using System;
using System.Collections.Generic;
using System.Text;
using DMSOnlineStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DMSOnlineStore.Infrastructure.Data.ModelConfigurations
{
   public class UnitOfMeasureConfig : IEntityTypeConfiguration<UnitOfMeasure>
    {
        public void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
        {
            builder.Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(d => d.Name)
                .IsUnique();

            builder.Property(d => d.Description)
                .HasMaxLength(100);
        }
    }
}
