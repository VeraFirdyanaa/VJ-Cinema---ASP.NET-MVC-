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
		public ActionResult Edit(int id)
		{
			return Content("id=" + id);
		}
	}
}