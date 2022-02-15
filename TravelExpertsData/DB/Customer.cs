using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TravelExpertsMVC.Data
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
            CreditCards = new HashSet<CreditCard>();
            CustomersRewards = new HashSet<CustomersReward>();
        }

        public int CustomerId { get; set; }
        public string CustFirstName { get; set; }
        public string CustLastName { get; set; }
        public string CustAddress { get; set; }
        public string CustCity { get; set; }
        public string CustProv { get; set; }
        public string CustPostal { get; set; }
        public string CustCountry { get; set; }

        
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}")]
        public string CustHomePhone { get; set; }


        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}")]
        public string CustBusPhone { get; set; }
        [EmailAddress]
        public string CustEmail { get; set; }
        public int? AgentId { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [Compare("ConfirmPassword")]
        public string CustPassword { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [Display(Name = "Confirm Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        public virtual ICollection<CustomersReward> CustomersRewards { get; set; }
    }
}
