using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(35, MinimumLength =2, ErrorMessage = "The name of the customer can be a max of 35 characthers and a minimum of 2 characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "The phone number to the customer can be a max of 15 characthers and a minimum of 2 characters")]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "The address to the customer can be a max of 50 characthers and a minimum of 10 characters")]
        public string Address { get; set; }
    }
}
