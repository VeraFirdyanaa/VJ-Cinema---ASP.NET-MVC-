using System.Data.Entity; 
using System.Linq;
using System.Web.Mvc;
using VJCinema.Models;
using VJCinema.ViewModel;

namespace VJCinema.Controllers
{
	public class CustomerController : Controller
	{
		private ApplicationDbContext _context;

		//GET/api/customer
		public CustomerController()
		{
			_context = new ApplicationDbContext();
		}

		//GET/api/customer/1
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ActionResult New()
		{
			var membershipTypes = _context.MembershipTypes.ToList();
			var viewModel = new CustomerFormViewModel
			{
				Customer = new Customer(),
				MembershipTypes = membershipTypes
			};
			return View("CustomerForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Customer customer)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new CustomerFormViewModel
				{
					Customer = customer,
					MembershipTypes = _context.MembershipTypes.ToList()
				};
				return View("CustomerForm", viewModel);
			}
			if (customer.idCustomer == 0)
				_context.Customers.Add(customer);
			else
			{
				var customerInDb = _context.Customers.Single(c => c.idCustomer == customer.idCustomer);

				//TryUpdateModel(customerInDb, "", new string[] { "Name", "Email"});

				// Mapper.Map(customer, customerInDb); 

				//mengatur masing2 property , bisa juga dengan menggunakan AutoMapper
				customerInDb.nameCustomer = customer.nameCustomer;
				customerInDb.Birthdate = customer.Birthdate;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
				customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
			}
			_context.SaveChanges();

			return RedirectToAction("Index", "Customers"); 
		}

		// GET: Customer
		public ViewResult  Index()
		{
			//var customers = _context.Customers.Include(c => c.MembershipType).ToList();
			return View();
		}

		//untuk aksi detail
		public ActionResult Details(int id)
		{
			var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.idCustomer == id);
			if (customer == null)
				return HttpNotFound();
			return View(customer);
		}

		public ActionResult Edit(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.idCustomer == id);

			if (customer == null)
				return HttpNotFound();

			var viewModel = new CustomerFormViewModel
			{
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList()
			};
			return View("CustomerForm", viewModel);
		}
	}
}