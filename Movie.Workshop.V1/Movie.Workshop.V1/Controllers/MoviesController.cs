using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Workshop.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.Workshop.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        // GET: api/<MoviesController>
        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, StaticDB.Movies);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            try
            {
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request!");
                }

                if (id >= StaticDB.Movies.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Movie does not exist!");
                }

                return StatusCode(StatusCodes.Status200OK, StaticDB.Movies[id]);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("searchbygenre")]
        public ActionResult<Movie> Get(string genre)
        {
            try
            {
                if (string.IsNullOrEmpty(genre))
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Enter a genre!");
                }

                Movie theMovie = StaticDB.Movies.FirstOrDefault(x => x.Genre.ToLower().Contains(genre.ToLower()));
                return StatusCode(StatusCodes.Status200OK, theMovie.Title.ToString());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        // POST api/<MoviesController>
        [HttpPost("addmovie")]
        public IActionResult Post([FromBody] Movie movie)
        {
            try
            {
                StaticDB.Movies.Add(movie);
                return StatusCode(StatusCodes.Status201Created, "Movie added!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error!");
            }
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{idMovie}")]
        public IActionResult Put(int idMovie, [FromBody] string description)
        {
            try
            {
                if (idMovie < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request!");
                }

                if (idMovie >= StaticDB.Movies.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Movie does not exist!");
                }

                Movie movie = StaticDB.Movies[idMovie];
                if (movie.Description == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Please enter a description!");
                }

                movie.Description = description;
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            try
            {
                StaticDB.Movies.RemoveAt(index);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
    }
}
