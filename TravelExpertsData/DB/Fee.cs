using System;
using System.Collections.Generic;

#nullable disable

namespace TravelExpertsMVC.Data
{
    public partial class Fee
    {
        public Fee()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public string FeeId { get; set; }
        public string FeeName { get; set; }
        public decimal FeeAmt { get; set; }
        public string FeeDesc { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
