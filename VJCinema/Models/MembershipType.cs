using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VJCinema.Models
{
	public class MembershipType
	{
		public byte idMembershipType  { get; set; }
		[Required]
		public string nameMember { get; set; }
		public short SignUpFee { get; set; }
		public byte DurationInMonths { get; set; }
		public byte DiscountRates { get; set; }

		public static readonly byte Unknown = 0;
		public static readonly byte PayAsYouGo = 1;
	}
} 