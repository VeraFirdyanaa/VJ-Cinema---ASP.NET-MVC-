using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using VJCinema.Controllers;

namespace VJCinema.Models
{
	[Table("tblMovie")]
	public class Movie
	{
		[Key]
		public int idMovie { get; set; }

		[Required]
		[StringLength(255)]
		public string nameMovie { get; set; }

		//FK
		public Genre Genre { get; set; }

		[Display(Name = "Genre")]
		[Required]
		public byte idGenre { get; set; }

		public DateTime DateAdded { get; set; }

		[Display(Name = "Release Date")]
		public DateTime ReleaseDate { get; set; }

		[Display(Name = "Number in Stock")]
		[Range(1, 20)]
		public byte NumberInStock { get; set; }
	}
}