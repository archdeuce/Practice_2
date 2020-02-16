using System;
using System.Collections.Generic;
using System.Text;

namespace _2020_02_11_cw.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
