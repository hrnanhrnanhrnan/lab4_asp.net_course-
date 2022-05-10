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
    public class CustomersController : Controller
    {
        private readonly IRepository<Customer, int> _customerRepository;
        private readonly IRepository<CustomerBook, int> _customerBookRepository;
        private readonly IRepository<Book, int> _bookRepository;
        public CustomersController(IRepository<Customer, int> customerRepository, IRepository<CustomerBook, int> customerBookRepository, IRepository<Book, int> bookRepository)
        {
            _customerRepository = customerRepository;
            _customerBookRepository = customerBookRepository;
            _bookRepository = bookRepository;
        }

        //Index of the customers controller, fechtes all customers and send that to the view
        //if no customers is found it will return the CustomersNotFound view
        public async Task<IActionResult> Index()
        {
            var customers = await _customerRepository.GetAll();
            if(customers != null)
            {
                return View(customers);
            }

            return View("CustomersNotFound");
        }

        //Fetches a single customer and creates a new instance of the CustomerViewModel and sets the customer property of the viewmodel to the customer specified
        //and sets the books property as all books that the customer has borrowed
        //then returns that to the view
        //if no customers is found the CustomerNotFound view is returned
        public async Task<IActionResult> Customer(int? id)
        {
            var customer = await _customerRepository.GetSingle(id??1);
            if(customer != null)
            {
                var customerBooksViewModel = new CustomerViewModel();
                customerBooksViewModel.Customer = customer;
                var customerBooks = await _customerBookRepository.GetAll();

                customerBooksViewModel.Books = customerBooks.Where(cb => cb.CustomerId == customer.CustomerId)
                    .Join(await _bookRepository.GetAll(),
                    o => o.BookId, i => i.BookId,
                    (cb, book) => new Book { BookId = book.BookId, Title = book.Title, Description = book.Description, IsBorrowed = book.IsBorrowed })
                    .ToList();
                return View(customerBooksViewModel);
            }
            Response.StatusCode = 404;
            return View("CustomerNotFound", id);
        }

        //Returns the view for the create action
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //If the submitted model from the create view is valid, then the customer will be added to the database
        //and the user is redirected to the customer action and view for the created customer
        //if the validation fails then the user is returned to the Create view with the validation errors
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var addedCustomer = await _customerRepository.Add(customer);
                await _customerRepository.SaveChanges();
                return RedirectToAction("Customer", new { id = addedCustomer.CustomerId });
            }
            return View();
        }

        //fetches the specified customer and returns that to the view
        //if no customer is found then returns the CustomerNotFound view
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var customer = await _customerRepository.GetSingle(id??1);
            if(customer != null)
            {
                return View(customer);
            }
            Response.StatusCode = 404;
            return View("CustomerNotFound", id);
        }

        //if modelstate is valid then the incoming model from the edit method is passed from the form and updates the specified customer in the database table
        //then after changes is saved, the user is redirected back to the Customer action and Customer view
        //if any changes is not valid, then the Edit view will be returnerd again along with validation errors in the Edit view
        [HttpPost]
        public async Task<IActionResult> Edit(Customer model)
        {
            if (ModelState.IsValid)
            {
                var customer = await _customerRepository.GetSingle(model.CustomerId);
                customer.Name = model.Name;
                customer.Address = model.Address;
                customer.PhoneNumber = model.PhoneNumber;
                var updatedCustomer = await _customerRepository.Update(model);
                await _customerRepository.SaveChanges();
                return RedirectToAction("Customer", new { id = updatedCustomer.CustomerId });
            }

            return View(model);
        }

        //deletes the specified customer from the database
        //If the customers not found, then returns CustomerNotFound view
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerRepository.GetSingle(id);
            
            if(customer != null)
            {
                await _customerRepository.Delete(customer);
                await _customerRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            Response.StatusCode = 404;
            return View("CustomerNotFound", id);
        }
    }
}
