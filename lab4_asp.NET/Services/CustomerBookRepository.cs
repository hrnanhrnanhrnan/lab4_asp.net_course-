using lab4_asp.NET.Contexts;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4_asp.NET.Services
{
    public class CustomerBookRepository : IRepository<CustomerBook, int>
    {
        private readonly LibraryDbContext _context;
        public CustomerBookRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public Task<CustomerBook> Add(CustomerBook entity)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerBook> Delete(CustomerBook entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerBook>> GetAll()
        {
            return await _context.CustomerBooks.Include(cb => cb.Book).Include(cb => cb.Customer).ToListAsync();
        }

        public async Task<CustomerBook> GetSingle(int specifier)
        {
            return await _context.CustomerBooks.FirstOrDefaultAsync(cb => cb.CustomerBookId == specifier);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public Task<CustomerBook> Update(CustomerBook entity)
        {
            throw new NotImplementedException();
        }
    }
}
