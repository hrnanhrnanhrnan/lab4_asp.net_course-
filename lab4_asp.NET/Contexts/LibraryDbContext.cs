using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4_asp.NET.Contexts
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<CustomerBook> CustomerBooks { get; set; }

        //seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasData(new List<Customer>
            {
                new Customer{CustomerId=1, Name="Robin", Address="Storgatan 11, 89139 Övik", PhoneNumber="0705837487837"},
                new Customer{CustomerId=2, Name="Peter", Address="Björkgatan 400, 90326 Umeå", PhoneNumber="09087238173"},
                new Customer{CustomerId=3, Name="Maja", Address="Storgatan 11, 89139 Övik", PhoneNumber="0709348492834"},
                new Customer{CustomerId=4, Name="Petra", Address="Hållgatan 1, 891340 Övik", PhoneNumber="070565675"},
                new Customer{CustomerId=5, Name="Sandra", Address="Gatan 3, 89111 Övik", PhoneNumber="0705469456"},
                new Customer{CustomerId=6, Name="Håkan", Address="Storgatan 10, 90333 Umeå", PhoneNumber="090123001239"},
                new Customer{CustomerId=7, Name="Mendela", Address="Storgatan 1, 89138 Övik", PhoneNumber="07056045964"},
            });

            modelBuilder.Entity<Book>().HasData(new List<Book>
            {
                new Book{BookId=1, Title="Lord of the rings", Description="Fantasy om en grupp med personer som ska förstöra en ring", IsBorrowed=true, ImageUrl="\\images\\lotr.jpg"},
                new Book{BookId=2, Title="Hej kom och hjälp mig!", Description="Biografi om en person som vill ha hjälp", IsBorrowed=false, ImageUrl="\\images\\hkohm.jfif"},
                new Book{BookId=3, Title="Avengers", Description="En grupp med superhjätar som ska försvara världen", IsBorrowed=true, ImageUrl="\\images\\avengers.jfif"},
                new Book{BookId=4, Title="Pippi Långstrump", Description="Superpippi", IsBorrowed=true, ImageUrl="\\images\\pippi.jfif"},
                new Book{BookId=5, Title="Harry Potter", Description="Verklighetsbaserad bok om en unge som lär sig magi", IsBorrowed=true, ImageUrl="\\images\\harryp.jfif"},
            });

            modelBuilder.Entity<CustomerBook>().HasData(new List<CustomerBook>
            {
                new CustomerBook{CustomerBookId=1, CustomerId=1, BookId=1},
                new CustomerBook{CustomerBookId=2, CustomerId=1, BookId=3},
                new CustomerBook{CustomerBookId=3, CustomerId=2, BookId=3},
                new CustomerBook{CustomerBookId=4, CustomerId=2, BookId=4},
                new CustomerBook{CustomerBookId=5, CustomerId=2, BookId=5},
                new CustomerBook{CustomerBookId=6, CustomerId=3, BookId=5},
                new CustomerBook{CustomerBookId=7, CustomerId=4, BookId=5},
                new CustomerBook{CustomerBookId=8, CustomerId=5, BookId=1},
                new CustomerBook{CustomerBookId=9, CustomerId=6, BookId=4},
                new CustomerBook{CustomerBookId=10, CustomerId=7, BookId=1},
                new CustomerBook{CustomerBookId=11, CustomerId=7, BookId=5},
            });
        }
    }
}
