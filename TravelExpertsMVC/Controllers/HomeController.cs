using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return View();
        }

        // GET: HomeController/Packages
        public ActionResult Packages()
        {
            return View();
        }

        // GET: HomeController/Login
        public ActionResult Login()
        {
            return View();
        }

        // GET: HomeController/CustomerHome
        public ActionResult CustomerHome()
        {
            return View();
        }

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
        public ActionResult Register()
        {
            return View();
        }

        // GET: HomeController/ThankYou
        public ActionResult ThankYou()
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
