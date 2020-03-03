using System;
using System.Collections.Generic;
using System.Text;

namespace _2020_02_25_cw.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Student Student { get; set; }
    }
}
