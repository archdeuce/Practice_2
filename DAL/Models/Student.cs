using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Course Course { get; set; }
    }
}
