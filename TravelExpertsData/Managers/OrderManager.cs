using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExpertsMVC.Data;

//Author: Filip
namespace TravelExpertsData.Managers
{
    public static class OrderManager
    {
        //returns customer info based on given id
        public static Customer GetCustomerInfo(int customerId)
        {

            TravelExpertsContext db = new TravelExpertsContext();

            Customer customer = db.Customers.Find(customerId);

            return customer;
        }

        //adds booking to db
        public static void BookPackage(Booking booking)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            db.Bookings.Add(booking);
            db.SaveChanges();
        }
    }
}
