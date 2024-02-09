using Application;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MoviesController : Controller

    {

        IMovie _movie;
        IGenre _genre;

        public MoviesController(IMovie movie, IGenre genre)
        {
            _movie = movie;
            _genre = genre;

        }

        [Authorize(Policy ="User")]
        public async Task<IActionResult> Index()
        {

            var movies = await _movie.GetAllMovie();

            return View(movies);
        }


        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Genres = new SelectList(await _genre.GetAllGenres(), "GenreId", "GenreName");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMovieViewModel movie)
        {

            if (!ModelState.IsValid)
            {

                return View(movie);
            }

            await _movie.CreateMovie(movie);

            return RedirectToAction("Index");
        }

    }
}
