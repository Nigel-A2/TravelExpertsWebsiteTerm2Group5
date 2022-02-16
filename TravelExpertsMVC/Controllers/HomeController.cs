using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelExpertsData.Managers;
using TravelExpertsMVC.Data;
using TravelExpertsMVC.Models;

namespace TravelExpertsMVC
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: HomeController/Contact
        public ActionResult Contact()
        {

            ContactViewModel contactView = new ContactViewModel();
            contactView.Agencies = AgentManager.GetAgencies();
            contactView.Agents = AgentManager.GetAgents();

            //return View(contactView);
            //List<Agent> agents = null;
            //try
            //{
            //    agents = AgentManager.GetAgents();
            //}
            //catch (Exception)
            //{
            //    TempData["Message"] = "Database connection problem. Try again later.";
            //    TempData["IsError"] = true;
            //}

            //List<Agency> agencies = null;
            //try
            //{
            //    agencies = AgentManager.GetAgencies();
            //}
            //catch (Exception)
            //{
            //    TempData["Message"] = "Database connection problem. Try again later.";
            //    TempData["IsError"] = true;
            //}
            return View(contactView);
        }

        // GET: HomeController/Packages
        public ActionResult Packages()
        {
            PackageViewModel packageView = new PackageViewModel();
            packageView.Packages = PackageManager.GetPackages();
            return View(packageView);
        }

        // GET: HomeController/Login
        public IActionResult Login(string returnUrl = "")
        {
            if (returnUrl != null)
                TempData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Customer customer)
        {
            Customer cust = UserManager.Authenticate(customer.CustFirstName, customer.CustLastName, customer.CustPassword);
            if (cust == null) // authentication failed
            {
                return View(); // stay on the login page
            }

            // using cookies

            //store customer ID in session object
            HttpContext.Session.SetInt32("CurrentCustomer", (int)cust.CustomerId);
            // user != null -- authentication passed
            List<Claim> claim = new List<Claim>
            {
                new Claim(ClaimTypes.Name, cust.CustFirstName)
				//new Claim("FullName", cust.ID)
			};

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claim, "Cookies"); // cookies authetication
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync("Cookies", claimsPrincipal);

            if (String.IsNullOrEmpty(TempData["ReturnUrl"].ToString()))
                return RedirectToAction("Index"); 
            else
                return Redirect(TempData["ReturnUrl"].ToString());
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        // GET: HomeController/CustomerHome
        public ActionResult CustomerHome()
        {
            return View();
        }

        [Authorize]
        // GET: HomeController/Order
        public ActionResult Order()
        {
            return View();
        }

        // GET: HomeController/OrderPlaced
        public ActionResult OrderPlaced()
        {
            return View();
        }

        // GET: HomeController/Register
        public IActionResult Register()
        {
            return View(new Customer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Customer customer)
        {
            try 
            {
                if(customer.CustBusPhone == null)
                {
                    customer.CustBusPhone = customer.CustHomePhone;
                }
                // from movies example
                UserManager.AddCustomer(customer);
                return RedirectToAction("ThankYou");
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                return View();
            }
        }


        // GET: HomeController/ThankYou
        public IActionResult ThankYou(Customer customer)
        {
            return View();
        }

        // POST: HomeController/Create
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

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
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

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
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
