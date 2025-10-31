using BookingService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Infrastructure.Context.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(20);
            // Relationships
            builder.HasMany(c => c.Bookings)
                   .WithOne(b => b.Customer)
                   .HasForeignKey(b => b.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
