using System;
using System.Collections.Generic;
using System.Text;
using DMSOnlineStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DMSOnlineStore.Infrastructure.Data.ModelConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(250)
                ;
            builder.Property(d => d.Email)
                .IsRequired();
            builder.HasIndex(d => d.Email)
                .IsUnique();

            builder.Property(d => d.IsAdmin)
                .HasDefaultValue(false);
            
            builder.Property(d => d.Password)
                .IsRequired();

         }
    }
}
