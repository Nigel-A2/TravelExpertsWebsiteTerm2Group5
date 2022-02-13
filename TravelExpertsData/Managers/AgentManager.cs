using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExpertsMVC.Data;

namespace TravelExpertsData.Managers
{
    public class AgentManager
    {

        /// <summary>
        /// get list of agents
        /// </summary>
        /// <returns>list of all agents</returns>
        public static List<Agent> GetAgents()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Agents.ToList();
        }

        public static List<Agency> GetAgencies()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Agencies.ToList();
        }
    }
}
