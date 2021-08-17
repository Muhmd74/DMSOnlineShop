using System;
using System.Collections.Generic;
using System.Text;
using DMSOnlineStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DMSOnlineStore.Infrastructure.Data.ModelConfigurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
           

            //Order : User
            builder.HasOne(d => d.User)
                .WithMany(d => d.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
