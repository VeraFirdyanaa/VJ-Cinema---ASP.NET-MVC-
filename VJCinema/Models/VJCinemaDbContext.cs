using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VJCinema.Controllers;

namespace VJCinema.Models
{
	public class VJCinemaDbContext : DbContext
	{
		public VJCinemaDbContext() : base("Name : DefaultConnection")
		{

		}
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<MembershipType> MembershipTypes { get; set; }
		public DbSet<Genre> Genres { get; set; }
	}
}