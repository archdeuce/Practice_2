using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Department
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
