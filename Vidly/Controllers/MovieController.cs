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

        private IEnumerable<Movie> GetMovies()
        {
            var movies = new List<Movie>
            {
                new Movie { Name = "Shrek", Id = 1 },
                new Movie { Name = "Spiderman", Id = 2 }
            };

            return movies;
        }

        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }



        public ActionResult Edit(int Id)
        {
            var movie = GetMovies().SingleOrDefault(c => c.Id == Id);

            if (movie == null)
                return HttpNotFound();

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