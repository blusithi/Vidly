using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext db;

        public CustomersController()
        {
            db = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = db.Customers
                //.Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            db.Customers.Add(customer);
            db.SaveChanges();
            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        [HttpPut]
        public void UpdateCustomer(int Id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
  

            var customerInDb = db.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);
            db.SaveChanges();
        }
        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            if(Id <= 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var customerInDb = db.Customers.SingleOrDefault(c => c.Id == Id);
            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            db.Customers.Remove(customerInDb);
            db.SaveChanges();
        }



    }
}
