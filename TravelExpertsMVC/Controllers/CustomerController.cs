using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelExpertsData.Managers;
using TravelExpertsMVC.Data;

// Authors: Filip,

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
            return View(customer); //show customer info if logged in

        }

        [HttpPost]
        public ActionResult Edit(Customer customer) //update information with new info from forms
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
    }
}
