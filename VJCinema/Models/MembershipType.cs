using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VJCinema.Models
{
	public class MembershipType
	{
		public byte idMembershipType  { get; set; }
		public short SignUpFee { get; set; }
		public byte DurationInMonths { get; set; }
		public byte DiscountRates { get; set; }
	}
}