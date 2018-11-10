using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Order
    {
        [Display(Name = "OrderId")]
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "CustomerId")]
        public int CustomerId { get; set; }

        //[Required]
        //[Display(Name = "ProductsList")]
        //public virtual List<Product> ProductsList { get; set; }

        [Display(Name = "IsSent")]
        public bool IsSent { get; set; }

        [Display(Name = "IsMoneyTaken")]
        public bool IsMoneyTaken { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Customer")]
        public virtual Customer Customer { get; set; }

        [Display(Name = "Products")]
        public virtual DbSet<Product> Products { get; set; }
    }
}