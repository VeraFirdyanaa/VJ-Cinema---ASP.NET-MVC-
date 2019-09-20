using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VJCinema.Controllers
{
	public class Genre
	{
		public int idGenre { get; set; }

		[Required]
		[StringLength(255)]
		public string nameGenre { get; set; }
	}
}