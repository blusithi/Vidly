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
        public ViewResult Index()
        {
            var customer = new List<Customer>
            {
                new Customer { Name = "Bonele Lusithi", Id = 1 },
                new Customer { Name = "Mabedi Lusithi", Id = 2 }
            };

            var movieViewModel = new CustomerViewModel()
            {
                Customers = customer
            };

            return View(movieViewModel);
        }

        public ActionResult Edit(int Id)
        {
            var customer = new Customer();
            customer.Name = "Shrek";
            customer.Id = 1;

            return View(customer);
        }
    }
}