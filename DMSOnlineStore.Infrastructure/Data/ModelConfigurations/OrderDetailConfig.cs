using System;
using System.Collections.Generic;
using System.Text;
using DMSOnlineStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DMSOnlineStore.Infrastructure.Data.ModelConfigurations
{
  public  class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
          
            //OrderDetail : UnitOfMeasure
            builder.HasOne(d => d.UnitOfMeasure)
                .WithMany(d => d.OrderDetails)
                .HasForeignKey(d => d.UnitOfMeasureId)
                .OnDelete(DeleteBehavior.NoAction);
            //OrderDetail : Item
            builder.HasOne(d => d.Item)
                .WithMany(d => d.OrderDetails)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.NoAction);
            //OrderDetail : Order
            builder.HasOne(d => d.Order)
                .WithMany(d => d.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
