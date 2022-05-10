using lab4_asp.NET.Contexts;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4_asp.NET.Services
{
    public class CustomerRepository : IRepository<Customer, int>
    {
        private readonly LibraryDbContext _context;
        public CustomerRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> Add(Customer entity)
        {
            var addedCustomer = await _context.AddAsync(entity);
            return addedCustomer.Entity;
        }

        public async Task<Customer> Delete(Customer entity)
        {
            var customer = await GetSingle(entity.CustomerId);
            if(customer != null)
            {
                _context.Customers.Remove(customer);
                return customer;
            }
            return null;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetSingle(int specifier)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == specifier);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> Update(Customer entity)
        {
            var result = await GetSingle(entity.CustomerId);
            if(result != null)
            {
                result.Name = entity.Name;
                result.PhoneNumber = entity.PhoneNumber;
                result.Address = entity.Address;
                return result;
            }
            return null;
        }
    }
}
