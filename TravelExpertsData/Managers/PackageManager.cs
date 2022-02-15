using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExpertsMVC.Data;

namespace TravelExpertsData.Managers
{
    public static class PackageManager
    {
        public static List<Package> GetPackages()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Packages.ToList();
        }
    }
}
