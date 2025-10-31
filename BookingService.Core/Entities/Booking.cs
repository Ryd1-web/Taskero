using BookingService.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Entities
{
    public class Booking : BaseEntity<int>
    {
        public DateTime BookingDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public string Status { get; set; } // e.g., Scheduled, Completed, Canceled
    }
}
