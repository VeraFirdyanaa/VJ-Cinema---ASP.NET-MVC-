using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VJCinema.Controllers;

namespace VJCinema.Models
{
	public class Movie
	{
		public int idMovie { get; set; }
		[Required]
		[StringLength(255)]
		public string nameMovie { get; set; }
		public Genre Genre { get; set; }

		[Display(Name = "Gendre")]
		[Required]
		public byte GendreId { get; set; }

		public DateTime DateAdded { get; set; }
		
		[Display(Name = "Release Date")]
		public DateTime ReleaseDate { get; set; }

		[Display(Name = "Number in Stock")]
		[Range(1,20)]
		public byte NumberInStock { get; set; }

		public byte NumberAvailable { get; set; }
	}
}