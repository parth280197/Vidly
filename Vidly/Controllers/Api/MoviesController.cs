using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
  public class MoviesController : ApiController
  {
    private ApplicationDbContext _context;
    MoviesController()
    {
      _context = new ApplicationDbContext();
    }
    //GET Api/Movies
    public IEnumerable<MovieDto> GetMovies()
    {
      return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
    }
    //GET Api/Movies/1
    public IHttpActionResult GetMovie(int id)
    {
      var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
      if (movie == null)
        return NotFound();
      return Ok(Mapper.Map<Movie, MovieDto>(movie));
    }

    //POST Api/Movies/
    [HttpPost]
    public IHttpActionResult CreateMovie(MovieDto movieDto)
    {
      if (!ModelState.IsValid)
        return BadRequest();
      var movie = Mapper.Map<MovieDto, Movie>(movieDto);
      _context.Movies.Add(movie);
      movieDto.Id = movie.Id;
      _context.SaveChanges();
      return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
    }

    //PUT Api/Movies/id
    [HttpPut]
    public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
      if (movieInDb == null)
        throw new HttpResponseException(HttpStatusCode.NotFound);

      Mapper.Map(movieDto, movieInDb);
      _context.SaveChanges();
      return Ok();
    }

    // DELETE: api/Movies/5
    [HttpDelete]
    public IHttpActionResult DeleteMovie(int id)
    {
      var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
      if (movieInDb == null)
        throw new HttpResponseException(HttpStatusCode.NotFound);
      _context.Movies.Remove(movieInDb);
      _context.SaveChanges();
      return Ok();
    }
  }
}
