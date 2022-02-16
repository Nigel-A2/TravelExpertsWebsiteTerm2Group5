using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelExpertsData.Managers;
using TravelExpertsMVC.Data;

// Authors:

namespace TravelExpertsMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            int? customerID = HttpContext.Session.GetInt32("CurrentCustomer");
            if (customerID == null)
            {
                // non-owner logged in
                return RedirectToAction("Login", "Home");
            }
            Customer customer = UserManager.GetCustomer((int)customerID);
            return View(customer);

        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            int? customerID = HttpContext.Session.GetInt32("CurrentCustomer");
            customer.CustomerId = (int)customerID;
            if (ModelState.IsValid)
            {
                UserManager.UpdateCustomer(customer);
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
