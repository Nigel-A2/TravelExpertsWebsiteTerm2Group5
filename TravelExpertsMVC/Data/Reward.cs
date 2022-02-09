using System;
using System.Collections.Generic;

#nullable disable

namespace TravelExpertsMVC.Data
{
    public partial class Reward
    {
        public Reward()
        {
            CustomersRewards = new HashSet<CustomersReward>();
        }

        public int RewardId { get; set; }
        public string RwdName { get; set; }
        public string RwdDesc { get; set; }

        public virtual ICollection<CustomersReward> CustomersRewards { get; set; }
    }
}
