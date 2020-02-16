using System;
using System.Collections.Generic;
using System.Text;

namespace _2020_02_11_cw.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        public virtual IList<Student> Students { get; set; }
    }
}
