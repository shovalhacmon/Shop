using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Shop.Models
{
    public class Product
    {
        [Display(Name = "ProductId")]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "ProductName")]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "SupplierName")]
        [DataType(DataType.Text)]
        public string SupplierName { get; set; }

        [Required]
        [Display(Name = "Price")]
        public float Price { get; set; }

        [Required]
        [Display(Name = "Weight")]
        public float Weight { get; set; }

        [Required]
        [Display(Name = "SeasonId")]
        public int SeasonId { get; set; }

        [Display(Name = "Category")]
        [DataType(DataType.Text)]
        public string Category { get; set; }

        //[JsonIgnore]
        public ICollection<OrderProduct> OrderProduct { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Season> Season { get; set; }

    }
}