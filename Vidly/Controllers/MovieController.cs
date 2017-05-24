using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ViewResult Index()
        {
           var movies = new List<Movie>
            {
                new Movie { Name = "Shrek", Id = 1 },
                new Movie { Name = "Spiderman", Id = 2 }
            };

            var movieViewModel = new MovieViewModel()
            {
                Movies = movies
            };

            return View(movieViewModel);
        }

        public ViewResult Random()
        {
            var movie = new Movie();
            movie.Name = "Shreak";

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var movie = new Movie();
            movie.Name = "Shrek";
            movie.Id = 1;

            return View(movie);
        }

        [Route("movie/released/{year:regex(\\d{4})}/{month:range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            var movie = new Movie();
            movie.Name = "Shreak";
            ViewData["Movie"] = movie;
            return View();
        }
    }
}