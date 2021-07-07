using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services
{
    public class StoreService : IStoreService
    {
        private readonly StoreDbContext context;

        public StoreService()
        {
            this.context = new StoreDbContext();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>(this.context.Customers.Include(c => c.Orders).ThenInclude(o => o.OrderItems).ThenInclude(oi => oi.Product).ThenInclude(p => p.Brand)
                                                            .Include(c => c.Orders).ThenInclude(o => o.OrderItems).ThenInclude(oi => oi.Product).ThenInclude(c => c.Category));
        }

        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>(this.context.Products.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Stocks).ThenInclude(s => s.Store).ThenInclude(s => s.Staffs));
        }
    }
}
