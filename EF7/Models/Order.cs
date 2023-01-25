using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF7.Models
{
    public class Order : EntityBase
    {
        public override int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? OrderNumber { get; set; }
        public decimal? TotalAmount { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual IList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
