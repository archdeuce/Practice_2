using System;
using System.Collections.Generic;
using System.Text;

namespace _2020_02_25_cw.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        ICollection<Address> Addresses { get; set; }
        ICollection<Course> Courses { get; set; }
    }
}
