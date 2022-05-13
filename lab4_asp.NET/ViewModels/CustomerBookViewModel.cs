using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4_asp.NET.ViewModels
{
    public class CustomerBookViewModel : CustomerBook
    {
        public List<Customer> Customers { get; set; }
        public List<Book> Books { get; set; }

    }
}
