using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TravelExpertsData.Managers;
using TravelExpertsMVC.Data;
using TravelExpertsMVC.Models;

// Author: William

namespace TravelExpertsMVC.Controllers
{

    public class OrderController : Controller
    {
        // GET: OrderController
        public ActionResult Index()
        {
            int? customerID = HttpContext.Session.GetInt32("CurrentCustomer");
            if (customerID == null)
            {
                // non-owner logged in
                return RedirectToAction("Login", "Home");
            }
            Customer customer = OrderManager.GetCustomerInfo((int)customerID);
            return View(customer);
        }

        // GET: HomeController/Packages
        public ActionResult Packages()
        {
            PackageViewModel packageView = new PackageViewModel();
            packageView.Packages = PackageManager.GetPackages();
            return View(packageView);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(Package package)
        {
            Console.WriteLine("ABCD");
            return View(package);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order(IFormCollection collection)
        {
            int numberOfPeople = Convert.ToInt32(collection["people"]);
            int packageId = Convert.ToInt32(collection["package"]);
            string tripType = collection["tripType"];
            try
            {
                Booking booking = new Booking();
                booking.BookingDate = DateTime.Now;
                booking.CustomerId = (int)HttpContext.Session.GetInt32("CurrentCustomer");
                booking.PackageId = packageId;
                booking.TripTypeId = tripType;
                booking.TravelerCount = numberOfPeople;
                OrderManager.BookPackage(booking);
                return RedirectToAction("ThankYou", "Home");
            }
            catch
            {
                return RedirectToAction("Packages");
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
