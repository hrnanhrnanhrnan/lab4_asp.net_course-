using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "The title of the book can be a max of 50 characters and a minimum of 5 characters")]
        public string Title { get; set; }
        [StringLength(150, ErrorMessage = "The description of the book can be a max of 150 characters")]
        public string Description { get; set; }
        public bool IsBorrowed { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<CustomerBook> CustomerBooks { get; set; }
    }
}
