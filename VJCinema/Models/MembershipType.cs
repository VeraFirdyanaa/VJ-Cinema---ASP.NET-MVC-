using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VJCinema.Models
{
	[Table("tblMembership")]
	public class MembershipType
	{
		[Key]
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