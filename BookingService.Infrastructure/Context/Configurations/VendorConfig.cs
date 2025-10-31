using BookingService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Infrastructure.Context.Configurations
{
    public class VendorConfig : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable("Vendors");
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id).ValueGeneratedOnAdd();
            builder.Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(v => v.Email)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(v => v.PhoneNumber)
                .HasMaxLength(20);
            // Relationships
            builder.HasMany(v => v.Services)
                   .WithOne(s => s.Vendor)
                   .HasForeignKey(s => s.VendorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
