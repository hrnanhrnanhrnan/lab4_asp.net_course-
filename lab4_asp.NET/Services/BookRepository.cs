using lab4_asp.NET.Contexts;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4_asp.NET.Services
{
    public class BookRepository : IRepository<Book, int>
    {
        private readonly LibraryDbContext _context;
        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public Task<Book> Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Delete(Book entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetSingle(int specifier)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.BookId == specifier);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public Task<Book> Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
