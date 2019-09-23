using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VJCinema.Dtos;
using VJCinema.Models;

namespace VJCinema.Controllers.Api
{
	public class CustomersController : ApiController
	{
		public ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		//GET/ api/customers
		[HttpGet]
		public IHttpActionResult GetCustomers()
		//public IEnumerable<CustomerDto> GetCustomers()
		{
			//var customersQuery = _context.Customers.Include(c => c.MembershipType);

			//if (!String.IsNullOrWhiteSpace(query))
			//	customersQuery = customersQuery.Where(c => c.nameCustomer.Contains(query));

			var customerDtos = _context.Customers.ToList().Select(Mapper.Map< Customer, CustomerDto >);

			return Ok(customerDtos);
			//return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
		}

		//GET/api/customers/1
		[HttpGet]
		public IHttpActionResult GetCustomer(int id)
		//sebelum menggunakan IHttpActionResult 
		//public CustomerDto GetCustomer(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.idCustomer == id);

			if (customer == null)
				return NotFound();
			//sebelum menggunakan IHttpActionResult 
			//throw new HttpResponseException(HttpStatusCode.NotFound);

			return Ok(Mapper.Map<Customer, CustomerDto>(customer));
			//sebelum menggunakan IHttpActionResult 
			//return Mapper.Map<Customer, CustomerDto>(customer);
			//sebelum menggunakan Dto
			//return customer;
		}

		//POST/api/customer
		[HttpPost]
		public IHttpActionResult CreateCustomer(CustomerDto customerDto)
		//sebelum menggunakan IHttpActionResult
		//public CustomerDto CreateCustomer(CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();
				//throw new HttpResponseException(HttpStatusCode.BadRequest);

			var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
			_context.Customers.Add(customer);
			_context.SaveChanges();

			customerDto.idCustomer = customer.idCustomer;

			return Created(new Uri(Request.RequestUri + "/" + customer.idCustomer), customerDto);
		}

		//PUT/api/customer/1
		[HttpPut]
		public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
		//sebelum menggunakan IHttpResult
		//public void UpdateCustomer(int id, CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
				//sebelum menggunakan IHttpActionResult
				//throw new HttpResponseException(HttpStatusCode.BadRequest);
				return BadRequest();

			//sebelum menggunakan Auto Mapper
			var customerInDb = _context.Customers.SingleOrDefault(c => c.idCustomer == id);

			if (customerInDb == null)
				//sebelum menggunakan IHttpActionResult
				//throw new HttpResponseException(HttpStatusCode.NotFound);
				return NotFound();

			Mapper.Map(customerDto, customerInDb);
			//Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
			//customerInDb.nameCustomer = customer.nameCustomer;
			//customerInDb.Birthdate = customer.Birthdate;
			//customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
			//customerInDb.MembershipTypeId = customer.MembershipTypeId;

			_context.SaveChanges();
			return Ok();
		}

		//DELETE/api/customer/1
		[HttpDelete]
		public IHttpActionResult DeleteCustomer(int id)
		{
			var customerInDb = _context.Customers.SingleOrDefault(c => c.idCustomer == id);

			if (customerInDb == null)
				return NotFound();
			//sebelum menggunakan IHttpActionResult
			//throw new HttpResponseException(HttpStatusCode.NotFound);

			_context.Customers.Remove(customerInDb);
			_context.SaveChanges();

			return Ok();
		}
    }
}
