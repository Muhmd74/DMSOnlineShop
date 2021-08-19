using System;
using System.Collections.Generic;
using System.Text;
using DMSOnlineStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DMSOnlineStore.Infrastructure.Data.ModelConfigurations
{
   public class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(d => d.Description)
                .HasMaxLength(250);

            builder.HasIndex(d => d.Price)
                .IsUnique();

            builder.Property(d => d.IsDeleted)
                .HasDefaultValue(false);

             builder.Property(d => d.Quantity)
                .IsRequired();

            //Item : UnitOfMeasure
            builder.HasOne(d => d.UnitOfMeasure)
                .WithMany(d => d.Items)
                .HasForeignKey(d => d.UnitOfMeasureId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
