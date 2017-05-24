using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers

        private IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer { Name = "Bonele Lusithi", Id = 1 },
                new Customer { Name = "Mabedi Lusithi", Id = 2 }
            };

            return customers;
        }

        public ViewResult Index()
        {
            var customer = GetCustomers();

            return View(customer);
        }

        public ActionResult Edit(int Id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);

        }
    }
}