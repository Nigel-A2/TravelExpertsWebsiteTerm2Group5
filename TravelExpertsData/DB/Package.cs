using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TravelExpertsMVC.Data
{
    public partial class Package
    {
        public Package()
        {
            Bookings = new HashSet<Booking>();
            PackagesProductsSuppliers = new HashSet<PackagesProductsSupplier>();
        }

        public int PackageId { get; set; }

        [Display(Name = "Package Name")]
        public string PkgName { get; set; }

        [Display(Name = "Departure Date")]
        public DateTime? PkgStartDate { get; set; }

        [Display(Name = "Return Date")]
        [DisplayFormat(DataFormatString = "{0:MMM dd yyyy")]
        public DateTime? PkgEndDate { get; set; }

        [Display(Name = "Description")]
        public string PkgDesc { get; set; }

        [Display(Name = "Price")]
        public decimal PkgBasePrice { get; set; }

        public decimal? PkgAgencyCommission { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<PackagesProductsSupplier> PackagesProductsSuppliers { get; set; }

    }
}
