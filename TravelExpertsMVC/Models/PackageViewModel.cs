using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TravelExpertsMVC.Data;

namespace TravelExpertsMVC.Models
{
    public class PackageViewModel
    {
        public IEnumerable<Package> Packages { get; set; }

        public int PackageId { get; set; }

        [Display(Name = "Package Name")]
        public string PkgName { get; set; }

        [Display(Name = "Departure Date")]
        public DateTime? PkgStartDate { get; set; }

        [Display(Name = "Return Date")]
        public DateTime? PkgEndDate { get; set; }

        [Display(Name = "Description")]
        public string PkgDesc { get; set; }

        [Display(Name = "Price")]
        public decimal PkgBasePrice { get; set; }

        public decimal? PkgAgencyCommission { get; set; }
    }
}
