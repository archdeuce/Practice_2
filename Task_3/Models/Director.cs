using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<MovieDirection> MovieDirections { get; set; }
    }
}
