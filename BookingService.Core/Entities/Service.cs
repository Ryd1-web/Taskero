using BookingService.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Entities
{
    public class Service : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DurationInMinutes { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public Service()
        {
            Bookings = new List<Booking>();
            Customers = new List<Customer>();
        }
    }
}
