using Application.Interfaces;
using Domain.Models;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _dbContext;

        public BookRepository(AppDbContext context) => _dbContext = context;

        public async Task<IEnumerable<Book>> GetListAsync()
        {
            return await _dbContext.Set<Book>().ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Book>().FindAsync(id);
        }

        public async Task<Book> AddAsync(Book book)
        {
            await _dbContext.Set<Book>().AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task UpdateAsync(Book book)
        {
            _dbContext.Entry(book).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            _dbContext.Set<Book>().Remove(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}
