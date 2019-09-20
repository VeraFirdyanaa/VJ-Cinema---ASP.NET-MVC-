using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VJCinema.Models
{
	public class Customer
	{
		public int idCustomer { get; set; }
		[Required]
		public string nameCustomer { get; set; }
		public bool IsSubscribedToNewsletter { get; set; }
		public MembershipType MembershipType { get; set; }
		public byte MembershipTypeId { get; set; }
		[Display(Name = "Date of Birth")]
		public DateTime? Birthdate { get; set; }
	}
}