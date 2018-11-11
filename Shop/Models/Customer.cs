using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Display(Name = "CustomerName")]
        [DataType(DataType.Text)]
        public string CustomerName { get; set; }

        [Display(Name = "Address")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        public bool isManager { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        //public virtual ICollection<Order> Orders { get; set; }
    }

    public class Register
    {
        [Required]
        [Display(Name = "CustomerName")]
        [DataType(DataType.Text)]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}