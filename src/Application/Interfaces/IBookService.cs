using Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetBooks();
        Task<BookViewModel> GetBook(int id);
        Task<BookViewModel> AddBook(BookViewModel book);
        Task UpdateBook(int id, BookViewModel book);
        Task DeleteBook(int id);
    }
}
