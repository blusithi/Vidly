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
    public class MovieController : Controller
    {
        // GET: Movie

        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var genres = _context.Genre.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.GenreId = movie.GenreId;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate= movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");

        }


        public ViewResult Index()
        {
            var movie = _context.Movies.Include(c => c.Genre).ToList();

            return View(movie);
        }



        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == Id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genre.ToList()
            };

            return View("MovieForm", viewModel);
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