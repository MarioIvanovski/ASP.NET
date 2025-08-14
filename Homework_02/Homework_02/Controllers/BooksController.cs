using Homework_02.Models;
using Homework_03.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_02.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Books>> GetAllBooks()
        {
            return Ok(StaticDb.Books);
        }

        [HttpGet("index")]
        public ActionResult<Books> GetBookByIndex([FromQuery] int index)
        {
            if (index < 0 || index >= StaticDb.Books.Count)
                return NotFound("Book not found");

            return Ok(StaticDb.Books[index]);
        }

        [HttpGet("filter")]
        public ActionResult<Books> GetBookByAuthorAndTitle([FromQuery] string author, [FromQuery] string title)
        {
            var book = StaticDb.Books
                .FirstOrDefault(b =>
                    b.Author.Equals(author, StringComparison.OrdinalIgnoreCase) &&
                    b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (book == null) return NotFound("Book not found");

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Books newBook)
        {
            if (newBook == null || string.IsNullOrWhiteSpace(newBook.Author) || string.IsNullOrWhiteSpace(newBook.Title))
                return BadRequest("Invalid book data");

            StaticDb.Books.Add(newBook);
            return Ok($"Book '{newBook.Title}' by {newBook.Author} added successfully");
        }

        [HttpPost("list")]
        public ActionResult<List<string>> AddMultipleBooks([FromBody] List<Books> books)
        {
            if (books == null || books.Count == 0)
                return BadRequest("No books provided");

            StaticDb.Books.AddRange(books);
            var titles = books.Select(b => b.Title).ToList();
            return Ok(titles);
        }
    }
}