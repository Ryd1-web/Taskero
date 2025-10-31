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
    public class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.BookingDate)
                .IsRequired();
            builder.Property(b => b.Status)
                .IsRequired()
                .HasMaxLength(50);
            // Relationships
            builder.HasOne(b => b.Customer)
                   .WithMany(c => c.Bookings)
                   .HasForeignKey(b => b.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Service)
                   .WithMany(s => s.Bookings)
                   .HasForeignKey(b => b.ServiceId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Business rule: prevent overlapping bookings for the same service at same time
            builder.HasIndex(b => new { b.ServiceId, b.BookingDate })
                   .IsUnique();
        }
    }
}
