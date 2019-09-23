using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VJCinema.Controllers;
using VJCinema.Models;

namespace VJCinema.ViewModel
{
	public class MovieFormViewModel
	{
		public IEnumerable<Genre> Genres { get; set; }

		public int? idMovie { get; set; }
		[Required]
		[StringLength(255)]
		public string nameMovie { get; set; }

		public Genre Genre { get; set; }

		[Display(Name = "Gendre")]
		[Required]
		public byte? GendreId { get; set; }

		public DateTime DateAdded { get; set; }

		[Display(Name = "Release Date")]
		[Required]
		public DateTime ReleaseDate { get; set; }

		[Display(Name = "Number in Stock")]
		[Range(1, 20)]
		[Required]
		public byte NumberInStock { get; set; }

		public byte NumberAvailable { get; set; }

		//public Movie Movie { get; set; }

		public string Title
		{
			get
			{
				//if ( Movie != null && Movie.idMovie != 0)
				//	return "Edit Movie";

				//return "New Movie";

				return idMovie != 0 ? "Edit Movie" : "New Movie";
			}
		}

		//mendefinisikan konstruktor yang mengambil objek film
		public MovieFormViewModel()
		{
			//untuk memastikan hidden for terisi
			idMovie = 0;
		}

		//constructor default yang akan digunakan saat membuat film baru
		public MovieFormViewModel(Movie movie)
		{
			idMovie = movie.idMovie;
			nameMovie = movie.nameMovie;
			ReleaseDate = movie.ReleaseDate;
			NumberInStock = movie.NumberInStock;
			GendreId = movie.idGenre;
		}
	}
}