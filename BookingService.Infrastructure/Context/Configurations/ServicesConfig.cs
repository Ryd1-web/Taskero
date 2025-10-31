using BookingService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Infrastructure.Context.Configurations
{
    public class ServicesConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(s => s.Description)
                .HasMaxLength(1000);
            builder.Property(s => s.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            // Relationships
            builder.HasMany(s => s.Bookings)
                   .WithOne(b => b.Service)
                   .HasForeignKey(b => b.ServiceId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.Vendor)
                   .WithMany(v => v.Services)
                   .HasForeignKey(s => s.VendorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
