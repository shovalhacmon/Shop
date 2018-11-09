using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class ProductsJoinedSeasons
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }
        public int SeasonId { get; set; }
        public string SeasonName { get; set; }
        public string Category { get; set; }
    }
}