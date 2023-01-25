using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF7.Models
{
    public class Customer : EntityBase
    {
        public override int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public virtual IList<Order> Orders { get; set; } = new List<Order>();
    }
}
