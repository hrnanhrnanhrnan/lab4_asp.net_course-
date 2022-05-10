using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4_asp.NET.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public bool IsReturned { get; set; }
    }
}
