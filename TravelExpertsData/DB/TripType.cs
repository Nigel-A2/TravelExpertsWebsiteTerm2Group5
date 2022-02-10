using System;
using System.Collections.Generic;

#nullable disable

namespace TravelExpertsMVC.Data
{
    public partial class TripType
    {
        public TripType()
        {
            Bookings = new HashSet<Booking>();
        }

        public string TripTypeId { get; set; }
        public string Ttname { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
