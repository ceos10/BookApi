using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookViewModel>> GetBooks()
        {
            var books = await _bookRepository.GetListAsync();
            return _mapper.Map<IEnumerable<BookViewModel>>(books);
        }

        public async Task<BookViewModel> GetBook(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<BookViewModel>(book);
        }

        public async Task<BookViewModel> AddBook(BookViewModel book)
        {
            var bookToInsert = _mapper.Map<Book>(book);
            var bookAdded = await _bookRepository.AddAsync(bookToInsert);
            return _mapper.Map<BookViewModel>(bookAdded);
        }

        public async Task UpdateBook(int id, BookViewModel book)
        {
            var bookResponse = await _bookRepository.GetByIdAsync(id);
            if (bookResponse is null)
                return; 

            book.Id = id;
            var bookToUpdate = _mapper.Map<Book>(book);
            await _bookRepository.UpdateAsync(bookToUpdate);
        }

        public async Task DeleteBook(int id)
        {
            var bookToDelete = await _bookRepository.GetByIdAsync(id);
            await _bookRepository.DeleteAsync(bookToDelete);
        }
    }
}
