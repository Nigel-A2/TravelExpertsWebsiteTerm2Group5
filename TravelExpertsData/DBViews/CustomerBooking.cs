using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//author: Filip Florek
namespace TravelExpertsData.DBViews
{
    /*
     Class conatins all necesary info about booking from customers perspective,
        which is displayed on the website
     
     */
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
