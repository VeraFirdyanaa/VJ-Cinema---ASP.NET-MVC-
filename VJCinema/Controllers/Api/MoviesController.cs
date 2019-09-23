using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VJCinema.Dtos;
using VJCinema.Models;

namespace VJCinema.Controllers.Api
{
    public class MoviesController : ApiController
    {
		private VJCinemaDbContext _context;

		public MoviesController()
		{
			_context = new VJCinemaDbContext();
		}

		public IEnumerable<MovieDto> GetMovies ()
		{
			return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
		}

		public IHttpActionResult GetMovie(int id)
		{
			var movie = _context.Movies.SingleOrDefault(m => m.idMovie == id);

			if (movie == null)
				return NotFound();

			return Ok(Mapper.Map<Movie, MovieDto>(movie));
		}

		[HttpPost]
		public IHttpActionResult CreateMovie(MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var movie = Mapper.Map<MovieDto, Movie>(movieDto);
			_context.Movies.Add(movie);
			_context.SaveChanges();

			movieDto.idMovie = movie.idMovie;
			return Created(new Uri(Request.RequestUri + "/" + movie.idMovie), movieDto);
		}

		[HttpPut]
		public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var movieInDb = _context.Movies.SingleOrDefault(m => m.idMovie == id);

			if (movieInDb == null)
				return NotFound();

			Mapper.Map(movieDto, movieInDb);

			_context.SaveChanges();
			return Ok();
		}

		[HttpDelete]
		public IHttpActionResult DeleteMovie(int id)
		{
			var movieInDb = _context.Movies.SingleOrDefault(m => m.idGenre == id);

			if (movieInDb == null)
				return NotFound();

			_context.Movies.Remove(movieInDb);
			_context.SaveChanges();

			return Ok();
		}
	}
}
