using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VJCinema.Models;
using VJCinema.ViewModel;

namespace VJCinema.Controllers
{
	public class MovieController : Controller
	{

		private ApplicationDbContext _context;

		public MovieController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ViewResult Index()
		{
			var movies = _context.Movies.Include(m => m.Genre).ToList();

			return View(movies);
		}

		public ViewResult New()
		{
			var genres = _context.Genres.ToList();

			var viewModel = new MovieFormViewModel
			{
				Genres = genres
			};

			return View("MovieForm", viewModel);
		}

		public ActionResult Edit(int id)
		{
			//return Content("id=" + id);

			var movie = _context.Movies.SingleOrDefault(c => c.idMovie == id);

			if (movie == null)
				return HttpNotFound();

			var viewModel = new MovieFormViewModel(movie)
			{
				Genres = _context.Genres.ToList()
			};

			return View("MovieForm", viewModel);
		}

		public ActionResult Details(int id)
		{
			var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.idGenre == id);

			if (movie == null)
				return HttpNotFound();

			return View(movie);
		}

		// GET: Movie
		public ActionResult Random()
		{
			var movie = new Movie() { nameMovie = "Shrek!" };
			var customers = new List<Customer>
			{
				//ambil dari ViewModel {"nama model" = Nama Cust}
				new Customer { nameCustomer = "Customer 1"},
				new Customer { nameCustomer = "Customer 2"}
			};

			var viewModel = new RandomMovieViewModel
			{
				Movie = movie,
				Customers = customers
			};
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new MovieFormViewModel(movie)
				{
					Genres = _context.Genres.ToList()
				};
				return View("MovieForm", viewModel);
			}
			 
			if (movie.idMovie == 0)
			{
				movie.DateAdded = DateTime.Now;
				_context.Movies.Add(movie);
			}
			else
			{
				var movieInDb = _context.Movies.Single(m => m.idMovie == movie.idMovie);
				movieInDb.nameMovie = movie.nameMovie;
				movieInDb.idGenre = movie.idGenre;
				movieInDb.ReleaseDate = movie.ReleaseDate;
				movieInDb.NumberInStock = movie.NumberInStock;

			}
			_context.SaveChanges();
			return RedirectToAction("Index", "Movie");
		}
	}
}