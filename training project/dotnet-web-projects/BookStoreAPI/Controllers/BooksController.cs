using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private static readonly List<string> books = new() { "C# Basics", "ASP.NET Core", "Entity Framework" };

        [HttpGet]
        public IEnumerable<string> Get() => books;

        [HttpPost]
        public IActionResult Post(string book)
        {
            books.Add(book);
            return Ok(books);
        }
    }
}