using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpertsMVC.Data;

namespace TravelExpertsMVC.Models
{

    /// <summary>
    /// Facilitates using two models in a single view. 
    /// </summary>
    /// William Rust -- February 13, 2022
    public class ContactViewModel
    {
        public IEnumerable<Agent> Agents { get; set; }

        public IEnumerable<Agency> Agencies { get; set; }

    }
}
