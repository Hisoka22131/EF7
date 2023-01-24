using EF7.Repository.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF7.Repository
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(ApplicationContext context) : base(context)
        {
        }

        public override void AddEntity(Customer entity)
        {
            context.Add(entity);
        }

        public override void DeleteEntity(int? Id)
        {
            if (Id == null)
                return;
            Customer customer = context.Customer.Find(Id);

            if (customer == null)
                return;

            context.Customer.Remove(customer);
        }

        public override Customer? GetEntity(int? Id)
        {
            if (Id == null)
                return null;

            return context.Customer.Find(Id);
        }

        public override IEnumerable<Customer> GetAll()
        {
            return context.Customer.Include(q => q.Orders).ToList();
        }

        public override void UpdateEntity(Customer customer)
        {
            context.Entry(customer).State = EntityState.Modified;
        }
    }
}
