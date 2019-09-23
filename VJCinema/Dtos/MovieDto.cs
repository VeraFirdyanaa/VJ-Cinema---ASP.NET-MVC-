using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VJCinema.Dtos
{
	public class MovieDto
	{
		public int idMovie { get; set; }

		[Required]
		[StringLength(255)]
		public string nameMovie { get; set; }
		
		[Required]
		public byte idGenre { get; set; }

		public DateTime DateAdded { get; set; }

		public DateTime ReleaseDate { get; set; }

		[Range(1, 20)]
		public byte NumberInStock { get; set; }
	}
}