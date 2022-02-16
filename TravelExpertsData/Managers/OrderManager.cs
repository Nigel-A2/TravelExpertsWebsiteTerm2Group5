using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExpertsMVC.Data;

namespace TravelExpertsData.Managers
{
    public static class OrderManager
    {
        public static Customer GetCustomerInfo(int customerId)
        {

            TravelExpertsContext db = new TravelExpertsContext();

            Customer customer = db.Customers.Find(customerId);

            return customer;
        }

        public static void BookPackage(Booking booking)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            db.Bookings.Add(booking);
            db.SaveChanges();
        }
    }
}
