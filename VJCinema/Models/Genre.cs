using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VJCinema.Controllers
{
	[Table("tblGenre")]
	public class Genre
	{
		[Key]
		public int idGenre { get; set; }

		[Required]
		[StringLength(255)]
		public string nameGenre { get; set; }
	}
}