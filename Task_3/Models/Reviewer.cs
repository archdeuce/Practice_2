using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
