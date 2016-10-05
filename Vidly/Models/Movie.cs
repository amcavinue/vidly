using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    using System.IO;
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Range(1, 20)]
        public int Stock { get; set; }
        public string FileLocation { get; set; }
        public void SaveImage(HttpPostedFileBase file, HttpContextBase _httpContext)
        {
            if (file != null && file.ContentLength != 0)
            {
                if (FileLocation != null)
                {
                    // Delete the old file.
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + FileLocation);
                }

                // Save file to server and db.
                var fileName = Path.GetFileName(file.FileName);
                var dir = "Content/uploads";
                var absDir = _httpContext.Server.MapPath(dir);
                if (!Directory.Exists(absDir))
                {
                    Directory.CreateDirectory(absDir);
                }
                file.SaveAs(Path.Combine(_httpContext.Server.MapPath("~/" + dir), fileName));

                FileLocation = dir + "/" + fileName;
            }
        }

        public void UpdateDb(HttpRequestBase _request, HttpContextBase _httpContext, ApplicationDbContext _context, Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                // Update database fields.
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Stock = movie.Stock;

                // Save the image file.
                var file = _request.Files["Movie.FileLocation"];
                movieInDb.SaveImage(file, _httpContext);
            }

            _context.SaveChanges();
        }
    }
}