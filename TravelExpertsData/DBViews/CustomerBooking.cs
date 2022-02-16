using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData.DBViews
{
    public class CustomerBooking
    {
        public int BookingId { get; set; }
        public string BookingNo { get; set; }
        public int PeopleNo { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? TripStart { get; set; }
        public DateTime? TripEnd { get; set; }
        public string Description { get; set; }
        public List<string> ProductsInBooking { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
