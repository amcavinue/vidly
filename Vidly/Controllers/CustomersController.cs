using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = new List<string>();

                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }

                var response = new
                {
                    success = false,
                    responseText = "It failed.",
                    errors = errors.ToArray()
                };

                return Json(response, JsonRequestBehavior.AllowGet);
            }

            customer.UpdateDb(_context, customer);
            return Json(new { success = true, responseText = "It worked." }, JsonRequestBehavior.AllowGet);
        }

        // GET: Customers
        public ActionResult Index()
        {
            // Use Entity Framework to get the customers from the database & iterate over it immediately.
            // var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            var membershipTypes = _context.MembershipTypes.ToList();

            return View(membershipTypes);
        }

        // GET: Customers/Details/{id}
        [Route("customers/details/{id}")]
        public ActionResult Customer(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer, 
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("New", viewModel);
        }
    }
}