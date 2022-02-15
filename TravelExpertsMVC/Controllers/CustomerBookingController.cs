using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpertsData.DBViews;
using TravelExpertsData.Managers;

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
                // non-owner logged in
                return RedirectToAction("Login", "Home");
            }
            List<CustomerBooking> bookings = BookingManager.GetCustomerBookings((int)customerID);
            return View(bookings);
        }

        // GET: CustomerBookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerBookingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerBookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerBookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerBookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerBookingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerBookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
