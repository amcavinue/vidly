using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    using System.IO;
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        // Get: movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            if (User.IsInRole("CanManageMovies"))
            {
                return View("List", movies);
            }
            
            return View("ReadOnlyList", movies);
        }
        
        // GET: Movies/Details/{id}
        [Route("movies/details/{id}")]
        public ActionResult Movie(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        public ActionResult New()
        {
            var viewModel = new NewMovieViewModel
            {
                Movie = new Movie(),
                Genres = _context.Genres.ToList()
            };

            return View("New", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, responseText = "It failed." }, JsonRequestBehavior.AllowGet);
            }

            movie.UpdateDb(Request, HttpContext, _context, movie);
            return Json(new { success = true, responseText = "It worked." }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("New", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return Json(new { success = false, responseText = "It failed." }, JsonRequestBehavior.AllowGet);
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Json(new { success = true, responseText = "It worked." }, JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.Include(m => m.Genre).ToList();
        }
    }
}
