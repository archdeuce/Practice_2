using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? PostalCode { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
