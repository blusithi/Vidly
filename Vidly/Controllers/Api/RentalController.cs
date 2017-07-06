using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;
using System.Data.Entity;
using AutoMapper;
namespace Vidly.Controllers.Api
{
    public class RentalController : ApiController
    {
        private ApplicationDbContext db;

        public RentalController()
        {
            db = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = db.Customers.SingleOrDefault(c => c.Id == newRentalDto.CustomerId);
            if (customer == null)
                return BadRequest("Customer Id is not valid");
            if (newRentalDto.MovieIds.Count == 0)
                return BadRequest("No movies have been given");

            var movies = db.Movies.Where(c => newRentalDto.MovieIds.Contains(c.Id));

            if (newRentalDto.MovieIds.Count != newRentalDto.MovieIds.Count)
                return BadRequest("One or more MovieIds are invalid");



            foreach (var movie in movies)
            { if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie not available");
                }
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                movie.NumberAvailable--;
                db.Rentals.Add(rental);
            }

            db.SaveChanges();
            return Ok();
        }
    }
}
