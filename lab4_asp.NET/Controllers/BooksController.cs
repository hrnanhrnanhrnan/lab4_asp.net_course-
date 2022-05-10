using lab4_asp.NET.Services;
using lab4_asp.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4_asp.NET.Controllers
{
    public class BooksController : Controller
    {
        private readonly IRepository<Book, int> _bookRepository;
        public BooksController(IRepository<Book, int> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //Fetches all books from the database, if not null then creates list of BookViewModel and foreach book in the database creates a new BookViewModel
        //then sets the book propery of the BookViewModel to the book
        //and if the books IsBorrowed property is true then the BookViewModels isReturned property is set to false and vice versa
        //then returns the view along with the list of BookViewModels
        //if no books is found then the BooksNotFound view is returned
        public async Task<IActionResult> Index()
        {

            var books = await _bookRepository.GetAll();
            if (books != null)
            {
                var bookViewModels = new List<BookViewModel>();

                foreach (var book in books)
                {
                    var bookViewModel = new BookViewModel
                    {
                        Book = book
                    };
                    if (book.IsBorrowed)
                    {
                        bookViewModel.IsReturned = false;
                    }
                    else
                    {
                        bookViewModel.IsReturned = true;
                    }

                    bookViewModels.Add(bookViewModel);
                }
                return View(bookViewModels); 
            }

            return View("BooksNotFound");
        }

        //Fetches the specified book from the database, if not null then creates a new BookViewModel
        //then sets the book propery of the BookViewModel to the book
        //and if the books IsBorrowed property is true then the BookViewModels isReturned property is set to false and vice versa
        //then returns the view along with the BookViewModel instance
        //if the specified book is found then the BookNotFound view is returned
        public async Task<IActionResult> Book(int? id)
        {
            var book = await _bookRepository.GetSingle(id ?? 1);
            if(book != null)
            {
                var bookViewModel = new BookViewModel
                {
                    Book = book
                };
                if (book.IsBorrowed)
                {
                    bookViewModel.IsReturned = false;
                }
                else
                {
                    bookViewModel.IsReturned = true;
                }
                
                return View(bookViewModel);
            }

            return View("BookNotFound", id);
        }
    }
}
