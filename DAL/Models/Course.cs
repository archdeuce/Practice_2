using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
