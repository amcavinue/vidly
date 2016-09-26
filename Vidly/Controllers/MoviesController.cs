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
                var viewModel = new NewMovieViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return Json(new { success = false, responseText = "It failed." }, JsonRequestBehavior.AllowGet);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var file = Request.Files["img-file"];

                // Update database fields.
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Stock = movie.Stock;

                if (file != null && file.ContentLength != 0)
                {
                    // Save file to server and db.
                    var fileName = Path.GetFileName(file.FileName);
                    var dir = "~/Content/uploads";
                    var absDir = HttpContext.Server.MapPath(dir);
                    if (!Directory.Exists(absDir))
                    {
                        Directory.CreateDirectory(absDir);
                    }
                    movieInDb.FileLocation = dir + "/" + fileName;
                    file.SaveAs(Path.Combine(Server.MapPath(dir), fileName));
                }
            }

            _context.SaveChanges();

            return Json(new { success = true, responseText = "It worked." }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

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
    }
}
