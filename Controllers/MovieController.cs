// TODO: Shareen Banu Shaik
// TODO: Student ID: 9081360

using Microsoft.AspNetCore.Mvc;
using MoviesApp.Models;
using MoviesApp.Repositories;

namespace MoviesApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IRepository _repo;

        // Allowed genres for dropdown
        private static readonly string[] AllowedGenres =
        {
            "Action", "Comedy", "Drama", "Horror", "SciFi"
        };

        public MovieController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: /Movie/Index
        public IActionResult Index()
        {
            var movies = _repo.GetAll();
            return View(movies);
        }

        // GET: /Movie/Details/5
        public IActionResult Details(int id)
        {
            if (id <= 0) return BadRequest();

            var movie = _repo.GetById(id);
            if (movie == null) return NotFound();

            return View(movie);
        }

        // GET: /Movie/Create
        public IActionResult Create()
        {
            ViewBag.Genres = AllowedGenres;
            return View();
        }

        // POST: /Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            ViewBag.Genres = AllowedGenres;

            if (!ModelState.IsValid)
                return View(movie);

            _repo.Add(movie);
            _repo.Save();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Movie/Edit/5
        public IActionResult Edit(int id)
        {
            if (id <= 0) return BadRequest();

            var movie = _repo.GetById(id);
            if (movie == null) return NotFound();

            ViewBag.Genres = AllowedGenres;
            return View(movie);
        }

        // POST: /Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Movie movie)
        {
            ViewBag.Genres = AllowedGenres;

            if (id != movie.Id) return BadRequest();

            if (!ModelState.IsValid)
                return View(movie);

            _repo.Update(movie);
            _repo.Save();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Movie/Delete/5  (Confirmation page)
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var movie = _repo.GetById(id);
            if (movie == null) return NotFound();

            return View(movie);
        }

        // POST: /Movie/DeleteConfirmed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _repo.GetById(id);
            if (movie == null) return NotFound();

            _repo.Delete(movie);
            _repo.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}