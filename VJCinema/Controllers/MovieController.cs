using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VJCinema.Models;
using VJCinema.ViewModel;

namespace VJCinema.Controllers
{
	public class MovieController : Controller
	{

		private VJCinemaDbContext _context;

		public MovieController()
		{
			_context = new VJCinemaDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
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
				Customers = customers
			};
			return View(viewModel);
		}

		public ActionResult Edit(int id)
		{
			//return Content("id=" + id);

			var movie = _context.Movies.SingleOrDefault(c => c.idMovie == id);

			if (movie == null)
				return HttpNotFound();

			var viewModel = new MovieFormViewModel (movie)
			{
				Genres = _context.Genres.ToList()
			};

			return View("Movie Form", viewModel);
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
				var customerInDb = _context.Movies.Single(c => c.idMovie == movie.idMovie);
				customerInDb.idMovie = movie.idMovie;
				customerInDb.nameMovie = movie.nameMovie;
			}

			_context.SaveChanges();
			return RedirectToAction("Index", "Movie");
		}


	}
}