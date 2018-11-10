﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }
        public Order Order{ get; set; }
        public Product Product { get; set; }
    }
}
