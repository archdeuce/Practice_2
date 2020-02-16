using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.Models
{
    public class StudentAdress
    {
        public int StudentAdressId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public int StudentId { get; set; }
        public StudentAdress Student { get; set; }
    }
}
