using Class03.Homework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Class03.Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // GET: api/<BooksController>
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, StaticDB.Books);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<BooksController>/5
        [HttpGet("{index}")]
        public ActionResult<Book> Get(int index)
        {
            try
            {
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request!");
                }

                if (index >= StaticDB.Books.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Book does not exist!");
                }

                return StatusCode(StatusCodes.Status200OK, StaticDB.Books[index]);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("filter_author_title")]
        public ActionResult<Book> Get(string author, string title)
        {
            try
            {
                if (string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Enter author or title, or both!");
                }

                if (string.IsNullOrEmpty(title))
                {
                    Book book = StaticDB.Books.FirstOrDefault(x => x.Author.ToLower().Contains(author.ToLower()));
                    if(book == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "No such author!");
                    }
                    return StatusCode(StatusCodes.Status200OK, book);
                }

                if (string.IsNullOrEmpty(author))
                {
                    Book book = StaticDB.Books.FirstOrDefault(x => x.Title.ToLower().Contains(title.ToLower()));
                    if (book == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "No such title!");
                    }
                    return StatusCode(StatusCodes.Status200OK, book);
                }

                Book theBook = StaticDB.Books.FirstOrDefault(x => x.Author.ToLower().Contains(author.ToLower()) && x.Title.ToLower().Contains(title.ToLower()));
                if(theBook == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "No such book!");
                }
                return StatusCode(StatusCodes.Status200OK, theBook);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        // POST api/<BooksController>
        [HttpPost("addbook")]
        public IActionResult Post([FromBody] Book book)
        { 
            try
            {
                StaticDB.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, "Book added!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error!");
            }
        }

        [HttpPost("addalistofbooks")]
        public IActionResult Post([FromBody] List<Book> books)
        {
            try
            {                
                return StatusCode(StatusCodes.Status200OK, books);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error!");
            }
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
