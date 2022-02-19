using System.Collections.Generic;
using System.Linq;
using TravelExpertsMVC.Data;

//Author: 

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
