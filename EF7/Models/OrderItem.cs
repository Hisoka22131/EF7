using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF7.Models
{
    public class OrderItem : EntityBase
    {
        public override int Id { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }

    }
}
