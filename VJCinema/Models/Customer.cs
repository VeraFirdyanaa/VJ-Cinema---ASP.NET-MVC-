using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VJCinema.Models
{
	[Table("tblCustomer")]
	public class Customer
	{
		[Key]
		public int idCustomer { get; set; }

		[Required(ErrorMessage = "Please enter customer's name.")]
		[StringLength(255)]
		public string nameCustomer { get; set; }

		public bool IsSubscribedToNewsletter { get; set; }
		 
		public MembershipType MembershipType { get; set; }

		[Display(Name ="Membership Type")]
		public byte MembershipTypeId { get; set; }

		[Display(Name = "Date of Birth")]
		[Min18YearsIfAMember]
		public DateTime? Birthdate { get; set; }
	}
}