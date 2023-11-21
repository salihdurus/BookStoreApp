using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly RepositoryContext context;

        public BooksController(RepositoryContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = context.Books.ToList();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var entity = context.Books.SingleOrDefault(x => x.Id == id);
            if (entity is null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            if (book is null)
            {
                return BadRequest();
            }
            context.Books.Add(book);
            context.SaveChanges();
            return StatusCode(201, book);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            if (!id.Equals(book.Id))
                return BadRequest();
            if (book is null)
                return BadRequest();

            var entity = context.Books.Where(x => x.Id == id).SingleOrDefault();
            if (entity is null)
                return NotFound();

            entity.Title = book.Title;
            entity.Price = book.Price;

            context.SaveChanges();
            return Ok(entity);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            var entity = context.Books.Where(b => b.Id == id).SingleOrDefault();
            if (entity is null)
                return NotFound();
            context.Books.Remove(entity);
            context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            var entity = context.Books.Where(b => b.Id.Equals(id)).SingleOrDefault();
            if (entity is null)
            {
                return NotFound();
            }
            bookPatch.ApplyTo(entity);
            context.SaveChanges();
            return NoContent();
        }
    }
}
