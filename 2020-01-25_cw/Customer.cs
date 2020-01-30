using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_01_25_cw
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public Customer(string firstName, string lastName, string city)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.City = city;
        }

        public Customer()
        {
        }
    }
}
