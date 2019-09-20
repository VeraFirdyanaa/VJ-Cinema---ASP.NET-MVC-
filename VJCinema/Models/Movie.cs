using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VJCinema.Models
{
	public class Movie
	{
		public int idMovie { get; set; }
		[Required]
		public string nameMovie { get; set; }
	}
}