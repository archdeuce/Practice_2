using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services
{
    public interface IStoreService
    {
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Product> GetProducts();
    }
}
