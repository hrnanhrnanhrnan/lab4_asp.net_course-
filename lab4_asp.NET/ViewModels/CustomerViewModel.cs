using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4_asp.NET.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<CustomerBook> CustomerBooks { get; set; }

        public CustomerViewModel GetCustomerVieModel()
        {
            Books = CustomerBooks.Where(c => c.CustomerId == Customer.CustomerId)
                .Join(Books, o => o.BookId, i => i.BookId, (c, b) => new Book
                {
                    BookId = b.BookId,
                    CustomerBooks = b.CustomerBooks,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    IsBorrowed = b.IsBorrowed,
                    Title = b.Title
                });
            return this;
        }
    }
}
