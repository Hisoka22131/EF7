﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF7
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? OrderNumber { get; set; }
        public decimal? TotalAmount { get; set; }
        public Customer Customer { get; set; }
        public IList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
