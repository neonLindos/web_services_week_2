using Microsoft.AspNetCore.Mvc;
using BooksApi.Models;

namespace BooksApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private static readonly List<Book> books = new()
    {
        new Book
        {
            Id = 1,
            Title = "Clean Code",
            Author = "Robert C. Martin",
            Year = 2008
        },

        new Book
        {
            Id = 2,
            Title = "The Pragmatic Programmer",
            Author = "David Thomas",
            Year = 1999
        }
    };

    // GET /api/books
    [HttpGet]
    public ActionResult<List<Book>> GetAll()
    {
        return Ok(books);
    }

    // POST /api/books
    [HttpPost]
    public ActionResult<Book> Create(Book book)
    {
        book.Id = books.Count == 0 ? 1 : books.Max(b => b.Id) + 1;

        books.Add(book);

        return Ok(book);
    }
}
