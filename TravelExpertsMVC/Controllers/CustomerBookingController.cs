using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TravelExpertsData.DBViews;
using TravelExpertsData.Managers;

//Authors: Filip, 

namespace TravelExpertsMVC.Controllers
{
    public class CustomerBookingController : Controller
    {
        // GET: CustomerBookingController
        public ActionResult Index()
        {
            int? customerID = HttpContext.Session.GetInt32("CurrentCustomer");
            if (customerID == null)
            {
                // no logged in user
                return RedirectToAction("Login", "Home");
            }
            List<CustomerBooking> bookings = BookingManager.GetCustomerBookings((int)customerID);
            return View(bookings);//returns bookings if logged in
        }
    }
}