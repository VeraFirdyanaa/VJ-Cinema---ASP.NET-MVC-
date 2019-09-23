using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VJCinema.Models;

namespace VJCinema.Dtos
{
	public class CustomerDto
	{
		public int idCustomer { get; set; }

		[Required]
		[StringLength(255)]
		public string nameCustomer { get; set; }

		public bool IsSubscribedToNewsletter { get; set; }

		public byte MembershipTypeId { get; set; }

		public MembershipTypeDto MembershipType { get; set; }

		//[Min18YearsIfAMember]
		public DateTime? Birthdate { get; set; }
	}
}