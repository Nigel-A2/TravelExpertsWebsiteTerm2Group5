using System;
using System.Collections.Generic;

#nullable disable

namespace TravelExpertsMVC.Data
{
    public partial class Affiliation
    {
        public Affiliation()
        {
            SupplierContacts = new HashSet<SupplierContact>();
        }

        public string AffilitationId { get; set; }
        public string AffName { get; set; }
        public string AffDesc { get; set; }

        public virtual ICollection<SupplierContact> SupplierContacts { get; set; }
    }
}
