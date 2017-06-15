using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;


namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers

        private ApplicationDbContext _context;

        public CustomersController()
        {
          
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public ActionResult Save(Customer Customer)
        {
            if (Customer.Id == 0)
            {
                _context.Customers.Add(Customer);
            }
            else
            {
                var CustomerInDb = _context.Customers.Single(c => c.Id == Customer.Id);
                CustomerInDb.MembershipTypeId = Customer.MembershipTypeId;
                CustomerInDb.IsSubscribedToNewsletter = Customer.IsSubscribedToNewsletter;
                CustomerInDb.Name = Customer.Name;
                CustomerInDb.BirthDate = Customer.BirthDate;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");

        }

        public ActionResult New()
        {
            var membershipType = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipType
            };

            return View("CustomerForm", viewModel);
        }

        public ViewResult Index()
        {
            var customer = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customer);
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };

            return View("CustomerForm", viewModel);

        }
    }
}