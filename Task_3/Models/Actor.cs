using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; }
    }
}
