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
        public ICollection<Book> Books { get; set; }
    }
}
