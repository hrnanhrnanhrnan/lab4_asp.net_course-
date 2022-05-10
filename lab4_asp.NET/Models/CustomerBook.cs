using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class CustomerBook
    {
        [Key]
        public int CustomerBookId { get; set; }
        public DateTime LoanDate { get; private set; } = DateTime.Today;
        public DateTime EndLoanDate { get; private set; } = DateTime.Today.AddDays(21);
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
