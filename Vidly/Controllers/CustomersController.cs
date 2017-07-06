using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;
using System.Runtime.Caching;


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
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel(customer)
                {
                    MembershipTypes = _context.MembershipType.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var CustomerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                CustomerInDb.MembershipTypeId = customer.MembershipTypeId;
                CustomerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                CustomerInDb.Name = customer.Name;
                CustomerInDb.BirthDate = customer.BirthDate;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");

        }
        [Authorize(Roles = RoleName.CanManageCustomers)]
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
            if (MemoryCache.Default["Genres"] == null)
            {
                MemoryCache.Default["Genres"] = _context.Genre.ToList();
            }

            var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;

            if(User.IsInRole(RoleName.CanManageCustomers))
                return View("List");

                return View("ReadOnlyList");
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes = _context.MembershipType.ToList()
            };

            return View("CustomerForm", viewModel);

        }
    }
}