using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager manager;

        public BooksController(IServiceManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = manager.BookService.GetAllBooks(false);
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var entity = manager.BookService.GetOneBookById(id, false);
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
            manager.BookService.CreateOneBook(book);
            return StatusCode(201, book);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            if (!id.Equals(book.Id))
                return BadRequest();
            if (book is null)
                return BadRequest();

            manager.BookService.UpdateOneBook(id, book, true);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            manager.BookService.DeleteOneBook(id, false);
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            var entity = manager.BookService.GetOneBookById(id, true);
            if (entity is null)
            {
                return NotFound();
            }
            bookPatch.ApplyTo(entity);
            manager.BookService.UpdateOneBook(id, entity, true);
            return NoContent();
        }
    }
}
