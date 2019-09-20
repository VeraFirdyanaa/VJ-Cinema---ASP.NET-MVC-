using System;
using System.Collections.Generic;
using System.Data.Entity; 
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VJCinema.Models;

namespace VJCinema.Controllers
{
	public class CustomerController : Controller
	{
		private VJCinemaDbContext _context;

		public CustomerController()
		{
			_context = new VJCinemaDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ActionResult New()
		{
			return View();
		}
		// GET: Customer
		public ActionResult Index()
		{
			var customers = _context.Movie.Include(c => c.MembershipType).ToList();
			return View(customers);
		}

		//untuk aksi detail
		public ActionResult Details(int id)
		{
			var customer = _context.Movie.SingleOrDefault(c => c.idCustomer == id);
			if (customer == null)
				return HttpNotFound();
			return View(customer);
		}

		[HttpPost]
		public ActionResult Save(Customer customer)
		{
			if(customer.idCustomer == 0)
			{
				_context.Movie.Add(customer);
			}
			else
			{
				var customerInDb = _context.Movie.Single(c => c.idCustomer == customer.idCustomer);
				customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
				customerInDb.nameCustomer = customer.nameCustomer;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
				customerInDb.Birthdate = customer.Birthdate;
			}

			_context.SaveChanges();
			return View("Index", "Customer");
		}
	}
}