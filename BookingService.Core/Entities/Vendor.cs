using BookingService.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Entities
{
    public class Vendor : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Service> Services { get; set; }
        public Vendor()
        {
            Services = new List<Service>();
        }
    }
}
