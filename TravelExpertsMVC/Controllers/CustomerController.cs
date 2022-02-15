using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpertsData.Managers;
using TravelExpertsMVC.Data;

namespace TravelExpertsMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditProfile()
        {
            int? customerID = HttpContext.Session.GetInt32("CurrentCustomer");
            if (customerID == null)
            {
                // non-owner logged in
                return RedirectToAction("Login", "Customer");
            }
            Customer customer = UserManager.GetCustomer((int)customerID);
            return View(customer);

        }

        // GET: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(Customer customer)
        {
            int? customerID = HttpContext.Session.GetInt32("CurrentCustomer");
            customer.CustomerId = (int)customerID;
            if (ModelState.IsValid)
            {
                Customer cust = UserManager.UpdateCustomer(customer);
                if (cust == null)
                {
                    return View(customer);
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(customer);
            }
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
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

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            //get customer
            //fill form with current data
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
