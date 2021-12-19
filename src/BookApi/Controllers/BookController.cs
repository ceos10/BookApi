using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService) => _bookService = bookService;

        [Route("~/"), HttpGet]
        public async Task<IEnumerable<BookViewModel>> GetBooks()
        {
            return await _bookService.GetBooks();
        }

        [Route("~/{id:int}/"), HttpGet]
        public async Task<BookViewModel> GetBookById(int id)
        {
            return await _bookService.GetBook(id);
        }

        [Route("~/"), HttpPost]
        public async Task<BookViewModel> AddBook([FromBody] BookViewModel book)
        {
            return await _bookService.AddBook(book);
        }

        [Route("~/{id:int}/"), HttpPut]
        public async Task UpdateBook(int id, [FromBody] BookViewModel book)
        {
            await _bookService.UpdateBook(id, book);
        }

        [Route("~/{id:int}/"), HttpDelete]
        public async Task DeleteBook(int id)
        {
            await _bookService.DeleteBook(id);
        }
    }
}
